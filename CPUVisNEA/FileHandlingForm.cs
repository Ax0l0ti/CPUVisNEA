using System;
using System.IO;
using System.Windows.Forms;

namespace CPUVisNEA
{
    public partial class FileHandlingForm : Form
    {
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\";
        
        public FileHandlingForm()
        {
            InitializeComponent();
        }

        private void frmLocalDriveAccess_Load( object sender, EventArgs e )
        {
            string sAppPath = Environment.GetFolderPath( Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\" ;
            path = sAppPath ;
        }
        //Delete File Button
        private void btn_Delete_Click( object sender, EventArgs e )
        {
            string DeletePath = path + txt_DeleteFileName.Text;
            File.Delete( DeletePath );
        }
        
        // Push to File Button
        // - Creates a new File 
        // - OverWrites a File
        private void btn_Push_Click( object sender, EventArgs e )
        {
            string PushPath = path + txt_FilePushTo.Text;
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

        }
        // Retrieve File Content Button
        private void btn_Get_Click( object sender, EventArgs e )
        {
            string LoadPath = path + txt_FileGetName.Text;
            try
            {
                using ( StreamReader sr = File.OpenText( LoadPath ) )
                {
                    string s = "";
                    while ( (s = sr.ReadLine()) != null )
                    {
                        txt_Get.Text += s;
                    }
                }
            }
            catch
            {
                MessageBox.Show( " File Name error " );
            }
            
        }
        //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendtext?view=net-7.0 
    }
}