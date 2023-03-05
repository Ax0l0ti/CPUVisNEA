using System.ComponentModel;

namespace CPUVisNEA
{
    partial class LoadFile_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_FileGetName = new System.Windows.Forms.RichTextBox();
            this.txt_Get = new System.Windows.Forms.RichTextBox();
            this.btn_Load = new System.Windows.Forms.Button();
            this.DD_files = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txt_FileGetName
            // 
            this.txt_FileGetName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FileGetName.Location = new System.Drawing.Point(487, 106);
            this.txt_FileGetName.Margin = new System.Windows.Forms.Padding(5);
            this.txt_FileGetName.Name = "txt_FileGetName";
            this.txt_FileGetName.Size = new System.Drawing.Size(402, 49);
            this.txt_FileGetName.TabIndex = 9;
            this.txt_FileGetName.Text = "";
            // 
            // txt_Get
            // 
            this.txt_Get.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Get.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Get.Location = new System.Drawing.Point(30, 106);
            this.txt_Get.Margin = new System.Windows.Forms.Padding(5);
            this.txt_Get.Name = "txt_Get";
            this.txt_Get.Size = new System.Drawing.Size(427, 330);
            this.txt_Get.TabIndex = 8;
            this.txt_Get.Text = "";
            // 
            // btn_Load
            // 
            this.btn_Load.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Load.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Load.Location = new System.Drawing.Point(30, 40);
            this.btn_Load.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(427, 49);
            this.btn_Load.TabIndex = 7;
            this.btn_Load.Text = "Load Selected Program : ";
            this.btn_Load.UseVisualStyleBackColor = false;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // DD_files
            // 
            this.DD_files.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DD_files.FormattingEnabled = true;
            this.DD_files.Location = new System.Drawing.Point(487, 40);
            this.DD_files.Name = "DD_files";
            this.DD_files.Size = new System.Drawing.Size(402, 49);
            this.DD_files.TabIndex = 10;
            this.DD_files.Text = "Select a Program";
            // 
            // LoadFile_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(924, 450);
            this.Controls.Add(this.DD_files);
            this.Controls.Add(this.txt_FileGetName);
            this.Controls.Add(this.txt_Get);
            this.Controls.Add(this.btn_Load);
            this.Name = "LoadFile_Form";
            this.Text = "LoadFile_Form";
            this.Load += new System.EventHandler(this.LoadFile_Form_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.RichTextBox txt_FileGetName;
        private System.Windows.Forms.RichTextBox txt_Get;
        private System.Windows.Forms.Button btn_Load;

        #endregion

        private System.Windows.Forms.ComboBox DD_files;
    }
}