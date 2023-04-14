using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

/*
____________________________________________________________________________________________________________
Method Notes

Load Form  ---->  Edit Stage
-----
Compile stage
Use Compile class

---->  clean
---->  validate
--------->  If valid 
-------------->  assign RAM with correspondence for user program
-------------->  enter Running Stage 
--------->  else  ----> stay Edit Stage 

Running Stage 
Use CPU class 

Wipe any old run logs and load byte list to be executed
----> SetUpFresh() 
----> RefreshLogs()
----> FillRam()

---->  Run() ==== do while( ! halted ) 
--------->  WaitTillStep()
--------->  FDECycle()
------------->  Fetch() Go to RAM class at index
------------->  Decode()
------------------>  Check how many indexes arguments takes
------------------>  Fetch arguments
------------->  Execute()
------------------>  ExecuteInstruction()
------------------>  Add new CPUState to History 
--------->  Output to FDE Logs
___________________________________________________________________________________________________________
*/

namespace CPUVisNEA
{
    //class UI inherits from form to allow for a CPU class parameter to be passed and utilised
    public partial class UI : Form
    {
        private readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\";
        private readonly List<string> availableFiles = new List<string>(); //used for file handling
        private bool Editstate = true; // used to indicate what is visible and current state ( edit / run ) 
        private readonly CPU cpu;
        private bool HumanReadableMemory = true; // indicates whether byte list displayed as Integers or binary. 
        private bool paused; // determines whether next instruction should be executed, halts FDE cycle
        private int currentExecutionIndex; // used as CPU program counter for current memory index being executed


        public UI(CPU cpu)
        {
            this.cpu = cpu;
            InitializeComponent();
        }

        //when the form loads, get all available file names from the directory 
        //this should be both 
        private void UI_Load(object sender, EventArgs e)
        {
            UpdateFileNames();
            RunSpeed.SetRange(0, 5000);
            //always load program in edit state
            setEditState(true);
        }

        private void UpdateFileNames()
        {
            availableFiles.Clear();
            foreach (var filePath in Directory.GetFiles(path))
            {
                var fileName = filePath.Replace(path, "");
                availableFiles.Add(fileName);
            }

            Trace.WriteLine($"{availableFiles.Count} Files named : {string.Join(", ", availableFiles)}");
        }

        private void run()
        {
            btn_MachineHuman.Enabled = true;
            //set up and refresh all variables for new Run Command
            cpu.SetUpFresh();
            RefreshLogs();
            cpu.FillRam();
            //fist index is always 0

            VisualMemoryCreate();
            SPRCreate();
            do
            {
                wait(RunSpeed.Value);
                currentExecutionIndex = cpu.CurrentState.PC.content;
                VisualMemoryUpdate();
                cpu.FDECycle(); // Complete 1 cycle
                updateFDELogs();
                SPRupdate();
                //de moivre theorem (!A & !B) == !(A|B)
                //continues to run whilst edit state hasn't been called or form returned to edit state 
            } while (!cpu.CheckHalted() && !Editstate);
        }
        
        
        
        // Cell is a child class that inherits from the default class used in forms of panels
        // this form contains 2 Labels
        // -> private Cell title as it doesnt need to be written to
        // -> public content title needs to be colour edited and content potentially changed with each FDE cycle 
        

        public class Cell : Panel
        {
            private readonly Label name;
            public Label content;

            public Cell(string name)
            {
                // Initialize the name label
                this.name = new Label();
                this.name.Text = name;
                this.name.AutoSize = false;
                this.name.TextAlign = ContentAlignment.MiddleCenter;
                this.name.Dock = DockStyle.Top;
                // name in boldened font
                this.name.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);


                // Initialize the content label
                content = new Label();
                content.Text = "";
                content.AutoSize = false;
                content.TextAlign = ContentAlignment.MiddleCenter;
                content.Dock = DockStyle.Bottom;

                // Add the name and content labels to the cell

                // Set the cell's controls and initial background color
                BackColor = Color.LightSlateGray;
                Controls.Add(this.name);
                Controls.Add(content);
            }

            public Color BackColor
            {
                set => content.BackColor = value;
            }
        }



        private void VisualMemoryCreate()
        {
            var max = ReqNumOfMemoryIndexes();

            MemoryTable.Controls.Clear();
            // for '(max / 10) + 1' columns means that required num of row always rounds upwards to accommodate
            for (var row = 0; row < max / 10 + 1; row++)
            for (var col = 0; col < 10; col++)
            {
                var index = row * 10 + col;


                var cell = new Cell(index.ToString());
                if (max <= index)
                {
                    var text = "0";
                    cell.content.Text = text;
                }
                else
                {
                    var text = $"{cpu.ram.Memory[index]}";
                    cell.content.Text = text;
                }

                MemoryTable.Controls.Add(cell, col, row);
            }
        }

