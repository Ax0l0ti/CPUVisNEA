using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NUnit.Framework;

//https://resources.jetbrains.com/storage/products/rider/docs/Rider_default_win_shortcuts.pdf?_gl=1*8v6mpv*_ga*Mzk0Njg2ODg3LjE2NjExMDU4MzA.*_ga_9J976DJZ68*MTY3NTAyNjgxNS4xNy4wLjE2NzUwMjY4MjAuMC4wLjA.&_ga=2.77451923.725299765.1675026816-394686887.1661105830

namespace CPUVisNEA
{
    /* General todos 
     * ----> Make Register Dictionary SP Basic ( used to find register for given string )
     * ----> Check if direct or indirect addressing
     * ----> LABELS
     * ----> Fill InstructionLocations
     * ----> use LabelToRAMIndex, LabelledInstructions, Instruction Locations
     */


    //----------------------------------------Main Class CPU------------------------------------------------
    // CPU acts as the main class that operates as the main bulk of class interactions and back end code

    public class CPU
    {
        // Special Purpose Registers used by a CPU 
        // PC, MAR, MDR, ACC, CIR, MBR

        private Register[] SPRegisters = { /*PC, MAR, MDR, ACC, CIR, MBR*/ };
        private Dictionary<string, int> LabelToRamIndex = new Dictionary<string, int>() { };

        // readonly variable for me to modify in case more or less registers are needed for testing, final code, adjustments etc.
        private static readonly int BasicRegisterNumber = 10;
        // Normal User interactable Registers in a Computer
        private Register[] BasicRegisters;

