namespace TuringMachineBuilder
{
    partial class Builder
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
            this.label1 = new System.Windows.Forms.Label();
            this.numberOfStatesTextBox = new System.Windows.Forms.TextBox();
            this.generateBtn = new System.Windows.Forms.Button();
            this.statesDataGridView = new System.Windows.Forms.DataGridView();
            this.isFinal = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.xCoordinate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yCoordinate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transitionsDataGridView = new System.Windows.Forms.DataGridView();
            this.fromStateID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.toStateID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.readChar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.writeChar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movement = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.angle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lockBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.statesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transitionsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of States";
            // 
            // numberOfStatesTextBox
            // 
            this.numberOfStatesTextBox.Location = new System.Drawing.Point(183, 17);
            this.numberOfStatesTextBox.Name = "numberOfStatesTextBox";
            this.numberOfStatesTextBox.Size = new System.Drawing.Size(409, 20);
            this.numberOfStatesTextBox.TabIndex = 1;
            // 
            // generateBtn
            // 
            this.generateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateBtn.Location = new System.Drawing.Point(398, 300);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(182, 46);
            this.generateBtn.TabIndex = 3;
            this.generateBtn.Text = "Generate";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generate_Click);
            // 
            // statesDataGridView
            // 
            this.statesDataGridView.AllowUserToAddRows = false;
            this.statesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.statesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.statesDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isFinal,
            this.xCoordinate,
            this.yCoordinate});
            this.statesDataGridView.Location = new System.Drawing.Point(18, 76);
            this.statesDataGridView.Name = "statesDataGridView";
            this.statesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.statesDataGridView.Size = new System.Drawing.Size(245, 189);
            this.statesDataGridView.TabIndex = 4;
            // 
            // isFinal
            // 
            this.isFinal.HeaderText = "Is Final State";
            this.isFinal.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.isFinal.Name = "isFinal";
            this.isFinal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isFinal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isFinal.Width = 95;
            // 
            // xCoordinate
            // 
            this.xCoordinate.HeaderText = "x";
            this.xCoordinate.Name = "xCoordinate";
            this.xCoordinate.Width = 38;
            // 
            // yCoordinate
            // 
            this.yCoordinate.HeaderText = "y";
            this.yCoordinate.Name = "yCoordinate";
            this.yCoordinate.Width = 38;
            // 
            // transitionsDataGridView
            // 
            this.transitionsDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.transitionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transitionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fromStateID,
            this.toStateID,
            this.readChar,
            this.writeChar,
            this.movement,
            this.angle});
            this.transitionsDataGridView.Location = new System.Drawing.Point(269, 76);
            this.transitionsDataGridView.Name = "transitionsDataGridView";
            this.transitionsDataGridView.Size = new System.Drawing.Size(716, 189);
            this.transitionsDataGridView.TabIndex = 5;
            this.transitionsDataGridView.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.transitionsDataGridView_CellStateChanged);
            this.transitionsDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.transitionsDataGridView_CellValueChanged);
            // 
            // fromStateID
            // 
            this.fromStateID.HeaderText = "From State ID";
            this.fromStateID.Name = "fromStateID";
            this.fromStateID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fromStateID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // toStateID
            // 
            this.toStateID.HeaderText = "To State ID";
            this.toStateID.Name = "toStateID";
            this.toStateID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.toStateID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // readChar
            // 
            this.readChar.HeaderText = "Read Char";
            this.readChar.Name = "readChar";
            // 
            // writeChar
            // 
            this.writeChar.HeaderText = "Write Char";
            this.writeChar.Name = "writeChar";
            // 
            // movement
            // 
            this.movement.HeaderText = "Movements";
            this.movement.Items.AddRange(new object[] {
            "Right",
            "Left",
            "Stable"});
            this.movement.Name = "movement";
            // 
            // angle
            // 
            this.angle.HeaderText = "Angle in Degree";
            this.angle.Name = "angle";
            this.angle.ReadOnly = true;
            this.angle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // lockBtn
            // 
            this.lockBtn.Location = new System.Drawing.Point(610, 15);
            this.lockBtn.Name = "lockBtn";
            this.lockBtn.Size = new System.Drawing.Size(75, 23);
            this.lockBtn.TabIndex = 6;
            this.lockBtn.Text = "Lock";
            this.lockBtn.UseVisualStyleBackColor = true;
            this.lockBtn.Click += new System.EventHandler(this.lockBtn_Click);
            // 
            // Builder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 358);
            this.Controls.Add(this.lockBtn);
            this.Controls.Add(this.transitionsDataGridView);
            this.Controls.Add(this.statesDataGridView);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.numberOfStatesTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Builder";
            this.Text = "Builder";
            ((System.ComponentModel.ISupportInitialize)(this.statesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transitionsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numberOfStatesTextBox;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.DataGridView statesDataGridView;
        private System.Windows.Forms.DataGridView transitionsDataGridView;
        private System.Windows.Forms.Button lockBtn;
        private System.Windows.Forms.DataGridViewComboBoxColumn fromStateID;
        private System.Windows.Forms.DataGridViewComboBoxColumn toStateID;
        private System.Windows.Forms.DataGridViewTextBoxColumn readChar;
        private System.Windows.Forms.DataGridViewTextBoxColumn writeChar;
        private System.Windows.Forms.DataGridViewComboBoxColumn movement;
        private System.Windows.Forms.DataGridViewTextBoxColumn angle;
        private System.Windows.Forms.DataGridViewComboBoxColumn isFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn xCoordinate;
        private System.Windows.Forms.DataGridViewTextBoxColumn yCoordinate;
    }
}

