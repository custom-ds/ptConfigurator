using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ptConfigurator
{
    public partial class frmCalibrate : Form
    {
        public frmCalibrate()
        {
            InitializeComponent();
            this.Load += frmCalibrate_Load;
        }

        private void frmCalibrate_Load(object sender, EventArgs e)
        {
            lblCurrentCorrection.Text = "Current Correction: " + Program.ATConfig.WSPRCorrection.ToString() + " ppb";
            txtFreqCorrection.Text = Program.ATConfig.WSPRCorrection.ToString();

            cmboTargetFreq.SelectedIndex = 0;
        }

        private void btnWSPRProgram_Click(object sender, EventArgs e)
        {
            // Commit any pending edit in the correction field before writing
            txtFreqCorrection_Leave(sender, e);

            Program.MainForm.StartWriteConfig();
        }

        private void btnWSPRRead_Click(object sender, EventArgs e)
        {
            Program.MainForm.StartReadConfig(() =>
            {
                lblCurrentCorrection.Text = "Current Correction: " + Program.ATConfig.WSPRCorrection.ToString() + " ppb";
                txtFreqCorrection.Text = Program.ATConfig.WSPRCorrection.ToString();
            });
        }

        private void txtFreqCorrection_Leave(object sender, EventArgs e)
        {
            try
            {
                Program.ATConfig.WSPRCorrection = Convert.ToInt32(txtFreqCorrection.Text);
            }
            catch
            {
            }
            txtFreqCorrection.Text = Program.ATConfig.WSPRCorrection.ToString();
        }

        private void btnWSPRToneLong_Click(object sender, EventArgs e)
        {
            Program.MainForm.StartWSPRLongTone();
        }

        private void btnWSPRToneShort_Click(object sender, EventArgs e)
        {
            Program.MainForm.StartWSPRShortTone();
        }

        private void txtActualFreq_TextChanged(object sender, EventArgs e)
        {



        }

        private void txtActualFreq_Leave(object sender, EventArgs e)
        {
            

        }

        private void btnWSPRFreq1_Click(object sender, EventArgs e)
        {
            Program.MainForm.StartWSPRPacketA();
        }

        private void btnWSPRFreq2_Click(object sender, EventArgs e)
        {
            Program.MainForm.StartWSPRPacketB();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double actualFreq, targetFreq;
            //convert the text to integer
            try
            {
                actualFreq = Convert.ToDouble(txtActualFreq.Text);
                //Update the txtActualFreq to show the frequency in Hz with commas as thousand separators
                txtActualFreq.Text = actualFreq.ToString("N0");

                targetFreq = (cmboTargetFreq.SelectedIndex + 1) * 10000000;      //converted into Hz


            }
            catch
            {
                //just trim the text to remove any non-numeric characters
                txtActualFreq.Text = new string(txtActualFreq.Text.Where(c => char.IsDigit(c)).ToArray());

                txtFreqCorrection.Text = "";
                return;
            }

            //verify that the actual frequency is within a reasonable range of the target frequency (e.g., within 2000 Hz)
            if (Math.Abs(actualFreq - targetFreq) > 2000)
            {
                MessageBox.Show("Actual frequency is too far from the target frequency. Please check your measurements and try again.", "Frequency Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFreqCorrection.Text = "";
                return;
            }



            //calculate the correction factor based on the target frequency and the actual frequency

            double correction = ((actualFreq - targetFreq) * 1000000000) / targetFreq;
            Program.ATConfig.WSPRCorrection = (int)correction;

            txtFreqCorrection.Text = Program.ATConfig.WSPRCorrection.ToString("N0");
        }
    }
}
