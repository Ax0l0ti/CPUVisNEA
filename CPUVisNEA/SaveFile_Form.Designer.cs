using System.ComponentModel;

namespace CPUVisNEA
{
    partial class SaveFile_Form
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
            this.btn_Push = new System.Windows.Forms.Button();
            this.Note = new System.Windows.Forms.TextBox();
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Push
            // 
            this.btn_Push.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Push.Location = new System.Drawing.Point(29, 26);
            this.btn_Push.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Push.Name = "btn_Push";
            this.btn_Push.Size = new System.Drawing.Size(290, 49);
            this.btn_Push.TabIndex = 7;
            this.btn_Push.Text = "Save Program\r\n";
            this.btn_Push.UseVisualStyleBackColor = true;
            this.btn_Push.Click += new System.EventHandler(this.btn_Push_Click);
            // 
            // Note
            // 
            this.Note.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Note.Location = new System.Drawing.Point(29, 83);
            this.Note.Multiline = true;
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(696, 116);
            this.Note.TabIndex = 11;
            this.Note.Text = "Note : \r\n• If a Program already has that name, it will overwrite.\r\n   • Overwriti" + "ng cannot be undone";
            // 
            // txt_FileName
            // 
            this.txt_FileName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FileName.Location = new System.Drawing.Point(334, 26);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.Size = new System.Drawing.Size(391, 48);
            this.txt_FileName.TabIndex = 12;
            this.txt_FileName.TextChanged += new System.EventHandler(this.txt_FileName_TextChanged);
            // 
            // SaveFile_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(756, 237);
            this.Controls.Add(this.txt_FileName);
            this.Controls.Add(this.Note);
            this.Controls.Add(this.btn_Push);
            this.Name = "SaveFile_Form";
            this.Text = "SaveFile_Form";
            this.Load += new System.EventHandler(this.SaveFile_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txt_FileName;
        private System.Windows.Forms.Button btn_Push;

        #endregion

        private System.Windows.Forms.TextBox Note;
    }
}