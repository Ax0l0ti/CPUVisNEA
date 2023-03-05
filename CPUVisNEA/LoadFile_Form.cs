using System;
using System.Collections.Generic;
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
            string LoadPath = path + txt_FileGetName.Text;
            try
            {
                using ( StreamReader sr = File.OpenText( LoadPath ) )
                {
                    string s = "";
                    ReturnedProgram = sr.ReadToEnd();
                    txt_Get.Text = sr.ReadToEnd();
                }
            }
            catch
            {
                MessageBox.Show( " File Name error " );
            }
            
            if (DialogResult.Yes == MessageBox.Show($"Do you want to load this program? ",
                    "This will erase you current Assembly Program", MessageBoxButtons.YesNo))
            {
            }
        }
        //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendtext?view=net-7.0 
        
    }
}