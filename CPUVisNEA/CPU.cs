using System;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CPUVisNEA
{
    //------------------------------------------------------------------------------------------------------
    public class CPU
    {
        public Register[] SPRegisters;
        public List<Register> BasicRegisters = new List<Register>(10);
        public RAM Ram = new RAM();
        public ALU Alu = new ALU();
        

        private void ChangeState()
        {
        }


        /* TODO add 
         GetAssFiles()  // for the menu of load programs
         Save()  //calls Ram.SaveProg calls create new instantiation of AssProg
 
         Compile() 
         CompileValid() //set defaults to variables
         stateChange()
         Update RunSpeed
         Runspeed Dictionary //to translate choices to int speed or user step
         Run()
         step() //does an iteration
         RequestInputs() 
         Outputs()
         DisplayShortFDE()
         DisplayLongFDE()
         ReturnToEdit() 
         */
        public void SetUp()
        {
            // Program Counter
            var PC = new IntReg("PC", 0);
            // Memory Address Register
            var MAR = new CodeReg("MAR", "");
            // Memory Data Register
            var MDR = new IntReg("MDR", 0);
            //Accumulator
            var ACC = new IntReg("ACC", 0);
            //Current Instruction Register
            var CIR = new CodeReg("CIR", "");
            // Memory Buffer Register 
            var MBR = new IntReg("PC", 0);
            //Adding all Registers to the Special Purpose Registers
            //as assigning can only happen in declaration, temporary holds the info before transfer
            Register[] temporary = { PC, MAR, MDR, ACC, CIR, MBR };
            SPRegisters = temporary;
        }
        
        

        public bool Compile(string text)
        {
            bool valid = false;
            try
            {
                /*split the string representing the content of the textbox into string[]
                 By looking for the new line character*/ 
                var program = new List<string>(text.Split('\n'));
                
                Ram.UProgRAM = program;
                //TODO Remove blanks & Validate 
                Trace.Write($"Compiled: [{text}] into {Ram.UProgRAM.Count} instructions");
                Ram.Cleanse();
                Trace.Write($"removed blank space: to {Ram.UProgRAM.Count} instructions");
                valid = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
                valid = false;
            }
            
            
           
            

            // try
            // {
            //     Ram.Cleanse();
            // }
            // catch (Exception ex)
            // {
            //     MessageBox.Show(" failed to shorten code");
            // }

            // TODO: throw an exception if this isn't a valid program
            return valid;

        }

        public CPU()
        {
            SetUp();
        }
    }

    public class RAM
    {
        private readonly bool binaryMode = false;
        public List<string> UProgRAM = new List<string>();

        //Local Convert function in RAM class to completely translate the users program between its binary representation
        //and its assembly language representation. This is completed by checking the local class variable binaryMode to
        //select the direction on conversion - binary to Assembly ( Bin2Ass() ) or Assembly to binary ( Ass2Bin() ) 
        private List<string> Convert()
        {
            var newContent = new List<string>();
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
        //Cleanse() used for removing all blank lines
        public void Cleanse()
        {
            List<String> temporary = new List<string>();
            foreach (string line in UProgRAM)
            {
                if (!String.IsNullOrWhiteSpace(line))
                {
                    temporary.Add(line);
                }
            }

            UProgRAM = temporary;
        }


        /* TODO add 
         state????
         UpdateRam( string newContent ) 
         SaveProg( string UprogRam) return AssProg
         */
    }

/*basic class of a register. As a register can store either a string or integer I have
 created a parent class that can be inherited for both basic and special registers */
    public abstract class Register
    {
        //display name of Register Instance
        protected string name;

        //determines if Assembly language is allowed or integers. useful to determine what data type the content is
        // doesnt have to be passed as a parameter as child class influences assAllowed value
        protected bool assAllowed;

        //protected constructor so inherited classes can use class
        protected Register(string name)
        {
        }

        //function to extract value of Register's assAllowed value due to local scope
        protected bool getAllow()
        {
            return assAllowed;
        }

        //function to extract value of Register's name value due to local scope
        protected string getName()
        {
            return name;
        }
    }

    //class for Integer only registers that hold opcode values
    public class IntReg : Register
    {
        private readonly int content;

        public IntReg(string name, int content) : base(name)
        {
            assAllowed = false;
            this.content = content;
        }

        protected int RetContent()
        {
            return content;
        }
    }

    public class CodeReg : Register
    {
        private readonly string content;

        public CodeReg(string name, string content) : base(name)
        {
            assAllowed = true;
            this.content = content;
        }

        protected string RetContent()
        {
            return content;
        }
    }
    //needs to be improved below 

    //special case registers created due to Special Purpose needing to store Opcode instructions from assembly language as a string to display 

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

    //--------------------------------------end of CPU -----------------------------------------------
//assembly program
    public class AssProg
    {
        private string fileName; //what to search when accessing
        private string displayName;
        private string[] filecontent;

        public AssProg(string fileName, string displayName, string[] filecontent)
        {
            this.fileName = fileName;
            this.displayName = displayName;
            this.filecontent = filecontent;
        }
    } // maybe have a list of AssProgs? Then call append(Ram.saveProg()) 
}

