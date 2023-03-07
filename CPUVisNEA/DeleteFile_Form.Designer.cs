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
            this.btn_Delete = new System.Windows.Forms.Button();
            this.DD_DeletableFiles = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(25, 28);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(224, 49);
            this.btn_Delete.TabIndex = 8;
            this.btn_Delete.Text = "Delete File :";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_DeleteFile_Click);
            // 
            // DD_DeletableFiles
            // 
            this.DD_DeletableFiles.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DD_DeletableFiles.FormattingEnabled = true;
            this.DD_DeletableFiles.Location = new System.Drawing.Point(269, 28);
            this.DD_DeletableFiles.Name = "DD_DeletableFiles";
            this.DD_DeletableFiles.Size = new System.Drawing.Size(350, 49);
            this.DD_DeletableFiles.TabIndex = 9;
            this.DD_DeletableFiles.SelectedIndexChanged += new System.EventHandler(this.DD_DeletableFiles_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(25, 99);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(594, 110);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Note : \r\nDefault Files cannot be deleted\r\nOnly user created files can be deleted";
            // 
            // DeleteFile_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(658, 242);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DD_DeletableFiles);
            this.Controls.Add(this.btn_Delete);
            this.Name = "DeleteFile_Form";
            this.Text = "DeleteFile_Form";
            this.Load += new System.EventHandler(this.DeleteFile_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button btn_Delete;

        #endregion

        private System.Windows.Forms.ComboBox DD_DeletableFiles;
        private System.Windows.Forms.TextBox textBox1;
    }
}