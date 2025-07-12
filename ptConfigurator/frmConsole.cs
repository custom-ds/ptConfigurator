using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ptConfigurator
{
    public partial class frmConsole: Form
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

        public frmConsole()
        {
            this.HandleCreated += (sender, e) => {                 // Get a handle to a copy of this form's system (window) menu
                IntPtr hSysMenu = GetSystemMenu(this.Handle, false);

                // Add a separator
                AppendMenu(hSysMenu, MF_SEPARATOR, 0, string.Empty);

                // Add the About menu item
                AppendMenu(hSysMenu, MF_STRING, SYSMENU_COPY_ALL, "Copy All to Clipboard");
            };

            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);


            // Test if the Copy All item was selected from the system menu
            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == SYSMENU_COPY_ALL))
            {
                //Copy everything in the console to the clipboard
                Clipboard.SetText(txtConsole.Text);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program.ATSerialData.NewHistory)
            {
                //there's something new to see
                txtConsole.Text = Program.ATSerialData.getComHistory();

                //Scroll to the bottom
                txtConsole.SelectionStart = txtConsole.Text.Length;
                txtConsole.ScrollToCaret();
            }
        }

        private void frmConsole_Load(object sender, EventArgs e)
        {
            this.setFormSizes();
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
