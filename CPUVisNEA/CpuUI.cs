using System;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using NUnit.Framework.Internal;

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
-----
Running Stage 
Use CPU class 

---->  Run() ==== while( ! halt ) do ...

--------->  Fetch() Go to RAM class at index
--------->  Decode()
-------------->  Check how many indexes arguements takes
-------------->  Fetch arguements
--------->  Execute()
-------------->  ExecuteInstruction()
-------------->  Add new CPUState to History 

___________________________________________________________________________________________________________

*/
namespace CPUVisNEA
{
    
    public partial class UI : Form
    {

        private bool Editstate = true;
        private CPU cpu;

        public UI(CPU cpu)
            {
                this.cpu = cpu;
                InitializeComponent();
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
                    // TODO: show dialog / write to output pane
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
            
            cpu.Run();
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