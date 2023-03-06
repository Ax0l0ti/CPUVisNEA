using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CPUVisNEA
{
    public partial class LoadFile_Form : Form
    {
        private List<string> existingFiles = new List<string>();
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\";
        public string ReturnedProgram = "";

        public LoadFile_Form(  List<string> existingFiles  )
        {
            this.existingFiles= existingFiles;
            InitializeComponent();
            //todo make this a select list box of possible closable files
            // found through searching through files, takes CpuUI.Files<List> as parameter
            // select all files 
        }
        private void LoadFile_Form_Load(object sender, EventArgs e)
        {
            DD_files.DataSource = existingFiles;
            
        }

        // Retrieve File Content Button
        private void btn_Load_Click( object sender, EventArgs e )
        {
            string LoadPath = path + DD_files.Text;
            try
            {
                using ( StreamReader sr = File.OpenText( LoadPath ) )
                {
                    ReturnedProgram = sr.ReadToEnd();
                    Trace.WriteLine($"Program taken from file is : \n{ReturnedProgram}");
                }
            }
            catch
            {
                MessageBox.Show( " File Name error " );
            }
            
            if (DialogResult.Yes == MessageBox.Show("This will erase you current Assembly Program",
                    $"Load {DD_files.Text} program?" , MessageBoxButtons.YesNo))
            {
                Close();
            }
        }
        //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendtext?view=net-7.0
    }
}