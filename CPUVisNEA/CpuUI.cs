using System;
using System.Collections;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using NUnit.Framework.Internal;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

//todo look at this for design https://www.101computing.net/LMC/# 
/*
____________________________________________________________________________________________________________
Full method

Load Form  ---->  Edit Stage
-----
Compile stage
Use Compile class

---->  clean
---->  validate
--------->  If valid 
-------------->  assign RAM with correspondence for user program
-------------->  enter Running Stage 
--------->  else  ---->  Edit Stage 
---->  
Running Stage 
Use CPU class 

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
    public partial class UI : Form
    {
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\";
        private List<string> availableFiles = new List<string>();
        private bool Editstate = true;
        private CPU cpu;
        private bool HumanReadableMemory = false;
        private bool paused = false;
        private int currentExecution = 0 ;


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
            //todo 
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
                    // todo wait for step
                    checked
                    {
                        
                    }
                    wait(RunSpeed.Value);
                    currentExecution = cpu.CurrentState.PC.content;
                    VisualMemoryUpdate();
                    cpu.FDECycle(); // Complete 1 cycle
                    updateFDELogs();
                    SPRupdate();
                    //de moivre theorem (!A & !B) == !(A|B)
                    //continues to run whilst edit state hasn't been called or form returned to edit state 
                } while (!cpu.CheckHalted() && !Editstate);
            
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

                /*
                     label.Dock = DockStyle.Fill;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    MemoryTable.Controls.Add( label, col, row );
                    */
                MemoryTable.Controls.Add(cell, col, row);
            }
        }

        private void SPRCreate()
        {
            int index = 0;
            var SPRs = new List<string> { "PC", "MAR", "MDR", "ACC", "CIR", "MBR" };
            var pc = new Cell("PC");
            pc.content.Text = cpu.CurrentState.PC.content.ToString();
            SPRTable.Controls.Add(pc,index,0);
            index++;
            
            var mar = new Cell("MAR");
            mar.content.Text = cpu.CurrentState.MAR.content.ToString();
            SPRTable.Controls.Add(mar,index,0);
            index++;

            var mdr = new Cell("MDR");
            mdr.content.Text = cpu.CurrentState.MDR.content.ToString();
            SPRTable.Controls.Add(mdr,index,0);
            index++;

            var acc = new Cell("ACC");
            acc.content.Text = cpu.CurrentState.ACC.content.ToString();
            SPRTable.Controls.Add(acc,index,0);
            index++;

            var cir = new Cell("CIR");
            cir.content.Text = cpu.CurrentState.CIR.content;
            SPRTable.Controls.Add(cir,index,0);
            index++;

            for (var i = 0; i < cpu.CurrentState.Basic.Length; i++)
            {
                var Registeri = new Cell($"R{i}");
                Registeri.content.Text = cpu.CurrentState.Basic[i].content.ToString();
                BasicRegTable.Controls.Add(Registeri,i,0);
            }
        }

        private void SPRupdate()
        {
            //todo copy memory 
            int index = 0;
            
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

            //((Cell)MemoryTable.Controls[index]).content.Text = text;
            for (var i = 0; i < cpu.CurrentState.Basic.Length; i++)
            {
                ((Cell)BasicRegTable.Controls[i]).content.Text = cpu.CurrentState.Basic[i].content.ToString();
            }
        }

        private int ReqNumOfMemoryIndexes()
        {
            return cpu.ram.Memory.Count;
        }


        private void VisualMemoryUpdate()
        {
            System.Drawing.Font BinaryFont = new Font("Microsoft Sans Serif", 6F, FontStyle.Bold);
            System.Drawing.Font HumanFont = new Font("Microsoft Sans Serif", 10.5F, FontStyle.Bold);
            var max = ReqNumOfMemoryIndexes();
            for (var row = 0; row < max / 10 + 1; row++)
            for (var col = 0; col < 10; col++)
            {
                var index = row * 10 + col;
                string text = "";
                if (cpu.ram.Memory.Count <= index)
                    text = "0";
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
                if (index == currentExecution)
                    MemoryTable.Controls[index].BackColor = Color.DeepSkyBlue;
                else
                    MemoryTable.Controls[index].BackColor = Color.DarkSlateGray;
                
                ((Cell)MemoryTable.Controls[index]).content.Text = text;
            }
        }
        // Cell is a child class that inherits from the default class used in forms of panels
        // this form contains 2 Labels
        // -> private Cell title as it doesnt need to be written to
        // -> public content title needs to be colour edited and content potentially changed with each FDE cycle 
        public string bytePrint(int index)
        {
            return $"{Int32.Parse(Convert.ToString(cpu.ram.Memory[index], 2)):0000 0000}";
        }
        
        public class Cell : Panel
        {
            private Label name;
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
                /* Panel panel = new Panel();
                panel.BackColor = Color.White;
                panel.Controls.Add(content);
                panel.Controls.Add(this.name);
                panel.Dock = DockStyle.Fill;

                // Set the cell's controls and initial background color
                Controls.Add(panel); */
                BackColor = Color.LightSlateGray;
                Controls.Add(this.name);
                Controls.Add(content);
            }

            public Color BackColor
            {
                set => content.BackColor = value;
            }

            // Other properties and methods as needed
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

        private void gb_userInput_Enter(object sender, EventArgs e)
        {
        }

        private void pnl_uCodeManip_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btn_Compile_Click(object sender, EventArgs e)
        {
            try
            {
                cpu.Compiler = new Compiler();
                var valid = cpu.Compile(txt_uProg.Text);
                Trace.WriteLine($"compiled: \n {txt_uProg.Text}");
                setEditState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to Compile Program, error message : {ex} on line ");
            }
            // if valid, call CPU.ChangeState()
            // if invalid, output assembly problems
        }

        private void setEditState(bool edit)
        {
            Trace.WriteLine($"Switched to Edit Mode to {edit} \n");
            // edit mode
            Editstate = edit;
            txt_uProg.Enabled = edit;
            btn_Compile.Visible = edit;
            btn_LoadFile.Visible = edit;
            
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

            //need to create function to update Compiler class local variable of contents
            //
            // int len = this.txt_uProg.Lines.Length;
            // for(int line = 0, line<len;lin)
            // {
            //     
            // }
            //
        }

        private void btn_ReturnToEdit_Click(object sender, EventArgs e)
        {
            setEditState(true);
            btn_MachineHuman.Enabled = false;
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            //cpu.Run();
            run();
        }

        private void updateFDELogs()
        {
            foreach (var change in cpu.CurrentState.changeLog) txt_shortFDE.AppendText(change + Environment.NewLine );
            foreach (var change in cpu.CurrentState.DetailedChangeLog) txt_longFDE.AppendText(change + Environment.NewLine );

            if (cpu.CurrentState.Outputs != null) txt_out.Text += " " + cpu.CurrentState.Outputs;
        }

        private void btn_SaveFile_Click(object sender, EventArgs e)
        {
            //todo validate???
            //btn_Compile_Click(sender,e);
            var SaveFile = new SaveFile_Form(txt_uProg.Text, availableFiles);
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
            //whilst the Load isnt dealt with, carry on showing it
            LoadFile.ShowDialog();
            if (LoadFile.ReturnedProgram != "") txt_uProg.Text = LoadFile.ReturnedProgram;
        }

        //declared inside UI class to allow interaction and register when a click event on the form is taken
        private void wait(int ms)
        {
            do
            {
                Application.DoEvents();
            } while (paused);
            
            var timer = new System.Windows.Forms.Timer();
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

        private void btn_MachineHuman_Click(object sender, EventArgs e)
        {
            //currently Human readable
            if (HumanReadableMemory)
            {
                btn_MachineHuman.Text = "Change to Numbers";
            }
            else
            {
                btn_MachineHuman.Text = "Change to Bytes";
            }
            //switch bool regardless of bytes or number
            HumanReadableMemory = !HumanReadableMemory;
            VisualMemoryUpdate();
        }
    }
}
/*
//TODO
Notes Section
____________________________________________________________________________________________________________
User Program

    2 states, edit and run state. Run state has added Compiler display and step button 

    File Handling - 
        Creat dictionary that is maps executable file names to description/displayName of loadable files.
        stick files in the Bin > Debug > 
        messagebox.show

    Compile //is there error?
        yes --> output error line, reason for error and line content. Also return edit state 
        no --> Compile next Line OR return run state, remove edit access to User Program TextBox. 
               Compile Button turns to "return to edit" button 
               
               Calculate number of Compiler Lines Required
               Remove FDE Log Texts

        Create Method to read Line and check if acceptable structure, ?regular expression?

FDE Cycle Console Logs
    
Short FDE Cycle Log 

Set structure for all FDE cycles
Erase Text after complete FDE log / when new compile 

Detailed FDE Cycle Log 
Scrollable and continuously add to log. Only remove after Compile

//---------------------------------------------------------------------------------------
 QUESTION MARK CIRCLE BOX WHEN CLICKED
 
Class Query
    display image
    private string title
    private string contents
    public Clicked{ new MessageBox( content ) ) 
        Title
    
*/