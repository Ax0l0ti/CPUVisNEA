using System;
using System.IO;
using System.Windows.Forms;

namespace CPUVisNEA
{
    public partial class LoadFile_Form : Form
    {
        public LoadFile_Form()
        {
            InitializeComponent();
            //todo make this a select list box of possible closable files
            // found through searching through files, takes CpuUI.Files<List> as parameter
            // select all files 
        }

        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\";
        // Retrieve File Content Button
        private void btn_Load_Click( object sender, EventArgs e )
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
            
            if (DialogResult.Yes == MessageBox.Show($"Do you want to load this program? ",
                    "This will erase you current Assembly Program", MessageBoxButtons.YesNo))
            {
                //todo return string
            }
            //todo return nothing
        }
        //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendtext?view=net-7.0 
    }
}