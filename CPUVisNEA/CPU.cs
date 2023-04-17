using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

//https://resources.jetbrains.com/storage/products/rider/docs/Rider_default_win_shortcuts.pdf?_gl=1*8v6mpv*_ga*Mzk0Njg2ODg3LjE2NjExMDU4MzA.*_ga_9J976DJZ68*MTY3NTAyNjgxNS4xNy4wLjE2NzUwMjY4MjAuMC4wLjA.&_ga=2.77451923.725299765.1675026816-394686887.1661105830

namespace CPUVisNEA
{
    //----------------------------------------Main Class CPU------------------------------------------------
    // CPU acts as the main class that operates as the main bulk of class interactions and back end code

    public class CPU
    {
        private readonly Dictionary<string, int> LabelToRamIndex = new Dictionary<string, int>();

        // readonly variable for me to modify in case more or less registers are needed for testing, final code, adjustments etc.
        private static readonly int NumberOf_BasicRegisters = 10;

        // Normal User interactable Registers in a Computer
        private Register[] BasicRegisters;

        private int PCNonBranchIncriment = 0;


        // public for CPU User Interface to have access to Current State and History
        // this allows it to output to the simple and detailed FDE Log
        public List<CPUState> History = new List<CPUState>();
        public CPUState CurrentState;

        public RAM ram = new RAM();

        // used to compile User string to Cleaned Instruction[]. This confirms the program is valid before trying to compile the code in technically correct CPU assembly translation 
        public Compiler Compiler = new Compiler();
        public string NextDetailedFDELog;

        public enum Instructions : byte
        {
            //enum number integer can be converted to represent binary value
            HALT,
            OUT,
            LDR,
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
            LSR
        }

        //switch case that takes a enum from Instructions and translates it to a new instance of a correspondent Instruction class 
        public static Instruction newInstruction(Instructions instr)
        {
            //switches on the enum byte value automatically allotted to each Instruction Tag in the enum above
            switch (instr)
            {
                case Instructions.HALT:
                    return new Halt();
                case Instructions.OUT:
                    return new Out();
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
                case "IntegerArg":
                    return new IntegerArg(ByteFormOfContent);
                case "LineLabel":
                    return GetNewLabelDetails(ByteFormOfContent);
                default:
                    throw new Exception($"Invalid Argument Type {ArgType.Name}\n\n ");
            }
        }

        private LineLabel GetNewLabelDetails(int TargetLocation)
        {
            //whilst this looping method has Time Complexity O( n ), labelsDictionary has a very limited size and hence will be efficient enough to search through
            var labelTag = LabelToRamIndex.FirstOrDefault(x => x.Value == TargetLocation).Key;
            if (labelTag == null) MessageBox.Show("Ram to Instruction Execute - Branch label not found");
            var LabelToAdd = new LineLabel(labelTag);
            LabelToAdd.LabelDestination = TargetLocation;
            return LabelToAdd;
        }


        /*---------------------------------------- Run ------------------------------------------------
        This run is void and not used by the program. This was a console applicable run that works with NUnit testing interface and debug window
        This is the function that is used to construct the more complex Run method used for Forms in the CpuUI class which builds off the form class
        |  BREAKDOWN
        |----> SetUpFresh() Resets all used variables called by Run() 
        |----> FillRam() Takes Compiled Version of User Program and stores in RAM class
        
        |----> whilst not halted repeat
        |----> FDE cycle console outputs build up over Fetch Decode Execute Instructions
        |----> FDECycle()  ( Preforms 1 full cycle of Fetch Decode Execute CPU Cycle )
        |--------->  Fetch() 
        |-------------->  access RAM class and retrieve the memory index at Program Counter
        |--------->  Decode()
        |-------------->  Decode byte value and create Instruction
        |-------------->  Check how many arguments Instruction takes
        |-------------->  Retrieve and append parameters to Instruction
        |--------->  Execute()
        |-------------->  ExecuteInstruction()
        |-------------->  Add new CPUState to History 
        |----> CheckHalted() 
        
        */

        //this was a console based run for the Nunit test console 
        public void Run()
        {
            //set up and refresh all variables for new Run Command
            SetUpFresh();
            FillRam();

            // stop execution if Halt is called
            do
            {
                FDECycle(); // Complete 1 cycle
            } while (!CheckHalted());
        }

