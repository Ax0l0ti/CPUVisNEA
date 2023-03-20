
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gb_outputs = new System.Windows.Forms.GroupBox();
            this.txt_longFDE = new System.Windows.Forms.TextBox();
            this.txt_shortFDE = new System.Windows.Forms.TextBox();
            this.gb_InpOut = new System.Windows.Forms.GroupBox();
            this.txt_out = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.gb_registers = new System.Windows.Forms.GroupBox();
            this.BasicRegTable = new System.Windows.Forms.TableLayoutPanel();
            this.SPRTable = new System.Windows.Forms.TableLayoutPanel();
            this.gb_Display = new System.Windows.Forms.GroupBox();
            this.btn_MachineHuman = new System.Windows.Forms.Button();
            this.lbl_MemoryTest = new System.Windows.Forms.Label();
            this.MemoryTable = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_uCodeManip = new System.Windows.Forms.Panel();
            this.txt_uProg = new System.Windows.Forms.TextBox();
            this.gb_Execute = new System.Windows.Forms.GroupBox();
            this.btn_pause = new System.Windows.Forms.Button();
            this.RunSpeed = new System.Windows.Forms.TrackBar();
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_ReturnToEdit = new System.Windows.Forms.Button();
            this.btn_Run = new System.Windows.Forms.Button();
            this.btn_Compile = new System.Windows.Forms.Button();
            this.gb_UAssControls = new System.Windows.Forms.GroupBox();
            this.btn_LoadFile = new System.Windows.Forms.Button();
            this.btn_DeleteFile = new System.Windows.Forms.Button();
            this.btn_SaveFile = new System.Windows.Forms.Button();
            this.gb_userInput = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gb_outputs.SuspendLayout();
            this.gb_InpOut.SuspendLayout();
            this.gb_registers.SuspendLayout();
            this.gb_Display.SuspendLayout();
            this.gb_Execute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RunSpeed)).BeginInit();
            this.gb_UAssControls.SuspendLayout();
            this.gb_userInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_outputs
            // 
            this.gb_outputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.gb_outputs.Controls.Add(this.txt_longFDE);
            this.gb_outputs.Controls.Add(this.txt_shortFDE);
            this.gb_outputs.Controls.Add(this.gb_InpOut);
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
            // 
            // gb_InpOut
            // 
            this.gb_InpOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(84)))), ((int)(((byte)(151)))));
            this.gb_InpOut.Controls.Add(this.txt_out);
            this.gb_InpOut.Controls.Add(this.groupBox4);
            this.gb_InpOut.ForeColor = System.Drawing.Color.White;
            this.gb_InpOut.Location = new System.Drawing.Point(23, 36);
            this.gb_InpOut.Margin = new System.Windows.Forms.Padding(6);
            this.gb_InpOut.Name = "gb_InpOut";
            this.gb_InpOut.Padding = new System.Windows.Forms.Padding(6);
            this.gb_InpOut.Size = new System.Drawing.Size(721, 257);
            this.gb_InpOut.TabIndex = 3;
            this.gb_InpOut.TabStop = false;
            this.gb_InpOut.Text = "Outputs";
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
            this.txt_out.Size = new System.Drawing.Size(612, 200);
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
            this.gb_registers.Controls.Add(this.BasicRegTable);
            this.gb_registers.Controls.Add(this.SPRTable);
            this.gb_registers.ForeColor = System.Drawing.Color.White;
            this.gb_registers.Location = new System.Drawing.Point(12, 1008);
            this.gb_registers.Margin = new System.Windows.Forms.Padding(6);
            this.gb_registers.Name = "gb_registers";
            this.gb_registers.Padding = new System.Windows.Forms.Padding(6);
            this.gb_registers.Size = new System.Drawing.Size(876, 267);
            this.gb_registers.TabIndex = 2;
            this.gb_registers.TabStop = false;
            this.gb_registers.Text = "Registers";
            // 
            // BasicRegTable
            // 
            this.BasicRegTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.BasicRegTable.ColumnCount = 10;
            this.BasicRegTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BasicRegTable.Location = new System.Drawing.Point(11, 149);
            this.BasicRegTable.Name = "BasicRegTable";
            this.BasicRegTable.RowCount = 1;
            this.BasicRegTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.BasicRegTable.Size = new System.Drawing.Size(863, 90);
            this.BasicRegTable.TabIndex = 6;
            // 
            // SPRTable
            // 
            this.SPRTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.SPRTable.ColumnCount = 5;
            this.SPRTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SPRTable.Location = new System.Drawing.Point(9, 36);
            this.SPRTable.Name = "SPRTable";
            this.SPRTable.RowCount = 1;
            this.SPRTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.SPRTable.Size = new System.Drawing.Size(863, 100);
            this.SPRTable.TabIndex = 5;
            // 
            // gb_Display
            // 
            this.gb_Display.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.gb_Display.Controls.Add(this.btn_MachineHuman);
            this.gb_Display.Controls.Add(this.lbl_MemoryTest);
            this.gb_Display.Controls.Add(this.MemoryTable);
            this.gb_Display.Controls.Add(this.gb_registers);
            this.gb_Display.ForeColor = System.Drawing.Color.White;
            this.gb_Display.Location = new System.Drawing.Point(702, 0);
            this.gb_Display.Margin = new System.Windows.Forms.Padding(6);
            this.gb_Display.Name = "gb_Display";
            this.gb_Display.Padding = new System.Windows.Forms.Padding(6);
            this.gb_Display.Size = new System.Drawing.Size(900, 1400);
            this.gb_Display.TabIndex = 1;
            this.gb_Display.TabStop = false;
            this.gb_Display.Text = "CPU stuff";
            // 
            // btn_MachineHuman
            // 
            this.btn_MachineHuman.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_MachineHuman.ForeColor = System.Drawing.Color.White;
            this.btn_MachineHuman.Location = new System.Drawing.Point(708, 46);
            this.btn_MachineHuman.Margin = new System.Windows.Forms.Padding(6);
            this.btn_MachineHuman.Name = "btn_MachineHuman";
            this.btn_MachineHuman.Size = new System.Drawing.Size(178, 77);
            this.btn_MachineHuman.TabIndex = 9;
            this.btn_MachineHuman.Text = "Machine Code\r\nHuman Code \r\n";
            this.btn_MachineHuman.UseVisualStyleBackColor = false;
            this.btn_MachineHuman.Visible = false;
            // 
            // lbl_MemoryTest
            // 
            this.lbl_MemoryTest.AutoSize = true;
            this.lbl_MemoryTest.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MemoryTest.Location = new System.Drawing.Point(21, 72);
            this.lbl_MemoryTest.Name = "lbl_MemoryTest";
            this.lbl_MemoryTest.Size = new System.Drawing.Size(170, 48);
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
            this.MemoryTable.Location = new System.Drawing.Point(21, 148);
            this.MemoryTable.Name = "MemoryTable";
            this.MemoryTable.RowCount = 8;
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MemoryTable.Size = new System.Drawing.Size(863, 784);
            this.MemoryTable.TabIndex = 4;
            this.MemoryTable.Paint += new System.Windows.Forms.PaintEventHandler(this.MemoryTable_Paint);
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
            this.txt_uProg.Location = new System.Drawing.Point(128, 205);
            this.txt_uProg.Margin = new System.Windows.Forms.Padding(0);
            this.txt_uProg.Multiline = true;
            this.txt_uProg.Name = "txt_uProg";
            this.txt_uProg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_uProg.Size = new System.Drawing.Size(536, 766);
            this.txt_uProg.TabIndex = 3;
            this.txt_uProg.Text = resources.GetString("txt_uProg.Text");
            this.txt_uProg.TextChanged += new System.EventHandler(this.txt_uProg_TextChanged);
            // 
            // gb_Execute
            // 
            this.gb_Execute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_Execute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(84)))), ((int)(((byte)(151)))));
            this.gb_Execute.Controls.Add(this.btn_pause);
            this.gb_Execute.Controls.Add(this.RunSpeed);
            this.gb_Execute.Controls.Add(this.btn_play);
            this.gb_Execute.Controls.Add(this.btn_ReturnToEdit);
            this.gb_Execute.Controls.Add(this.btn_Run);
            this.gb_Execute.Controls.Add(this.btn_Compile);
            this.gb_Execute.ForeColor = System.Drawing.Color.White;
            this.gb_Execute.Location = new System.Drawing.Point(12, 1008);
            this.gb_Execute.Margin = new System.Windows.Forms.Padding(6);
            this.gb_Execute.Name = "gb_Execute";
            this.gb_Execute.Padding = new System.Windows.Forms.Padding(6);
            this.gb_Execute.Size = new System.Drawing.Size(630, 239);
            this.gb_Execute.TabIndex = 3;
            this.gb_Execute.TabStop = false;
            this.gb_Execute.Text = "Execution Buttons";
            // 
            // btn_pause
            // 
            this.btn_pause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_pause.ForeColor = System.Drawing.Color.White;
            this.btn_pause.Location = new System.Drawing.Point(453, 133);
            this.btn_pause.Margin = new System.Windows.Forms.Padding(6);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(81, 59);
            this.btn_pause.TabIndex = 12;
            this.btn_pause.Text = "Pause";
            this.btn_pause.UseVisualStyleBackColor = false;
            this.btn_pause.Visible = false;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // RunSpeed
            // 
            this.RunSpeed.Location = new System.Drawing.Point(199, 32);
            this.RunSpeed.Name = "RunSpeed";
            this.RunSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RunSpeed.Size = new System.Drawing.Size(419, 90);
            this.RunSpeed.TabIndex = 11;
            this.RunSpeed.Tag = "";
            // 
            // btn_play
            // 
            this.btn_play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_play.ForeColor = System.Drawing.Color.White;
            this.btn_play.Location = new System.Drawing.Point(546, 133);
            this.btn_play.Margin = new System.Windows.Forms.Padding(6);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(72, 59);
            this.btn_play.TabIndex = 10;
            this.btn_play.Text = "Play";
            this.btn_play.UseVisualStyleBackColor = false;
            this.btn_play.Visible = false;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
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
            // btn_Compile
            // 
            this.btn_Compile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_Compile.ForeColor = System.Drawing.Color.White;
            this.btn_Compile.Location = new System.Drawing.Point(12, 32);
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
            this.gb_UAssControls.Size = new System.Drawing.Size(652, 139);
            this.gb_UAssControls.TabIndex = 4;
            this.gb_UAssControls.TabStop = false;
            this.gb_UAssControls.Text = "File & Assembely Controls";
            // 
            // btn_LoadFile
            // 
            this.btn_LoadFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_LoadFile.ForeColor = System.Drawing.Color.White;
            this.btn_LoadFile.Location = new System.Drawing.Point(232, 36);
            this.btn_LoadFile.Name = "btn_LoadFile";
            this.btn_LoadFile.Size = new System.Drawing.Size(190, 70);
            this.btn_LoadFile.TabIndex = 12;
            this.btn_LoadFile.Text = "Load Program ";
            this.btn_LoadFile.UseVisualStyleBackColor = false;
            this.btn_LoadFile.Click += new System.EventHandler(this.btn_LoadFile_Click);
            // 
            // btn_DeleteFile
            // 
            this.btn_DeleteFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_DeleteFile.ForeColor = System.Drawing.Color.White;
            this.btn_DeleteFile.Location = new System.Drawing.Point(453, 36);
            this.btn_DeleteFile.Name = "btn_DeleteFile";
            this.btn_DeleteFile.Size = new System.Drawing.Size(190, 70);
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
            this.btn_SaveFile.Size = new System.Drawing.Size(192, 70);
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
            this.gb_userInput.Size = new System.Drawing.Size(700, 1400);
            this.gb_userInput.TabIndex = 0;
            this.gb_userInput.TabStop = false;
            this.gb_userInput.Text = "User Input";
            this.gb_userInput.Enter += new System.EventHandler(this.gb_userInput_Enter);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.tableLayoutPanel2.ColumnCount = 10;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
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
            this.gb_InpOut.ResumeLayout(false);
            this.gb_InpOut.PerformLayout();
            this.gb_registers.ResumeLayout(false);
            this.gb_Display.ResumeLayout(false);
            this.gb_Display.PerformLayout();
            this.gb_Execute.ResumeLayout(false);
            this.gb_Execute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RunSpeed)).EndInit();
            this.gb_UAssControls.ResumeLayout(false);
            this.gb_userInput.ResumeLayout(false);
            this.gb_userInput.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel BasicRegTable;

        private System.Windows.Forms.TableLayoutPanel SPRTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

        private System.Windows.Forms.Button btn_MachineHuman;

        private System.Windows.Forms.Button btn_pause;

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
        private System.Windows.Forms.GroupBox gb_Display;
        private System.Windows.Forms.GroupBox gb_InpOut;
        private System.Windows.Forms.TextBox txt_out;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel pnl_uCodeManip;
        private System.Windows.Forms.TextBox txt_uProg;
        private System.Windows.Forms.GroupBox gb_Execute;
        private System.Windows.Forms.Button btn_Compile;
        private System.Windows.Forms.GroupBox gb_UAssControls;
        private System.Windows.Forms.Button btn_SaveFile;
        private System.Windows.Forms.GroupBox gb_userInput;
        private System.Windows.Forms.Button btn_ReturnToEdit;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.TableLayoutPanel MemoryTable;
        private System.Windows.Forms.Label lbl_MemoryTest;
        private System.Windows.Forms.TrackBar RunSpeed;
    }
    
    
    
    
    
    
}