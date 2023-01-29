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
Initial

-----
Compile stage

-----
Running Stage 


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
                    var valid = cpu.Compile(txt_uProg.Text);
                    MessageBox.Show($"compiled: {txt_uProg.Text}");
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
                if (edit != this.Editstate)
                {
                    Trace.WriteLine($"Switched to {edit} mode");
                    this.Editstate = edit;
                    txt_uProg.Enabled = edit;
                }
            }

            private void txt_uProg_TextChanged(object sender, EventArgs e)
            {
                //current method is inefficient as it iterates round every line when updating
                Regex blank = new Regex(@"\s*");
                
      
                int i = 0;
                bool validLine = true; 
                //while there is still a line with text on it
                while (validLine)
                {
                    //as there is no built in function for converting a text box from a big string to lines or
                    
                    try
                    {
                        if (txt_uProg.Lines != null)
                        { 
                            cpu.Ram.UProgRAM[i] = txt_uProg.Lines[i];
                        }
                    }
                    catch(Exception exception)
                    {
                        //if error stop compiling as this is either end of textbook string or incorrect syntax
                        Console.WriteLine(exception);
                        validLine = false;
                    }
                    i++;
                }

                //need to create function to update RAM class local variable of contents
                //
                // int len = this.txt_uProg.Lines.Length;
                // for(int line = 0, line<len;lin)
                // {
                //     
                // }
                //
            }
        }
     
}
/*
//TODO
Notes Section
____________________________________________________________________________________________________________
User Program

    2 states, edit and run state. Run state has added RAM display and step button 

    File Handling - 
        Creat dictionary that is maps executable file names to description/displayName of loadable files.
        stick files in the Bin > Debug > 
        messagebox.show
        

    USER RAM 
        need to find

    Compile //is there error?
        yes --> output error line, reason for error and line content. Also return edit state 
        no --> Compile next Line OR return run state, remove edit access to User Program TextBox. 
               Compile Button turns to "return to edit" button 
               
               Calculate number of RAM Lines Required
               Remove FDE Log Texts

        Create Method to read Line and check if acceptable structure, ?regular expression?

FDE Cycle Console Logs
    
Short FDE Cycle Log 

Set structure for all FDE cycles
Erase Text after complete FDE log / when new compile 

Detailed FDE Cycle Log 
Scrollable and continuously add to log. Only remove after Compile
____________________________________________________________________________________________________________
Classes

class CPU 
    Register Array
    RAM class 
    
class RAM 
    Contents {List of Text Arrays ( User input area ) } 
    DisplayType ( Binary Assembly ) 
    
    Private String[] Binary2Ass
    Private String[] Ass2Binary 
    Private String[] GetContents( Contents )
    
class Register
    display name
    Content value 
    bool Accept Assemble
    
    If Assemble true 
        Method ConvertDisplay type  
        
Class ALU 
    Mapping Dictionary of Binary and assembly 
    
    

____________________________________________________________________________________________________________

 QUESTION MARK CIRCLE BOX WHEN CLICKED
Class Query
    display image
    contents ( simple text ) 
    whenClicked
*/