using System;
using System.Drawing;
using System.Collections.Generic;

namespace CPUVisNEA
{
           //------------------------------------------------------------------------------------------------------
        public class CPU
    {
        public List<Register> SPRegisters = new List<Register>(6)
        {
            new OpcodeReg("succ")
        };
        public List<Register> BasicRegisters = new List<Register>(10);
        public RAM Ram = new RAM();
        public ALU Alu = new ALU();

        private void ChangeState()
        {
            
        }
    }
    public class RAM
    {
        private bool binaryMode = false;
        public List<string> UProgRAM = new List<string>();

        //Local Convert function in RAM class to completely translate the users program between its binary representation
        //and its assembly language representation. This is completed by checking the local class variable binaryMode to
        //select the direction on conversion - binary to Assembly ( Bin2Ass() ) or Assembly to binary ( Ass2Bin() ) 
        private List<string> Convert()
        {
            List<string> newContent = new List<string>();
            if (binaryMode)
            {
                //      newContent = Bin2Ass();
            }
            //   else newContent = Ass2Bin();

            return newContent;
        }

        private List<string> Ass2Bin()
        {
            //for all lines run algorithm to change assembely track to binary equivelant


            return UProgRAM;
        } 
        
        private List<string> Bin2Ass()
        {
            //opposite search of bin to ass for all lines
            //both stored as strings 
            
            return UProgRAM;
        }
        

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

        protected int RetContent()
        {
            return content;
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
        
        //LDR Rd, <memory ref> Load the value stored in the memory location specified by <memory ref> into register d.
        private void LDR( Rd, <memory ref> ) {} 
        
        //STR Rd, <memory ref> Store the value that is in register d into the memory location specified by <memory ref>.
        private void STR( Rd, <memory ref> ) {}
        
        //ADD Rd, Rn, <operand2> Add the value specified in <operand2> to the value in register n and store the result in register d.
        private void ADD( Rd, Rn, <operand2> ) {}
        
        //SUB Rd, Rn, <operand2> Subtract the value specified by <operand2> from the value in register n and store the result in register d.
        private void SUB( Rd, Rn, <operand2> ) {}
        
        //MOV Rd, <operand2> Copy the value specified by <operand2> into register d.
        private void MOV( Rd, <operand2> ) {}
        
        //CMP Rn, <operand2> Compare the value stored in register n with the value specified by <operand2>.
        private void CMP( Rn, <operand2> ) {}
        
        //B <label> Always branch to the instruction at position <label> in the program.
        private void B( <label> ) {}
        
        //B<condition> <label> Conditionally branch to the instruction at position <label> in the program if the last comparison met the criteria specified by the <condition>. Possible values for <condition> and their meaning are: EQ:Equal to, NE:Not equal to, GT:Greater than, LT:Less than.
        //conditonal branch as method B already used
        private void B_if( <condition>, <label> ) {}
        
        //AND Rd, Rn, <operand2> Perform a bitwise logical AND operation between the value in register n and the value specified by <operand2> and store the result in register d.
        private void AND( Rd, Rn, <operand2> )
        
        //ORR Rd, Rn, <operand2> Perform a bitwise logical OR operation between the value in register n and the value specified by <operand2> and store the result in register d.
        private void ORR( Rd, Rn, <operand2> ) {}
        
        //EOR Rd, Rn, <operand2> Perform a bitwise logical exclusive or (XOR) operation between the value in register n and the value specified by <operand2> and store the result in register d.
        private void EOR( Rd, Rn, <operand2>) {}
        
        //MVN Rd, <operand2> Perform a bitwise logical NOT operation on the value specified by <operand2> and store the result in register d.
        private void MVN( Rd, <operand2> ) {}
        
        //LSL Rd, Rn, <operand2> Logically shift left the value stored in register n by the number of bits specified by <operand2> and store the result in register d.
        private void LSL( Rd, Rn, <operand2>){}
        
        //LSR Rd, Rn, <operand2> Logically shift right the value stored in register n by the number of bits specified by <operand2> and store the result in register d.
        private void LSR( Rd, Rn, <operand2> ){}
        
        //HALT Stop the execution of the program.
        //Basically change state to edit 
        private void Halt(){}
        

        
        
        <operand2> can be #nnn or Rm to use either a constant or the contents of register Rm.
        Registers are R0 to R12.
         */

    }
    //------------------------------------------------------------------------------------------------------

    
}