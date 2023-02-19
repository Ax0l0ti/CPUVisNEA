using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
    // CPU acts as the main class that operates as the main bulk of class interactions and back end code

    public class CPU
    {
        // Special Purpose Registers used by a CPU 
        // PC, MAR, MDR, ACC, CIR, MBR

        private Register[] SPRegisters = { /*PC, MAR, MDR, ACC, CIR, MBR*/ };

        // Program Counter
        private readonly IntReg PC = new IntReg("PC", 0);

        // Memory Address Register
        private readonly CodeReg MAR = new CodeReg("MAR", "");

        // Memory Data Register
        private readonly IntReg MDR = new IntReg("MDR", 0);

        //Accumulator
        private readonly IntReg ACC = new IntReg("ACC", 0);

        //Current Instruction Register
        private readonly CodeReg CIR = new CodeReg("CIR", "");

        // Memory Buffer Register 
        private readonly IntReg MBR = new IntReg("MBR", 0);


        // readonly variable for me to modify in case more or less registers are needed for testing, final code, adjustments etc.
        private static readonly int BasicRegisterNumber = 10;

        // Normal User interactable Registers in a Computer
        private Register[] BasicRegisters = new Register[BasicRegisterNumber];

        // todo explain why line below is bs, how to 
        //private Tuple<Register[], Register[], int>[] CPUHistory = new Tuple<Register[], Register[], int>[] {};
        private CPUState[] History = { };


        private readonly RAM ram = new RAM();
        public Compiler Compiler = new Compiler();

        public enum Instructions : byte
        {
            //todo reorder to correct AQA order
            //enum number integer can be converted to represent binary value 
            //e.g Halt == 0 == 0000
            //e.g LDR == 5 == 0101
            LDR,
            STR,
            ADD,
            SUB,
            MOV,
            CMP,
            B,
            BEQ,
            BNE,
            BGT,
            BLT,
            AND,
            ORR,
            EOR,
            MVN,
            LSL,
            LSR,
            HALT
        }

        //switch case that takes a enum from Instructions and translates it to a new instance of a correspondent Instruction class 
        public static Instruction newInstruction(Instructions instr)
        {
            //switches on the enum byte value automatically allotted to each Instruction Tag 
            switch (instr)
            {
                case Instructions.HALT:
                    return new Halt();
                case Instructions.B:
                    return new B(Instructions.B);
                case Instructions.BEQ:
                    return new Beq();
                case Instructions.BNE:
                    return new Bne();
                case Instructions.BLT:
                    return new Blt();
                case Instructions.BGT:
                    return new Bgt();
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
                    //as it switches based on enum value, any value higher than the potential maxima ( SUB )
                    throw new ArgumentOutOfRangeException(nameof(instr), instr, null);
            }
        }

        internal Argument TypeAndByteToArg(Type ArgType, byte ByteFormOfContent)
        {
            //C# doesnt allow the instantiation of a class using a Type variable
            // hence I created a switchcase of the class name matched to the name of the type which is the same
            switch (ArgType.Name)
            {
                case "RegisterArg":
                    return new RegisterArg(ByteFormOfContent);
                    break;
                case "IntArg":
                    return new IntegerArg(ByteFormOfContent);
                    break;
                case "Label":
                    return new RegisterArg(ByteFormOfContent);
                    break;
                default:
                    throw new Exception($"Invalid Type {ArgType.Name} ");
            }
        }


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
            var halted = false;
            while (!halted)
            {
                // Searches from index in RAM for next Instruction
                // calls Display Fetch Log
                var FetchedInstruction = Fetch(PC.content);
                // Checks How many Parameters Required
                // calls ParameterFetch() to get Parameters
                // calls Display Decode Log

                var InstructionToExecute = Decode(FetchedInstruction);
                Execute(InstructionToExecute);
            }
        }

        public void FillRam(Instruction[] FullInstructions)
        {
        }

        //CPU calls Instruction to access the byte representing the Instruction at the index of the Program Counter
        private byte Fetch(int index)
        {
            return ram.GetByteAt(PC.content);
        }

        // Decode returns the 
        public Instruction Decode(byte BinaryInstruction)
        {
            //Convert the bina
            var InstructionInt = Convert.ToInt32(BinaryInstruction);

            var TargetInstruction = newInstruction((Instructions)InstructionInt);
            var parameters = GetNumberOfParameters(TargetInstruction);

            for (var i = 0; i < parameters - 1; i++)
            {
                //use the Instruction class to retrieve the required type of arg at parameter index i 
                var ArgType = TargetInstruction.GetReqArgType(i);
                //Instanciate a new instance of the specific Argument 
                // this uses the Argtype to indicate the subclass of Argument and accesses the ram to retrieve the byte representing the Arg's content
                var FilledArg = TypeAndByteToArg(ArgType, ram.GetByteAt(PC.content + i));
                TargetInstruction.addArg(FilledArg);

                //incrementing the Program counter by number of bytes used to store parameters to access the next instruction assuming no branch condition
            }

            return TargetInstruction;
        }

        private int GetNumberOfParameters(Instruction TargetInstruction)
        {
            var parameters = 0;
            parameters = TargetInstruction.NumberOfParameters();
            return parameters;
        }


        private void Execute(Instruction instr)
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
            var MBR = new IntReg("MBR", 0);
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
            var valid = false;

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

        private readonly byte[] Memory = { };
        private Instruction[] AssembelyProgram = { };
        private bool binaryMode;

        //Local Convert function in RAM class to completely translate the users program displayed in RAm between its binary representation
        //and its assembly language representation. This is completed by checking the local class variable binaryMode to
        //select the direction on conversion - binary to Assembly ( Bin2Ass() ) or Assembly to binary ( Ass2Bin() ) 

        //this is useful so students can see what is being held in RAM as values they can read and understand

        internal byte GetByteAt(int index)
        {
            return Memory[index];
        }

        internal byte[] GetBytesAt(int index, int ByteSize)
        {
            byte[] BytesOfArgs = { };
            for (var incriment = 0; incriment < ByteSize - 1; incriment++)
                BytesOfArgs.Append(Memory[index + incriment]);

            return BytesOfArgs;
        }

        private List<string> Convert()
        {
            var newContent = new List<string>();
            if (binaryMode)
            {
                newContent = Bin2Ass();
                binaryMode = false;
            }
            else
            {
                newContent = Ass2Bin();
            }

            binaryMode = true;

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
        public Instruction[] CompUProg_Instructions = { };


        //Cleanse() used for removing all lines comprised of blank characters (blank line) 
        public void Cleanse()
        {
            var temporary = new List<string>();
            foreach (var line in UStringProg)
                if (!string.IsNullOrWhiteSpace(line))
                    temporary.Add(line);

            UStringProg = temporary;
        }

        //checks if valid format, called after cleanse
        public Instruction[] valid(List<string> program)
        {
            Instruction[] InstrArray = { };

            foreach (var line in program)
            {
                //linearly iterate through Program and add correspondent Instruction to array of instruction with parameters
                var nextInstr = lineToInstruction(line);
                InstrArray.Append(nextInstr);
            }

            return InstrArray;
        }

        public Instruction lineToInstruction(string line)
        {
            //todo           
            //Regular expressions of valid Label / register / condition / memory reference / operand
            var VmemRef = new Regex("R[0-9]");
            var Vlabel = "";
            var VReg = @"(B)";
            var Vcondition = "";

            var tokens = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 1)
            {
                //it must be HALT command if only one word 
                //return new Halt();
            }
            else
            {
                var instruction = tokens[0];
                var args = new List<string>();
                // we have split on whitespace, but we need to split on comma too
                for (var i = 1; i < tokens.Length; i++)
                {
                    var token = tokens[i];
                    var strings = token.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (var s in strings) args.Add(s);
                }


                CPU.Instructions instrType;
                Enum.TryParse(instruction, out instrType);
                byte testFromMem = 1;
                var inst = (CPU.Instructions)testFromMem;
                var parsed = CPU.newInstruction(instrType);
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
                    {
                        parsed = Mov.parseArgs(args);
                        break;
                    }
                    case "Beq":
                    {
                        parsed = Mov.parseArgs(args);
                        break;
                    }
                    case "Bne":
                    {
                        parsed = Mov.parseArgs(args);
                        break;
                    }
                    case "Blt":
                    {
                        parsed = Mov.parseArgs(args);
                        break;
                    }
                    case "BMT":
                    {
                        parsed = Mov.parseArgs(args);
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
        private readonly object content;

        //protected constructor so inherited classes can use class
        //by using content as an object, this allows different registers to assign strings or integers to content
        protected Register(string name, object content)
        {
            this.name = name;
            this.content = content;
        }

        //function to extract value of Register's assAllowed value due to local scope
        protected object RetContent()
        {
            //todo overrided
            return content;
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
        internal int content;

        public IntReg(string name, int content) : base(name, content)
        {
            assAllowed = false;
            this.content = content;
        }
    }

    //class for Assembly opcode only registers that hold opcode values
    public class CodeReg : Register
    {
        internal string content;

        public CodeReg(string name, string content) : base(name, content)
        {
            assAllowed = true;
            this.content = content;
        }
    }

    //needs to be improved below 

    //special case registers created due to Special Purpose needing to store Opcode instructions from assembly language as a string to display 
    //mabye delete below? Methods stored in individual classes instead

    public class CPUState
    {
        private Register[] SpecialPurpose;
        private Register[] Basic;

        public CPUState(Register[] specialPurpose, Register[] basic)
        {
            SpecialPurpose = specialPurpose;
            Basic = basic;
        }
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