        private void SPRCreate()
        {
            var index = 0;
            var SPRs = new List<string> { "PC", "MAR", "MDR", "ACC", "CIR", "MBR" };
            var pc = new Cell("PC");
            pc.content.Text = cpu.CurrentState.PC.content.ToString();
            SPRTable.Controls.Add(pc, index, 0);
            index++;

            var mar = new Cell("MAR");
            mar.content.Text = cpu.CurrentState.MAR.content.ToString();
            SPRTable.Controls.Add(mar, index, 0);
            index++;

            var mdr = new Cell("MDR");
            mdr.content.Text = cpu.CurrentState.MDR.content;
            SPRTable.Controls.Add(mdr, index, 0);
            index++;

            var acc = new Cell("ACC");
            acc.content.Text = cpu.CurrentState.ACC.content.ToString();
            SPRTable.Controls.Add(acc, index, 0);
            index++;

            var cir = new Cell("CIR");
            cir.content.Text = cpu.CurrentState.CIR.content;
            SPRTable.Controls.Add(cir, index, 0);
            index++;

            for (var i = 0; i < cpu.CurrentState.Basic.Length; i++)
            {
                var Registeri = new Cell($"R{i}");
                Registeri.content.Text = cpu.CurrentState.Basic[i].content.ToString();
                BasicRegTable.Controls.Add(Registeri, i, 0);
            }
        }
        public string bytePrint(int index)
        {
            return $"{int.Parse(Convert.ToString(cpu.ram.Memory[index], 2)):0000 0000}";
        }

        private void SPRupdate()
        {
            var index = 0;

            ((Cell)SPRTable.Controls[index]).content.Text = cpu.CurrentState.PC.content.ToString();
            index++;

            ((Cell)SPRTable.Controls[index]).content.Text = cpu.CurrentState.MAR.content.ToString();
            index++;

            ((Cell)SPRTable.Controls[index]).content.Text = cpu.CurrentState.MDR.content;
            index++;

            ((Cell)SPRTable.Controls[index]).content.Text = cpu.CurrentState.ACC.content.ToString();
            index++;

            ((Cell)SPRTable.Controls[index]).content.Text = cpu.CurrentState.CIR.content;
            index++;

            for (var i = 0; i < cpu.CurrentState.Basic.Length; i++)
                ((Cell)BasicRegTable.Controls[i]).content.Text = cpu.CurrentState.Basic[i].content.ToString();
        }

        private int ReqNumOfMemoryIndexes()
        {
            return cpu.ram.Memory.Count;
        }


        private void VisualMemoryUpdate()
        {
            var BinaryFont = new Font("Microsoft Sans Serif", 6F, FontStyle.Bold);
            var HumanFont = new Font("Microsoft Sans Serif", 10.5F, FontStyle.Bold);
            var max = ReqNumOfMemoryIndexes();
            for (var row = 0; row < max / 10 + 1; row++)
            for (var col = 0; col < 10; col++)
            {
                var index = row * 10 + col;
                var text = "";
                if (cpu.ram.Memory.Count <= index)
                {
                    text = "0";
                }
                else
                {
                    if (HumanReadableMemory)
                    {
                        text = $"{cpu.ram.Memory[index]}";

                        ((Cell)MemoryTable.Controls[index]).content.Font = HumanFont;
                    }
                    else
                    {
                        ((Cell)MemoryTable.Controls[index]).content.Font = BinaryFont;
                        text = bytePrint(index);
                    }
                }


                // Create a new Label control with the text and add it to the TableLayoutPanel
                if (index == currentExecutionIndex)
                    MemoryTable.Controls[index].BackColor = Color.DeepSkyBlue;
                else
                    MemoryTable.Controls[index].BackColor = Color.DarkSlateGray;

                ((Cell)MemoryTable.Controls[index]).content.Text = text;
            }
        }

        
        private void RefreshLogs()
        {
            txt_longFDE.Text = "";
            txt_shortFDE.Text = "";
            txt_out.Text = "";
            MemoryTable.Controls.Clear();
            SPRTable.Controls.Clear();
            BasicRegTable.Controls.Clear();
        }

        private void btn_Compile_Click(object sender, EventArgs e)
        {
            try
            {
                cpu.Compiler = new Compiler();
                //if caught error compiling go to catch and dont switch edit state
                cpu.Compile(txt_uProg.Text);
                Trace.WriteLine($"compiled: \n {txt_uProg.Text}");
                setEditState(false);
            }
            catch (Exception ex)
            {
                //used as message to user to output message that contains :
                // string of line, line number, error e.g Instruction or argument invalid
                MessageBox.Show($"Failed to Compile Program, error message : {ex} on line ", "Assembly Invalid");
            }
        }

