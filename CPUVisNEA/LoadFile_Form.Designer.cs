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
            this.SuspendLayout();
            // 
            // txt_FileGetName
            // 
            this.txt_FileGetName.Location = new System.Drawing.Point(30, 141);
            this.txt_FileGetName.Margin = new System.Windows.Forms.Padding(5);
            this.txt_FileGetName.Name = "txt_FileGetName";
            this.txt_FileGetName.Size = new System.Drawing.Size(299, 46);
            this.txt_FileGetName.TabIndex = 9;
            this.txt_FileGetName.Text = "";
            // 
            // txt_Get
            // 
            this.txt_Get.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Get.Location = new System.Drawing.Point(30, 197);
            this.txt_Get.Margin = new System.Windows.Forms.Padding(5);
            this.txt_Get.Name = "txt_Get";
            this.txt_Get.Size = new System.Drawing.Size(299, 227);
            this.txt_Get.TabIndex = 8;
            this.txt_Get.Text = "";
            // 
            // btn_Load
            // 
            this.btn_Load.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Load.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Load.Location = new System.Drawing.Point(30, 14);
            this.btn_Load.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(299, 107);
            this.btn_Load.TabIndex = 7;
            this.btn_Load.Text = "Load Content \r\nFrom :\r\n";
            this.btn_Load.UseVisualStyleBackColor = false;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // LoadFile_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(367, 450);
            this.Controls.Add(this.txt_FileGetName);
            this.Controls.Add(this.txt_Get);
            this.Controls.Add(this.btn_Load);
            this.Name = "LoadFile_Form";
            this.Text = "LoadFile_Form";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.RichTextBox txt_FileGetName;
        private System.Windows.Forms.RichTextBox txt_Get;
        private System.Windows.Forms.Button btn_Load;

        #endregion
    }
}