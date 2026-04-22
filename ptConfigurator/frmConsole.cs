using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ptConfigurator
{
    public partial class frmConsole : Form
    {
        //Calls to add items to the system menu
        // P/Invoke constants
        private const int WM_SYSCOMMAND = 0x112;
        private const int MF_STRING = 0x0;
        private const int MF_SEPARATOR = 0x800;

        // P/Invoke Declarations
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);

        private int SYSMENU_COPY_ALL = 0x1;

        private const int FifoMaxLines = 2000;

        public static frmConsole ActiveConsole { get; private set; }

        private readonly Queue<string> _fifo = new Queue<string>();
        private string _lineBuffer = "";
        private bool _fifoUpdated = false;

        public frmConsole()
        {
            this.HandleCreated += (sender, e) => {
                IntPtr hSysMenu = GetSystemMenu(this.Handle, false);
                AppendMenu(hSysMenu, MF_SEPARATOR, 0, string.Empty);
                AppendMenu(hSysMenu, MF_STRING, SYSMENU_COPY_ALL, "Copy All to Clipboard");
            };

            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == SYSMENU_COPY_ALL))
            {
                Clipboard.SetText(txtConsole.Text);
            }
        }

        private void frmConsole_Load(object sender, EventArgs e)
        {
            ActiveConsole = this;

            if (frmMain.Instance != null && frmMain.Instance.EnsurePortOpen())
                AppendLine(string.Format("[Console] Connected on {0}.", frmMain.Instance.TrackerPortName));
            else
                AppendLine("[Console] Could not open port — select a COM port in the main window first.");
        }

        private void frmConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            ActiveConsole = null;
            frmMain.Instance?.ReleasePort();
        }

        private void frmConsole_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                frmMain.Instance.ConsoleSend(e.KeyChar.ToString());
            }
            catch { }

            e.Handled = true;
        }

        // Called from frmMain's timer tick on the UI thread with bytes just read from commTracker.
        public void FeedBytes(byte[] data)
        {
            string incoming = "";
            foreach (byte b in data)
            {
                char c = (char)b;
                if (c == '\r') continue;
                if (c == '\n') incoming += "\n";
                else if (c == '\t') incoming += "   ";
                else if (c >= ' ' && c <= '~') incoming += c;
            }

            if (incoming.Length == 0) return;

            lock (_fifo)
            {
                _lineBuffer += incoming;

                int pos;
                while ((pos = _lineBuffer.IndexOf('\n')) >= 0)
                {
                    string line = _lineBuffer.Substring(0, pos);
                    _lineBuffer = _lineBuffer.Substring(pos + 1);

                    if (line.Length > 0)
                        pushFifo(line);
                }

                _fifoUpdated = true;
            }
        }

        private void pushFifo(string line)
        {
            // caller holds lock(_fifo)
            _fifo.Enqueue(line);
            while (_fifo.Count > FifoMaxLines)
                _fifo.Dequeue();
        }

        // Adds a local status line (not from the port) and marks the display dirty.
        private void AppendLine(string line)
        {
            lock (_fifo)
            {
                pushFifo(line);
                _fifoUpdated = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool dirty;
            lock (_fifo)
            {
                dirty = _fifoUpdated;
                _fifoUpdated = false;
            }

            if (!dirty) return;

            string[] lines;
            lock (_fifo)
            {
                lines = _fifo.ToArray();
            }

            StringBuilder sb = new StringBuilder();
            foreach (string l in lines)
            {
                sb.AppendLine(l);
            }

            txtConsole.Text = sb.ToString();
            txtConsole.SelectionStart = txtConsole.Text.Length;
            txtConsole.ScrollToCaret();
        }
    }
}