        public void FDECycle()
        {
            // reset next FDE log variable 
            NextDetailedFDELog = "";
            // Searches from index in RAM for next Instruction
            // calls Display Fetch Log
            var FetchedInstruction = Fetch(CurrentState.PC.content);
            //todo add into fetch
            NextDetailedFDELog +=
                $"\n----------------\n   Fetch\n----------------\n CPU fetches byte from memory at address index of MAR value {CurrentState.PC.content}\nThe value returned ({FetchedInstruction}) is stored in MDR.";
            // Checks How many Parameters Required
            // calls ParameterFetch() to get Parameters
            // Incriments Program Counter 
            // Adds the Decode section of FDe cycle with FDE
            var InstructionToExecute = Decode(FetchedInstruction);

            NextDetailedFDELog +=
                $"\n----------------\n   Execute\n----------------\nExecuting {InstructionToExecute.Tag} with parameters: {string.Join(", ", InstructionToExecute.args.Select(arg => $"{arg.name}"))}";

            try
            {
                CurrentState = Execute(InstructionToExecute);
                NextDetailedFDELog += $"\n{CurrentState.DetailedChangeLog[0]}";
                //FDE_Add message written in full details for individual FDE Cycle to add to complex FDE log
                Trace.WriteLine(NextDetailedFDELog);
            }
            catch (Exception ex)
            {
                throw new Exception($" Failed to execute {InstructionToExecute} \n error : {ex}");
            }


            //add to the CPU History
            History.Add(CurrentState);
        }

        public bool CheckHalted()
        {
            return CurrentState.PC.content < 0;
        }

        //use compiled version of assembly program to correctly store all values of program into RAM 
        public void FillRam()
        {
            // write the program as bytes in ram
            var index = 0;
            foreach (var instruction in Compiler.CompUProg_Instructions)
            {
                // for every instruction in the compiled program, fill RAM index with instruction signiture 
                ram.Memory.Add((byte)instruction.Tag);
                ram.InstructionLocations[instruction] = index;
                //increment and for each argument of instruction store operand and increment again
                index++;
                foreach (var argument in instruction.args)
                {
                    ram.Memory.Add(argument.ToByte());
                    index++;
                }
            }

            // fill in all branch targets to Ram after full compile analyses and records any ppotentail branch locations
            foreach (var instruction in Compiler.CompUProg_Instructions)
                if (instruction.GetType().IsSubclassOf(typeof(Branch)))
                {
                    var firstArg = instruction.args[0];
                    var label = (LineLabel)firstArg;
                    var jumpTarget = Compiler.LabelledInstructions[label.name];
                    var jumpLocation = ram.InstructionLocations[jumpTarget];
                    LabelToRamIndex.Add(label.name, jumpLocation);
                    ((LineLabel)instruction.args[0]).LabelDestination = jumpLocation;
                    ram.Memory[ram.InstructionLocations[instruction] + 1] = instruction.args[0].ToByte();
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
                /* TypeAndByteToArg creates a new Argument the Argtype to indicate the subclass of Argument and accesses
                 the ram to retrieve the byte at the index of instruction incrimented by the parameter number dsd representing the Arg's content
                */
                var FilledArg = TypeAndByteToArg(ArgType, ram.GetByteAt(CurrentState.PC.content + i + 1));
                TargetInstruction.addArg(FilledArg);

                //incrementing the Program counter by number of bytes used to store parameters to access the next instruction assuming no branch condition
            }

            NextDetailedFDELog +=
                $"\n----------------\n   Decode\n----------------\n CPU decodes MDR {BinaryInstruction} as a {TargetInstruction.Tag} Instruction, assigned to CIR. {parameters} parameters required. \n CPU Fetches parameters from Memory Indexes {CurrentState.PC.content + 1} to {CurrentState.PC.content + parameters + 1}";
            //if not a halt instruction
            if (parameters > 0)
                CurrentState.PC.content += parameters + 1;
            return TargetInstruction;
        }

        private int GetNumberOfParameters(Instruction TargetInstruction)
        {
            int parameters;
            parameters = TargetInstruction.NumberOfParameters();
            return parameters;
        }


        private CPUState Execute(Instruction instr)
        {
            //call the overriden instruction's execute command with its given arguements
            //( Could be partically more efficient with passed args but this allows easy testing
            //with my Unit testing interface for if executeInstruction works)

            var NewState = CurrentState.Copy();
            NewState.MAR = NewState.PC;
            try
            {
                if (NewState.MAR.content < ram.Memory.Count)
                    NewState.MDR.content = $"{ram.Memory[NewState.MAR.content]}";
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $" index {NewState.MAR.content} of Ram Memory count {ram.Memory.Count} caused error : {ex}");
            }


