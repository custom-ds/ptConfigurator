using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ptConfigurator
{
    public partial class frmConnect : Form
    {
        int iProgressCounter = 0;
        public frmConnect()
        {
            InitializeComponent();
        }

        private void frmConnect_Load(object sender, EventArgs e)
        {
            label2.Text = "Entering Configuration";
            label1.Text = "Connect the tracker to the selected serial port and power it on.  Pressing the reset button may be necessary if it is not already in configuration mode.";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (iProgressCounter < 100) iProgressCounter++;
            progressBar1.Value = iProgressCounter;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}