using System;
using System.IO;
using System.Windows.Forms;

namespace CPUVisNEA
{


    public partial class DeleteFile_Form : Form
    {
        public DeleteFile_Form()
        {
            InitializeComponent();
            
            //todo make this a select list box of possible closable files
            // found through searching through files, takes CpuUI.Files<List> as parameter
            // select only user made files
        }

        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\";
        //Delete File Button
        private void btn_DeleteFile_Click( object sender, EventArgs e )
        {

            string DeletePath = path + txt_DeleteFileName.Text;
            // if user confirms delete, delete the file and close deleteFile form
            if (DialogResult.Yes == MessageBox.Show($"Delete file : {txt_DeleteFileName.Text} ?",
                    "This action is permenant", MessageBoxButtons.YesNo))
            {
                File.Delete( DeletePath );
                Close();
            }
        }
    }
}