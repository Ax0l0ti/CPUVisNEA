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
     * ----> Make Register Dictionary SP Basic ( used to find register for given string )
     * ----> Check if direct or indirect addressing
     * ----> 
     */


    //----------------------------------------Main Class CPU------------------------------------------------
    // CPU acts as the main class that operates as the main bulk of class interactions and back end code

    public class CPU
    {
        // Special Purpose Registers used by a CPU 
        // PC, MAR, MDR, ACC, CIR, MBR

        private Register[] SPRegisters = { /*PC, MAR, MDR, ACC, CIR, MBR*/ };

        // Program Counter
        private IntReg PC = new IntReg("PC", 0);

        // Memory Address Register
        private CodeReg MAR = new CodeReg("MAR", "");

        // Memory Data Register
        private IntReg MDR = new IntReg("MDR", 0);

        //Accumulator
        private IntReg ACC = new IntReg("ACC", 0);

        //Current Instruction Register
        private CodeReg CIR = new CodeReg("CIR", "");

        // Memory Buffer Register 
        private IntReg MBR = new IntReg("MBR", 0);


        // readonly variable for me to modify in case more or less registers are needed for testing, final code, adjustments etc.
        private static readonly int BasicRegisterNumber = 10;

        // Normal User interactable Registers in a Computer
        private Register[] BasicRegisters; 

        // todo explain why line below is bs, how to 
        //private Tuple<Register[], Register[], int>[] CPUHistory = new Tuple<Register[], Register[], int>[] {};
        private List<CPUState> History = new List<CPUState>();
        private CPUState CurrentState;
        
        
        private RAM ram = new RAM();
        // used to compile User string to Cleaned Instruction[]. This confirms the program is valid before trying to compile the code in technically correct CPU assembly translation 
        public Compiler Compiler = new Compiler();

        public enum Instructions : byte
        {
            //enum number integer can be converted to represent binary value
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
            //switches on the enum byte value automatically allotted to each Instruction Tag in the enum above
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
        
        //As the Form must Compile before executing Run, the Main Entrance of Run doesnt need to Compile the code but simply Fillram
        /*---------------------------------------- Run ------------------------------------------------
        |  BREAKDOWN
        |
        |----> FillRam() Takes Compiled Version of List
        |
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
            FillRam(); 
            
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
                CurrentState = Execute(InstructionToExecute);
                halted = CheckHalted();
            }
        }

        private bool CheckHalted()
        {
            return CurrentState.PC.content < 0;
        }

        //use compiled version of assembly program to correctly store all values of program into RAM 
        public void FillRam()
        {
            
            int index = 0;
            foreach (var instruction in Compiler.CompUProg_Instructions)
            {
                // for every instruction in the compiled program, fill 
                ram.Memory[index] = (byte)instruction.Tag;
                index++;
                
                foreach (var argument in instruction.args)
                {
                    ram.Memory[index] = argument.ToByte();
                    index++;
                }
            }

            
        }

        //CPU calls Instruction to access the byte representing the Instruction at the index of the Program Counter
        private byte Fetch(int index)
        {
            return ram.GetByteAt(PC.content);
        }

        // Decode returns the Instruction to be ran with the correspondent arguments decoded
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


        private CPUState Execute(Instruction instr)
        {
            //call the overriden instruction's execute command with its given arguements
            //( Could be partically more efficient with passed args but this allows easy testing
            //with my Unit testing interface for if executeInstruction works)
            var NewState = instr.executeInstruction(instr.args, CurrentState);
            return NewState;
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
        // function used in CPU constructor to generate initial values with the index at the first byte of RAM 
        private void SetUp()
        {
            //create a default Current State for the CPU to execute first instructions 
            CurrentState = new CPUState();
        }
        
        public bool Compile(string text)
        {
            var valid = false;

            try
            {
                CompileLoader(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Compile failed");
            }

            // TODO: throw an exception if this isn't a valid program


            return valid;
        }
        public void CompileLoader(string text)
        {
            try
            {
                /*split the string representing the content of the textbox into string[]
                 By looking for the new line character*/
                var program = new List<string>(text.Split('\n'));
                Trace.WriteLine($"Start Compiling: [{text}] into {Compiler.StringProgram.Count} instructions");
                Compiler.fullCompile( program );
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
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

        public byte[] Memory = { };
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


        private List<string> FormRamDisplay_Convert()
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
        
        public List<string> StringProgram = new List<string>();
        public Instruction[] CompUProg_Instructions = { };

        public void fullCompile( List<string> program )
        {
            StringProgram = program;

            CleanseStringProg( program );
            Trace.WriteLine($"removed blank space: to {StringProgram.Count} instructions");

           CompUProg_Instructions = Valid(StringProgram);
        }
        //Cleanse() used for removing all lines comprised of blank characters (blank line) 
        public void CleanseStringProg( List<string> StringsProg )
        {
            var temporary = new List<string>();
            //foreach line in s
            foreach (var line in StringsProg)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    temporary.Add(line);
                }
            }
            StringProgram = temporary;
        }

        //checks if valid format, called after cleanse
        public Instruction[] Valid(List<string> program)
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
            var tokens = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var instruction = tokens[0];
                var args = new List<string>();
                // iterate through all seperated tokens 
                for (var i = 1; i < tokens.Length; i++)
                {
                    var token = tokens[i];
                    // we have split on whitespace, but we need to split on comma too. this may lead a token to become multiple tokens 
                    var strings = token.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    //for every new token add to argument array
                    foreach (var s in strings) args.Add(s);
                }
                
                CPU.Instructions instrType;
                Enum.TryParse(instruction, out instrType);
                var parsed = CPU.newInstruction(instrType);
                switch (instruction)
                {
                    case "HALT":
                    {
                        //special case stop execution return to edit state 
                        parsed = new Halt();
                        break;
                    }
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


                    default: throw new Exception($"Unknown instruction: {instruction}");
                }

                // now add the arguments to the instruction:
                Instruction.addParsedArgs(parsed, args);
                return parsed;
        }
    }

