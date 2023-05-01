using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CPUVisNEA
{
    public partial class LoadFile_Form : Form
    {
        private readonly List<string> existingFiles = new List<string>();
        private readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\";
        public string ReturnedProgram = "";

        public LoadFile_Form(List<string> existingFiles)
        {
            // found through searching through files, takes CpuUI.Files<List> as parameter
            // select all files 
            this.existingFiles = existingFiles;
            InitializeComponent();
        }

        private void LoadFile_Form_Load(object sender, EventArgs e)
        {
            DD_files.DataSource = existingFiles;
        }

        // Retrieve File Content Button
        private void btn_Load_Click(object sender, EventArgs e)
        {
            var LoadPath = path + DD_files.Text;
            try
            {
                using (var sr = File.OpenText(LoadPath))
                {
                    ReturnedProgram = sr.ReadToEnd();
                    Trace.WriteLine($"Program taken from file is : \n{ReturnedProgram}");
                }
            }
            catch
            {
                MessageBox.Show(" File Name error ");
            }

            if (DialogResult.Yes == MessageBox.Show("This will erase your current Assembly Program",
                    $"Load {DD_files.Text} program?", MessageBoxButtons.YesNo))
            {
                Trace.WriteLine($"Program returned from file {DD_files.Text} is : \n{ReturnedProgram}");
                Close();
            }

        }
    }
}