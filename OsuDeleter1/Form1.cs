using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Humanizer;
using OsuDeleter;


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
        private bool _isOsuDir = false;

        public void directoryButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (Directory.Exists(folderBrowserDialog1.SelectedPath))
                if (folderBrowserDialog1.SelectedPath.Contains("osu"))
                {
                    _isOsuDir = true;
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

        public static List<string> FileList = new List<string>();

        private double _count;

        private void BeginScanButton_Click(object sender, EventArgs e)
        {
            if (_osuDirectory == null)
                MessageBox.Show("You have not chosen an Osu! directory yet.");
            else
            {
                FileList.Clear(); 
                try
                {
                    if (_jpgFilesChecked)
                        FileParser.ParseFiles(_osuDirectory, "*.jpg");
                    if (_pngFilesChecked)
                        FileParser.ParseFiles(_osuDirectory, "*.png");
                    if (_wavFilesChecked)
                        FileParser.ParseFiles(_osuDirectory, "*.wav");
                    if (_aviFilesChecked)
                        FileParser.ParseFiles(_osuDirectory, ".avi");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error - Access denied. Try running the program as administrator (certain system directories will always deny access, e.g. recycle bin)");
                    return;
                }
                if (FileList.Count == 0)
                {
                    MessageBox.Show("No files have been found. Did you choose the correct directory for Osu?");
                }
                else
                {
                    
                    //Buttons and labels
                    _count = FileList.Count;
                    amountOfFilesFoundNumberLabel.Text = _count.ToString();
                    DeleteFilesButton.Enabled = true;
                    AmountOfFilesTextLabel.Enabled = true;
                    amountOfFilesFoundNumberLabel.Show();
                    TotalFileSizeNumberLabel.Show();
                    TotalFileSize.Enabled = true;
                    clearFilesButton.Enabled = true;

                    // Get total size of all files and show next to total amount of files
                    double totalSize = 0;
                    foreach (var value in FileList)
                    {
                        FileInfo fileInfo = new FileInfo(value);
                        totalSize += fileInfo.Length;
                    }

                    // Humanising size
                    var totalSizeHumanized = totalSize.Bytes();
                    TotalFileSizeNumberLabel.Text = totalSizeHumanized.Humanize("#.##");
                }
            }
        }

        private DialogResult _dialogResult2;

        private void DeleteFilesButton_Click(object sender, EventArgs e)
        {
            _dialogResult = MessageBox.Show($"Are you sure you want to delete {FileList.Count()} file(s)?", "", MessageBoxButtons.YesNo);
            if (_dialogResult == DialogResult.Yes)
            {
                if (_isOsuDir)
                {
                    FileDeleter.DeleteFiles(FileList);
                    MessageBox.Show($"{_count} files has been deleted.");
                    ClearLabels();
                }
                else
                {
                    _dialogResult2 =
                        MessageBox.Show(
                            $"Warning - Path does NOT contain 'Osu'. The full path is {_osuDirectory}. This will delete files your files. Proceed with deletion?",
                            "Warning - potential incorrect path", MessageBoxButtons.OKCancel);
                    if (_dialogResult2 == DialogResult.OK)
                    {
                        FileDeleter.DeleteFiles(FileList);
                        MessageBox.Show($"{_count} files has been deleted.");
                        ClearLabels();
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ClearLabels() // Should make this a toggleable function, to clear+hide and show accordingly. 
        {
            _count = 0;
            TotalFileSizeNumberLabel.Text = "";
            amountOfFilesFoundNumberLabel.Text = "";
            AmountOfFilesTextLabel.Enabled = false;
            TotalFileSize.Enabled = false;
            TotalFileSizeNumberLabel.Hide();
            amountOfFilesFoundNumberLabel.Hide();
            DeleteFilesButton.Enabled = false;
            FileList.Clear();
        }

        private void clearFilesButton_Click(object sender, EventArgs e)
        {
            ClearLabels();
        }
    }
}