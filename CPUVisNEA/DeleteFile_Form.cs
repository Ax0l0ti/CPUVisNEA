using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CPUVisNEA
{
    public partial class DeleteFile_Form : Form
    {
        private List<string> existingFiles = new List<string>();
        private readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\";

        public DeleteFile_Form(List<string> existingFiles)
        {
            InitializeComponent();
            this.existingFiles = existingFiles;
            DD_DeletableFiles.DataSource = existingFiles;
            // found through searching through files, takes CpuUI.Files<List> as parameter
            // select only user made files
        }

        private void DeleteFile_Form_Load(object sender, EventArgs e)
        {
            //Delete File Button
        }

        private void btn_DeleteFile_Click(object sender, EventArgs e)
        {
            var DeletePath = path + DD_DeletableFiles.Text;
            // if user confirms delete, delete the file and close deleteFile form
            if (DialogResult.Yes == MessageBox.Show($"Delete file : {DD_DeletableFiles.Text} ?",
                    "This action is permanent", MessageBoxButtons.YesNo))
            {
                Trace.WriteLine($"Deleted File : {DD_DeletableFiles.Text} ");
                File.Delete(DeletePath);
                Close();
            }
        }

        private void DD_DeletableFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}