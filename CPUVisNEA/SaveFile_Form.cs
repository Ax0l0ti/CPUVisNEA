using System;
using System.IO;
using System.Windows.Forms;

namespace CPUVisNEA
{
    public partial class SaveFile_Form : Form
    {
        private string ProgramToSave = "";
        public SaveFile_Form(string Program)
        {
            ProgramToSave = Program;
            InitializeComponent();
        }

        private void SaveFile_Form_Load(object sender, EventArgs e)
        {
            
        }

        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\";
        // Push to File Button
        // - Creates a new File 
        // - OverWrites a File
        private void btn_Push_Click( object sender, EventArgs e )
        {
            string PushPath = ProgramToSave;
            if ( !File.Exists( PushPath ) )
            {
                // Create a file to write to.
                using ( StreamWriter sw = File.CreateText( PushPath ) )
                {
                    sw.WriteLine(txt_Program.Text);
                    sw.Close();
                }
            }
            using ( StreamWriter sw = new StreamWriter( PushPath ) )
            {
                sw.WriteLine( txt_Program.Text );
                sw.Close();
            }
            Close();
        }
    }
}