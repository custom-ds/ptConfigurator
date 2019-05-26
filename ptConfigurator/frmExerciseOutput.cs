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
    public partial class frmExerciseOutput : Form
    {
        public frmExerciseOutput()
        {
            InitializeComponent();
        }

        private void frmExerciseOutput_Load(object sender, EventArgs e)
        {

        }

        public void setResults(string strExerciseOutput)
        {
            txtOutput.Text = strExerciseOutput;
        }
    }
}
