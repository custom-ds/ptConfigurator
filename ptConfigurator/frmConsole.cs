using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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

        private SerialPort _port;
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
            this.setFormSizes();
            this.openPort();
        }

        private void frmConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            closePort();
        }

        private void openPort()
        {
            string portName = Config.LoadSetting("CommPort");
            if (string.IsNullOrEmpty(portName))
            {
                AppendLine("[Console] No COM port saved — select a port in the main window first.");
                return;
            }

            try
            {
                _port = new SerialPort(portName, 19200);
                _port.DataReceived += port_DataReceived;
                _port.Open();
                AppendLine(string.Format("[Console] Opened {0} at 19200 baud.", portName));
            }
            catch (Exception ex)
            {
                AppendLine(string.Format("[Console] Could not open {0}: {1}", portName, ex.Message));
                _port = null;
            }
        }

        private void closePort()
        {
            if (_port != null)
            {
                try
                {
                    _port.DataReceived -= port_DataReceived;
                    if (_port.IsOpen)
                        _port.Close();
                }
                catch { }
                _port.Dispose();
                _port = null;
            }
        }

        // Fires on a background thread — only touch _fifo / _lineBuffer / _fifoUpdated here.
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                int count = sp.BytesToRead;
                if (count <= 0) return;

                byte[] buf = new byte[count];
                sp.Read(buf, 0, count);

                string incoming = "";
                foreach (byte b in buf)
                {
                    char c = (char)b;
                    if (c == '\r') continue;            // drop bare \r
                    if (c == '\n') incoming += "\n";
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
            catch { }
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_port == null || !_port.IsOpen)
            {
                AppendLine("[Console] Port is not open.");
                return;
            }

            string text = txtSend.Text;
            if (string.IsNullOrEmpty(text)) return;

            try
            {
                _port.Write(text + "\n");
                txtSend.Clear();
            }
            catch (Exception ex)
            {
                AppendLine(string.Format("[Console] Send failed: {0}", ex.Message));
            }
        }

        private void txtSend_LostFocus(object sender, EventArgs e)
        {
            txtSend.Focus();
        }

        private void setFormSizes()
        {
            txtConsole.Width = this.Width - 15;
            txtConsole.Height = this.ClientRectangle.Height - 35;

            txtSend.Top = this.ClientRectangle.Height - 30;
            txtSend.Left = 5;
            txtSend.Width = this.Width - 100;

            btnSend.Top = this.ClientRectangle.Height - 30;
            btnSend.Left = this.ClientRectangle.Width - 50;
        }

        private void frmConsole_ResizeEnd(object sender, EventArgs e)
        {
            this.setFormSizes();
        }
    }
}