//----------------------------------------Class of user interactable Registers  ------------------------------------------------

/*basic class of a register. As a register can store either a string or integer I have
 created a parent class that can be inherited for both basic and special registers */
    public abstract class Register
    {
        //display name of Register Instance
        protected string name;
// TODO give an ID (byte value)
        //determines if Assembly language is allowed or integers. useful to determine what data type the content is
        // doesnt have to be passed as a parameter as child class influences assAllowed value
        protected bool assAllowed;
        protected object content;

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
        
        // the SpecialPurpose Register array contains all required data for immediate execution and testing of any instruction
        // needs to be public so any index in arrays can be quickly accessed for both Instruction classes and Test Console
        
        // Program Counter
        public IntReg PC;

        // Memory Address Register
        public CodeReg MAR;

        // Memory Data Register
        public IntReg MDR;

        //Accumulator
        public IntReg ACC;

        //Current Instruction Register
        public CodeReg CIR;

        // Memory Buffer Register 
        public IntReg MBR;
            
        public IntReg[] Basic;

        public CPUState()
        {
            PC = new IntReg("PC", 0);
            MAR = new CodeReg("MAR", "");
            MDR = new IntReg("MDR", 0);
            ACC = new IntReg("ACC", 0);
            CIR = new CodeReg("CIR", "");
            MBR = new IntReg("MBR", 0);
            Basic = new IntReg[6];
            for (int i = 0; i < Basic.Length; i++)
            {
                Basic[i] = new IntReg($"R{i}", 0);
            }
        }

        public CPUState Copy()
        {
            var cpuState = new CPUState();
            cpuState.PC.content = PC.content; 
            cpuState.MAR.content = MAR.content; 
            cpuState.MDR.content = MDR.content; 
            cpuState.ACC.content = ACC.content; 
            cpuState.CIR.content = CIR.content; 
            cpuState.MBR.content = MBR.content;
            for (int i = 0; i < Basic.Length; i++)
            {
                cpuState.Basic[i].content = Basic[i].content;
            }
            return cpuState;
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