            NewState.CIR.content = $"{instr.Tag}";
            NewState = instr.executeInstruction(instr.args, NewState);
            return NewState;
        }

        // function used in CPU constructor to generate initial values with the index at the first byte of RAM 
        // set public to help with Nunit tests ans CPU User Interface access
        public void SetUpFresh()
        {
            /* Reset everything to fresh : 
             CurrentState
             History
             Ram
             LabelToRam Dictionary*/

            CurrentState = new CPUState();
            History = new List<CPUState>();
            ram = new RAM();
            LabelToRamIndex.Clear();
        }

        public bool Compile(string text)
        {
            var valid = false;

            try
            {
                /*split the string representing the content of the textbox into string[]
                 By looking for the new line character*/
                var program = new List<string>(text.Split('\n'));

                Trace.WriteLine($"Start Compiling: [ '\n'{text}'\n']");
                Compiler.fullCompile(program);
                //
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Compile failed: {ex}");
                //all exceptions that are accounted for finish with \n\n
                var errorMsgWithoutCallStack = ex.Message.Substring(0, ex.Message.IndexOf("\n\n"));
                //show a Message box that displays the contextual error without details user doesnt need to see
                MessageBox.Show($"Encountered error whilst Compiling :{errorMsgWithoutCallStack}", "Assembly Invalid");
                return false;
            }
        }

