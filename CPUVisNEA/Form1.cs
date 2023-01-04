using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
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
    
    Convert Binary / ( Assembly & numbers )
    
class Register
    display name
    Content value 
    bool Accept Assemble
    
    If Assemble true 
        Method ConvertDisplay type  
        
Class ALU 
    Mapping Dictionary of Binary and assembly 

____________________________________________________________________________________________________________

LIL QUESTION MARK CIRCLE BOX WHEN CLICKED
Class Query
    display image
    contents ( simple text ) 
    whenClicked

*/
namespace CPUVisNEA
{
    
    public partial class UI : Form
        {

            public UI()
            {
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

            }

            private void txt_uProg_TextChanged(object sender, EventArgs e)
            {
                throw new System.NotImplementedException();

            }
        }
    public class CPU
    {
        public List<Register> SPRegisters = new List<Register>(6)
        {
            new OpcodeReg("succ")
        };
        public List<Register> BasicRegisters = new List<Register>(10);
        public RAM Ram = new RAM();
        public ALU Alu = new ALU();
    }
    public class RAM
    {
        public List<string> UProgContent = new List<string>();
    }

    public abstract class Register
    {
        private bool assAllowed = false;
        private int content;
        

        public Register(bool assAllowed, int content)
        {
            this.content = Convert.ToInt16(content);
        }

        protected Register(bool assAllowed, string contol)
        {
        
        }
    } 
    //needs to be improved below 
    
    //special case registers created due to Special Purpose needing to store Opcode instructions from assembly language as a string to display 
    public class OpcodeReg : Register
    {
        private static bool assAllowed = true;
        private string content;

        public OpcodeReg(string content) : base(assAllowed, content)
        {
            this.content = Convert.ToString(content);
            
        }
        
        //TODO 
    }

    public class ALU
    {
        /*
        LDR Rd, <memory ref> Load the value stored in the memory location specified by <memory ref> into register d.
        STR Rd, <memory ref> Store the value that is in register d into the memory location specified by <memory ref>.
        ADD Rd, Rn, <operand2> Add the value specified in <operand2> to the value in register n and store the result in register d.
        SUB Rd, Rn, <operand2> Subtract the value specified by <operand2> from the value in register n and store the result in register d.
        MOV Rd, <operand2> Copy the value specified by <operand2> into register d.
        CMP Rn, <operand2> Compare the value stored in register n with the value specified by <operand2>.
        B <label> Always branch to the instruction at position <label> in the program.
        B<condition> <label> Conditionally branch to the instruction at position <label> in the program if the last comparison met the criteria specified by the <condition>. Possible values for <condition> and their meaning are: EQ:Equal to, NE:Not equal to, GT:Greater than, LT:Less than.
        AND Rd, Rn, <operand2> Perform a bitwise logical AND operation between the value in register n and the value specified by <operand2> and store the result in register d.
        ORR Rd, Rn, <operand2> Perform a bitwise logical OR operation between the value in register n and the value specified by <operand2> and store the result in register d.
        EOR Rd, Rn, <operand2> Perform a bitwise logical exclusive or (XOR) operation between the value in register n and the value specified by <operand2> and store the result in register d.
        MVN Rd, <operand2> Perform a bitwise logical NOT operation on the value specified by <operand2> and store the result in register d.
        LSL Rd, Rn, <operand2> Logically shift left the value stored in register n by the number of bits specified by <operand2> and store the result in register d.
        LSR Rd, Rn, <operand2> Logically shift right the value stored in register n by the number of bits specified by <operand2> and store the result in register d.
        HALT Stop the execution of the program.
        <operand2> can be #nnn or Rm to use either a constant or the contents of register Rm.
        Registers are R0 to R12.
         */

    }
}
