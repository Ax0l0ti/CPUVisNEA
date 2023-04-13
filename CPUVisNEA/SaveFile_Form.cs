using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CPUVisNEA
{
    public partial class SaveFile_Form : Form
    {
        private readonly string ProgramToSave = "";
        private readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\";

        public SaveFile_Form(string Program)
        {
            InitializeComponent();
            ProgramToSave = Program;
        }

        private void SaveFile_Form_Load(object sender, EventArgs e)
        {
        }

        // Push to File Button
        // - Creates a new File 
        // - OverWrites a File
        private void btn_Push_Click(object sender, EventArgs e)
        {
            var PushPath = path + txt_FileName.Text;
            if (!File.Exists(PushPath))
            {
                // Create a file to write to.
                using (var sw = File.CreateText(PushPath))
                {
                    sw.WriteLine(ProgramToSave);
                    sw.Close();
                }

                Close();
            }
            else
            {
                // if not in list of default files, allow overwrite 
                if (!new List<string> { "EveryTest", "For100", "Labeltest", "Multiplication" }.Contains(txt_FileName
                        .Text))
                {
                    if (DialogResult.Yes == MessageBox.Show($"overwrite contents of file : {txt_FileName.Text} ?",
                            "This action is permenant", MessageBoxButtons.YesNo))
                    {
                        File.Delete(PushPath);
                        using (var sw = File.CreateText(PushPath))
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
    }
}