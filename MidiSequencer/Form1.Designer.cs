namespace MidiSequencer
{
    partial class MidiSequencer
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
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.measureBox = new System.Windows.Forms.NumericUpDown();
            this.lblMeasureCount = new System.Windows.Forms.Label();
            this.lblBPM = new System.Windows.Forms.Label();
            this.bpmBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentMeasure = new System.Windows.Forms.Label();
            this.lblCurrentBeat = new System.Windows.Forms.Label();
            this.pnlToggleBoxArea = new System.Windows.Forms.Panel();
            this.dropDownMidiDevices = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.noteLengthBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.measureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpmBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteLengthBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(268, 111);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Location = new System.Drawing.Point(110, 66);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(43, 13);
            this.lblCurrentTime.TabIndex = 1;
            this.lblCurrentTime.Text = "0:00:00";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(363, 111);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // measureBox
            // 
            this.measureBox.Location = new System.Drawing.Point(689, 91);
            this.measureBox.Name = "measureBox";
            this.measureBox.Size = new System.Drawing.Size(51, 20);
            this.measureBox.TabIndex = 3;
            this.measureBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.measureBox.ValueChanged += new System.EventHandler(this.measureBox_ValueChanged);
            // 
            // lblMeasureCount
            // 
            this.lblMeasureCount.AutoSize = true;
            this.lblMeasureCount.Location = new System.Drawing.Point(596, 93);
            this.lblMeasureCount.Name = "lblMeasureCount";
            this.lblMeasureCount.Size = new System.Drawing.Size(79, 13);
            this.lblMeasureCount.TabIndex = 4;
            this.lblMeasureCount.Text = "Measure Count";
            // 
            // lblBPM
            // 
            this.lblBPM.AutoSize = true;
            this.lblBPM.Location = new System.Drawing.Point(596, 121);
            this.lblBPM.Name = "lblBPM";
            this.lblBPM.Size = new System.Drawing.Size(30, 13);
            this.lblBPM.TabIndex = 6;
            this.lblBPM.Text = "BPM";
            // 
            // bpmBox
            // 
            this.bpmBox.Location = new System.Drawing.Point(689, 119);
            this.bpmBox.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.bpmBox.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.bpmBox.Name = "bpmBox";
            this.bpmBox.Size = new System.Drawing.Size(51, 20);
            this.bpmBox.TabIndex = 5;
            this.bpmBox.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.bpmBox.ValueChanged += new System.EventHandler(this.bpmBox_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Current Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Current Measure";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Current Beat";
            // 
            // lblCurrentMeasure
            // 
            this.lblCurrentMeasure.AutoSize = true;
            this.lblCurrentMeasure.Location = new System.Drawing.Point(110, 93);
            this.lblCurrentMeasure.Name = "lblCurrentMeasure";
            this.lblCurrentMeasure.Size = new System.Drawing.Size(43, 13);
            this.lblCurrentMeasure.TabIndex = 11;
            this.lblCurrentMeasure.Text = "0:00:00";
            // 
            // lblCurrentBeat
            // 
            this.lblCurrentBeat.AutoSize = true;
            this.lblCurrentBeat.Location = new System.Drawing.Point(110, 121);
            this.lblCurrentBeat.Name = "lblCurrentBeat";
            this.lblCurrentBeat.Size = new System.Drawing.Size(43, 13);
            this.lblCurrentBeat.TabIndex = 12;
            this.lblCurrentBeat.Text = "0:00:00";
            // 
            // pnlToggleBoxArea
            // 
            this.pnlToggleBoxArea.Location = new System.Drawing.Point(18, 169);
            this.pnlToggleBoxArea.Name = "pnlToggleBoxArea";
            this.pnlToggleBoxArea.Size = new System.Drawing.Size(739, 392);
            this.pnlToggleBoxArea.TabIndex = 13;
            // 
            // dropDownMidiDevices
            // 
            this.dropDownMidiDevices.FormattingEnabled = true;
            this.dropDownMidiDevices.Location = new System.Drawing.Point(363, 21);
            this.dropDownMidiDevices.Name = "dropDownMidiDevices";
            this.dropDownMidiDevices.Size = new System.Drawing.Size(182, 21);
            this.dropDownMidiDevices.TabIndex = 14;
            this.dropDownMidiDevices.SelectedIndexChanged += new System.EventHandler(this.dropDownMidiDevices_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(596, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Note Length";
            // 
            // noteLengthBox
            // 
            this.noteLengthBox.DecimalPlaces = 2;
            this.noteLengthBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.noteLengthBox.Location = new System.Drawing.Point(689, 64);
            this.noteLengthBox.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.noteLengthBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.noteLengthBox.Name = "noteLengthBox";
            this.noteLengthBox.Size = new System.Drawing.Size(51, 20);
            this.noteLengthBox.TabIndex = 15;
            this.noteLengthBox.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "MIDI Device";
            // 
            // MidiSequencer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 573);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.noteLengthBox);
            this.Controls.Add(this.dropDownMidiDevices);
            this.Controls.Add(this.pnlToggleBoxArea);
            this.Controls.Add(this.lblCurrentBeat);
            this.Controls.Add(this.lblCurrentMeasure);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBPM);
            this.Controls.Add(this.bpmBox);
            this.Controls.Add(this.lblMeasureCount);
            this.Controls.Add(this.measureBox);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.btnStartStop);
            this.Name = "MidiSequencer";
            this.Text = "MidiSequencer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.measureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpmBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteLengthBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.NumericUpDown measureBox;
        private System.Windows.Forms.Label lblMeasureCount;
        private System.Windows.Forms.Label lblBPM;
        private System.Windows.Forms.NumericUpDown bpmBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentMeasure;
        private System.Windows.Forms.Label lblCurrentBeat;
        private System.Windows.Forms.Panel pnlToggleBoxArea;
        private System.Windows.Forms.ComboBox dropDownMidiDevices;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown noteLengthBox;
        private System.Windows.Forms.Label label5;
    }
}

