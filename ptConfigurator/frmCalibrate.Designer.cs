namespace ptConfigurator
{
    partial class frmCalibrate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnWSPRRead = new System.Windows.Forms.Button();
            this.lblCurrentCorrection = new System.Windows.Forms.Label();
            this.btnWSPRProgram = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWSPRFreqB = new System.Windows.Forms.Button();
            this.btnWSPRFreqA = new System.Windows.Forms.Button();
            this.btnWSPRToneLong = new System.Windows.Forms.Button();
            this.btnWSPRToneShort = new System.Windows.Forms.Button();
            this.txtFreqCorrection = new System.Windows.Forms.TextBox();
            this.cmboTargetFreq = new System.Windows.Forms.ComboBox();
            this.txtActualFreq = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 430);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VHF Trackers";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblInstructions);
            this.groupBox2.Controls.Add(this.btnWSPRRead);
            this.groupBox2.Controls.Add(this.lblCurrentCorrection);
            this.groupBox2.Controls.Add(this.btnWSPRProgram);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnWSPRFreqB);
            this.groupBox2.Controls.Add(this.btnWSPRFreqA);
            this.groupBox2.Controls.Add(this.btnWSPRToneLong);
            this.groupBox2.Controls.Add(this.btnWSPRToneShort);
            this.groupBox2.Controls.Add(this.txtFreqCorrection);
            this.groupBox2.Controls.Add(this.cmboTargetFreq);
            this.groupBox2.Controls.Add(this.txtActualFreq);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(382, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 430);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HF Trackers";
            // 
            // lblInstructions
            // 
            this.lblInstructions.Location = new System.Drawing.Point(7, 30);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(387, 51);
            this.lblInstructions.TabIndex = 14;
            this.lblInstructions.Text = "Instructions:";
            // 
            // btnWSPRRead
            // 
            this.btnWSPRRead.Location = new System.Drawing.Point(293, 213);
            this.btnWSPRRead.Name = "btnWSPRRead";
            this.btnWSPRRead.Size = new System.Drawing.Size(75, 23);
            this.btnWSPRRead.TabIndex = 13;
            this.btnWSPRRead.Text = "Read";
            this.btnWSPRRead.UseVisualStyleBackColor = true;
            this.btnWSPRRead.Click += new System.EventHandler(this.btnWSPRRead_Click);
            // 
            // lblCurrentCorrection
            // 
            this.lblCurrentCorrection.AutoSize = true;
            this.lblCurrentCorrection.Location = new System.Drawing.Point(37, 217);
            this.lblCurrentCorrection.Name = "lblCurrentCorrection";
            this.lblCurrentCorrection.Size = new System.Drawing.Size(119, 13);
            this.lblCurrentCorrection.TabIndex = 12;
            this.lblCurrentCorrection.Text = "Current Correction:  ppb";
            // 
            // btnWSPRProgram
            // 
            this.btnWSPRProgram.Location = new System.Drawing.Point(293, 253);
            this.btnWSPRProgram.Name = "btnWSPRProgram";
            this.btnWSPRProgram.Size = new System.Drawing.Size(75, 23);
            this.btnWSPRProgram.TabIndex = 11;
            this.btnWSPRProgram.Text = "Program";
            this.btnWSPRProgram.UseVisualStyleBackColor = true;
            this.btnWSPRProgram.Click += new System.EventHandler(this.btnWSPRProgram_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "ppb";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Measured Frequency";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Target Frequency";
            // 
            // btnWSPRFreqB
            // 
            this.btnWSPRFreqB.Location = new System.Drawing.Point(131, 381);
            this.btnWSPRFreqB.Name = "btnWSPRFreqB";
            this.btnWSPRFreqB.Size = new System.Drawing.Size(184, 23);
            this.btnWSPRFreqB.TabIndex = 6;
            this.btnWSPRFreqB.Text = "WSPR Packet (B)";
            this.btnWSPRFreqB.UseVisualStyleBackColor = true;
            // 
            // btnWSPRFreqA
            // 
            this.btnWSPRFreqA.Location = new System.Drawing.Point(131, 352);
            this.btnWSPRFreqA.Name = "btnWSPRFreqA";
            this.btnWSPRFreqA.Size = new System.Drawing.Size(184, 23);
            this.btnWSPRFreqA.TabIndex = 5;
            this.btnWSPRFreqA.Text = "WSPR Packet (A)";
            this.btnWSPRFreqA.UseVisualStyleBackColor = true;
            // 
            // btnWSPRToneLong
            // 
            this.btnWSPRToneLong.Location = new System.Drawing.Point(73, 96);
            this.btnWSPRToneLong.Name = "btnWSPRToneLong";
            this.btnWSPRToneLong.Size = new System.Drawing.Size(132, 23);
            this.btnWSPRToneLong.TabIndex = 4;
            this.btnWSPRToneLong.Text = "Long Tone";
            this.btnWSPRToneLong.UseVisualStyleBackColor = true;
            this.btnWSPRToneLong.Click += new System.EventHandler(this.btnWSPRToneLong_Click);
            // 
            // btnWSPRToneShort
            // 
            this.btnWSPRToneShort.Location = new System.Drawing.Point(211, 96);
            this.btnWSPRToneShort.Name = "btnWSPRToneShort";
            this.btnWSPRToneShort.Size = new System.Drawing.Size(132, 23);
            this.btnWSPRToneShort.TabIndex = 3;
            this.btnWSPRToneShort.Text = "Short Tone";
            this.btnWSPRToneShort.UseVisualStyleBackColor = true;
            this.btnWSPRToneShort.Click += new System.EventHandler(this.btnWSPRToneShort_Click);
            // 
            // txtFreqCorrection
            // 
            this.txtFreqCorrection.Location = new System.Drawing.Point(40, 254);
            this.txtFreqCorrection.Name = "txtFreqCorrection";
            this.txtFreqCorrection.Size = new System.Drawing.Size(100, 20);
            this.txtFreqCorrection.TabIndex = 2;
            this.txtFreqCorrection.Leave += new System.EventHandler(this.txtFreqCorrection_Leave);
            // 
            // cmboTargetFreq
            // 
            this.cmboTargetFreq.FormattingEnabled = true;
            this.cmboTargetFreq.Items.AddRange(new object[] {
            "10.000MHz",
            "20.000MHz",
            "30.000MHz",
            "40.000MHz"});
            this.cmboTargetFreq.Location = new System.Drawing.Point(40, 152);
            this.cmboTargetFreq.Name = "cmboTargetFreq";
            this.cmboTargetFreq.Size = new System.Drawing.Size(121, 21);
            this.cmboTargetFreq.TabIndex = 1;
            // 
            // txtActualFreq
            // 
            this.txtActualFreq.Location = new System.Drawing.Point(268, 153);
            this.txtActualFreq.Name = "txtActualFreq";
            this.txtActualFreq.Size = new System.Drawing.Size(100, 20);
            this.txtActualFreq.TabIndex = 0;
            this.txtActualFreq.TextChanged += new System.EventHandler(this.txtActualFreq_TextChanged);
            this.txtActualFreq.Leave += new System.EventHandler(this.txtActualFreq_Leave);
            // 
            // frmCalibrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCalibrate";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Testing and Calibration";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFreqCorrection;
        private System.Windows.Forms.ComboBox cmboTargetFreq;
        private System.Windows.Forms.TextBox txtActualFreq;
        private System.Windows.Forms.Button btnWSPRProgram;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWSPRFreqB;
        private System.Windows.Forms.Button btnWSPRFreqA;
        private System.Windows.Forms.Button btnWSPRToneLong;
        private System.Windows.Forms.Button btnWSPRToneShort;
        private System.Windows.Forms.Button btnWSPRRead;
        private System.Windows.Forms.Label lblCurrentCorrection;
        private System.Windows.Forms.Label lblInstructions;
    }
}