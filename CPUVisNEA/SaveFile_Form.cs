using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CPUVisNEA
{
    public partial class SaveFile_Form : Form
    {
        private string ProgramToSave = "";
        private List<string> existingFiles = new List<string>();
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\";
        public SaveFile_Form( string Program, List<string> existingFiles )
        {

            InitializeComponent();
            ProgramToSave = Program;
            this.existingFiles= existingFiles;
        }

        private void SaveFile_Form_Load(object sender, EventArgs e)
        {
        }
        // Push to File Button
        // - Creates a new File 
        // - OverWrites a File
        private void btn_Push_Click( object sender, EventArgs e )
        {
            string PushPath = path + txt_FileName.Text;
            if ( !File.Exists( PushPath ) )
            {
                // Create a file to write to.
                using ( StreamWriter sw = File.CreateText( PushPath ) )
                {
                    sw.WriteLine(ProgramToSave);
                    sw.Close();

                }
                Close();
            }
            else
            {
                // if not in list of default files, allow overwrite 
                if(  !( new List<string>(){ "succ", "admin" } ).Contains(txt_FileName.Text)  )
                {
                    if (DialogResult.Yes == MessageBox.Show($"overwrite contents of file : {txt_FileName.Text} ?",
                            "This action is permenant", MessageBoxButtons.YesNo))
                    {
                        
                        File.Delete(PushPath);
                        using (StreamWriter sw = File.CreateText( PushPath ) )
                        {
                            sw.WriteLine(ProgramToSave);
                            sw.Close();

                        }
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show($" the file name {txt_FileName.Text} is taken by a default file. Please try a new name");
                }
                
            }
            
        }

        private void txt_FileName_TextChanged(object sender, EventArgs e)
        {
        }
    }
}