        //used by testing Console and main program
        public CPU()
        {
            SetUpFresh();
        }
    }
    //----------------------------------------Random Access Memory Class - Compiling methods ------------------------------------------------

    public class RAM
    {
        // Memory stores the byte representation of the User's assembely script
        public List<byte> Memory = new List<byte>();

        // whilst not used by program or CpuUI, this can be used by the NUnit for testing the compiled program directly without using FDE method
        private Instruction[] AssembelyProgram;

        // Dictionary is used with the Compiler class' LabelledInstructions to connect Labels to RAM indexes in the CPU class
        public Dictionary<Instruction, int> InstructionLocations = new Dictionary<Instruction, int>();
        private bool binaryMode;

        //Local Convert function in RAM class to completely translate the users program displayed in RAm between its binary representation
        //and its assembly language representation. This is completed by checking the local class variable binaryMode to
        //select the direction on conversion - binary to Assembly ( Bin2Ass() ) or Assembly to binary ( Ass2Bin() ) 

        //this is useful so students can see what is being held in RAM as values they can read and understand

        internal byte GetByteAt(int index)
        {
            if (index > -1)
                return Memory[index];
            throw new Exception($"Index {index} invalid memory index \n\n");
        }
    }

    public class Compiler
    {
        // 
        public List<string> StringProgram = new List<string>();

        public List<Instruction> CompUProg_Instructions = new List<Instruction>();

        // Dictionary is used with the RAM class' InstructionLocations to map Labels to RAM indexes in the CPU class
        // maps a Dictionary of Label names to correct Instruction index in CompUProg_Instructions
        public Dictionary<string, Instruction> LabelledInstructions = new Dictionary<string, Instruction>();


        public void fullCompile(List<string> program)
        {
            StringProgram = program;

            CleanseProg(program);
            Trace.WriteLine($"removed blank space: to {StringProgram.Count} instructions");
            CompUProg_Instructions = Valid(StringProgram);
            // now resolve labels
            for (var i = 0; i < CompUProg_Instructions.Count; i++)
            {
                var maybeBranch = CompUProg_Instructions[i];
                //if any subclass of branch, assign branch label value 
                if (maybeBranch.GetType().IsInstanceOfType(typeof(Branch)))
                {
                    // branch instructions need to know where their label points to
                    var target = (LineLabel)maybeBranch.args[0];
                    if (!LabelledInstructions.ContainsKey(target.name))
                        throw new Exception($"Label: {target.name} not defined\n\n");
                }
            }
        }

        //Cleanse() used for removing all lines comprised of blank characters (blank line) 
        public void CleanseProg(List<string> StringsProg)
        {
            var tempProg = new List<string>();

            var line = "";
            //foreach line in s
            for (var i = 0; i < StringsProg.Count; i++)
            {
                line = StringsProg[i];
                if (!string.IsNullOrWhiteSpace(line)) tempProg.Add(line);
            }

            StringProgram = tempProg;
        }

        //checks if valid format, called after cleanse
        public List<Instruction> Valid(List<string> program)
        {
            var InstrArray = new List<Instruction>();
            // foreach line in user script try translate to instruction. If fialed throw the contextualised exception up to compile
            foreach (var line in program)
                try
                {
                    //linearly iterate through Program and add correspondent Instruction to array of instruction with parameters
                    var nextInstr = lineToInstruction(line);
                    InstrArray.Add(nextInstr);
                    if (nextInstr.Label != null) LabelledInstructions.Add(nextInstr.Label, nextInstr);
                }
                catch (Exception ex)
                {
                    throw new Exception($"\nFailed to Compile line {InstrArray.Count + 1} : {line}\n{ex} ");
                }

            return InstrArray;
        }

        // takes a single string line and outputs the equivalent Instruction to append to an Instruction[]
        public Instruction lineToInstruction(string line)
        {
            // split on whitespace and comma means split whitespace
            var tokens = line.Split(new[] { ' ', '\t', '\n', '\r', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string label = null;
            string instruction = null;
            var args = new List<string>();
            // iterate through all seperated tokens 
            for (var i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                if (i == 0 && token.EndsWith(":"))
                    label = token.Remove(token.Length - 1);
                else if (instruction == null)
                    instruction = token;
                else
                    // not a label or an instruction so it must be an arg
                    args.Add(token);
            }

            CPU.Instructions instrType;
            //try to assign instrType by instruction if valid 
            Enum.TryParse(instruction, out instrType);
            //if returns false, throw exception of invalid instruction instead of creating new instruction
            if (!Enum.TryParse(instruction, out instrType))
                throw new Exception($"Invalid Instruction name : {instruction}\n\n ");
            var parsed = CPU.newInstruction(instrType);
            if (label != null) parsed.Label = label;

            // now try add the arguments to the instruction. 
            // this is done by passing the list of string arguments and instruction 
            Instruction.addParsedArgs(parsed, args);

            return parsed;
        }
    }

//----------------------------------------Class of user interactable Registers  ------------------------------------------------

/*basic class of a register. As a register can store either a string or integer I have
 created a parent class that can be inherited for both basic and special registers 
 Used both for General and Special Purpose Registers*/

    public abstract class Register
    {
        //display name of Register Instance
        protected string Name;

        //determines if Assembly language is allowed or integers. useful to determine what data type the content is
        // doesnt have to be passed as a parameter as child class influences assAllowed value
        protected bool AssAllowed;
        protected object Content;

        //protected constructor so inherited classes can use class
        //by using content as an object, this allows different registers to assign strings or integers to content as seen below
        protected Register(string name, object content)
        {
            Name = name;
            Content = content;
        }
    }

    //class for Integer only registers that hold opcode values
    public class IntReg : Register
    {
        internal int content;

        public IntReg(string name, int content) : base(name, content)
        {
            AssAllowed = false;
            this.content = content;
        }
    }

    //class for Assembly opcode only registers that hold opcode values
    public class CodeReg : Register
    {
        internal string content;

        public CodeReg(string name, string content) : base(name, content)
        {
            AssAllowed = true;
            this.content = content;
        }
    }

    // holds a snapshot of a CPU's state. It is the parameter and return type for an Execution Statemen
    public class CPUState
    {
        // the SpecialPurpose Register array contains all required data for immediate execution and testing of any instruction
        // needs to be public so any index in arrays can be quickly accessed for both Instruction classes and Test Console
        public List<string> changeLog = new List<string>();

        public List<string> DetailedChangeLog = new List<string>();

        // Program Counter
        public IntReg PC;

        // Memory Address Register
        public IntReg MAR;

        // Memory Data Register
        public CodeReg MDR;

        //Accumulator
        public IntReg ACC;

        //Current Instruction Register
        public CodeReg CIR;

        public IntReg[] Basic;

        // potentially used
        public string Outputs;

        public CPUState()
        {
            PC = new IntReg("PC", 0);
            MAR = new IntReg("MAR", 0);
            MDR = new CodeReg("MDR", "");
            ACC = new IntReg("ACC", 0);
            CIR = new CodeReg("CIR", "");
            Basic = new IntReg[10];
            for (var i = 0; i < Basic.Length; i++) Basic[i] = new IntReg($"R{i}", 0);
        }


        public CPUState Copy()
        {
            var cpuState = new CPUState();
            cpuState.PC.content = PC.content;
            cpuState.MAR.content = MAR.content;
            cpuState.MDR.content = MDR.content;
            cpuState.ACC.content = ACC.content;
            cpuState.CIR.content = CIR.content;
            for (var i = 0; i < Basic.Length; i++) cpuState.Basic[i].content = Basic[i].content;
            return cpuState;
        }
    }
}