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
 
    /* General todos 
     * ----> Regex for Arguements
     * ----> LineInstruction
     * ---------> Instructions need to edit Cpu registers / pass CPU as parameter?
     * ---------> Add rest of options
     * ----> Branch needs new Instruction subclasses ( overide Branch class)
     * 
     */
    
    //----------------------------------------Main Class CPU------------------------------------------------
    // vast majority of classes are instantiated in CPU 
    public class CPU
    {
        public enum Instructions : byte
        {
            //todo reorder to correct AQA order
            //enum number integer can be converted to represent binary value 
            //e.g Halt == 0 == 0000
            //e.g LDR == 5 == 0101
            HALT, B, MOV, CMP, MVN, LDR, STR, AND, ORR, EOR, LSL, LSR, ADD, SUB
        }


        public static Instruction newInstruction(Instructions instr)
        {
            switch (instr)
            {
                case Instructions.HALT:
                    return new Halt();
                case Instructions.B:
                    return new B();
                case Instructions.MOV:
                    return new Mov();
                case Instructions.CMP:
                    return new Cmp();
                case Instructions.MVN:
                    return new Mvn();
                case Instructions.LDR:
                    return new Ldr();
                case Instructions.STR:
                    return new Str();
                case Instructions.AND:
                    return new And();
                case Instructions.ORR:
                    return new Orr();
                case Instructions.EOR:
                    return new Eor();
                case Instructions.LSL:
                    return new Lsl();
                case Instructions.LSR:
                    return new Lsr();
                case Instructions.ADD:
                    return new Add();
                case Instructions.SUB:
                    return new Sub();
                default:
                    throw new ArgumentOutOfRangeException(nameof(instr), instr, null);
            }
        }
 

        // Special Purpose Registers used by a CPU 
        private Register[] SPRegisters;
        // Normal interactable 
        private Register[] BasicRegisters = new Register[10]; 
        // todo explain why line below is bs, how to fix - CPUState[] new class 
        private Tuple<Register[], Register[], int>[] CPUHistory = new Tuple<Register[], Register[], int>[] {};

        private RAM ram = new RAM();
        public Compiler Compiler = new Compiler();
        public ALU Alu = new ALU();
        
        /*---------------------------------------- Run ------------------------------------------------
        |  BREAKDOWN
        |---->  Run() ==== while( ! halt ) do ...
        |
        |--------->  Fetch() Go to RAM class at index
        |--------->  Decode()
        |-------------->  Check how many indexes arguements takes
        |-------------->  Fetch arguements
        |--------->  Execute()
        |-------------->  ExecuteInstruction()
        |-------------->  Add new CPUState to History 
        */
        public void Run()
        {
            bool halted = false;
            while(!halted){
             Fetch();
             Decode();
             Execute( );
            }
             
        }

        public void Fetch()
        {
            
        }

        public void Decode()
        {
            
        }
        public void Execute(Instruction instr)
        {
            //call the overriden instruction's execute command with its given arguements
            //( Could be partically more efficient with passed args but this allows easy testing
            //with my Unit testing interface for if executeInstruction works)
            instr.executeInstruction(instr.args, /*todo*/null);
        }


        private void UpdateRunSpeed(int selection)
        {
            // 
        }
        /* TODO add 
         GetAssemblyFiles()  // for the menu of load programs
         SaveUserAssembly()  //calls Compiler.SaveProg calls create new instantiation of AssProg
         
         
         Runspeed Dictionary //to translate choices to int speed or user step
         Run() // uses big if( user step ) else run at speed ...
         step() //does an iteration
         RequestInputs() // display message box to take input
            // message box code req while(!validInput) { carry on asking for input type }  
         Outputs() // update lil output box and pass to FDE stuff
         DisplayShortFDE() // create calls for steps in cycle e.g 
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


        public void RamLoader(string text)
        {
            try
            {
                /*split the string representing the content of the textbox into string[]
                 By looking for the new line character*/ 
                var program = new List<string>(text.Split('\n'));
                
                Compiler.UStringProg = program;
                Trace.WriteLine($"Compiled: [{text}] into {Compiler.UStringProg.Count} instructions");
                Compiler.Cleanse();
                Trace.WriteLine($"removed blank space: to {Compiler.UStringProg.Count} instructions");
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
                RamLoader(text);
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
        //todo mabye string that can be made byte OR all List<string> to smth else
        
        private byte[][] Memory = new byte[5][] ;
        private Instruction[] AssembelyProgram = new Instruction[] { };
        private bool binaryMode = false;
        
        //Local Convert function in RAM class to completely translate the users program displayed in RAm between its binary representation
        //and its assembly language representation. This is completed by checking the local class variable binaryMode to
        //select the direction on conversion - binary to Assembly ( Bin2Ass() ) or Assembly to binary ( Ass2Bin() ) 
        
        //this is useful so students can see what is being held in RAM as values they can read and understand
        private List<string> Convert()
        {
            var newContent = new List<string>();
            if (binaryMode)
            {
                newContent = Bin2Ass();
                binaryMode = false;
            }
            else newContent = Ass2Bin(); binaryMode = true;

            return newContent;
        }

        private List<string> Ass2Bin()
        {
            //for all lines run algorithm to change assembely track to binary equivelant
            return null;
        }

        private List<string> Bin2Ass()
        {
            //opposite search of bin to ass for all lines
            //both stored as strings 
            return null;
        }
    }
    public class Compiler
    {
        
        public List<string> UStringProg = new List<string>();
        public Instruction[] CompUProg_Instructions = new Instruction[] { };
        

        
        
        //Cleanse() used for removing all lines comprised of blank characters (blank line) 
        public void Cleanse()
        {
            List<String> temporary = new List<string>();
            foreach (string line in UStringProg)
            {
                if (!String.IsNullOrWhiteSpace(line))
                {
                    temporary.Add(line);
                }
            }

            UStringProg = temporary;
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

            }
            else
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

                
                CPU.Instructions instrType;
                CPU.Instructions.TryParse(instruction, out instrType);
                byte testFromMem = 1;
                CPU.Instructions inst = (CPU.Instructions)testFromMem;
                Instruction parsed = CPU.newInstruction(instrType);
                switch (instruction)
                {

                    case "HALT":
                    {
                        //special case stop execution return to edit state 
                        parsed = new Halt();
                        break;
                    }

                    /* as Branch can be a non conditional or conditional variant,
                     I have decided to model all Instructions on a single class that changes 
                     execution nature dependent on the condition passed down to the B constructor
                     ( condition given by removing the B from switch case instruction to get add-on e.g EQ or NE) */
                    case "B":
                    case "BEQ":
                    case "BNE":
                    case "BLT":
                    case "BMT":
                    {
                        //remove the B from case. If B, returns null else returns remaining string
                        string condition = instruction.Replace("B", null);
                        //pass condition down to override parseArgs
                        //this in turn passes down the conditional to the constructor of the B
                        parsed = B.parseArgs(args,condition);
                        break;
                    }

                    case "MOV":
                    {
                        parsed = Mov.parseArgs(args);
                        break;
                    }

                    case "CMP":
                    {
                        parsed = Cmp.parseArgs(args);
                        break;
                    }

                    case "MVN":
                    {
                        parsed = Mvn.parseArgs(args);
                        break;
                    }

                    case "LDR":
                    {
                        parsed = Ldr.parseArgs(args);
                        break;
                    }

                    case "AND":
                    {
                        parsed = And.parseArgs(args);
                        break;
                    }

                    case "ORR":
                    {
                        parsed = Orr.parseArgs(args);
                        break;
                    }

                    case "EOR":
                    {
                        parsed = Eor.parseArgs(args);
                        break;
                    }

                    case "LSL":
                    {
                        parsed = Lsl.parseArgs(args);
                        break;
                    }

                    case "LSR":
                    {
                        parsed = Lsr.parseArgs(args);
                        break;
                    }

                    case "ADD":
                    {
                        parsed = Add.parseArgs(args);
                        break;
                    }

                    case "SUB":
                    {
                        parsed = Sub.parseArgs(args);
                        break;
                    }
                    //todo add rest of options


                    default: throw new Exception($"Unknown instruction: {instruction}");
                }

                // now add the arguments to the instruction:
                Instruction.addParsedArgs(parsed, args);
                return parsed;
            }

            //todo change line below to failsafe, move comment above 
            return new Mov();
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
        
        //B<condition>  <label>  Conditionally branch to the instruction at position <label> in the program if the last comparison met the criteria specified by the <condition>. Possible values for <condition> and their meaning are: EQ:Equal to, NE:Not equal to, GT:Greater than, LT:Less than.
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

    public class CPUState
    {
        
    }

    //--------------------------------------Assembely Program classes - files -----------------------------------------------
//assembly program
//need to test access 
    public class AssProg
    {
        private string fileLocation; //what to search when accessing file directory
        private string displayName; //name shown in list (end of file ) 
        private string[] filecontent;

        public AssProg(string fileLocation, string displayName, string[] filecontent)
        {
            this.fileLocation = fileLocation;
            this.displayName = displayName;
            this.filecontent = filecontent;
        }
        
    } // maybe have a list of AssProgs? Then call append(Compiler.saveProg()) 
    
     
}