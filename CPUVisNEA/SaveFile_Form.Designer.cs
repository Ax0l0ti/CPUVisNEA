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
            this.txt_FilePushTo = new System.Windows.Forms.RichTextBox();
            this.btn_Push = new System.Windows.Forms.Button();
            this.txt_Program = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txt_FilePushTo
            // 
            this.txt_FilePushTo.Location = new System.Drawing.Point(41, 338);
            this.txt_FilePushTo.Margin = new System.Windows.Forms.Padding(5);
            this.txt_FilePushTo.Name = "txt_FilePushTo";
            this.txt_FilePushTo.Size = new System.Drawing.Size(181, 46);
            this.txt_FilePushTo.TabIndex = 8;
            this.txt_FilePushTo.Text = "";
            // 
            // btn_Push
            // 
            this.btn_Push.Location = new System.Drawing.Point(41, 289);
            this.btn_Push.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Push.Name = "btn_Push";
            this.btn_Push.Size = new System.Drawing.Size(183, 38);
            this.btn_Push.TabIndex = 7;
            this.btn_Push.Text = "Push to File : ";
            this.btn_Push.UseVisualStyleBackColor = true;
            this.btn_Push.Click += new System.EventHandler(this.btn_Push_Click);
            // 
            // txt_Program
            // 
            this.txt_Program.Location = new System.Drawing.Point(41, 49);
            this.txt_Program.Margin = new System.Windows.Forms.Padding(5);
            this.txt_Program.Name = "txt_Program";
            this.txt_Program.Size = new System.Drawing.Size(181, 227);
            this.txt_Program.TabIndex = 6;
            this.txt_Program.Text = "";
            // 
            // SaveFile_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(271, 450);
            this.Controls.Add(this.txt_FilePushTo);
            this.Controls.Add(this.btn_Push);
            this.Controls.Add(this.txt_Program);
            this.Name = "SaveFile_Form";
            this.Text = "SaveFile_Form";
            this.Load += new System.EventHandler(this.SaveFile_Form_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.RichTextBox txt_FilePushTo;
        private System.Windows.Forms.Button btn_Push;
        private System.Windows.Forms.RichTextBox txt_Program;

        #endregion
    }
}