        private int PCNonBranchIncriment = 0;
        
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
                    return new B();
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
                case "IntegerArg":
                    return new IntegerArg(ByteFormOfContent);
                    break;
                case "Label":
                    return new Label("Test" /*VFat todo*/ );
                    break;
                default:
                    throw new Exception($"Invalid Type {ArgType.Name} ");
            }
        }
        
        //As the Form must Compile before executing Run, the Main Entrance of Run doesnt need to Compile the code but simply Fillram
        /*---------------------------------------- Run ------------------------------------------------
        |  BREAKDOWN
        |----> SetUp() Sets a default for Current CPU state
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
            SetUp();
            FillRam();

            var halted = false;
            while (!halted)
            {
                // Searches from index in RAM for next Instruction
                // calls Display Fetch Log

                var FetchedInstruction = Fetch(CurrentState.PC.content);
                
                // Checks How many Parameters Required
                // calls ParameterFetch() to get Parameters
                // Incriments Program Counter 
                // calls Display Decode Log
                

                var InstructionToExecute = Decode(FetchedInstruction);
                
                CurrentState = Execute(InstructionToExecute);
                //add to the CPU History
                History.Add(CurrentState);
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
            // write the program as bytes in ram
            int index = 0;
            foreach (var instruction in Compiler.CompUProg_Instructions)
            {
                // for every instruction in the compiled program, fill RAM index with instruction signiture 
                //todo appemnds??? or byte List
                ram.Memory[index] = (byte)instruction.Tag;
                ram.InstructionLocations[instruction] = index;
                //increment and for each argument of instruction store operand and increment again
                index++;
                foreach (var argument in instruction.args)
                {
                    ram.Memory[index] = argument.ToByte();
                    index++;
                }
            }
            // fill in branch targets
            foreach (var instruction in Compiler.CompUProg_Instructions)
            {
                if (instruction.GetType().IsInstanceOfType( typeof(Branch)))
                {
                    var firstArg = instruction.args[0];
                    var label = (Label)firstArg;
                        var jumpTarget = Compiler.LabelledInstructions[label.name];
                        var jumpLocation = ram.InstructionLocations[jumpTarget];
                        label.location = jumpLocation;
                }
            }
            
        }

        //CPU calls Instruction to access the byte representing the Instruction at the index of the Program Counter
        private byte Fetch(int index)
        {
            return ram.GetByteAt(index);
        }

        // Decode returns the Instruction to be ran with the correspondent arguments decoded
        public Instruction Decode(byte BinaryInstruction)
        {
            //Convert the bina
            var InstructionInt = Convert.ToInt32(BinaryInstruction);

            var TargetInstruction = newInstruction((Instructions)InstructionInt);
            var parameters = GetNumberOfParameters(TargetInstruction);
            
            // start at the index after Instruction RAM index and iterate for all parameters
            for (var i = 0; i < parameters; i++)
            {
                //use the Instruction class to retrieve the required type of arg at parameter index i 
                var ArgType = TargetInstruction.GetReqArgType(i);
                //Instanciate a new instance of the specific Argument 
                // this uses the Argtype to indicate the subclass of Argument and accesses the ram to retrieve the byte representing the Arg's content
                if (ArgType.GetType() == typeof(Label))
                {
                    //FilledArg = GetNewLabelDetails();
                }
                var FilledArg = TypeAndByteToArg(ArgType, ram.GetByteAt(CurrentState.PC.content + i));
                TargetInstruction.addArg(FilledArg);

                //incrementing the Program counter by number of bytes used to store parameters to access the next instruction assuming no branch condition
            }

            PCIncriment( parameters );

            return TargetInstruction;
        }

        private int GetNumberOfParameters(Instruction TargetInstruction)
        {
            var parameters = 0;
            parameters = TargetInstruction.NumberOfParameters();
            return parameters;
        }

        /* todo private Label GetNewLabelDetails()
        {
            return n;
        } */
        
        private void PCIncriment( int parameters)
        {
            /* increment the Program Counter by 1 for instruction and all parameters for next execution
             However a branch command will overwrite this Increment to the branched location*/
            CurrentState.PC.content =+ parameters + 1;
        }


        private CPUState Execute(Instruction instr)
        {
            //call the overriden instruction's execute command with its given arguements
            //( Could be partically more efficient with passed args but this allows easy testing
            //with my Unit testing interface for if executeInstruction works)
            
            var NewState = instr.executeInstruction(instr.args, CurrentState.Copy());
            
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
        //todo check if fills Memory
        public bool Compile(string text)
        {
            var valid = false;

            try
            {
                /*split the string representing the content of the textbox into string[]
                 By looking for the new line character*/
                var program = new List<string>(text.Split('\n'));
                //todo label mapping
                
                Trace.WriteLine($"Start Compiling: [ '\n'{text}'\n']");
                Compiler.fullCompile( program );
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Compile failed: {ex}");
                MessageBox.Show($"Compile failed {ex} ");
            }
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
        public byte[] Memory = new byte[256] ;
        private Instruction[] AssembelyProgram = { };
        public Dictionary<Instruction, int> InstructionLocations = new Dictionary<Instruction, int>() ;
        private bool binaryMode;

        //Local Convert function in RAM class to completely translate the users program displayed in RAm between its binary representation
        //and its assembly language representation. This is completed by checking the local class variable binaryMode to
        //select the direction on conversion - binary to Assembly ( Bin2Ass() ) or Assembly to binary ( Ass2Bin() ) 

        //this is useful so students can see what is being held in RAM as values they can read and understand

        internal byte GetByteAt(int index)
        {
            return Memory[index];
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
        
        public List<Instruction> CompUProg_Instructions = new List<Instruction>() ;
        // maps a Dictionary of Label names to correct Instruction index in CompUProg_Instructions
        public Dictionary<string, Instruction> LabelledInstructions = new Dictionary<string, Instruction>();



        public void fullCompile( List<string> program)
        {
            StringProgram = program;

            CleanseProg(program);
            Trace.WriteLine($"removed blank space: to {StringProgram.Count} instructions");
            CompUProg_Instructions = Valid(StringProgram);
            // now resolve labels
            for (int i = 0; i < CompUProg_Instructions.Count; i++)
            {
                var maybeBranch = CompUProg_Instructions[i];
                //if any subclass of branch, assign branch label value 
                if (maybeBranch.GetType().IsInstanceOfType(typeof(Branch)))
                {
                    // branch instructions need to know where their label points to
                    Label target = (Label)maybeBranch.args[0];
                    if (!LabelledInstructions.ContainsKey(target.name))
                    {
                        throw new Exception($"Label: {target.name} not defined");
                    }
                }
            }
        }
        //Cleanse() used for removing all lines comprised of blank characters (blank line) 
        public void CleanseProg(List<string> StringsProg)
        {
            var tempProg = new List<string>();

            string line = "";
            //foreach line in s
            for (int i = 0; i < StringsProg.Count; i++)
            {
                line = StringsProg[i];
                if (!string.IsNullOrWhiteSpace(line))
                {
                    tempProg.Add(line);
                }
            }
            StringProgram = tempProg;

        }

        //checks if valid format, called after cleanse
        public List<Instruction> Valid(List<string> program)
        {
            List<Instruction> InstrArray = new List<Instruction>() ;
            foreach (var line in program)
            {
                //linearly iterate through Program and add correspondent Instruction to array of instruction with parameters
                var nextInstr = lineToInstruction(line);
                InstrArray.Add(nextInstr);
                if (nextInstr.Label != null)
                {
                    LabelledInstructions.Add(nextInstr.Label, nextInstr);
                }
            }
// TODO: now for any instuction with an arg that is a jump label, make sure you can find it in the dictionary
            return InstrArray;
        }


        public Instruction lineToInstruction(string line)
        {
            // split on whitespace and comma means split whitespace
            var tokens = line.Split(new char[]{' ','\t', '\n', '\r', ','}, StringSplitOptions.RemoveEmptyEntries);
            String label = null;
            String instruction = null;
            var args = new List<string>();
            // iterate through all seperated tokens 
            for (int i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                if (i == 0 && token.EndsWith(":"))
                {
                    label = token.Remove(token.Length-1);
                } else if (instruction == null)
                {
                    instruction = token;
                }
                else
                {
                    // not a label or an instruction so it must be an arg
                    args.Add(token);
                }
            }
            CPU.Instructions instrType;
            Enum.TryParse(instruction, out instrType);
            var parsed = CPU.newInstruction(instrType);
            if (label != null)
            {
                parsed.Label = label;
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
        //todo create list of changes
        // the SpecialPurpose Register array contains all required data for immediate execution and testing of any instruction
        // needs to be public so any index in arrays can be quickly accessed for both Instruction classes and Test Console
        public List<string> changeLog = new List<string>();

        public List<string> DetailedChangeLog = new List<string>();
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