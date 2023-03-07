
using System.Windows.Forms;

namespace CPUVisNEA
{
    partial class UI
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
            this.gb_outputs = new System.Windows.Forms.GroupBox();
            this.txt_longFDE = new System.Windows.Forms.TextBox();
            this.txt_shortFDE = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.gb_registers = new System.Windows.Forms.GroupBox();
            this.txt_TEMPORARY = new System.Windows.Forms.TextBox();
            this.gb_Display = new System.Windows.Forms.GroupBox();
            this.lbl_MemoryTest = new System.Windows.Forms.Label();
            this.MemoryTable = new System.Windows.Forms.TableLayoutPanel();
            this.gb_InpOut = new System.Windows.Forms.GroupBox();
            this.txt_out = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pnl_uCodeManip = new System.Windows.Forms.Panel();
            this.txt_uProg = new System.Windows.Forms.TextBox();
            this.gb_Execute = new System.Windows.Forms.GroupBox();
            this.btb_PlayOrPause = new System.Windows.Forms.Button();
            this.btn_ReturnToEdit = new System.Windows.Forms.Button();
            this.btn_Run = new System.Windows.Forms.Button();
            this.DD_Scheme = new System.Windows.Forms.ComboBox();
            this.btn_Compile = new System.Windows.Forms.Button();
            this.gb_UAssControls = new System.Windows.Forms.GroupBox();
            this.btn_LoadFile = new System.Windows.Forms.Button();
            this.btn_DeleteFile = new System.Windows.Forms.Button();
            this.btn_SaveFile = new System.Windows.Forms.Button();
            this.gb_userInput = new System.Windows.Forms.GroupBox();
            this.txt_CurrentFDE = new System.Windows.Forms.TextBox();
            this.RunSpeed = new System.Windows.Forms.TrackBar();
            this.gb_outputs.SuspendLayout();
            this.gb_registers.SuspendLayout();
            this.gb_Display.SuspendLayout();
            this.gb_InpOut.SuspendLayout();
            this.gb_Execute.SuspendLayout();
            this.gb_UAssControls.SuspendLayout();
            this.gb_userInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RunSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_outputs
            // 
            this.gb_outputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.gb_outputs.Controls.Add(this.txt_CurrentFDE);
            this.gb_outputs.Controls.Add(this.txt_longFDE);
            this.gb_outputs.Controls.Add(this.txt_shortFDE);
            this.gb_outputs.Controls.Add(this.groupBox3);
            this.gb_outputs.ForeColor = System.Drawing.Color.White;
            this.gb_outputs.Location = new System.Drawing.Point(1600, 0);
            this.gb_outputs.Margin = new System.Windows.Forms.Padding(6);
            this.gb_outputs.Name = "gb_outputs";
            this.gb_outputs.Padding = new System.Windows.Forms.Padding(6);
            this.gb_outputs.Size = new System.Drawing.Size(800, 1400);
            this.gb_outputs.TabIndex = 2;
            this.gb_outputs.TabStop = false;
            this.gb_outputs.Text = "Console Logs";
            // 
            // txt_longFDE
            // 
            this.txt_longFDE.AllowDrop = true;
            this.txt_longFDE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.txt_longFDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_longFDE.ForeColor = System.Drawing.Color.White;
            this.txt_longFDE.Location = new System.Drawing.Point(23, 892);
            this.txt_longFDE.Margin = new System.Windows.Forms.Padding(6);
            this.txt_longFDE.Multiline = true;
            this.txt_longFDE.Name = "txt_longFDE";
            this.txt_longFDE.ReadOnly = true;
            this.txt_longFDE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_longFDE.Size = new System.Drawing.Size(756, 381);
            this.txt_longFDE.TabIndex = 3;
            this.txt_longFDE.TextChanged += new System.EventHandler(this.txt_longFDE_TextChanged);
            // 
            // txt_shortFDE
            // 
            this.txt_shortFDE.AllowDrop = true;
            this.txt_shortFDE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.txt_shortFDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_shortFDE.ForeColor = System.Drawing.Color.White;
            this.txt_shortFDE.Location = new System.Drawing.Point(23, 499);
            this.txt_shortFDE.Margin = new System.Windows.Forms.Padding(6);
            this.txt_shortFDE.Multiline = true;
            this.txt_shortFDE.Name = "txt_shortFDE";
            this.txt_shortFDE.ReadOnly = true;
            this.txt_shortFDE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_shortFDE.Size = new System.Drawing.Size(756, 381);
            this.txt_shortFDE.TabIndex = 2;
            this.txt_shortFDE.TextChanged += new System.EventHandler(this.txt_shortFDE_TextChanged);
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
            // 
            // gb_registers
            // 
            this.gb_registers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(84)))), ((int)(((byte)(151)))));
            this.gb_registers.Controls.Add(this.txt_TEMPORARY);
            this.gb_registers.ForeColor = System.Drawing.Color.White;
            this.gb_registers.Location = new System.Drawing.Point(12, 1008);
            this.gb_registers.Margin = new System.Windows.Forms.Padding(6);
            this.gb_registers.Name = "gb_registers";
            this.gb_registers.Padding = new System.Windows.Forms.Padding(6);
            this.gb_registers.Size = new System.Drawing.Size(776, 267);
            this.gb_registers.TabIndex = 2;
            this.gb_registers.TabStop = false;
            this.gb_registers.Text = "Registers";
            // 
            // txt_TEMPORARY
            // 
            this.txt_TEMPORARY.AllowDrop = true;
            this.txt_TEMPORARY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.txt_TEMPORARY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TEMPORARY.ForeColor = System.Drawing.Color.White;
            this.txt_TEMPORARY.Location = new System.Drawing.Point(22, 69);
            this.txt_TEMPORARY.Margin = new System.Windows.Forms.Padding(6);
            this.txt_TEMPORARY.Multiline = true;
            this.txt_TEMPORARY.Name = "txt_TEMPORARY";
            this.txt_TEMPORARY.ReadOnly = true;
            this.txt_TEMPORARY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_TEMPORARY.Size = new System.Drawing.Size(682, 165);
            this.txt_TEMPORARY.TabIndex = 4;
            this.txt_TEMPORARY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gb_Display
            // 
            this.gb_Display.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.gb_Display.Controls.Add(this.lbl_MemoryTest);
            this.gb_Display.Controls.Add(this.MemoryTable);
            this.gb_Display.Controls.Add(this.gb_InpOut);
            this.gb_Display.Controls.Add(this.gb_registers);
            this.gb_Display.ForeColor = System.Drawing.Color.White;
            this.gb_Display.Location = new System.Drawing.Point(800, 0);
            this.gb_Display.Margin = new System.Windows.Forms.Padding(6);
            this.gb_Display.Name = "gb_Display";
            this.gb_Display.Padding = new System.Windows.Forms.Padding(6);
            this.gb_Display.Size = new System.Drawing.Size(800, 1400);
            this.gb_Display.TabIndex = 1;
            this.gb_Display.TabStop = false;
            this.gb_Display.Text = "CPU stuff";
            // 
            // lbl_MemoryTest
            // 
            this.lbl_MemoryTest.AutoSize = true;
            this.lbl_MemoryTest.Location = new System.Drawing.Point(106, 300);
            this.lbl_MemoryTest.Name = "lbl_MemoryTest";
            this.lbl_MemoryTest.Size = new System.Drawing.Size(89, 25);
            this.lbl_MemoryTest.TabIndex = 5;
            this.lbl_MemoryTest.Text = "Memory";
            // 
            // MemoryTable
            // 
            this.MemoryTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.MemoryTable.ColumnCount = 10;
            this.MemoryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemoryTable.Location = new System.Drawing.Point(26, 328);
            this.MemoryTable.Name = "MemoryTable";
            this.MemoryTable.RowCount = 10;
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.Size = new System.Drawing.Size(732, 671);
            this.MemoryTable.TabIndex = 4;
            this.MemoryTable.Paint += new System.Windows.Forms.PaintEventHandler(this.MemoryTable_Paint);
            // 
            // gb_InpOut
            // 
            this.gb_InpOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(84)))), ((int)(((byte)(151)))));
            this.gb_InpOut.Controls.Add(this.txt_out);
            this.gb_InpOut.Controls.Add(this.groupBox4);
            this.gb_InpOut.ForeColor = System.Drawing.Color.White;
            this.gb_InpOut.Location = new System.Drawing.Point(37, 36);
            this.gb_InpOut.Margin = new System.Windows.Forms.Padding(6);
            this.gb_InpOut.Name = "gb_InpOut";
            this.gb_InpOut.Padding = new System.Windows.Forms.Padding(6);
            this.gb_InpOut.Size = new System.Drawing.Size(721, 257);
            this.gb_InpOut.TabIndex = 3;
            this.gb_InpOut.TabStop = false;
            // 
            // txt_out
            // 
            this.txt_out.AllowDrop = true;
            this.txt_out.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.txt_out.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_out.ForeColor = System.Drawing.Color.White;
            this.txt_out.Location = new System.Drawing.Point(29, 36);
            this.txt_out.Margin = new System.Windows.Forms.Padding(6);
            this.txt_out.Multiline = true;
            this.txt_out.Name = "txt_out";
            this.txt_out.ReadOnly = true;
            this.txt_out.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_out.Size = new System.Drawing.Size(167, 200);
            this.txt_out.TabIndex = 3;
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
            this.txt_uProg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txt_uProg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_uProg.Font = new System.Drawing.Font("Microsoft New Tai Lue", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_uProg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_uProg.Location = new System.Drawing.Point(78, 205);
            this.txt_uProg.Margin = new System.Windows.Forms.Padding(0);
            this.txt_uProg.Multiline = true;
            this.txt_uProg.Name = "txt_uProg";
            this.txt_uProg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_uProg.Size = new System.Drawing.Size(678, 766);
            this.txt_uProg.TabIndex = 3;
            this.txt_uProg.Text = "B Test\r\nMOV R0, #10\r\nOUT R0\r\nTest: MOV R0, #69\r\nOUT R0\r\nHALT";
            this.txt_uProg.TextChanged += new System.EventHandler(this.txt_uProg_TextChanged);
            // 
            // gb_Execute
            // 
            this.gb_Execute.AutoSize = true;
            this.gb_Execute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_Execute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(84)))), ((int)(((byte)(151)))));
            this.gb_Execute.Controls.Add(this.RunSpeed);
            this.gb_Execute.Controls.Add(this.btb_PlayOrPause);
            this.gb_Execute.Controls.Add(this.btn_ReturnToEdit);
            this.gb_Execute.Controls.Add(this.btn_Run);
            this.gb_Execute.Controls.Add(this.DD_Scheme);
            this.gb_Execute.Controls.Add(this.btn_Compile);
            this.gb_Execute.ForeColor = System.Drawing.Color.White;
            this.gb_Execute.Location = new System.Drawing.Point(20, 1054);
            this.gb_Execute.Margin = new System.Windows.Forms.Padding(6);
            this.gb_Execute.Name = "gb_Execute";
            this.gb_Execute.Padding = new System.Windows.Forms.Padding(6);
            this.gb_Execute.Size = new System.Drawing.Size(746, 244);
            this.gb_Execute.TabIndex = 3;
            this.gb_Execute.TabStop = false;
            this.gb_Execute.Text = "Execution Buttons";
            // 
            // btb_PlayOrPause
            // 
            this.btb_PlayOrPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btb_PlayOrPause.ForeColor = System.Drawing.Color.White;
            this.btb_PlayOrPause.Location = new System.Drawing.Point(318, 32);
            this.btb_PlayOrPause.Margin = new System.Windows.Forms.Padding(6);
            this.btb_PlayOrPause.Name = "btb_PlayOrPause";
            this.btb_PlayOrPause.Size = new System.Drawing.Size(52, 59);
            this.btb_PlayOrPause.TabIndex = 10;
            this.btb_PlayOrPause.UseVisualStyleBackColor = false;
            this.btb_PlayOrPause.Visible = false;
            // 
            // btn_ReturnToEdit
            // 
            this.btn_ReturnToEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_ReturnToEdit.ForeColor = System.Drawing.Color.White;
            this.btn_ReturnToEdit.Location = new System.Drawing.Point(12, 121);
            this.btn_ReturnToEdit.Margin = new System.Windows.Forms.Padding(6);
            this.btn_ReturnToEdit.Name = "btn_ReturnToEdit";
            this.btn_ReturnToEdit.Size = new System.Drawing.Size(178, 82);
            this.btn_ReturnToEdit.TabIndex = 9;
            this.btn_ReturnToEdit.Text = "Return to Edit (Cancel Run ) ";
            this.btn_ReturnToEdit.UseVisualStyleBackColor = false;
            this.btn_ReturnToEdit.Visible = false;
            this.btn_ReturnToEdit.Click += new System.EventHandler(this.btn_ReturnToEdit_Click);
            // 
            // btn_Run
            // 
            this.btn_Run.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_Run.ForeColor = System.Drawing.Color.White;
            this.btn_Run.Location = new System.Drawing.Point(12, 32);
            this.btn_Run.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(178, 77);
            this.btn_Run.TabIndex = 8;
            this.btn_Run.Text = "Run Program\r\n\r\n";
            this.btn_Run.UseVisualStyleBackColor = false;
            this.btn_Run.Visible = false;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
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
            this.DD_Scheme.Location = new System.Drawing.Point(391, 23);
            this.DD_Scheme.Name = "DD_Scheme";
            this.DD_Scheme.Size = new System.Drawing.Size(346, 59);
            this.DD_Scheme.TabIndex = 7;
            this.DD_Scheme.Tag = "";
            // 
            // btn_Compile
            // 
            this.btn_Compile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_Compile.ForeColor = System.Drawing.Color.White;
            this.btn_Compile.Location = new System.Drawing.Point(96, 55);
            this.btn_Compile.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Compile.Name = "btn_Compile";
            this.btn_Compile.Size = new System.Drawing.Size(210, 104);
            this.btn_Compile.TabIndex = 4;
            this.btn_Compile.Text = "Compile Assembely Code\r\n";
            this.btn_Compile.UseVisualStyleBackColor = false;
            this.btn_Compile.Click += new System.EventHandler(this.btn_Compile_Click);
            // 
            // gb_UAssControls
            // 
            this.gb_UAssControls.AutoSize = true;
            this.gb_UAssControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_UAssControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(84)))), ((int)(((byte)(151)))));
            this.gb_UAssControls.Controls.Add(this.btn_LoadFile);
            this.gb_UAssControls.Controls.Add(this.btn_DeleteFile);
            this.gb_UAssControls.Controls.Add(this.btn_SaveFile);
            this.gb_UAssControls.ForeColor = System.Drawing.Color.White;
            this.gb_UAssControls.Location = new System.Drawing.Point(12, 36);
            this.gb_UAssControls.Margin = new System.Windows.Forms.Padding(6);
            this.gb_UAssControls.Name = "gb_UAssControls";
            this.gb_UAssControls.Padding = new System.Windows.Forms.Padding(6);
            this.gb_UAssControls.Size = new System.Drawing.Size(766, 139);
            this.gb_UAssControls.TabIndex = 4;
            this.gb_UAssControls.TabStop = false;
            this.gb_UAssControls.Text = "File & Assembely Controls";
            // 
            // btn_LoadFile
            // 
            this.btn_LoadFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_LoadFile.ForeColor = System.Drawing.Color.White;
            this.btn_LoadFile.Location = new System.Drawing.Point(268, 36);
            this.btn_LoadFile.Name = "btn_LoadFile";
            this.btn_LoadFile.Size = new System.Drawing.Size(230, 70);
            this.btn_LoadFile.TabIndex = 12;
            this.btn_LoadFile.Text = "Load Program ";
            this.btn_LoadFile.UseVisualStyleBackColor = false;
            this.btn_LoadFile.Click += new System.EventHandler(this.btn_LoadFile_Click);
            // 
            // btn_DeleteFile
            // 
            this.btn_DeleteFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_DeleteFile.ForeColor = System.Drawing.Color.White;
            this.btn_DeleteFile.Location = new System.Drawing.Point(527, 36);
            this.btn_DeleteFile.Name = "btn_DeleteFile";
            this.btn_DeleteFile.Size = new System.Drawing.Size(230, 70);
            this.btn_DeleteFile.TabIndex = 11;
            this.btn_DeleteFile.Text = "Delete Existing Program";
            this.btn_DeleteFile.UseVisualStyleBackColor = false;
            this.btn_DeleteFile.Click += new System.EventHandler(this.btn_DeleteFile_Click);
            // 
            // btn_SaveFile
            // 
            this.btn_SaveFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_SaveFile.ForeColor = System.Drawing.Color.White;
            this.btn_SaveFile.Location = new System.Drawing.Point(12, 36);
            this.btn_SaveFile.Name = "btn_SaveFile";
            this.btn_SaveFile.Size = new System.Drawing.Size(230, 70);
            this.btn_SaveFile.TabIndex = 8;
            this.btn_SaveFile.Text = "Save Program";
            this.btn_SaveFile.UseVisualStyleBackColor = false;
            this.btn_SaveFile.Click += new System.EventHandler(this.btn_SaveFile_Click);
            // 
            // gb_userInput
            // 
            this.gb_userInput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_userInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.gb_userInput.Controls.Add(this.gb_UAssControls);
            this.gb_userInput.Controls.Add(this.gb_Execute);
            this.gb_userInput.Controls.Add(this.txt_uProg);
            this.gb_userInput.Controls.Add(this.pnl_uCodeManip);
            this.gb_userInput.ForeColor = System.Drawing.Color.White;
            this.gb_userInput.Location = new System.Drawing.Point(0, 0);
            this.gb_userInput.Margin = new System.Windows.Forms.Padding(6);
            this.gb_userInput.Name = "gb_userInput";
            this.gb_userInput.Padding = new System.Windows.Forms.Padding(6);
            this.gb_userInput.Size = new System.Drawing.Size(800, 1400);
            this.gb_userInput.TabIndex = 0;
            this.gb_userInput.TabStop = false;
            this.gb_userInput.Text = "User Input";
            this.gb_userInput.Enter += new System.EventHandler(this.gb_userInput_Enter);
            // 
            // txt_CurrentFDE
            // 
            this.txt_CurrentFDE.AllowDrop = true;
            this.txt_CurrentFDE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.txt_CurrentFDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CurrentFDE.ForeColor = System.Drawing.Color.White;
            this.txt_CurrentFDE.Location = new System.Drawing.Point(23, 167);
            this.txt_CurrentFDE.Margin = new System.Windows.Forms.Padding(6);
            this.txt_CurrentFDE.Multiline = true;
            this.txt_CurrentFDE.Name = "txt_CurrentFDE";
            this.txt_CurrentFDE.ReadOnly = true;
            this.txt_CurrentFDE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_CurrentFDE.Size = new System.Drawing.Size(756, 320);
            this.txt_CurrentFDE.TabIndex = 4;
            // 
            // RunSpeed
            // 
            this.RunSpeed.Location = new System.Drawing.Point(318, 121);
            this.RunSpeed.Name = "RunSpeed";
            this.RunSpeed.Size = new System.Drawing.Size(419, 90);
            this.RunSpeed.TabIndex = 11;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(2424, 1329);
            this.Controls.Add(this.gb_userInput);
            this.Controls.Add(this.gb_outputs);
            this.Controls.Add(this.gb_Display);
            this.HelpButton = true;
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(2450, 1400);
            this.Name = "UI";
            this.Padding = new System.Windows.Forms.Padding(20, 5, 5, 5);
            this.Load += new System.EventHandler(this.UI_Load);
            this.gb_outputs.ResumeLayout(false);
            this.gb_outputs.PerformLayout();
            this.gb_registers.ResumeLayout(false);
            this.gb_registers.PerformLayout();
            this.gb_Display.ResumeLayout(false);
            this.gb_Display.PerformLayout();
            this.gb_InpOut.ResumeLayout(false);
            this.gb_InpOut.PerformLayout();
            this.gb_Execute.ResumeLayout(false);
            this.gb_Execute.PerformLayout();
            this.gb_UAssControls.ResumeLayout(false);
            this.gb_userInput.ResumeLayout(false);
            this.gb_userInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RunSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btn_LoadFile;

        private System.Windows.Forms.Button btn_DeleteFile;

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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel pnl_uCodeManip;
        private System.Windows.Forms.TextBox txt_uProg;
        private System.Windows.Forms.GroupBox gb_Execute;
        public System.Windows.Forms.ComboBox DD_Scheme;
        private System.Windows.Forms.Button btn_Compile;
        private System.Windows.Forms.GroupBox gb_UAssControls;
        private System.Windows.Forms.Button btn_SaveFile;
        private System.Windows.Forms.GroupBox gb_userInput;
        private System.Windows.Forms.Button btn_ReturnToEdit;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Button btb_PlayOrPause;
        private System.Windows.Forms.TableLayoutPanel MemoryTable;
        private System.Windows.Forms.Label lbl_MemoryTest;
        private TextBox txt_CurrentFDE;
        private TrackBar RunSpeed;
    }
    
    
    
    
    
    
}