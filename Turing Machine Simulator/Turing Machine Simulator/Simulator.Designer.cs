namespace Turing_Machine_Simulator
{
    partial class Simulator
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
            this.controlPanel = new System.Windows.Forms.Panel();
            this.nightVisionCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.loadModelBtn = new System.Windows.Forms.Button();
            this.resultBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.inputLabel = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.stepBtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Convex = new System.Windows.Forms.Panel();
            this.generateModelBtn = new System.Windows.Forms.Button();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.controlPanel.Controls.Add(this.generateModelBtn);
            this.controlPanel.Controls.Add(this.nightVisionCheckBox);
            this.controlPanel.Controls.Add(this.label1);
            this.controlPanel.Controls.Add(this.speedTrackBar);
            this.controlPanel.Controls.Add(this.resultPanel);
            this.controlPanel.Controls.Add(this.loadModelBtn);
            this.controlPanel.Controls.Add(this.resultBtn);
            this.controlPanel.Controls.Add(this.okBtn);
            this.controlPanel.Controls.Add(this.inputLabel);
            this.controlPanel.Controls.Add(this.inputTextBox);
            this.controlPanel.Controls.Add(this.stepBtn);
            this.controlPanel.Controls.Add(this.runBtn);
            this.controlPanel.Location = new System.Drawing.Point(1009, 27);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(199, 595);
            this.controlPanel.TabIndex = 0;
            // 
            // nightVisionCheckBox
            // 
            this.nightVisionCheckBox.AutoSize = true;
            this.nightVisionCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nightVisionCheckBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.nightVisionCheckBox.Location = new System.Drawing.Point(13, 54);
            this.nightVisionCheckBox.Name = "nightVisionCheckBox";
            this.nightVisionCheckBox.Size = new System.Drawing.Size(91, 17);
            this.nightVisionCheckBox.TabIndex = 11;
            this.nightVisionCheckBox.Text = "Night Vision";
            this.nightVisionCheckBox.UseVisualStyleBackColor = true;
            this.nightVisionCheckBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nightVisionCheckBox_MouseClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Speed";
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.Location = new System.Drawing.Point(83, 3);
            this.speedTrackBar.Maximum = 2000;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(104, 45);
            this.speedTrackBar.SmallChange = 50;
            this.speedTrackBar.TabIndex = 9;
            this.speedTrackBar.Scroll += new System.EventHandler(this.speedTrackBar_Scroll);
            // 
            // resultPanel
            // 
            this.resultPanel.Location = new System.Drawing.Point(13, 218);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(174, 70);
            this.resultPanel.TabIndex = 8;
            // 
            // loadModelBtn
            // 
            this.loadModelBtn.Location = new System.Drawing.Point(44, 496);
            this.loadModelBtn.Name = "loadModelBtn";
            this.loadModelBtn.Size = new System.Drawing.Size(119, 36);
            this.loadModelBtn.TabIndex = 7;
            this.loadModelBtn.Text = "Load Model";
            this.loadModelBtn.UseVisualStyleBackColor = true;
            this.loadModelBtn.Click += new System.EventHandler(this.loadModelBtn_Click);
            // 
            // resultBtn
            // 
            this.resultBtn.Location = new System.Drawing.Point(44, 179);
            this.resultBtn.Name = "resultBtn";
            this.resultBtn.Size = new System.Drawing.Size(119, 33);
            this.resultBtn.TabIndex = 6;
            this.resultBtn.Text = "Result";
            this.resultBtn.UseVisualStyleBackColor = true;
            this.resultBtn.Click += new System.EventHandler(this.resultBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(44, 374);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(119, 36);
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // inputLabel
            // 
            this.inputLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.inputLabel.Location = new System.Drawing.Point(73, 299);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(60, 22);
            this.inputLabel.TabIndex = 3;
            this.inputLabel.Text = "Input";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(29, 324);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(148, 20);
            this.inputTextBox.TabIndex = 2;
            // 
            // stepBtn
            // 
            this.stepBtn.Location = new System.Drawing.Point(44, 131);
            this.stepBtn.Name = "stepBtn";
            this.stepBtn.Size = new System.Drawing.Size(119, 33);
            this.stepBtn.TabIndex = 1;
            this.stepBtn.Text = "Step";
            this.stepBtn.UseVisualStyleBackColor = true;
            this.stepBtn.Click += new System.EventHandler(this.stepBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(44, 84);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(119, 32);
            this.runBtn.TabIndex = 0;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Convex
            // 
            this.Convex.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Convex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Convex.Location = new System.Drawing.Point(12, 27);
            this.Convex.Name = "Convex";
            this.Convex.Size = new System.Drawing.Size(991, 595);
            this.Convex.TabIndex = 1;
            this.Convex.Paint += new System.Windows.Forms.PaintEventHandler(this.Convex_Paint);
            // 
            // generateModelBtn
            // 
            this.generateModelBtn.Location = new System.Drawing.Point(44, 538);
            this.generateModelBtn.Name = "generateModelBtn";
            this.generateModelBtn.Size = new System.Drawing.Size(119, 36);
            this.generateModelBtn.TabIndex = 12;
            this.generateModelBtn.Text = "Generate Model";
            this.generateModelBtn.UseVisualStyleBackColor = true;
            this.generateModelBtn.Click += new System.EventHandler(this.generateModelBtn_Click);
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 634);
            this.Controls.Add(this.Convex);
            this.Controls.Add(this.controlPanel);
            this.DoubleBuffered = true;
            this.Name = "Simulator";
            this.Text = "Turing Machine Simulator";
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button stepBtn;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button resultBtn;
        private System.Windows.Forms.Button loadModelBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.Panel Convex;
        private System.Windows.Forms.CheckBox nightVisionCheckBox;
        private System.Windows.Forms.Button generateModelBtn;
    }
}

