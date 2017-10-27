using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        private bool _isOsuDir;

        public void directoryButton_Click(object sender, EventArgs e)
        {
            BeginScanButton.Enabled = CheckboxesActive;
            ToggleLabels(false);
            _accessDeniedException = false;
            folderBrowserDialog1.ShowDialog();
            if (Directory.Exists(folderBrowserDialog1.SelectedPath))
                if (folderBrowserDialog1.SelectedPath.Contains("osu"))
                {
                    _isOsuDir = true;
                    if (folderBrowserDialog1.SelectedPath.Contains("\\Songs"))
                        _osuDirectory = folderBrowserDialog1.SelectedPath;
                    else
                        _osuDirectory = folderBrowserDialog1.SelectedPath + "\\Songs";
                    directoryTextBox.Text = _osuDirectory;
                }
                else
                {
                    _dialogResult = MessageBox.Show(
                        $"It looks like you didn't choose the Osu! directory. The directory you have selected is {folderBrowserDialog1.SelectedPath}. \nAre you sure you want to use this directory?",
                        "Incorrect path", MessageBoxButtons.YesNo);
                    if (_dialogResult == DialogResult.Yes)
                    {
                        _osuDirectory = folderBrowserDialog1.SelectedPath;
                        directoryTextBox.Text = _osuDirectory;
                    }
                    else
                    {
                        directoryTextBox.Text = "Choose Osu! directory";
                    }
                }
            else
            {
                MessageBox.Show("The path selected does not exist.");
                directoryTextBox.Text = "Choose Osu! directory";
            }
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

        private readonly List<string> FileList = new List<string>();

        private double _count;

        private bool _accessDeniedException;


        private void EnableBoxes(bool isVisible)
        {
            if (isVisible)
            {
                directoryButton.Enabled = true;
                jpgFilesTickBox.Enabled = true;
                pngFilesCheckBox.Enabled = true;
                aviFilesCheckBox.Enabled = true;
                wavFilesCheckBox.Enabled = true;
            }
            else
            {
                directoryButton.Enabled = false;
                jpgFilesTickBox.Enabled = false;
                pngFilesCheckBox.Enabled = false;
                aviFilesCheckBox.Enabled = false;
                wavFilesCheckBox.Enabled = false;
            }
        }
        private void ScanFilesInParallel()
        {
            clearFilesButton.Enabled = false;
            loadingCircle1.Visible = true;
            DeleteFilesButton.Enabled = false;
            FileList.Clear();
            EnableBoxes(true);
            BeginScanButton.Enabled = false;
            ScanningLabel.Visible = true;

            Task.Run(() =>
                {
                    
                    var result = new List<string>();
                    FileParser FileParser = new FileParser();
                    if (_jpgFilesChecked)
                        try
                        {
                            result.AddRange(FileParser.ParseFiles(_osuDirectory, "*.jpg"));
                            if (_pngFilesChecked)
                                result.AddRange(FileParser.ParseFiles(_osuDirectory, "*.png"));
                            if (_wavFilesChecked)
                                result.AddRange(FileParser.ParseFiles(_osuDirectory, "*.wav"));
                            if (_aviFilesChecked)
                                result.AddRange(FileParser.ParseFiles(_osuDirectory, "*.avi"));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Access denied. Try running as administrator.");
                            return null;
                        }
                    return result;
                })
                .ContinueWith((task) => {
                    if (task.Result == null)
                    {
                        EnableBoxes(true);
                        loadingCircle1.Visible = false;
                        ScanningLabel.Visible = false;
                        BeginScanButton.Enabled = true;
                    }
                    else
                    { 
                    FileList.AddRange(task.Result);
                    BeginScanButton.Enabled = true;
                    loadingCircle1.Visible = false;
                    ScanningLabel.Visible = false;

                    // Error checking - 0 files, etc

                    if (FileList.Count == 0 && _osuDirectory != null && _accessDeniedException == false)
                    {
                        MessageBox.Show("No files have been found. Did you choose the correct directory for Osu?");
                        EnableBoxes(true);
                    }
                    else if (_osuDirectory != null && _accessDeniedException == false)
                        {

                            _count = FileList.Count;
                            amountOfFilesFoundNumberLabel.Text = _count.ToString();
                            DeleteFilesButton.Enabled = true;
                            AmountOfFilesTextLabel.Enabled = true;
                            amountOfFilesFoundNumberLabel.Show();
                            TotalFileSizeNumberLabel.Show();
                            BeginScanButton.Enabled = true;

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
                            DeleteFilesButton.Enabled = true;
                            EnableBoxes(true);
                        }
                    }

                }, TaskScheduler.FromCurrentSynchronizationContext());
        }


        private void BeginScanButton_Click(object sender, EventArgs e)
        {
            if (_osuDirectory == null)
            {
                MessageBox.Show("You have not chosen an Osu! directory yet.");
            }
            else
            {
                TotalFileSizeNumberLabel.Visible = false;
                amountOfFilesFoundNumberLabel.Visible = false;
                ScanFilesInParallel();
            }
        }

        private DialogResult _dialogResult2;

        private void DeleteFilesButton_Click(object sender, EventArgs e)
        {
            _dialogResult = MessageBox.Show($"Are you sure you want to delete {FileList.Count()} file(s)?", "",
                MessageBoxButtons.YesNo);
            if (_dialogResult == DialogResult.Yes)
                if (_isOsuDir)
                {
                    FileDeleter.DeleteFiles(FileList);
                    MessageBox.Show($"{_count} files has been deleted.");
                    ToggleLabels(false);
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
                        ToggleLabels(false);
                    }
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ToggleLabels(bool visible)
        {
            if (visible)
            {
            }
            else
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
                loadingCircle1.Visible = false;
                _accessDeniedException = false;
            }
        }

        private void clearFilesButton_Click(object sender, EventArgs e)
        {
            ToggleLabels(false);
            _osuDirectory = null;
            directoryTextBox.Text = "Choose Osu! directory";
        }
    }
}