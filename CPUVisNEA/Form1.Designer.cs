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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gb_outputs = new System.Windows.Forms.GroupBox();
            this.txt_longFDE = new System.Windows.Forms.TextBox();
            this.txt_shortFDE = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.gb_registers = new System.Windows.Forms.GroupBox();
            this.gb_Display = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnl_uCodeManip = new System.Windows.Forms.Panel();
            this.txt_uProg = new System.Windows.Forms.TextBox();
            this.gb_Execute = new System.Windows.Forms.GroupBox();
            this.btn_Compile = new System.Windows.Forms.Button();
            this.DD_Speed = new System.Windows.Forms.ComboBox();
            this.DD_Scheme = new System.Windows.Forms.ComboBox();
            this.gb_UAssControls = new System.Windows.Forms.GroupBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_UIType = new System.Windows.Forms.Button();
            this.DD_LoadProg = new System.Windows.Forms.ComboBox();
            this.gb_userInput = new System.Windows.Forms.GroupBox();
            this.gb_InpOut = new System.Windows.Forms.GroupBox();
            this.txt_out = new System.Windows.Forms.TextBox();
            this.txt_Inp = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_TEMPORARY = new System.Windows.Forms.TextBox();
            this.gb_outputs.SuspendLayout();
            this.gb_registers.SuspendLayout();
            this.gb_Display.SuspendLayout();
            this.gb_Execute.SuspendLayout();
            this.gb_UAssControls.SuspendLayout();
            this.gb_userInput.SuspendLayout();
            this.gb_InpOut.SuspendLayout();
            this.SuspendLayout();
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
            this.txt_longFDE.Text = "\r\nEntire Console Log of CPU FDE Cycle. \r\nScrollable \r\nDoesnt overwrite\r\n\r\nReadOnl" +
    "y Textbox\r\n\r\n\r\n";
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
            this.txt_shortFDE.Text = "\r\nSingle Cycle Detailed Log of current CPU FDE Cycle. \r\nScrollable \r\nwill overwri" +
    "te with each cycle \r\n\r\nReadOnly Textbox";
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
            this.gb_registers.Controls.Add(this.txt_TEMPORARY);
            this.gb_registers.Location = new System.Drawing.Point(0, 962);
            this.gb_registers.Margin = new System.Windows.Forms.Padding(6);
            this.gb_registers.Name = "gb_registers";
            this.gb_registers.Padding = new System.Windows.Forms.Padding(6);
            this.gb_registers.Size = new System.Drawing.Size(800, 267);
            this.gb_registers.TabIndex = 2;
            this.gb_registers.TabStop = false;
            this.gb_registers.Text = "Registers";
            // 
            // gb_Display
            // 
            this.gb_Display.Controls.Add(this.gb_InpOut);
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
            // pnl_uCodeManip
            // 
            this.pnl_uCodeManip.AutoSize = true;
            this.pnl_uCodeManip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_uCodeManip.Location = new System.Drawing.Point(0, 0);
            this.pnl_uCodeManip.Margin = new System.Windows.Forms.Padding(6);
            this.pnl_uCodeManip.Name = "pnl_uCodeManip";
            this.pnl_uCodeManip.Size = new System.Drawing.Size(0, 0);
            this.pnl_uCodeManip.TabIndex = 2;
            this.pnl_uCodeManip.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_uCodeManip_Paint);
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
            this.txt_uProg.Text = resources.GetString("txt_uProg.Text");
            // 
            // gb_Execute
            // 
            this.gb_Execute.AutoSize = true;
            this.gb_Execute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_Execute.Controls.Add(this.DD_Scheme);
            this.gb_Execute.Controls.Add(this.DD_Speed);
            this.gb_Execute.Controls.Add(this.btn_Compile);
            this.gb_Execute.Location = new System.Drawing.Point(0, 962);
            this.gb_Execute.Margin = new System.Windows.Forms.Padding(6);
            this.gb_Execute.Name = "gb_Execute";
            this.gb_Execute.Padding = new System.Windows.Forms.Padding(6);
            this.gb_Execute.Size = new System.Drawing.Size(766, 267);
            this.gb_Execute.TabIndex = 3;
            this.gb_Execute.TabStop = false;
            this.gb_Execute.Text = "Execution Buttons";
            // 
            // btn_Compile
            // 
            this.btn_Compile.Location = new System.Drawing.Point(24, 37);
            this.btn_Compile.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Compile.Name = "btn_Compile";
            this.btn_Compile.Size = new System.Drawing.Size(210, 104);
            this.btn_Compile.TabIndex = 4;
            this.btn_Compile.Text = "Compile Assembely Code\r\n";
            this.btn_Compile.UseVisualStyleBackColor = true;
            // 
            // DD_Speed
            // 
            this.DD_Speed.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.DD_Speed.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DD_Speed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DD_Speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DD_Speed.FormattingEnabled = true;
            this.DD_Speed.Items.AddRange(new object[] {
            "Real time execution",
            "Fast",
            "Medium",
            "Slow",
            "User Controlled Step"});
            this.DD_Speed.Location = new System.Drawing.Point(411, 47);
            this.DD_Speed.Name = "DD_Speed";
            this.DD_Speed.Size = new System.Drawing.Size(346, 59);
            this.DD_Speed.TabIndex = 6;
            this.DD_Speed.Tag = "";
            // 
            // DD_Scheme
            // 
            this.DD_Scheme.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.DD_Scheme.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DD_Scheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DD_Scheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DD_Scheme.FormattingEnabled = true;
            this.DD_Scheme.Items.AddRange(new object[] {
            "Dark Mode",
            "Light Mode",
            "Colour Blind",
            "Hacker ",
            "Custom"});
            this.DD_Scheme.Location = new System.Drawing.Point(411, 175);
            this.DD_Scheme.Name = "DD_Scheme";
            this.DD_Scheme.Size = new System.Drawing.Size(346, 59);
            this.DD_Scheme.TabIndex = 7;
            this.DD_Scheme.Tag = "";
            // 
            // gb_UAssControls
            // 
            this.gb_UAssControls.AutoSize = true;
            this.gb_UAssControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_UAssControls.Controls.Add(this.DD_LoadProg);
            this.gb_UAssControls.Controls.Add(this.btn_UIType);
            this.gb_UAssControls.Controls.Add(this.btn_Save);
            this.gb_UAssControls.Location = new System.Drawing.Point(20, 36);
            this.gb_UAssControls.Margin = new System.Windows.Forms.Padding(6);
            this.gb_UAssControls.Name = "gb_UAssControls";
            this.gb_UAssControls.Padding = new System.Windows.Forms.Padding(6);
            this.gb_UAssControls.Size = new System.Drawing.Size(737, 135);
            this.gb_UAssControls.TabIndex = 4;
            this.gb_UAssControls.TabStop = false;
            this.gb_UAssControls.Text = "File & Assembely Controls";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(320, 33);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(170, 69);
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "Save program";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // btn_UIType
            // 
            this.btn_UIType.Location = new System.Drawing.Point(518, 33);
            this.btn_UIType.Name = "btn_UIType";
            this.btn_UIType.Size = new System.Drawing.Size(210, 69);
            this.btn_UIType.TabIndex = 9;
            this.btn_UIType.Text = "Convert Program to Assembley/Binary";
            this.btn_UIType.UseVisualStyleBackColor = true;
            // 
            // DD_LoadProg
            // 
            this.DD_LoadProg.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.DD_LoadProg.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DD_LoadProg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DD_LoadProg.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DD_LoadProg.FormattingEnabled = true;
            this.DD_LoadProg.Items.AddRange(new object[] {
            "Km ",
            "We vibe ",
            "NOt again"});
            this.DD_LoadProg.Location = new System.Drawing.Point(28, 35);
            this.DD_LoadProg.Name = "DD_LoadProg";
            this.DD_LoadProg.Size = new System.Drawing.Size(278, 59);
            this.DD_LoadProg.TabIndex = 10;
            this.DD_LoadProg.Tag = "";
            // 
            // gb_userInput
            // 
            this.gb_userInput.AutoSize = true;
            this.gb_userInput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_userInput.Controls.Add(this.gb_UAssControls);
            this.gb_userInput.Controls.Add(this.gb_Execute);
            this.gb_userInput.Controls.Add(this.txt_uProg);
            this.gb_userInput.Controls.Add(this.pnl_uCodeManip);
            this.gb_userInput.Controls.Add(this.groupBox1);
            this.gb_userInput.Location = new System.Drawing.Point(0, 0);
            this.gb_userInput.Margin = new System.Windows.Forms.Padding(6);
            this.gb_userInput.Name = "gb_userInput";
            this.gb_userInput.Padding = new System.Windows.Forms.Padding(6);
            this.gb_userInput.Size = new System.Drawing.Size(2412, 1382);
            this.gb_userInput.TabIndex = 0;
            this.gb_userInput.TabStop = false;
            this.gb_userInput.Text = "User Input";
            this.gb_userInput.Enter += new System.EventHandler(this.gb_userInput_Enter);
            // 
            // gb_InpOut
            // 
            this.gb_InpOut.Controls.Add(this.txt_out);
            this.gb_InpOut.Controls.Add(this.txt_Inp);
            this.gb_InpOut.Controls.Add(this.groupBox4);
            this.gb_InpOut.Location = new System.Drawing.Point(37, 36);
            this.gb_InpOut.Margin = new System.Windows.Forms.Padding(6);
            this.gb_InpOut.Name = "gb_InpOut";
            this.gb_InpOut.Padding = new System.Windows.Forms.Padding(6);
            this.gb_InpOut.Size = new System.Drawing.Size(721, 257);
            this.gb_InpOut.TabIndex = 3;
            this.gb_InpOut.TabStop = false;
            this.gb_InpOut.Text = "CPU inputs and outputs";
            // 
            // txt_out
            // 
            this.txt_out.AllowDrop = true;
            this.txt_out.Location = new System.Drawing.Point(394, 36);
            this.txt_out.Margin = new System.Windows.Forms.Padding(6);
            this.txt_out.Multiline = true;
            this.txt_out.Name = "txt_out";
            this.txt_out.ReadOnly = true;
            this.txt_out.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_out.Size = new System.Drawing.Size(300, 200);
            this.txt_out.TabIndex = 3;
            this.txt_out.Text = "Output\r\n-----------------\r\nTextBox to record Program Outputs/Prints whilst runnin" +
    "g user program\r\n\r\n\r\n";
            // 
            // txt_Inp
            // 
            this.txt_Inp.AllowDrop = true;
            this.txt_Inp.Location = new System.Drawing.Point(27, 36);
            this.txt_Inp.Margin = new System.Windows.Forms.Padding(6);
            this.txt_Inp.Multiline = true;
            this.txt_Inp.Name = "txt_Inp";
            this.txt_Inp.ReadOnly = true;
            this.txt_Inp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Inp.Size = new System.Drawing.Size(300, 200);
            this.txt_Inp.TabIndex = 2;
            this.txt_Inp.Text = "Input\r\n-----------------\r\nTextBox to record user inputs whilst running the assemb" +
    "ely program";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(1600, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox4.Size = new System.Drawing.Size(800, 1346);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "User Input";
            // 
            // txt_TEMPORARY
            // 
            this.txt_TEMPORARY.AllowDrop = true;
            this.txt_TEMPORARY.Location = new System.Drawing.Point(22, 69);
            this.txt_TEMPORARY.Margin = new System.Windows.Forms.Padding(6);
            this.txt_TEMPORARY.Multiline = true;
            this.txt_TEMPORARY.Name = "txt_TEMPORARY";
            this.txt_TEMPORARY.ReadOnly = true;
            this.txt_TEMPORARY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_TEMPORARY.Size = new System.Drawing.Size(756, 165);
            this.txt_TEMPORARY.TabIndex = 4;
            this.txt_TEMPORARY.Text = "TEMPORARY DEMINSTRATION\r\nPC        MAR      MDR \r\nValue    Value    Value \r\n\r\nACC" +
    "      CIR        MBF\r\nValue    Value    Value \r\n";
            this.txt_TEMPORARY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gb_outputs.ResumeLayout(false);
            this.gb_outputs.PerformLayout();
            this.gb_registers.ResumeLayout(false);
            this.gb_registers.PerformLayout();
            this.gb_Display.ResumeLayout(false);
            this.gb_Execute.ResumeLayout(false);
            this.gb_UAssControls.ResumeLayout(false);
            this.gb_userInput.ResumeLayout(false);
            this.gb_userInput.PerformLayout();
            this.gb_InpOut.ResumeLayout(false);
            this.gb_InpOut.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gb_outputs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TextBox txt_longFDE;
        private System.Windows.Forms.TextBox txt_shortFDE;
        private System.Windows.Forms.GroupBox gb_registers;
        private System.Windows.Forms.TextBox txt_TEMPORARY;
        private System.Windows.Forms.GroupBox gb_Display;
        private System.Windows.Forms.GroupBox gb_InpOut;
        private System.Windows.Forms.TextBox txt_out;
        private System.Windows.Forms.TextBox txt_Inp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnl_uCodeManip;
        private System.Windows.Forms.TextBox txt_uProg;
        private System.Windows.Forms.GroupBox gb_Execute;
        public System.Windows.Forms.ComboBox DD_Scheme;
        public System.Windows.Forms.ComboBox DD_Speed;
        private System.Windows.Forms.Button btn_Compile;
        private System.Windows.Forms.GroupBox gb_UAssControls;
        public System.Windows.Forms.ComboBox DD_LoadProg;
        private System.Windows.Forms.Button btn_UIType;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox gb_userInput;
    }
}