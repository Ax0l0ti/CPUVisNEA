using System;
using System.IO;
using System.Windows.Forms;

namespace CPUVisNEA
{
    public partial class FileHandlingForm : Form
    {
        private string path = "";
        
        public FileHandlingForm()
        {
            InitializeComponent();
        }

        private void frmLocalDriveAccess_Load( object sender, EventArgs e )
        {
            string sAppPath = Environment.GetFolderPath( Environment.SpecialFolder.Personal);
            path = sAppPath + "\\NEA\\";
        }

        private void button3_Click( object sender, EventArgs e )
        {
            File.Delete( path );
        }

        private void btn_Push_Click( object sender, EventArgs e )
        {
            path = path + txt_FilePushTo.Text;
            if ( !File.Exists( path ) )
            {
                // Create a file to write to.
                using ( StreamWriter sw = File.CreateText( path ) )
                {
                    sw.WriteLine(txt_Program.Text);
                    sw.Close();
                }
            }
            using ( StreamWriter sw = new StreamWriter( path ) )
            {
                sw.WriteLine( txt_Program.Text );
                sw.Close();
            }

        }

        private void btn_Get_Click( object sender, EventArgs e )
        {
            try
            {
                using ( StreamReader sr = File.OpenText( path ) )
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