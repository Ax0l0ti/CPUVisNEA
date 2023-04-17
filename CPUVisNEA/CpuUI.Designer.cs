
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
            this.components = new System.ComponentModel.Container();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gb_outputs = new System.Windows.Forms.GroupBox();
            this.lbl_DetailedLog = new System.Windows.Forms.Label();
            this.lbl_BasicLog = new System.Windows.Forms.Label();
            this.txt_longFDE = new System.Windows.Forms.TextBox();
            this.txt_shortFDE = new System.Windows.Forms.TextBox();
            this.gb_InpOut = new System.Windows.Forms.GroupBox();
            this.txt_out = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.gb_registers = new System.Windows.Forms.GroupBox();
            this.GPRegisterTable = new System.Windows.Forms.TableLayoutPanel();
            this.SPRTable = new System.Windows.Forms.TableLayoutPanel();
            this.gb_Display = new System.Windows.Forms.GroupBox();
            this.lbl_hover = new System.Windows.Forms.Label();
            this.btn_MachineHuman = new System.Windows.Forms.Button();
            this.lbl_MemoryTest = new System.Windows.Forms.Label();
            this.MemoryTable = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_uCodeManip = new System.Windows.Forms.Panel();
            this.txt_uProg = new System.Windows.Forms.TextBox();
            this.gb_Execute = new System.Windows.Forms.GroupBox();
            this.btn_step = new System.Windows.Forms.Button();
            this.btn_Help = new System.Windows.Forms.Button();
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
            this.Info = new System.Windows.Forms.ToolTip(this.components);
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
            this.gb_outputs.Controls.Add(this.lbl_DetailedLog);
            this.gb_outputs.Controls.Add(this.lbl_BasicLog);
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
            // lbl_DetailedLog
            // 
            this.lbl_DetailedLog.AutoSize = true;
            this.lbl_DetailedLog.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DetailedLog.Location = new System.Drawing.Point(23, 698);
            this.lbl_DetailedLog.Name = "lbl_DetailedLog";
            this.lbl_DetailedLog.Size = new System.Drawing.Size(240, 48);
            this.lbl_DetailedLog.TabIndex = 7;
            this.lbl_DetailedLog.Text = "Full FDE Log";
            // 
            // lbl_BasicLog
            // 
            this.lbl_BasicLog.AutoSize = true;
            this.lbl_BasicLog.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BasicLog.Location = new System.Drawing.Point(23, 304);
            this.lbl_BasicLog.Name = "lbl_BasicLog";
            this.lbl_BasicLog.Size = new System.Drawing.Size(271, 48);
            this.lbl_BasicLog.TabIndex = 6;
            this.lbl_BasicLog.Text = "Execution Log";
            // 
            // txt_longFDE
            // 
            this.txt_longFDE.AllowDrop = true;
            this.txt_longFDE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.txt_longFDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_longFDE.ForeColor = System.Drawing.Color.White;
            this.txt_longFDE.Location = new System.Drawing.Point(23, 752);
            this.txt_longFDE.Margin = new System.Windows.Forms.Padding(6);
            this.txt_longFDE.Multiline = true;
            this.txt_longFDE.Name = "txt_longFDE";
            this.txt_longFDE.ReadOnly = true;
            this.txt_longFDE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_longFDE.Size = new System.Drawing.Size(756, 521);
            this.txt_longFDE.TabIndex = 3;
            this.txt_longFDE.MouseHover += new System.EventHandler(this.txt_longFDE_MouseHover);
            // 
            // txt_shortFDE
            // 
            this.txt_shortFDE.AllowDrop = true;
            this.txt_shortFDE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.txt_shortFDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_shortFDE.ForeColor = System.Drawing.Color.White;
            this.txt_shortFDE.Location = new System.Drawing.Point(23, 358);
            this.txt_shortFDE.Margin = new System.Windows.Forms.Padding(6);
            this.txt_shortFDE.Multiline = true;
            this.txt_shortFDE.Name = "txt_shortFDE";
            this.txt_shortFDE.ReadOnly = true;
            this.txt_shortFDE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_shortFDE.Size = new System.Drawing.Size(756, 328);
            this.txt_shortFDE.TabIndex = 2;
            this.txt_shortFDE.MouseHover += new System.EventHandler(this.txt_shortFDE_MouseHover);
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
            this.gb_InpOut.Size = new System.Drawing.Size(756, 257);
            this.gb_InpOut.TabIndex = 3;
            this.gb_InpOut.TabStop = false;
            this.gb_InpOut.Text = "Outputs";
            // 
            // txt_out
            // 
            this.txt_out.AllowDrop = true;
            this.txt_out.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.txt_out.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_out.ForeColor = System.Drawing.Color.White;
            this.txt_out.Location = new System.Drawing.Point(25, 36);
            this.txt_out.Margin = new System.Windows.Forms.Padding(6);
            this.txt_out.Multiline = true;
            this.txt_out.Name = "txt_out";
            this.txt_out.ReadOnly = true;
            this.txt_out.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_out.Size = new System.Drawing.Size(711, 200);
            this.txt_out.TabIndex = 3;
            this.txt_out.MouseHover += new System.EventHandler(this.txt_out_MouseHover);
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
            this.gb_registers.Controls.Add(this.GPRegisterTable);
            this.gb_registers.Controls.Add(this.SPRTable);
            this.gb_registers.ForeColor = System.Drawing.Color.White;
            this.gb_registers.Location = new System.Drawing.Point(10, 1000);
            this.gb_registers.Margin = new System.Windows.Forms.Padding(6);
            this.gb_registers.Name = "gb_registers";
            this.gb_registers.Padding = new System.Windows.Forms.Padding(6);
            this.gb_registers.Size = new System.Drawing.Size(880, 270);
            this.gb_registers.TabIndex = 2;
            this.gb_registers.TabStop = false;
            this.gb_registers.Text = "Registers";
            // 
            // GPRegisterTable
            // 
            this.GPRegisterTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.GPRegisterTable.ColumnCount = 10;
            this.GPRegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GPRegisterTable.Location = new System.Drawing.Point(9, 171);
            this.GPRegisterTable.Name = "GPRegisterTable";
            this.GPRegisterTable.RowCount = 1;
            this.GPRegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.GPRegisterTable.Size = new System.Drawing.Size(863, 90);
            this.GPRegisterTable.TabIndex = 6;
            this.GPRegisterTable.MouseHover += new System.EventHandler(this.BasicRegTable_MouseHoverBasicRegTable_MouseHover);
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
            this.SPRTable.MouseHover += new System.EventHandler(this.SPRTable_MouseHover);
            // 
            // gb_Display
            // 
            this.gb_Display.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.gb_Display.Controls.Add(this.lbl_hover);
            this.gb_Display.Controls.Add(this.btn_MachineHuman);
            this.gb_Display.Controls.Add(this.lbl_MemoryTest);
            this.gb_Display.Controls.Add(this.MemoryTable);
            this.gb_Display.Controls.Add(this.gb_registers);
            this.gb_Display.ForeColor = System.Drawing.Color.White;
            this.gb_Display.Location = new System.Drawing.Point(700, 0);
            this.gb_Display.Margin = new System.Windows.Forms.Padding(6);
            this.gb_Display.Name = "gb_Display";
            this.gb_Display.Padding = new System.Windows.Forms.Padding(6);
            this.gb_Display.Size = new System.Drawing.Size(900, 1400);
            this.gb_Display.TabIndex = 1;
            this.gb_Display.TabStop = false;
            this.gb_Display.Text = "CPU stuff";
            // 
            // lbl_hover
            // 
            this.lbl_hover.AutoSize = true;
            this.lbl_hover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lbl_hover.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hover.Location = new System.Drawing.Point(162, 5);
            this.lbl_hover.Name = "lbl_hover";
            this.lbl_hover.Size = new System.Drawing.Size(549, 35);
            this.lbl_hover.TabIndex = 11;
            this.lbl_hover.Text = "Hover over Elements to get a descritpion!";
            this.lbl_hover.MouseHover += new System.EventHandler(this.lbl_hover_MouseHover);
            // 
            // btn_MachineHuman
            // 
            this.btn_MachineHuman.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_MachineHuman.Enabled = false;
            this.btn_MachineHuman.ForeColor = System.Drawing.Color.White;
            this.btn_MachineHuman.Location = new System.Drawing.Point(708, 46);
            this.btn_MachineHuman.Margin = new System.Windows.Forms.Padding(6);
            this.btn_MachineHuman.Name = "btn_MachineHuman";
            this.btn_MachineHuman.Size = new System.Drawing.Size(178, 77);
            this.btn_MachineHuman.TabIndex = 9;
            this.btn_MachineHuman.Text = "Convert to Machine Code \r\n";
            this.btn_MachineHuman.UseVisualStyleBackColor = false;
            this.btn_MachineHuman.Visible = false;
            this.btn_MachineHuman.Click += new System.EventHandler(this.btn_MachineHuman_Click);
            this.btn_MachineHuman.MouseHover += new System.EventHandler(this.btn_MachineHuman_MouseHover);
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
            this.MemoryTable.Size = new System.Drawing.Size(863, 823);
            this.MemoryTable.TabIndex = 4;
            this.MemoryTable.Paint += new System.Windows.Forms.PaintEventHandler(this.MemoryTable_Paint);
            this.MemoryTable.MouseHover += new System.EventHandler(this.MemoryTable_MouseHover);
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
            // 
            // txt_uProg
            // 
            this.txt_uProg.AcceptsTab = true;
            this.txt_uProg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txt_uProg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_uProg.Font = new System.Drawing.Font("Microsoft New Tai Lue", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_uProg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_uProg.Location = new System.Drawing.Point(21, 205);
            this.txt_uProg.Margin = new System.Windows.Forms.Padding(0);
            this.txt_uProg.Multiline = true;
            this.txt_uProg.Name = "txt_uProg";
            this.txt_uProg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_uProg.Size = new System.Drawing.Size(652, 766);
            this.txt_uProg.TabIndex = 3;
            this.txt_uProg.Text = "Please Write Assembly Program here";
            this.txt_uProg.TextChanged += new System.EventHandler(this.txt_uProg_TextChanged);
            // 
            // gb_Execute
            // 
            this.gb_Execute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_Execute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(84)))), ((int)(((byte)(151)))));
            this.gb_Execute.Controls.Add(this.btn_step);
            this.gb_Execute.Controls.Add(this.btn_Help);
            this.gb_Execute.Controls.Add(this.btn_pause);
            this.gb_Execute.Controls.Add(this.RunSpeed);
            this.gb_Execute.Controls.Add(this.btn_play);
            this.gb_Execute.Controls.Add(this.btn_ReturnToEdit);
            this.gb_Execute.Controls.Add(this.btn_Run);
            this.gb_Execute.Controls.Add(this.btn_Compile);
            this.gb_Execute.ForeColor = System.Drawing.Color.White;
            this.gb_Execute.Location = new System.Drawing.Point(21, 1008);
            this.gb_Execute.Margin = new System.Windows.Forms.Padding(6);
            this.gb_Execute.Name = "gb_Execute";
            this.gb_Execute.Padding = new System.Windows.Forms.Padding(6);
            this.gb_Execute.Size = new System.Drawing.Size(652, 262);
            this.gb_Execute.TabIndex = 3;
            this.gb_Execute.TabStop = false;
            this.gb_Execute.Text = "Execution Buttons";
            // 
            // btn_step
            // 
            this.btn_step.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_step.ForeColor = System.Drawing.Color.White;
            this.btn_step.Location = new System.Drawing.Point(310, 36);
            this.btn_step.Margin = new System.Windows.Forms.Padding(6);
            this.btn_step.Name = "btn_step";
            this.btn_step.Size = new System.Drawing.Size(100, 50);
            this.btn_step.TabIndex = 14;
            this.btn_step.Text = "Step";
            this.Info.SetToolTip(this.btn_step, "Runs 1 full FDE cycle ");
            this.btn_step.UseVisualStyleBackColor = false;
            this.btn_step.Visible = false;
            this.btn_step.Click += new System.EventHandler(this.btn_step_Click);
            // 
            // btn_Help
            // 
            this.btn_Help.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Help.ForeColor = System.Drawing.Color.White;
            this.btn_Help.Location = new System.Drawing.Point(419, 36);
            this.btn_Help.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.Size = new System.Drawing.Size(221, 104);
            this.btn_Help.TabIndex = 13;
            this.btn_Help.Text = "Instruction Set Help";
            this.btn_Help.UseVisualStyleBackColor = false;
            this.btn_Help.Visible = false;
            this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_pause.ForeColor = System.Drawing.Color.White;
            this.btn_pause.Location = new System.Drawing.Point(199, 90);
            this.btn_pause.Margin = new System.Windows.Forms.Padding(6);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(100, 50);
            this.btn_pause.TabIndex = 12;
            this.btn_pause.Text = "Pause";
            this.btn_pause.UseVisualStyleBackColor = false;
            this.btn_pause.Visible = false;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // RunSpeed
            // 
            this.RunSpeed.Location = new System.Drawing.Point(14, 167);
            this.RunSpeed.Name = "RunSpeed";
            this.RunSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RunSpeed.Size = new System.Drawing.Size(626, 90);
            this.RunSpeed.TabIndex = 11;
            this.RunSpeed.Tag = "";
            this.RunSpeed.MouseHover += new System.EventHandler(this.RunSpeed_MouseHover);
            // 
            // btn_play
            // 
            this.btn_play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_play.ForeColor = System.Drawing.Color.White;
            this.btn_play.Location = new System.Drawing.Point(199, 36);
            this.btn_play.Margin = new System.Windows.Forms.Padding(6);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(100, 50);
            this.btn_play.TabIndex = 10;
            this.btn_play.Text = "Play";
            this.btn_play.UseVisualStyleBackColor = false;
            this.btn_play.Visible = false;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // btn_ReturnToEdit
            // 
            this.btn_ReturnToEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_ReturnToEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReturnToEdit.ForeColor = System.Drawing.Color.White;
            this.btn_ReturnToEdit.Location = new System.Drawing.Point(419, 36);
            this.btn_ReturnToEdit.Margin = new System.Windows.Forms.Padding(6);
            this.btn_ReturnToEdit.Name = "btn_ReturnToEdit";
            this.btn_ReturnToEdit.Size = new System.Drawing.Size(221, 104);
            this.btn_ReturnToEdit.TabIndex = 9;
            this.btn_ReturnToEdit.Text = "Return to Edit Mode";
            this.btn_ReturnToEdit.UseVisualStyleBackColor = false;
            this.btn_ReturnToEdit.Visible = false;
            this.btn_ReturnToEdit.Click += new System.EventHandler(this.btn_ReturnToEdit_Click);
            // 
            // btn_Run
            // 
            this.btn_Run.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_Run.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Run.ForeColor = System.Drawing.Color.White;
            this.btn_Run.Location = new System.Drawing.Point(14, 36);
            this.btn_Run.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(173, 104);
            this.btn_Run.TabIndex = 8;
            this.btn_Run.Text = "Run Program";
            this.btn_Run.UseVisualStyleBackColor = false;
            this.btn_Run.Visible = false;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // btn_Compile
            // 
            this.btn_Compile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_Compile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Compile.ForeColor = System.Drawing.Color.White;
            this.btn_Compile.Location = new System.Drawing.Point(14, 36);
            this.btn_Compile.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Compile.Name = "btn_Compile";
            this.btn_Compile.Size = new System.Drawing.Size(173, 104);
            this.btn_Compile.TabIndex = 4;
            this.btn_Compile.Text = "Compile Program\r\n";
            this.btn_Compile.UseVisualStyleBackColor = false;
            this.btn_Compile.Click += new System.EventHandler(this.btn_Compile_Click);
            this.btn_Compile.MouseHover += new System.EventHandler(this.btn_Compile_MouseHover);
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
            this.gb_UAssControls.Location = new System.Drawing.Point(21, 36);
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
            // Info
            // 
            this.Info.AutoPopDelay = 10000;
            this.Info.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Info.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Info.InitialDelay = 500;
            this.Info.ReshowDelay = 100;
            this.Info.ShowAlways = true;
            this.Info.Tag = "";
            this.Info.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Info.ToolTipTitle = "Description";
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

        private System.Windows.Forms.Button btn_step;

        private System.Windows.Forms.Label lbl_BasicLog;

        private System.Windows.Forms.Label lbl_DetailedLog;

        private System.Windows.Forms.Button btn_Help;

        private System.Windows.Forms.Label lbl_hover;

        private System.Windows.Forms.Button fucku;

        private System.Windows.Forms.TableLayoutPanel GPRegisterTable;

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
        private ToolTip Info;
    }
    
    
    
    
    
    
}