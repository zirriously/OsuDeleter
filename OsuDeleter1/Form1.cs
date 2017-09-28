using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OsuDeleter1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string osuDirectory;
        private DialogResult dialogResult;

        public void directoryButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (Directory.Exists(folderBrowserDialog1.SelectedPath))
                if (folderBrowserDialog1.SelectedPath.Contains("osu"))
                {
                    if (folderBrowserDialog1.SelectedPath.Contains("\\Songs"))
                        osuDirectory = folderBrowserDialog1.SelectedPath;
                    else
                        osuDirectory = folderBrowserDialog1.SelectedPath + "\\Songs";
                }
                else
                {
                    dialogResult = MessageBox.Show(
                        $"It looks like you didn't choose the Osu! directory. The directory you have selected is {folderBrowserDialog1.SelectedPath}. \nAre you sure you want to use this directory?",
                        "Incorrect path", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                        osuDirectory = folderBrowserDialog1.SelectedPath;
                    if (dialogResult == DialogResult.No)
                        MessageBox.Show("Please pick another directory.");
                }
            else
                MessageBox.Show("The path selected does not exist.");
            directoryTextBox.Text = osuDirectory;
        }

        private void directoryTextBox_TextChanged(object sender, EventArgs e)
        {
            //osuDirectory = directoryTextBox.ToString();
        }


        private bool jpgFilesChecked;
        private bool pngFilesChecked;
        private bool wavFilesChecked;
        private bool aviFilesChecked;

        private void jpgFilesTickBox_CheckedChanged(object sender, EventArgs e)
        {
            jpgFilesChecked = jpgFilesTickBox.Checked;
            beginScanButton.Enabled = CheckboxesActive;
            //Console.WriteLine($"jpgFilesChecked = {jpgFilesChecked}");
        }

        private void pngFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pngFilesChecked = pngFilesCheckBox.Checked;
            beginScanButton.Enabled = CheckboxesActive;
            //Console.WriteLine($"pngFilesChecked = {pngFilesChecked}");
        }

        private void wavFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            wavFilesChecked = wavFilesCheckBox.Checked;
            beginScanButton.Enabled = CheckboxesActive;
            //Console.WriteLine($"wavFilesChecked = {wavFilesChecked}");
        }

        private void aviFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            aviFilesChecked = aviFilesCheckBox.Checked;
            beginScanButton.Enabled = CheckboxesActive;
            //Console.WriteLine($"aviFilesChecked = {aviFilesChecked}");
        }

        private bool CheckboxesActive => jpgFilesTickBox.Checked || pngFilesCheckBox.Checked ||
                                         wavFilesCheckBox.Checked || aviFilesCheckBox.Checked;

        private readonly List<string> fileList = new List<string>();

        private double count;

        private void beginScanButton_Click(object sender, EventArgs e)
        {
            if (osuDirectory == null)
                MessageBox.Show("You have not chosen an Osu! directory yet.");
            if (osuDirectory != null)
            {
                fileList.Clear();
                if (jpgFilesChecked)
                    fileList.AddRange(Directory.GetFiles(osuDirectory, "*.jpg", SearchOption.AllDirectories));
                if (pngFilesChecked)
                    fileList.AddRange(Directory.GetFiles(osuDirectory, "*.png", SearchOption.AllDirectories));
                if (wavFilesChecked)
                    fileList.AddRange(Directory.GetFiles(osuDirectory, "*.wav", SearchOption.AllDirectories));
                if (aviFilesChecked)
                    fileList.AddRange(Directory.GetFiles(osuDirectory, "*.avi", SearchOption.AllDirectories));
                if (fileList.Count == 0)
                {
                    MessageBox.Show("No files have been found. Did you choose the correct directory for Osu?");
                }
                else
                {
                    count = fileList.Count();
                    amountOfFilesFoundNumberLabel.Text = count.ToString();
                    deleteFilesButton.Enabled = true;
                    amountOfFilesTextLabel.Enabled = true;
                    amountOfFilesFoundNumberLabel.Show();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void deleteFilesButton_Click(object sender, EventArgs e)
        {
            dialogResult = dialogResult =
                MessageBox.Show($"Are you sure you want to delete {fileList.Count()} file(s)?", "",
                    MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (var i in fileList)
                    File.Delete(Convert.ToString(i));
                MessageBox.Show($"{count} files have been deleted.");
            }
            else
                MessageBox.Show("Deletion cancelled.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}