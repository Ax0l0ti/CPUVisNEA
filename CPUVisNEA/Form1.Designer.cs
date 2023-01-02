namespace CPUVisNEA
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gb_userInput = new System.Windows.Forms.GroupBox();
            this.gb_Execute = new System.Windows.Forms.GroupBox();
            this.rb_runSpeed = new System.Windows.Forms.RadioButton();
            this.btn_Compile = new System.Windows.Forms.Button();
            this.txt_uProg = new System.Windows.Forms.TextBox();
            this.pnl_uCodeManip = new System.Windows.Forms.Panel();
            this.pnl_InpOut = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_LoadProg = new System.Windows.Forms.Button();
            this.btn_ConvertBase = new System.Windows.Forms.Button();
            this.btn_SaveProg = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gb_outputs = new System.Windows.Forms.GroupBox();
            this.txt_longFDE = new System.Windows.Forms.TextBox();
            this.txt_shortFDE = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.gb_registers = new System.Windows.Forms.GroupBox();
            this.DropDown_ = new System.Windows.Forms.ComboBox();
            this.gb_Display = new System.Windows.Forms.GroupBox();
            this.gb_userInput.SuspendLayout();
            this.gb_Execute.SuspendLayout();
            this.pnl_uCodeManip.SuspendLayout();
            this.pnl_InpOut.SuspendLayout();
            this.gb_outputs.SuspendLayout();
            this.gb_Display.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_userInput
            // 
            this.gb_userInput.Controls.Add(this.gb_Execute);
            this.gb_userInput.Controls.Add(this.txt_uProg);
            this.gb_userInput.Controls.Add(this.pnl_uCodeManip);
            this.gb_userInput.Controls.Add(this.groupBox1);
            this.gb_userInput.Location = new System.Drawing.Point(0, 0);
            this.gb_userInput.Margin = new System.Windows.Forms.Padding(6);
            this.gb_userInput.Name = "gb_userInput";
            this.gb_userInput.Padding = new System.Windows.Forms.Padding(6);
            this.gb_userInput.Size = new System.Drawing.Size(800, 1346);
            this.gb_userInput.TabIndex = 0;
            this.gb_userInput.TabStop = false;
            this.gb_userInput.Text = "User Input";
            this.gb_userInput.Enter += new System.EventHandler(this.gb_userInput_Enter);
            // 
            // gb_Execute
            // 
            this.gb_Execute.Controls.Add(this.rb_runSpeed);
            this.gb_Execute.Controls.Add(this.btn_Compile);
            this.gb_Execute.Location = new System.Drawing.Point(0, 962);
            this.gb_Execute.Margin = new System.Windows.Forms.Padding(6);
            this.gb_Execute.Name = "gb_Execute";
            this.gb_Execute.Padding = new System.Windows.Forms.Padding(6);
            this.gb_Execute.Size = new System.Drawing.Size(800, 288);
            this.gb_Execute.TabIndex = 3;
            this.gb_Execute.TabStop = false;
            this.gb_Execute.Text = "Execution Buttons";
            // 
            // rb_runSpeed
            // 
            this.rb_runSpeed.AllowDrop = true;
            this.rb_runSpeed.AutoSize = true;
            this.rb_runSpeed.BackColor = System.Drawing.Color.Navy;
            this.rb_runSpeed.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rb_runSpeed.Location = new System.Drawing.Point(520, 48);
            this.rb_runSpeed.Margin = new System.Windows.Forms.Padding(6);
            this.rb_runSpeed.Name = "rb_runSpeed";
            this.rb_runSpeed.Size = new System.Drawing.Size(150, 29);
            this.rb_runSpeed.TabIndex = 5;
            this.rb_runSpeed.TabStop = true;
            this.rb_runSpeed.Text = "Run Speed";
            this.rb_runSpeed.UseVisualStyleBackColor = false;
            // 
            // btn_Compile
            // 
            this.btn_Compile.Location = new System.Drawing.Point(24, 37);
            this.btn_Compile.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Compile.Name = "btn_Compile";
            this.btn_Compile.Size = new System.Drawing.Size(150, 44);
            this.btn_Compile.TabIndex = 4;
            this.btn_Compile.Text = "Compile";
            this.btn_Compile.UseVisualStyleBackColor = true;
            // 
            // txt_uProg
            // 
            this.txt_uProg.AcceptsTab = true;
            this.txt_uProg.AllowDrop = true;
            this.txt_uProg.Font = new System.Drawing.Font("Microsoft New Tai Lue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_uProg.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_uProg.Location = new System.Drawing.Point(0, 192);
            this.txt_uProg.Margin = new System.Windows.Forms.Padding(6);
            this.txt_uProg.Multiline = true;
            this.txt_uProg.Name = "txt_uProg";
            this.txt_uProg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_uProg.Size = new System.Drawing.Size(796, 766);
            this.txt_uProg.TabIndex = 3;
            // 
            // pnl_uCodeManip
            // 
            this.pnl_uCodeManip.Controls.Add(this.pnl_InpOut);
            this.pnl_uCodeManip.Controls.Add(this.btn_LoadProg);
            this.pnl_uCodeManip.Controls.Add(this.btn_ConvertBase);
            this.pnl_uCodeManip.Controls.Add(this.btn_SaveProg);
            this.pnl_uCodeManip.Location = new System.Drawing.Point(0, 0);
            this.pnl_uCodeManip.Margin = new System.Windows.Forms.Padding(6);
            this.pnl_uCodeManip.Name = "pnl_uCodeManip";
            this.pnl_uCodeManip.Size = new System.Drawing.Size(800, 150);
            this.pnl_uCodeManip.TabIndex = 2;
            this.pnl_uCodeManip.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_uCodeManip_Paint);
            // 
            // pnl_InpOut
            // 
            this.pnl_InpOut.Controls.Add(this.button1);
            this.pnl_InpOut.Controls.Add(this.button2);
            this.pnl_InpOut.Controls.Add(this.button3);
            this.pnl_InpOut.Location = new System.Drawing.Point(8, 8);
            this.pnl_InpOut.Margin = new System.Windows.Forms.Padding(6);
            this.pnl_InpOut.Name = "pnl_InpOut";
            this.pnl_InpOut.Size = new System.Drawing.Size(800, 150);
            this.pnl_InpOut.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.button1.Location = new System.Drawing.Point(68, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 69);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load Premade Program";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(561, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 69);
            this.button2.TabIndex = 1;
            this.button2.Text = "Convert Program to Assembley/Binary";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(363, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 69);
            this.button3.TabIndex = 0;
            this.button3.Text = "Save program";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btn_LoadProg
            // 
            this.btn_LoadProg.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.btn_LoadProg.Location = new System.Drawing.Point(68, 38);
            this.btn_LoadProg.Name = "btn_LoadProg";
            this.btn_LoadProg.Size = new System.Drawing.Size(239, 69);
            this.btn_LoadProg.TabIndex = 2;
            this.btn_LoadProg.Text = "Load Premade Program";
            this.btn_LoadProg.UseVisualStyleBackColor = true;
            // 
            // btn_ConvertBase
            // 
            this.btn_ConvertBase.Location = new System.Drawing.Point(561, 38);
            this.btn_ConvertBase.Name = "btn_ConvertBase";
            this.btn_ConvertBase.Size = new System.Drawing.Size(210, 69);
            this.btn_ConvertBase.TabIndex = 1;
            this.btn_ConvertBase.Text = "Convert Program to Assembley/Binary";
            this.btn_ConvertBase.UseVisualStyleBackColor = true;
            // 
            // btn_SaveProg
            // 
            this.btn_SaveProg.Location = new System.Drawing.Point(363, 38);
            this.btn_SaveProg.Name = "btn_SaveProg";
            this.btn_SaveProg.Size = new System.Drawing.Size(170, 69);
            this.btn_SaveProg.TabIndex = 0;
            this.btn_SaveProg.Text = "Save program";
            this.btn_SaveProg.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(1600, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(800, 1346);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Input";
            // 
            // gb_outputs
            // 
            this.gb_outputs.Controls.Add(this.txt_longFDE);
            this.gb_outputs.Controls.Add(this.txt_shortFDE);
            this.gb_outputs.Controls.Add(this.groupBox3);
            this.gb_outputs.Location = new System.Drawing.Point(1600, 0);
            this.gb_outputs.Margin = new System.Windows.Forms.Padding(6);
            this.gb_outputs.Name = "gb_outputs";
            this.gb_outputs.Padding = new System.Windows.Forms.Padding(6);
            this.gb_outputs.Size = new System.Drawing.Size(800, 1346);
            this.gb_outputs.TabIndex = 2;
            this.gb_outputs.TabStop = false;
            this.gb_outputs.Text = "Console Logs";
            // 
            // txt_longFDE
            // 
            this.txt_longFDE.AllowDrop = true;
            this.txt_longFDE.Location = new System.Drawing.Point(20, 767);
            this.txt_longFDE.Margin = new System.Windows.Forms.Padding(6);
            this.txt_longFDE.Multiline = true;
            this.txt_longFDE.Name = "txt_longFDE";
            this.txt_longFDE.ReadOnly = true;
            this.txt_longFDE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_longFDE.Size = new System.Drawing.Size(756, 381);
            this.txt_longFDE.TabIndex = 3;
            // 
            // txt_shortFDE
            // 
            this.txt_shortFDE.AllowDrop = true;
            this.txt_shortFDE.Location = new System.Drawing.Point(20, 192);
            this.txt_shortFDE.Margin = new System.Windows.Forms.Padding(6);
            this.txt_shortFDE.Multiline = true;
            this.txt_shortFDE.Name = "txt_shortFDE";
            this.txt_shortFDE.ReadOnly = true;
            this.txt_shortFDE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_shortFDE.Size = new System.Drawing.Size(756, 381);
            this.txt_shortFDE.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(1600, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(800, 1346);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User Input";
            // 
            // gb_registers
            // 
            this.gb_registers.Location = new System.Drawing.Point(0, 962);
            this.gb_registers.Margin = new System.Windows.Forms.Padding(6);
            this.gb_registers.Name = "gb_registers";
            this.gb_registers.Padding = new System.Windows.Forms.Padding(6);
            this.gb_registers.Size = new System.Drawing.Size(800, 288);
            this.gb_registers.TabIndex = 2;
            this.gb_registers.TabStop = false;
            this.gb_registers.Text = "Registers";
            // 
            // DropDown_
            // 
            this.DropDown_.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.DropDown_.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DropDown_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropDown_.DropDownWidth = 200;
            this.DropDown_.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DropDown_.FormattingEnabled = true;
            this.DropDown_.Items.AddRange(new object[] {
            "Test",
            "Testy 2"});
            this.DropDown_.Location = new System.Drawing.Point(50, 50);
            this.DropDown_.Name = "DropDown_";
            this.DropDown_.Size = new System.Drawing.Size(344, 59);
            this.DropDown_.TabIndex = 3;
            this.DropDown_.SelectedIndexChanged += new System.EventHandler(this.DropDownTest_SelectedIndexChanged);
            // 
            // gb_Display
            // 
            this.gb_Display.Controls.Add(this.DropDown_);
            this.gb_Display.Controls.Add(this.gb_registers);
            this.gb_Display.Location = new System.Drawing.Point(800, 0);
            this.gb_Display.Margin = new System.Windows.Forms.Padding(6);
            this.gb_Display.Name = "gb_Display";
            this.gb_Display.Padding = new System.Windows.Forms.Padding(6);
            this.gb_Display.Size = new System.Drawing.Size(800, 1346);
            this.gb_Display.TabIndex = 1;
            this.gb_Display.TabStop = false;
            this.gb_Display.Text = "CPU stuff";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(2368, 1271);
            this.Controls.Add(this.gb_outputs);
            this.Controls.Add(this.gb_Display);
            this.Controls.Add(this.gb_userInput);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gb_userInput.ResumeLayout(false);
            this.gb_userInput.PerformLayout();
            this.gb_Execute.ResumeLayout(false);
            this.gb_Execute.PerformLayout();
            this.pnl_uCodeManip.ResumeLayout(false);
            this.pnl_InpOut.ResumeLayout(false);
            this.gb_outputs.ResumeLayout(false);
            this.gb_outputs.PerformLayout();
            this.gb_Display.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gb_userInput;
        private System.Windows.Forms.GroupBox gb_Execute;
        private System.Windows.Forms.RadioButton rb_runSpeed;
        private System.Windows.Forms.Button btn_Compile;
        private System.Windows.Forms.TextBox txt_uProg;
        private System.Windows.Forms.Panel pnl_uCodeManip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gb_outputs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TextBox txt_longFDE;
        private System.Windows.Forms.TextBox txt_shortFDE;
        private System.Windows.Forms.Button btn_SaveProg;
        private System.Windows.Forms.Button btn_LoadProg;
        private System.Windows.Forms.Button btn_ConvertBase;
        private System.Windows.Forms.Panel pnl_InpOut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox gb_registers;
        public System.Windows.Forms.ComboBox DropDown_;
        private System.Windows.Forms.GroupBox gb_Display;
    }
}