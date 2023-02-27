using System.ComponentModel;
using System.Windows.Forms;

namespace CPUVisNEA
{ 
    partial class FileHandlingForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_Program = new System.Windows.Forms.RichTextBox();
            this.btn_Push = new System.Windows.Forms.Button();
            this.btn_Get = new System.Windows.Forms.Button();
            this.btn_DeleteFile = new System.Windows.Forms.Button();
            this.txt_Get = new System.Windows.Forms.RichTextBox();
            this.txt_FilePushTo = new System.Windows.Forms.RichTextBox();
            this.txt_FileGetName = new System.Windows.Forms.RichTextBox();
            this.txt_DeleteFileName = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txt_Program
            // 
            this.txt_Program.Location = new System.Drawing.Point(192, 143);
            this.txt_Program.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txt_Program.Name = "txt_Program";
            this.txt_Program.Size = new System.Drawing.Size(181, 227);
            this.txt_Program.TabIndex = 0;
            this.txt_Program.Text = "";
            // 
            // btn_Push
            // 
            this.btn_Push.Location = new System.Drawing.Point(192, 383);
            this.btn_Push.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btn_Push.Name = "btn_Push";
            this.btn_Push.Size = new System.Drawing.Size(183, 38);
            this.btn_Push.TabIndex = 1;
            this.btn_Push.Text = "Push to File : ";
            this.btn_Push.UseVisualStyleBackColor = true;
            this.btn_Push.Click += new System.EventHandler(this.btn_Push_Click);
            // 
            // btn_Get
            // 
            this.btn_Get.Location = new System.Drawing.Point(386, 202);
            this.btn_Get.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(192, 38);
            this.btn_Get.TabIndex = 2;
            this.btn_Get.Text = "Get File Content : ";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.Click += new System.EventHandler(this.btn_Get_Click);
            // 
            // btn_DeleteFile
            // 
            this.btn_DeleteFile.Location = new System.Drawing.Point(588, 202);
            this.btn_DeleteFile.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btn_DeleteFile.Name = "btn_DeleteFile";
            this.btn_DeleteFile.Size = new System.Drawing.Size(192, 38);
            this.btn_DeleteFile.TabIndex = 3;
            this.btn_DeleteFile.Text = "Delete File :";
            this.btn_DeleteFile.UseVisualStyleBackColor = true;
            this.btn_DeleteFile.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_Get
            // 
            this.txt_Get.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Get.Location = new System.Drawing.Point(386, 250);
            this.txt_Get.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txt_Get.Name = "txt_Get";
            this.txt_Get.Size = new System.Drawing.Size(189, 227);
            this.txt_Get.TabIndex = 4;
            this.txt_Get.Text = "";
            // 
            // txt_FilePushTo
            // 
            this.txt_FilePushTo.Location = new System.Drawing.Point(192, 432);
            this.txt_FilePushTo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txt_FilePushTo.Name = "txt_FilePushTo";
            this.txt_FilePushTo.Size = new System.Drawing.Size(181, 46);
            this.txt_FilePushTo.TabIndex = 5;
            this.txt_FilePushTo.Text = "";
            // 
            // txt_FileGetName
            // 
            this.txt_FileGetName.Location = new System.Drawing.Point(386, 143);
            this.txt_FileGetName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txt_FileGetName.Name = "txt_FileGetName";
            this.txt_FileGetName.Size = new System.Drawing.Size(189, 46);
            this.txt_FileGetName.TabIndex = 6;
            this.txt_FileGetName.Text = "";
            // 
            // txt_DeleteFileName
            // 
            this.txt_DeleteFileName.Location = new System.Drawing.Point(588, 143);
            this.txt_DeleteFileName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txt_DeleteFileName.Name = "txt_DeleteFileName";
            this.txt_DeleteFileName.Size = new System.Drawing.Size(189, 46);
            this.txt_DeleteFileName.TabIndex = 7;
            this.txt_DeleteFileName.Text = "";
            // 
            // FileHandlingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 750);
            this.Controls.Add(this.txt_DeleteFileName);
            this.Controls.Add(this.txt_FileGetName);
            this.Controls.Add(this.txt_FilePushTo);
            this.Controls.Add(this.txt_Get);
            this.Controls.Add(this.btn_DeleteFile);
            this.Controls.Add(this.btn_Get);
            this.Controls.Add(this.btn_Push);
            this.Controls.Add(this.txt_Program);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "FileHandlingForm";
            this.Text = "LocalDriveAccess";
            this.Load += new System.EventHandler(this.frmLocalDriveAccess_Load);
            this.ResumeLayout(false);
        }

        #endregion
        private RichTextBox txt_Program;
        private Button btn_Push;
        private Button btn_Get;
        private Button btn_DeleteFile;
        private RichTextBox txt_Get;
        private RichTextBox txt_FilePushTo;
        private RichTextBox txt_FileGetName;
        private RichTextBox txt_DeleteFileName;
    }
}