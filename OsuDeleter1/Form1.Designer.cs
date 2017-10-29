namespace OsuDeleter
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
            this.TotalFileSize = new System.Windows.Forms.Label();
            this.TotalFileSizeNumberLabel = new System.Windows.Forms.Label();
            this.clearFilesButton = new System.Windows.Forms.Button();
            this.loadingCircle1 = new MRG.Controls.UI.LoadingCircle();
            this.ScanningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.BackColor = System.Drawing.Color.White;
            this.directoryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.directoryTextBox.Enabled = false;
            this.directoryTextBox.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directoryTextBox.ForeColor = System.Drawing.Color.LavenderBlush;
            this.directoryTextBox.Location = new System.Drawing.Point(34, 15);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.ReadOnly = true;
            this.directoryTextBox.Size = new System.Drawing.Size(400, 14);
            this.directoryTextBox.TabIndex = 1;
            this.directoryTextBox.Text = "Choose Osu! directory";
            this.directoryTextBox.TextChanged += new System.EventHandler(this.directoryTextBox_TextChanged);
            // 
            // directoryButton
            // 
            this.directoryButton.BackColor = System.Drawing.Color.Transparent;
            this.directoryButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.directoryButton.FlatAppearance.BorderSize = 2;
            this.directoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.directoryButton.Location = new System.Drawing.Point(17, 15);
            this.directoryButton.Name = "directoryButton";
            this.directoryButton.Size = new System.Drawing.Size(16, 16);
            this.directoryButton.TabIndex = 2;
            this.directoryButton.UseVisualStyleBackColor = false;
            this.directoryButton.Click += new System.EventHandler(this.directoryButton_Click);
            // 
            // jpgFilesTickBox
            // 
            this.jpgFilesTickBox.AutoSize = true;
            this.jpgFilesTickBox.BackColor = System.Drawing.Color.Transparent;
            this.jpgFilesTickBox.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jpgFilesTickBox.ForeColor = System.Drawing.Color.LavenderBlush;
            this.jpgFilesTickBox.Location = new System.Drawing.Point(13, 52);
            this.jpgFilesTickBox.Name = "jpgFilesTickBox";
            this.jpgFilesTickBox.Size = new System.Drawing.Size(68, 20);
            this.jpgFilesTickBox.TabIndex = 3;
            this.jpgFilesTickBox.Text = ".jpg files";
            this.jpgFilesTickBox.UseVisualStyleBackColor = false;
            this.jpgFilesTickBox.CheckedChanged += new System.EventHandler(this.jpgFilesTickBox_CheckedChanged);
            // 
            // pngFilesCheckBox
            // 
            this.pngFilesCheckBox.AutoSize = true;
            this.pngFilesCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.pngFilesCheckBox.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pngFilesCheckBox.ForeColor = System.Drawing.Color.LavenderBlush;
            this.pngFilesCheckBox.Location = new System.Drawing.Point(13, 68);
            this.pngFilesCheckBox.Name = "pngFilesCheckBox";
            this.pngFilesCheckBox.Size = new System.Drawing.Size(73, 20);
            this.pngFilesCheckBox.TabIndex = 4;
            this.pngFilesCheckBox.Text = ".png files";
            this.pngFilesCheckBox.UseVisualStyleBackColor = false;
            this.pngFilesCheckBox.CheckedChanged += new System.EventHandler(this.pngFilesCheckBox_CheckedChanged);
            // 
            // aviFilesCheckBox
            // 
            this.aviFilesCheckBox.AutoSize = true;
            this.aviFilesCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.aviFilesCheckBox.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aviFilesCheckBox.ForeColor = System.Drawing.Color.LavenderBlush;
            this.aviFilesCheckBox.Location = new System.Drawing.Point(13, 100);
            this.aviFilesCheckBox.Name = "aviFilesCheckBox";
            this.aviFilesCheckBox.Size = new System.Drawing.Size(69, 20);
            this.aviFilesCheckBox.TabIndex = 6;
            this.aviFilesCheckBox.Text = ".avi files";
            this.aviFilesCheckBox.UseVisualStyleBackColor = false;
            this.aviFilesCheckBox.CheckedChanged += new System.EventHandler(this.aviFilesCheckBox_CheckedChanged);
            // 
            // wavFilesCheckBox
            // 
            this.wavFilesCheckBox.AutoSize = true;
            this.wavFilesCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.wavFilesCheckBox.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wavFilesCheckBox.ForeColor = System.Drawing.Color.LavenderBlush;
            this.wavFilesCheckBox.Location = new System.Drawing.Point(13, 84);
            this.wavFilesCheckBox.Name = "wavFilesCheckBox";
            this.wavFilesCheckBox.Size = new System.Drawing.Size(77, 20);
            this.wavFilesCheckBox.TabIndex = 5;
            this.wavFilesCheckBox.Text = ".wav files";
            this.wavFilesCheckBox.UseVisualStyleBackColor = false;
            this.wavFilesCheckBox.CheckedChanged += new System.EventHandler(this.wavFilesCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label1.Location = new System.Drawing.Point(10, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select which files to delete";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BeginScanButton
            // 
            this.BeginScanButton.BackColor = System.Drawing.Color.Transparent;
            this.BeginScanButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.BeginScanButton.Enabled = false;
            this.BeginScanButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.BeginScanButton.FlatAppearance.BorderSize = 2;
            this.BeginScanButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BeginScanButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeginScanButton.ForeColor = System.Drawing.Color.LavenderBlush;
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
            this.AmountOfFilesTextLabel.BackColor = System.Drawing.Color.Transparent;
            this.AmountOfFilesTextLabel.Enabled = false;
            this.AmountOfFilesTextLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AmountOfFilesTextLabel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountOfFilesTextLabel.ForeColor = System.Drawing.Color.LavenderBlush;
            this.AmountOfFilesTextLabel.Location = new System.Drawing.Point(204, 56);
            this.AmountOfFilesTextLabel.Name = "AmountOfFilesTextLabel";
            this.AmountOfFilesTextLabel.Size = new System.Drawing.Size(66, 16);
            this.AmountOfFilesTextLabel.TabIndex = 10;
            this.AmountOfFilesTextLabel.Text = "Files found:";
            this.AmountOfFilesTextLabel.Click += new System.EventHandler(this.AmountOfFilesTextLabel_Click);
            // 
            // amountOfFilesFoundNumberLabel
            // 
            this.amountOfFilesFoundNumberLabel.AutoSize = true;
            this.amountOfFilesFoundNumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.amountOfFilesFoundNumberLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.amountOfFilesFoundNumberLabel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountOfFilesFoundNumberLabel.ForeColor = System.Drawing.Color.LavenderBlush;
            this.amountOfFilesFoundNumberLabel.Location = new System.Drawing.Point(261, 56);
            this.amountOfFilesFoundNumberLabel.Name = "amountOfFilesFoundNumberLabel";
            this.amountOfFilesFoundNumberLabel.Size = new System.Drawing.Size(14, 16);
            this.amountOfFilesFoundNumberLabel.TabIndex = 11;
            this.amountOfFilesFoundNumberLabel.Text = "0";
            this.amountOfFilesFoundNumberLabel.Click += new System.EventHandler(this.amountOfFilesFoundNumberLabel_Click);
            // 
            // DeleteFilesButton
            // 
            this.DeleteFilesButton.BackColor = System.Drawing.Color.Transparent;
            this.DeleteFilesButton.Enabled = false;
            this.DeleteFilesButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.DeleteFilesButton.FlatAppearance.BorderSize = 2;
            this.DeleteFilesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteFilesButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteFilesButton.Location = new System.Drawing.Point(127, 92);
            this.DeleteFilesButton.Name = "DeleteFilesButton";
            this.DeleteFilesButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteFilesButton.TabIndex = 12;
            this.DeleteFilesButton.Text = "Delete files";
            this.DeleteFilesButton.UseVisualStyleBackColor = false;
            this.DeleteFilesButton.Click += new System.EventHandler(this.DeleteFilesButton_Click);
            // 
            // TotalFileSize
            // 
            this.TotalFileSize.AutoSize = true;
            this.TotalFileSize.BackColor = System.Drawing.Color.Transparent;
            this.TotalFileSize.Enabled = false;
            this.TotalFileSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TotalFileSize.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalFileSize.ForeColor = System.Drawing.Color.LavenderBlush;
            this.TotalFileSize.Location = new System.Drawing.Point(204, 72);
            this.TotalFileSize.Name = "TotalFileSize";
            this.TotalFileSize.Size = new System.Drawing.Size(65, 16);
            this.TotalFileSize.TabIndex = 13;
            this.TotalFileSize.Text = "Size of files:";
            this.TotalFileSize.Click += new System.EventHandler(this.TotalFileSize_Click);
            // 
            // TotalFileSizeNumberLabel
            // 
            this.TotalFileSizeNumberLabel.AutoSize = true;
            this.TotalFileSizeNumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.TotalFileSizeNumberLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TotalFileSizeNumberLabel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalFileSizeNumberLabel.ForeColor = System.Drawing.Color.LavenderBlush;
            this.TotalFileSizeNumberLabel.Location = new System.Drawing.Point(261, 72);
            this.TotalFileSizeNumberLabel.Name = "TotalFileSizeNumberLabel";
            this.TotalFileSizeNumberLabel.Size = new System.Drawing.Size(14, 16);
            this.TotalFileSizeNumberLabel.TabIndex = 14;
            this.TotalFileSizeNumberLabel.Text = "0";
            this.TotalFileSizeNumberLabel.Click += new System.EventHandler(this.TotalFileSizeNumberLabel_Click);
            // 
            // clearFilesButton
            // 
            this.clearFilesButton.BackColor = System.Drawing.Color.Transparent;
            this.clearFilesButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.clearFilesButton.FlatAppearance.BorderSize = 2;
            this.clearFilesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearFilesButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearFilesButton.ForeColor = System.Drawing.Color.LavenderBlush;
            this.clearFilesButton.Location = new System.Drawing.Point(380, 92);
            this.clearFilesButton.Name = "clearFilesButton";
            this.clearFilesButton.Size = new System.Drawing.Size(53, 23);
            this.clearFilesButton.TabIndex = 15;
            this.clearFilesButton.Text = "Clear";
            this.clearFilesButton.UseVisualStyleBackColor = false;
            this.clearFilesButton.Click += new System.EventHandler(this.clearFilesButton_Click);
            // 
            // loadingCircle1
            // 
            this.loadingCircle1.Active = true;
            this.loadingCircle1.BackColor = System.Drawing.Color.Transparent;
            this.loadingCircle1.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle1.InnerCircleRadius = 8;
            this.loadingCircle1.Location = new System.Drawing.Point(262, 92);
            this.loadingCircle1.Name = "loadingCircle1";
            this.loadingCircle1.NumberSpoke = 24;
            this.loadingCircle1.OuterCircleRadius = 9;
            this.loadingCircle1.RotationSpeed = 100;
            this.loadingCircle1.Size = new System.Drawing.Size(26, 25);
            this.loadingCircle1.SpokeThickness = 4;
            this.loadingCircle1.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.IE7;
            this.loadingCircle1.TabIndex = 16;
            this.loadingCircle1.Text = "loadingCircle";
            this.loadingCircle1.Visible = false;
            // 
            // ScanningLabel
            // 
            this.ScanningLabel.AutoSize = true;
            this.ScanningLabel.BackColor = System.Drawing.Color.Transparent;
            this.ScanningLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ScanningLabel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScanningLabel.ForeColor = System.Drawing.Color.LavenderBlush;
            this.ScanningLabel.Location = new System.Drawing.Point(204, 97);
            this.ScanningLabel.Name = "ScanningLabel";
            this.ScanningLabel.Size = new System.Drawing.Size(59, 16);
            this.ScanningLabel.TabIndex = 17;
            this.ScanningLabel.Text = "Scanning";
            this.ScanningLabel.Visible = false;
            this.ScanningLabel.Click += new System.EventHandler(this.ScanningLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::OsuDeleter.Properties.Resources.OsuDeleterBG1;
            this.ClientSize = new System.Drawing.Size(447, 119);
            this.Controls.Add(this.ScanningLabel);
            this.Controls.Add(this.loadingCircle1);
            this.Controls.Add(this.clearFilesButton);
            this.Controls.Add(this.TotalFileSizeNumberLabel);
            this.Controls.Add(this.TotalFileSize);
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
            this.ForeColor = System.Drawing.Color.LavenderBlush;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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
        private System.Windows.Forms.Label TotalFileSize;
        private System.Windows.Forms.Label TotalFileSizeNumberLabel;
        private System.Windows.Forms.Button clearFilesButton;
        private MRG.Controls.UI.LoadingCircle loadingCircle1;
        private System.Windows.Forms.Label ScanningLabel;
    }
}

