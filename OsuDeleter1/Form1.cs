using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Humanizer;


namespace OsuDeleter1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TotalFileSizeNumberLabel.Text = "";
            amountOfFilesFoundNumberLabel.Text = "";
            clearFilesButton.Enabled = false;
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
            BeginScanButton.Enabled = CheckboxesActive;
            //Console.WriteLine($"_jpgFilesChecked = {_jpgFilesChecked}");
        }

        private void pngFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _pngFilesChecked = pngFilesCheckBox.Checked;
            BeginScanButton.Enabled = CheckboxesActive;
            //Console.WriteLine($"_pngFilesChecked = {_pngFilesChecked}");
        }

        private void wavFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _wavFilesChecked = wavFilesCheckBox.Checked;
            BeginScanButton.Enabled = CheckboxesActive;
            //Console.WriteLine($"_wavFilesChecked = {_wavFilesChecked}");
        }

        private void aviFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _aviFilesChecked = aviFilesCheckBox.Checked;
            BeginScanButton.Enabled = CheckboxesActive;
            //Console.WriteLine($"_aviFilesChecked = {_aviFilesChecked}");
        }

        private bool CheckboxesActive => jpgFilesTickBox.Checked || pngFilesCheckBox.Checked ||
                                         wavFilesCheckBox.Checked || aviFilesCheckBox.Checked;

        private readonly List<string> _fileList = new List<string>();

        private double count;

        private void BeginScanButton_Click(object sender, EventArgs e)
        {
            if (_osuDirectory == null)
                MessageBox.Show("You have not chosen an Osu! directory yet.");
            if (_osuDirectory != null)
            {
                _fileList.Clear();
                try
                {
                    if (_jpgFilesChecked)
                        _fileList.AddRange(Directory.GetFiles(_osuDirectory, "*.jpg", SearchOption.AllDirectories));
                    if (_pngFilesChecked)
                        _fileList.AddRange(Directory.GetFiles(_osuDirectory, "*.png", SearchOption.AllDirectories));
                    if (_wavFilesChecked)
                        _fileList.AddRange(Directory.GetFiles(_osuDirectory, "*.wav", SearchOption.AllDirectories));
                    if (_aviFilesChecked)
                        _fileList.AddRange(Directory.GetFiles(_osuDirectory, "*.avi", SearchOption.AllDirectories));
                }
                catch (Exception)
                {
                    MessageBox.Show("Error - Access denied. Try running the program as administrator (certain system directories will always deny access, e.g. recycle bin)");
                    return;
                }
                if (_fileList.Count == 0)
                {
                    MessageBox.Show("No files have been found. Did you choose the correct directory for Osu?");
                }
                else
                {
                    count = _fileList.Count();
                    amountOfFilesFoundNumberLabel.Text = count.ToString();
                    DeleteFilesButton.Enabled = true;
                    AmountOfFilesTextLabel.Enabled = true;
                    amountOfFilesFoundNumberLabel.Show();
                    TotalFileSizeNumberLabel.Show();
                    // Get total size of all files and show next to total amount of files
                    TotalFileSize.Enabled = true;
                    double totalSize = 0;
                    foreach (var value in _fileList)
                    {
                        FileInfo fileInfo = new FileInfo(value);
                        totalSize += fileInfo.Length;
                    }
                    var totalSizeHumanized = totalSize.Bytes();
                    TotalFileSizeNumberLabel.Text = totalSizeHumanized.Humanize("#.##");
                    clearFilesButton.Enabled = true;
                }
            }
        }



        private void DeleteFilesButton_Click(object sender, EventArgs e)
        {
            _dialogResult = _dialogResult =
                MessageBox.Show($"Are you sure you want to delete {_fileList.Count()} file(s)?", "",
                    MessageBoxButtons.YesNo);
            if (_dialogResult == DialogResult.Yes)
            {
                foreach (var i in _fileList)
                    File.Delete(Convert.ToString(i));
                MessageBox.Show($"{count} files have been deleted.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void clearFilesButton_Click(object sender, EventArgs e)
        {
            TotalFileSizeNumberLabel.Text = "";
            amountOfFilesFoundNumberLabel.Text = "";
            AmountOfFilesTextLabel.Enabled = false;
            TotalFileSize.Enabled = false;
            TotalFileSizeNumberLabel.Hide();
            amountOfFilesFoundNumberLabel.Hide();
            DeleteFilesButton.Enabled = false;
            _fileList.Clear();
        }
    }
}