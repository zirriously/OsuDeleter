﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public static List<string> FileList = new List<string>();

        private double _count;

        private Task ScanFilesTask()
        {
            var t = Task.Run(ScanFilesTask);
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
                MessageBox.Show(
                    "Error - Access denied. Try running the program as administrator (certain system directories will always deny access, e.g. recycle bin)");
                throw;
            }
            return t;
        }


        private async void BeginScanButton_Click(object sender, EventArgs e)
        {
            if (_osuDirectory == null)
                MessageBox.Show("You have not chosen an Osu! directory yet.");
            else
                await ScanFilesTask();
            if (FileList.Count == 0 && _osuDirectory != null)
            {
                MessageBox.Show("No files have been found. Did you choose the correct directory for Osu?");
            }
            else if (_osuDirectory != null)
            {
                _count = FileList.Count;
                amountOfFilesFoundNumberLabel.Text = _count.ToString();
                DeleteFilesButton.Enabled = true;
                AmountOfFilesTextLabel.Enabled = true;
                amountOfFilesFoundNumberLabel.Show();
                TotalFileSizeNumberLabel.Show();
                // Get total size of all files and show next to total amount of files
                TotalFileSize.Enabled = true;
                double totalSize = 0;
                foreach (var value in FileList)
                {
                    var fileInfo = new FileInfo(value);
                    totalSize += fileInfo.Length;
                }
                var totalSizeHumanized = totalSize.Bytes();
                TotalFileSizeNumberLabel.Text = totalSizeHumanized.Humanize("#.##");
                clearFilesButton.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void DeleteFilesButton_Click(object sender, EventArgs e)
        {
            _dialogResult = _dialogResult =
                MessageBox.Show($"Are you sure you want to delete {FileList.Count()} file(s)?", "",
                    MessageBoxButtons.YesNo);
            if (_dialogResult == DialogResult.Yes)
            {
                FileDeleter.DeleteFiles(FileList);
                MessageBox.Show($"{_count} files has been deleted.");
                ClearLabels();
            }
        }

        private void ClearLabels()
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