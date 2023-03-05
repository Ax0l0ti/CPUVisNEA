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
        }

        private void UpdateFileNames()
        {
            availableFiles.Clear();
            foreach (var fileName in Directory.GetFiles(path) ) 
            {
                availableFiles.Add(fileName);
            }

            MessageBox.Show($"{availableFiles.Count} Files named : "); //todo 
        }

        private void run()
        {

            //set up and refresh all variables for new Run Command
            cpu.SetUpFresh();
            RefreshLogs();
            cpu.FillRam();
            
            do{
                // todo wait for step
                cpu.FDECycle( /* todo step parameter to slow it down */ ); // Complete 1 cycle
                updateFDELogs(); //todo mabye make whenever updated
            } while (!cpu.CheckHalted());
            
        }

        private void RefreshLogs()
        {
            txt_longFDE.Text = "";
            txt_shortFDE.Text = "";
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
                    MessageBox.Show($"Failed to Compile Program, error message : {ex}");
                }
                // if valid, call CPU.ChangeState()
                // if invalid, output assembly problems

            }

            private void setEditState(bool edit)
            {
                Trace.WriteLine($"Switched to Edit Mode to {edit} \n");
                Editstate = edit;
                txt_uProg.Enabled = edit;
                btn_Compile.Visible = edit;
                btn_ReturnToEdit.Visible = !edit;
                btn_Run.Visible = !edit;
        }
            

            private void txt_uProg_TextChanged(object sender, EventArgs e)
            {
                //current method is inefficient as it iterates round every line when updating
                int i = 0;
                bool validLine = true; 
                //while there is still a line with text on it
                while (validLine)
                {
                    /*as there is no built in function for converting
                     a text box from a string to array of lines, I cant use a foreach loop or for loop */
                    //try to assign to-be compiled string the string value in the form's textbox
                    try { if (txt_uProg.Lines != null) { cpu.Compiler.StringProgram[i] = txt_uProg.Lines[i]; } }
                    catch(Exception exception)
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

            private void txt_Labels_TextChanged(object sender, EventArgs e)
            {
            }

        private void btn_ReturnToEdit_Click(object sender, EventArgs e)
        {
            setEditState(true);
        }

        private void btn_Run_Click( object sender, EventArgs e )
        {
            //cpu.Run();
            run();
        }

        private void updateFDELogs()
        {
            
            foreach (var change in cpu.CurrentState.changeLog)
            {
                txt_shortFDE.Text = txt_shortFDE.Text + change + Environment.NewLine ;
            }
            foreach (var change in cpu.CurrentState.DetailedChangeLog)
            {
                txt_longFDE.Text = txt_longFDE.Text + change + Environment.NewLine ;
            }

            
            
        }
        private void btn_SaveFile_Click(object sender, EventArgs e)
        {
            //todo validate???
            //btn_Compile_Click(sender,e);
            var SaveFile = new SaveFile_Form( txt_uProg.Text, availableFiles );
            SaveFile.Show();
            UpdateFileNames();
        }

        private void DD_LoadProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void btn_DeleteFile_Click(object sender, EventArgs e)
        {
            var DeleteFile = new DeleteFile_Form( availableFiles );
            DeleteFile.Show();
            UpdateFileNames();
        }

        private void btn_LoadFile_Click(object sender, EventArgs e)
        {
            var LoadFile = new LoadFile_Form( availableFiles );
            LoadFile.Show();
            if (LoadFile.ReturnedProgram != "")
            {
                txt_uProg.Text = LoadFile.ReturnedProgram;
            }
            UpdateFileNames();
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