        private void setEditState(bool edit)
        {
            Trace.WriteLine($"Switched to Edit Mode to {edit} \n");
            // edit mode
            Editstate = edit;
            txt_uProg.Enabled = edit;
            btn_Compile.Visible = edit;
            btn_LoadFile.Visible = edit;
            btn_Help.Visible = edit;
            
            // run mode
            btn_ReturnToEdit.Visible = !edit;
            btn_Run.Visible = !edit;
            btn_play.Visible = !edit;
            btn_pause.Visible = !edit;
            RunSpeed.Visible = !edit;
            btn_MachineHuman.Visible = !edit;
        }


        private void txt_uProg_TextChanged(object sender, EventArgs e)
        {
            //current method is inefficient as it iterates round every line when updating
            var i = 0;
            var validLine = true;
            //while there is still a line with text on it
            while (validLine)
            {
                /*as there is no built in function for converting
                 a text box from a string to array of lines, I cant use a foreach loop or for loop */
                //try to assign to-be compiled string the string value in the form's textbox
                try
                {
                    if (txt_uProg.Lines != null) cpu.Compiler.StringProgram[i] = txt_uProg.Lines[i];
                }
                catch (Exception exception)
                {
                    //if error stop compiling as this is either end of textbook string or incorrect syntax
                    Console.WriteLine(exception);
                    validLine = false;
                }

                i++;
            }
        }

        private void btn_ReturnToEdit_Click(object sender, EventArgs e)
        {
            setEditState(true);
            btn_MachineHuman.Enabled = false;
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            //cpu.Run() applicable for debug console and NuUnit testing. UI class run() instruction applicable for form and visual display
            //make sure the button cant be clicked twice
            btn_Run.Enabled = false;
            run();
            //button can now be clicked again
            btn_Run.Enabled = true;
        }

        private void updateFDELogs()
        {
            // for all small changes append to shortFDE
            foreach (var change in cpu.CurrentState.changeLog) txt_shortFDE.AppendText(change + Environment.NewLine);
            // as all detailed changes compiled into single string beforehand, it can simply be added
            txt_longFDE.AppendText(cpu.Fetch_Decode_add.Replace("\n", Environment.NewLine));

            if (cpu.CurrentState.Outputs != null) txt_out.AppendText(cpu.CurrentState.Outputs + " " );
        }

        private void btn_SaveFile_Click(object sender, EventArgs e)
        {
            var SaveFile = new SaveFile_Form(txt_uProg.Text);
            SaveFile.ShowDialog();
            UpdateFileNames();
        }

        private void btn_DeleteFile_Click(object sender, EventArgs e)
        {
            var DeleteFile = new DeleteFile_Form(availableFiles);
            DeleteFile.ShowDialog();
            UpdateFileNames();
        }

        private void btn_LoadFile_Click(object sender, EventArgs e)
        {
            var LoadFile = new LoadFile_Form(availableFiles);
            //whilst the Load isn't dealt with, carry on showing it
            LoadFile.ShowDialog();
            if (LoadFile.ReturnedProgram != "") txt_uProg.Text = LoadFile.ReturnedProgram;
        }

        //declared inside UI class to allow interaction and register when a click event on the form is taken
        private void wait(int ms)
        {
            // while paused, continue checking for continue clicked
            while (paused) Application.DoEvents();

            var timer = new Timer();
            if (ms == 0 || ms < 0) return;

            // Console.WriteLine("start wait timer");
            timer.Interval = ms;
            timer.Enabled = true;
            timer.Start();

            timer.Tick += (s, e) =>
            {
                timer.Enabled = false;
                timer.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer.Enabled) Application.DoEvents();
        }

