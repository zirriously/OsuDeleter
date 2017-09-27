using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsuDeleter1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string osuDirectory;
        DialogResult dialogResult;
        public void directoryButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (Directory.Exists(folderBrowserDialog1.SelectedPath))
            {
                if (folderBrowserDialog1.SelectedPath.Contains("osu"))
                {
                    if (folderBrowserDialog1.SelectedPath.Contains("\\Songs"))
                    {
                        osuDirectory = folderBrowserDialog1.SelectedPath;
                    }
                    else
                    {
                        osuDirectory = folderBrowserDialog1.SelectedPath + "\\Songs";
                    }
                }
                else
                {
                    dialogResult = MessageBox.Show($"It looks like you didn't choose the Osu! directory. The directory you have selected is {folderBrowserDialog1.SelectedPath}. \nAre you sure you want to use this directory?", "Incorrect path", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                        osuDirectory = folderBrowserDialog1.SelectedPath;
                    if (dialogResult == DialogResult.No)
                        MessageBox.Show("Please pick another directory.");
                }
            }
            else
            {
                MessageBox.Show("The path selected does not exist.");
            }
            directoryTextBox.Text = osuDirectory;
        }

        private void directoryTextBox_TextChanged(object sender, EventArgs e)
        {
            //osuDirectory = directoryTextBox.ToString();
        }


        bool jpgFilesChecked = false;
        bool pngFilesChecked = false;
        bool wavFilesChecked = false;
        bool aviFilesChecked = false;

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

        private bool CheckboxesActive
        {
                get { return (jpgFilesTickBox.Checked == true || pngFilesCheckBox.Checked == true || wavFilesCheckBox.Checked == true || aviFilesCheckBox.Checked == true); }
        }

        /*
        private List<String> FileList(String directory, String extension)
        {
            return Directory.GetFiles(directory, extension, SearchOption.AllDirectories).ToList();
        }
        */

        List<String> fileList = new List<String>();

        double count;
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
                    MessageBox.Show("No files have been found. Did you choose the correct directory for Osu?");
                else
                {
                    count = fileList.Count();
                    amountOfFilesFoundNumberLabel.Text = System.Convert.ToString(count);
                    deleteFilesButton.Enabled = true;
                    amountOfFilesTextLabel.Enabled = true;
                    amountOfFilesFoundNumberLabel.Show();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine($"{osuDirectory}");
        }

        private void deleteFilesButton_Click(object sender, EventArgs e)
        {
            dialogResult = dialogResult = MessageBox.Show($"Are you sure you want to delete {fileList.Count()} file(s)?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (var i in fileList)
                {
                    //Console.WriteLine("Deleted file " + i);
                    File.Delete(Convert.ToString(i));
                }
                MessageBox.Show($"{count} files have been deleted.");
            }
            if (dialogResult == DialogResult.No)
                MessageBox.Show("Deletion cancelled.");
        }

    }
}
