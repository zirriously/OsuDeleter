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

        private string _osuDirectory;
        private DialogResult _dialogResult;

        public void directoryButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (Directory.Exists(folderBrowserDialog1.SelectedPath))
                if (folderBrowserDialog1.SelectedPath.Contains("osu"))
                {
                    if (folderBrowserDialog1.SelectedPath.Contains("\\Songs"))
                        _osuDirectory = folderBrowserDialog1.SelectedPath;
                    else
                        _osuDirectory = folderBrowserDialog1.SelectedPath + "\\Songs";
                }
                else
                {
                    _dialogResult = MessageBox.Show(
                        $"It looks like you didn't choose the Osu! directory. The directory you have selected is {folderBrowserDialog1.SelectedPath}. \nAre you sure you want to use this directory?",
                        "Incorrect path", MessageBoxButtons.YesNo);
                    if (_dialogResult == DialogResult.Yes)
                        _osuDirectory = folderBrowserDialog1.SelectedPath;
                    if (_dialogResult == DialogResult.No)
                        MessageBox.Show("Please pick another directory.");
                }
            else
                MessageBox.Show("The path selected does not exist.");
            directoryTextBox.Text = _osuDirectory;
        }

        private void directoryTextBox_TextChanged(object sender, EventArgs e)
        {
            //_osuDirectory = directoryTextBox.ToString();
        }


        private bool _jpgFilesChecked;
        private bool _pngFilesChecked;
        private bool _wavFilesChecked;
        private bool _aviFilesChecked;

        private void jpgFilesTickBox_CheckedChanged(object sender, EventArgs e)
        {
            _jpgFilesChecked = jpgFilesTickBox.Checked;
            beginScanButton.Enabled = CheckboxesActive;
            //Console.WriteLine($"_jpgFilesChecked = {_jpgFilesChecked}");
        }

        private void pngFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _pngFilesChecked = pngFilesCheckBox.Checked;
            beginScanButton.Enabled = CheckboxesActive;
            //Console.WriteLine($"_pngFilesChecked = {_pngFilesChecked}");
        }

        private void wavFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _wavFilesChecked = wavFilesCheckBox.Checked;
            beginScanButton.Enabled = CheckboxesActive;
            //Console.WriteLine($"_wavFilesChecked = {_wavFilesChecked}");
        }

        private void aviFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _aviFilesChecked = aviFilesCheckBox.Checked;
            beginScanButton.Enabled = CheckboxesActive;
            //Console.WriteLine($"_aviFilesChecked = {_aviFilesChecked}");
        }

        private bool CheckboxesActive => jpgFilesTickBox.Checked || pngFilesCheckBox.Checked ||
                                         wavFilesCheckBox.Checked || aviFilesCheckBox.Checked;

        private readonly List<string> fileList = new List<string>();

        private double count;

        private void beginScanButton_Click(object sender, EventArgs e)
        {
            if (_osuDirectory == null)
                MessageBox.Show("You have not chosen an Osu! directory yet.");
            if (_osuDirectory != null)
            {
                fileList.Clear();
                if (_jpgFilesChecked)
                    fileList.AddRange(Directory.GetFiles(_osuDirectory, "*.jpg", SearchOption.AllDirectories));
                if (_pngFilesChecked)
                    fileList.AddRange(Directory.GetFiles(_osuDirectory, "*.png", SearchOption.AllDirectories));
                if (_wavFilesChecked)
                    fileList.AddRange(Directory.GetFiles(_osuDirectory, "*.wav", SearchOption.AllDirectories));
                if (_aviFilesChecked)
                    fileList.AddRange(Directory.GetFiles(_osuDirectory, "*.avi", SearchOption.AllDirectories));
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
            _dialogResult = _dialogResult =
                MessageBox.Show($"Are you sure you want to delete {fileList.Count()} file(s)?", "",
                    MessageBoxButtons.YesNo);
            if (_dialogResult == DialogResult.Yes)
            {
                foreach (var i in fileList)
                    File.Delete(Convert.ToString(i));
                MessageBox.Show($"{count} files have been deleted.");
            }
            else
            {
                MessageBox.Show("Deletion cancelled.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}