        private void MemoryTable_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            paused = false;
            btn_play.Enabled = false;
            btn_pause.Enabled = true;
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            paused = true;
            btn_play.Enabled = true;
            btn_pause.Enabled = false;
        }
        //alters variable that determines value of
        private void btn_MachineHuman_Click(object sender, EventArgs e)
        {
            //currently Human readable
            if (HumanReadableMemory)
                btn_MachineHuman.Text = "Change to Integers";
            else
                btn_MachineHuman.Text = "Change to Bytes";
            //switch bool regardless of bytes or number
            HumanReadableMemory = !HumanReadableMemory;
            VisualMemoryUpdate();
        }

        // most below are simply Hover over descriptions 
        private void MemoryTable_MouseHover(object sender, EventArgs e)
        {
            Info.Show("This is a Visual display of your program stored as binary (similar to an executable file)" +
                      "\nIt can also be translated into the binary's integer equivelants to make it easier to read",
                MemoryTable);
        }

        private void SPRTable_MouseHover(object sender, EventArgs e)
        {
            Info.Show(
                "This is a Row for Special Purpose Registers \nA list Registers and Purposes are as followed : \n        \nProgram Counter (PC) - holds memory index of the next instruction to be executed\nMemory Address Register (MAR) - holds the memory address of instruction required for execution\nMemory Data Register (MDR) - holds the data that is being read from or written to memory at MAR\nAccumulator (ACC) - holds intermediate results of arithmetic and logic operations (during execution)\nCurrent Instruction Register (CIR) - holds the instruction that is currently being executed by the CPU \n\t",
                SPRTable);
        }

        private void btn_MachineHuman_MouseHover(object sender, EventArgs e)
        {
            Info.Show("Button used to switch Visual Display \nbetween Machine code (binary) and the Integer equivalent",
                btn_MachineHuman);
        }

        private void txt_out_MouseHover(object sender, EventArgs e)
        {
            Info.Show(
                "Console that responds to the Assembly OUT command \nOutputs values of the register passed to the instruction during execution",
                txt_out);
        }

        private void txt_shortFDE_MouseHover(object sender, EventArgs e)
        {
            Info.Show(
                "Console used to track Fetch Decode Execute cycle \n This log is a simplified and more compact version compared to its counterpart",
                txt_shortFDE);
        }

        private void txt_longFDE_MouseHover(object sender, EventArgs e)
        {
            Info.Show(
                "Console used to track Fetch Decode Execute cycle \n This log is expanded and more detailed than its counterpart",
                txt_longFDE);
        }

        private void RunSpeed_MouseHover(object sender, EventArgs e)
        {
            Info.Show(
                "Slider that affects run time of execution \nRanges from Real Time Execution to large delays to allow the FDE cycle to be followed step by step",
                RunSpeed);
        }

        private void lbl_hover_MouseHover(object sender, EventArgs e)
        {
            Info.Show("Wow... very smart. Please actually use the project instead of messing about", lbl_hover);
        }

        private void btn_Compile_MouseHover(object sender, EventArgs e)
        {
            Info.Show(
                "Button used to compile the Assembly program (above)  \nThis will switch the window into run mode if successfully compiled",
                btn_Compile);
        }

        private void BasicRegTable_MouseHoverBasicRegTable_MouseHover(object sender, EventArgs e)
        {
            Info.Show("This is a Row for Basic Registers that hold integer values that the CPU can interact with",
                BasicRegTable);
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("STR Rd, <memory ref> - " +
                            "\nStore the value that is in register d into the memory location specified by <memory ref>." +
                            "\nADD Rd, Rn, <operand2> - " +
                            "\nAdd the value specified in <operand2> to the value in register n and store the result in register d." +
                            "\nSUB Rd, Rn, <operand2> - " +
                            "\nSubtract the value specified by <operand2> from the value in register n and store the result in register d." +
                            "\nMOV Rd, <operand2> - " +
                            "\nCopy the value specified by <operand2> into register d." +
                            "\nCMP Rn, <operand2> - " +
                            "\nCompare the value stored in register n with the value specified by <operand2>." +
                            "\nB <label> - " +
                            "\nAlways branch to the instruction at position <label> in the program." +
                            "\nBEQ <label> - " +
                            "\nBranch to the instruction at position <label> if the last comparison meets an equal to criteria." +
                            "\nBNE <label> - " +
                            "\nBranch to the instruction at position <label> if the last comparison meets a not equal to criteria." +
                            "\nBLT <label> - " +
                            "\nBranch to the instruction at position <label> if the last comparison meets a less than criteria." +
                            "\nBGT <label> - " +
                            "\nBranch to the instruction at position <label> if the last comparison meets a greater than criteria." +
                            "\nAND Rd, Rn, <operand2> - " +
                            "\nPerform a bitwise logical AND operation between the value in register n and the value specified by <operand2> and store the result in register d." +
                            "\nORR Rd, Rn, <operand2> - " +
                            "\nPerform a bitwise logical OR operation between the value in register n and the value specified by <operand2> and store the result in register d." +
                            "\nEOR Rd, Rn, <operand2> - " +
                            "\nPerform a bitwise logical XOR (exclusive or) operation between the value in register n and the value specified by <operand2> and store the result in register d." +
                            "\nMVN Rd, <operand2> - " +
                            "\nPerform a bitwise logical NOT operation on the value specified by <operand2> and store the result in register d." +
                            "\nLSL Rd, Rn, <operand2> - " +
                            "Logically shift left the value stored in register n by the number of bits specified by <operand2> and store the result in register d." +
                            "\nLSR Rd, Rn, <operand2> - " +
                            "\nLogically shift right the value stored in register n by the number of bits specified by <operand2> and store the result in register d." +
                            "\nHALT - Stops the execution of the program." +
                            "\nOUT Rn - Returns the value of Rn to the output log ( top right )",
                "Instruction Set is as follows :");
            Application.DoEvents();
        }
    }
}