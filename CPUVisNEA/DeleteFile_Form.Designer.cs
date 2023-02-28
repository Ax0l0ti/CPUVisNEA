using System.ComponentModel;

namespace CPUVisNEA
{
    partial class DeleteFile_Form
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
            this.txt_DeleteFileName = new System.Windows.Forms.RichTextBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_DeleteFileName
            // 
            this.txt_DeleteFileName.Location = new System.Drawing.Point(108, 117);
            this.txt_DeleteFileName.Margin = new System.Windows.Forms.Padding(5);
            this.txt_DeleteFileName.Name = "txt_DeleteFileName";
            this.txt_DeleteFileName.Size = new System.Drawing.Size(189, 72);
            this.txt_DeleteFileName.TabIndex = 9;
            this.txt_DeleteFileName.Text = "";
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(105, 33);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(192, 58);
            this.btn_Delete.TabIndex = 8;
            this.btn_Delete.Text = "Delete File :";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_DeleteFile_Click);
            // 
            // DeleteFile_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(404, 320);
            this.Controls.Add(this.txt_DeleteFileName);
            this.Controls.Add(this.btn_Delete);
            this.Name = "DeleteFile_Form";
            this.Text = "DeleteFile_Form";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.RichTextBox txt_DeleteFileName;
        private System.Windows.Forms.Button btn_Delete;

        #endregion
    }
}