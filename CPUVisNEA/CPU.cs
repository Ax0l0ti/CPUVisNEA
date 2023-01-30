using System;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;  
//https://resources.jetbrains.com/storage/products/rider/docs/Rider_default_win_shortcuts.pdf?_gl=1*8v6mpv*_ga*Mzk0Njg2ODg3LjE2NjExMDU4MzA.*_ga_9J976DJZ68*MTY3NTAyNjgxNS4xNy4wLjE2NzUwMjY4MjAuMC4wLjA.&_ga=2.77451923.725299765.1675026816-394686887.1661105830

namespace CPUVisNEA
{     
    
    //----------------------------------------Main Class CPU------------------------------------------------
    // vast majority of classes are instantiated in CPU ( Composition relation )
    public class CPU
    {
        public enum Instructions
        {
            HALT, B, MOV, CMP, MVN, LDR, AND, ORR, EOR, LSL, LSR, ADD, SUB
        }
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
        private void SetUp()
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


        public void fillRam(string text)
        {
            try
            {
                /*split the string representing the content of the textbox into string[]
                 By looking for the new line character*/ 
                var program = new List<string>(text.Split('\n'));
                
                Ram.UProgRAM = program;
                //TODO Remove blanks & Validate 
                Trace.WriteLine($"Compiled: [{text}] into {Ram.UProgRAM.Count} instructions");
                Ram.Cleanse();
                Trace.WriteLine($"removed blank space: to {Ram.UProgRAM.Count} instructions");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
       
        }
        public bool Compile(string text)
        {
            bool valid = false;
            
            try
            {
                fillRam(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" failed to shorten code");
            }

            // TODO: throw an exception if this isn't a valid program
            
            
            return valid;

        }

        public CPU()
        {
            SetUp();
        }
    }
    //----------------------------------------Random Access Memory Class - Compiling methods ------------------------------------------------
    public class RAM
    {
        private readonly bool binaryMode = false;
        public List<string> UProgRAM = new List<string>();
        private Instruction[] Program = new Instruction[] { };

        //Local Convert function in RAM class to completely translate the users program between its binary representation
        //and its assembly language representation. This is completed by checking the local class variable binaryMode to
        //select the direction on conversion - binary to Assembly ( Bin2Ass() ) or Assembly to binary ( Ass2Bin() ) 
        private List<string> Convert()
        {
            var newContent = new List<string>();
            if (binaryMode)
            {
                // newContent = Bin2Ass();
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
        //checks if valid format, called after cleanse
        public Instruction[] valid(List<String> program)
        {
            Instruction[] InstrArray = new Instruction[] {} ;
            
            foreach (var line in program)
            {
                //linearly iterate through Program and add correspondent Instruction to array of instruction with parameters
                Instruction nextInstr = lineToInstruction(line);
                InstrArray.Append(nextInstr);
            }
            return InstrArray;
        }
        
        public Instruction lineToInstruction (string line)
        { //todo           
            //Regular expressions of valid label / register / condition / memory reference / operand
            Regex VmemRef = new Regex("R[0-9]");
            string Vlabel = "";
            string VReg = @"(B)";
            string Vcondition = "";
            
            var tokens = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 1)
            {
                //it must be HALT command if only one word 
                //return new Halt();

            } else
            {
                string instruction = tokens[0];
                List<string> args = new List<string>();
                // we have split on whitespace, but we need to split on comma too
                for (int i = 1; i < tokens.Length; i++)
                {
                    var token = tokens[i];
                    var strings = token.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (var s in strings)
                    {
                        args.Add(s);
                    }
                }

                Instruction parsed;
                switch (instruction) 
                {
                    
                    case "HALT":
                    {
                        //special case stop execution return to edit state 
                        parsed = new Halt();
                        break;
                    }
                    //todo special as b can be condit or non condit
                    
                    case "B":
                    {
                        //special case condition 
                        
                        // if(condit exists)
                        // {
                        //     parsed = new B condit ();
                        // }
                        //
                        //TEMPORARY
                        parsed = new B();
                        break;
                    }

                    case "MOV":
                    {
                        parsed = new Mov();
                        break;
                    }

                    case "CMP":
                    {
                        parsed = new Cmp();
                        break;
                    } 

                    case "MVN":
                    {
                        parsed = new Mvn();
                        break;
                    }
                    
                    case "LDR":
                    {
                        parsed = new Ldr();
                        break;
                    }
                    
                    case "AND":
                    {
                        parsed = new And();
                        break;
                    }
                    
                    case "ORR":
                    {
                        parsed = new Orr();
                        break;
                    }
                    
                    case "EOR":
                    {
                        parsed = new Eor();
                        break;
                    }
                    
                    case "LSL":
                    {
                        parsed = new Lsl();
                        break;
                    }
                    
                    case "LSR":
                    {
                        parsed = new Lsr();
                        break;
                    }
                    
                    case "ADD":
                    {
                        parsed = new Add();
                        break;
                    }
                    
                    case "SUB":
                    {
                        parsed = new Sub();
                        break;
                    }
                    //todo add rest of options
                    
                    
                    default: throw new Exception($"Unknown instruction: {instruction}");
                }
                // now add the arguments to the instruction:
                Instruction.addParsedArgs(parsed, args);
                return parsed;
            }
            
            //----- valid line formats ----- 
            // ordered by input size
            // \w word character, 

            //HALT 
            //B <label>
            //B<condition> <label>
            // HALT    |    ( (B) (Vcondition)? (/w)* ) 
            //check if label exists OUTDATED COMMENTS 

            //MOV Rd, <operand2>
            //CMP Rn, <operand2>
            //MVN Rd, <operand2> 
            // ( (MOV) | (CMP) | (MVN) ) {VReg} ","\s {Voperand}
            
            //LDR Rd, <memory ref> 
            //STR Rd, <memory ref> 
            // ( (LDR) | (STR) ) {VReg} ","\s {Voperand}

            //AND Rd, Rn, <operand2>
            //ORR Rd, Rn, <operand2>
            //EOR Rd, Rn, <operand2>
            //LSL Rd, Rn, <operand2>
            //LSR Rd, Rn, <operand2>
            //ADD Rd, Rn, <operand2>
            //SUB Rd, Rn, <operand2>
            // ( (AND) | (ORR) | (EOR) | (LSL) | (LSR) | (ADD) | (SUB) ) {VReg} ","\s {VReg} ","\s {Voperand}
            //todo change line below to failsafe, move comment above 
            return new Mov();
        }
        /* outdated TODO add 
         state????
         UpdateRam( string newContent ) 
         SaveProg( string UprogRam) return AssProg
         */

        //----------------------------------------Execute ------------------------------------------------
        //todo fill in rest of cases
        public void execute(Instruction instr)
        {
            switch (instr.Tag)
            {
                case CPU.Instructions.MOV:
                    
                    break;
                case CPU.Instructions.ADD:
                    break;
                case CPU.Instructions.SUB:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    
//----------------------------------------Class of user interactable Registers  ------------------------------------------------

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
    //class for Assembly opcode only registers that hold opcode values
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
    //mabye delete below? Methods stored in individual classes instead
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

    //--------------------------------------Assembely Program classes - files -----------------------------------------------
//assembly program
//need to test access 
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