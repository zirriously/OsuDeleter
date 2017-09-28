namespace OsuDeleter1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.directoryButton = new System.Windows.Forms.Button();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.jpgFilesTickBox = new System.Windows.Forms.CheckBox();
            this.pngFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.aviFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.wavFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BeginScanButton = new System.Windows.Forms.Button();
            this.AmountOfFilesTextLabel = new System.Windows.Forms.Label();
            this.amountOfFilesFoundNumberLabel = new System.Windows.Forms.Label();
            this.DeleteFilesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directoryTextBox.Location = new System.Drawing.Point(34, 12);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.ReadOnly = true;
            this.directoryTextBox.Size = new System.Drawing.Size(400, 20);
            this.directoryTextBox.TabIndex = 1;
            this.directoryTextBox.Text = "Pick Osu! directory";
            this.directoryTextBox.TextChanged += new System.EventHandler(this.directoryTextBox_TextChanged);
            // 
            // directoryButton
            // 
            this.directoryButton.Location = new System.Drawing.Point(13, 11);
            this.directoryButton.Name = "directoryButton";
            this.directoryButton.Size = new System.Drawing.Size(22, 22);
            this.directoryButton.TabIndex = 2;
            this.directoryButton.UseVisualStyleBackColor = true;
            this.directoryButton.Click += new System.EventHandler(this.directoryButton_Click);
            // 
            // jpgFilesTickBox
            // 
            this.jpgFilesTickBox.AutoSize = true;
            this.jpgFilesTickBox.Location = new System.Drawing.Point(13, 52);
            this.jpgFilesTickBox.Name = "jpgFilesTickBox";
            this.jpgFilesTickBox.Size = new System.Drawing.Size(64, 17);
            this.jpgFilesTickBox.TabIndex = 3;
            this.jpgFilesTickBox.Text = ".jpg files";
            this.jpgFilesTickBox.UseVisualStyleBackColor = true;
            this.jpgFilesTickBox.CheckedChanged += new System.EventHandler(this.jpgFilesTickBox_CheckedChanged);
            // 
            // pngFilesCheckBox
            // 
            this.pngFilesCheckBox.AutoSize = true;
            this.pngFilesCheckBox.Location = new System.Drawing.Point(13, 68);
            this.pngFilesCheckBox.Name = "pngFilesCheckBox";
            this.pngFilesCheckBox.Size = new System.Drawing.Size(68, 17);
            this.pngFilesCheckBox.TabIndex = 4;
            this.pngFilesCheckBox.Text = ".png files";
            this.pngFilesCheckBox.UseVisualStyleBackColor = true;
            this.pngFilesCheckBox.CheckedChanged += new System.EventHandler(this.pngFilesCheckBox_CheckedChanged);
            // 
            // aviFilesCheckBox
            // 
            this.aviFilesCheckBox.AutoSize = true;
            this.aviFilesCheckBox.Location = new System.Drawing.Point(13, 100);
            this.aviFilesCheckBox.Name = "aviFilesCheckBox";
            this.aviFilesCheckBox.Size = new System.Drawing.Size(64, 17);
            this.aviFilesCheckBox.TabIndex = 6;
            this.aviFilesCheckBox.Text = ".avi files";
            this.aviFilesCheckBox.UseVisualStyleBackColor = true;
            this.aviFilesCheckBox.CheckedChanged += new System.EventHandler(this.aviFilesCheckBox_CheckedChanged);
            // 
            // wavFilesCheckBox
            // 
            this.wavFilesCheckBox.AutoSize = true;
            this.wavFilesCheckBox.Location = new System.Drawing.Point(13, 84);
            this.wavFilesCheckBox.Name = "wavFilesCheckBox";
            this.wavFilesCheckBox.Size = new System.Drawing.Size(70, 17);
            this.wavFilesCheckBox.TabIndex = 5;
            this.wavFilesCheckBox.Text = ".wav files";
            this.wavFilesCheckBox.UseVisualStyleBackColor = true;
            this.wavFilesCheckBox.CheckedChanged += new System.EventHandler(this.wavFilesCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select which files to delete";
            // 
            // BeginScanButton
            // 
            this.BeginScanButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BeginScanButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.BeginScanButton.Enabled = false;
            this.BeginScanButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BeginScanButton.FlatAppearance.BorderSize = 0;
            this.BeginScanButton.Location = new System.Drawing.Point(127, 52);
            this.BeginScanButton.Name = "BeginScanButton";
            this.BeginScanButton.Size = new System.Drawing.Size(75, 23);
            this.BeginScanButton.TabIndex = 8;
            this.BeginScanButton.Text = "Begin scan";
            this.BeginScanButton.UseVisualStyleBackColor = false;
            this.BeginScanButton.Click += new System.EventHandler(this.BeginScanButton_Click);
            // 
            // AmountOfFilesTextLabel
            // 
            this.AmountOfFilesTextLabel.AutoSize = true;
            this.AmountOfFilesTextLabel.Enabled = false;
            this.AmountOfFilesTextLabel.Location = new System.Drawing.Point(204, 56);
            this.AmountOfFilesTextLabel.Name = "AmountOfFilesTextLabel";
            this.AmountOfFilesTextLabel.Size = new System.Drawing.Size(109, 13);
            this.AmountOfFilesTextLabel.TabIndex = 10;
            this.AmountOfFilesTextLabel.Text = "Amount of files found:";
            // 
            // amountOfFilesFoundNumberLabel
            // 
            this.amountOfFilesFoundNumberLabel.AutoSize = true;
            this.amountOfFilesFoundNumberLabel.Location = new System.Drawing.Point(311, 56);
            this.amountOfFilesFoundNumberLabel.Name = "amountOfFilesFoundNumberLabel";
            this.amountOfFilesFoundNumberLabel.Size = new System.Drawing.Size(0, 13);
            this.amountOfFilesFoundNumberLabel.TabIndex = 11;
            // 
            // DeleteFilesButton
            // 
            this.DeleteFilesButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DeleteFilesButton.Enabled = false;
            this.DeleteFilesButton.FlatAppearance.BorderSize = 0;
            this.DeleteFilesButton.Location = new System.Drawing.Point(127, 92);
            this.DeleteFilesButton.Name = "DeleteFilesButton";
            this.DeleteFilesButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteFilesButton.TabIndex = 12;
            this.DeleteFilesButton.Text = "Delete files";
            this.DeleteFilesButton.UseVisualStyleBackColor = false;
            this.DeleteFilesButton.Click += new System.EventHandler(this.DeleteFilesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 120);
            this.Controls.Add(this.DeleteFilesButton);
            this.Controls.Add(this.amountOfFilesFoundNumberLabel);
            this.Controls.Add(this.AmountOfFilesTextLabel);
            this.Controls.Add(this.BeginScanButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aviFilesCheckBox);
            this.Controls.Add(this.wavFilesCheckBox);
            this.Controls.Add(this.pngFilesCheckBox);
            this.Controls.Add(this.jpgFilesTickBox);
            this.Controls.Add(this.directoryButton);
            this.Controls.Add(this.directoryTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "OsuDeleter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.Button directoryButton;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox jpgFilesTickBox;
        private System.Windows.Forms.CheckBox pngFilesCheckBox;
        private System.Windows.Forms.CheckBox aviFilesCheckBox;
        private System.Windows.Forms.CheckBox wavFilesCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BeginScanButton;
        private System.Windows.Forms.Label AmountOfFilesTextLabel;
        private System.Windows.Forms.Label amountOfFilesFoundNumberLabel;
        private System.Windows.Forms.Button DeleteFilesButton;
    }
}

