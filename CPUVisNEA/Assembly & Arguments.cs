using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace CPUVisNEA
{
    //---------------------------------------- Argument classes ------------------------------------------------
    /*
    //HALT 
    //B <Label>
    //B<condition> <Label> ( BGT BLT BEQ BNE )
    //MOV RegisterArg, IntegerArg
    //CMP RegisterArg, IntegerArg
    //MVN RegisterArg, IntegerArg
    //Out RegisterArg
    //LDR RegisterArg, RegisterArg
    //AND RegisterArg, RegisterArg, IntegerArg
    //ORR RegisterArg, RegisterArg, IntegerArg
    //EOR RegisterArg, RegisterArg, IntegerArg
    //LSL RegisterArg, RegisterArg, IntegerArg
    //LSR RegisterArg, RegisterArg, IntegerArg
    //ADD RegisterArg, RegisterArg, IntegerArg
    //SUB RegisterArg, RegisterArg, IntegerArg
    */
    public abstract class Argument
    {
        protected internal string Name;
        protected int Value;


        //all arguments have an integer Value to return. This allows contextualised Returns for each child class
        protected internal virtual int RetInt()
        {
            // whilst it can be inherited, it should never be an basic argument
            //if not a child class and using non overridden method, then throw an error
            throw new Exception("Argument not cast, still basic Argument class");
        }

        // this doesnt need context and is used whilst filling the Ram class after a valid compile
        protected internal virtual byte ToByte()
        {
            return (byte)Value;
        }
    }

    public class RegisterArg : Argument
    {
        // requires index of register before calling to CPU to retrieve value of target
        public int index;

        //no byteLength required as all register values only go up to 10 hence only one byte needed 
        // string parameter constructor to test compile register Argument
        public RegisterArg(string StringArg)
        {
            // from is R(index) or r(index) to allow for user Mistakes. Hence Memory Index is string minus first index of string 
            index = int.Parse(StringArg.Remove(0, 1));
            Name = $"R{index}";
            Value = index;
        }

        //second constructor for FDE Cycle retrieving from RAM 
        public RegisterArg(byte ByteForm)
        {
            index = Convert.ToInt32(ByteForm);
            Name = $"R{index}";
        }

        protected internal override byte ToByte()
        {
            return (byte)index;
        }

        protected internal override int RetInt()
        {
            return index;
        }
    }

    public class IntegerArg : Argument
    {
        public int value;
        //user may need to deal with integers above 255, therefore the required value representable value must be represented by variable bytes 

        public IntegerArg(string StringArg)
        {
            value = int.Parse(StringArg.Remove(0, 1));
            Name = $"{value}";
            //byte length isn't a parameter as it can be worked out from value
        }

        public IntegerArg(byte ByteForm)
        {
            value = Convert.ToInt32(ByteForm);
            Name = $"{value}";
        }

        protected internal override byte ToByte()
        {
            return (byte)value;
        }

        protected internal override int RetInt()
        {
            return value;
        }
    }

    public class LineLabel : Argument
    {
        public int LabelDestination;

        public LineLabel(string name)
        {
            Name = name;
        }

        public int Location
        {
            get => LabelDestination;
            set => LabelDestination = value;
        }

        protected internal override byte ToByte()
        {
            return (byte)LabelDestination;
        }

        protected internal override int RetInt()
        {
            return LabelDestination;
        }
    }


    //----------------------------------------Instruction classes and generation------------------------------------------------


    public abstract class Instruction
    {
        //protected so all inherited classes have args attributes 
        // internal so TestConsole can access Instruction child class' args
        protected internal List<Argument> args = new List<Argument>(); //list of instruction arguments
        protected string label;
        public CPU.Instructions Tag { get; } //use enum to get Tag ( instruction name ) 

        //sets instruction tag automatically to new instance of an Instruction class or child classes
        protected Instruction(CPU.Instructions tag)
        {
            Tag = tag;
        }

        public string Label
        {
            get => label;
            set => label = value;
        }

        //contains set of CPU.Instructions that correspond to an appropriate layout of Parameters 
        protected internal static Dictionary<CPU.Instructions[], Type[]> dictionaryOfValidParams =
            new Dictionary<CPU.Instructions[], Type[]>
            {
                //MOV CMP MVN 
                // acts on a register with integer e.g stores / compares 
                {
                    new[]
                    {
                        CPU.Instructions.MOV, CPU.Instructions.CMP, CPU.Instructions.MVN
                    },
                    new[] { typeof(RegisterArg), typeof(IntegerArg) }
                },
                //LDR
                // assigns Register same value from another register
                {
                    new[]
                    {
                        CPU.Instructions.LDR
                    },
                    new[] { typeof(RegisterArg), typeof(RegisterArg) }
                },
                //OUT
                //not a valid Instruction of AQA assembly Language - However acts as valuable asset for User Requested Console Outputs
                {
                    new[]
                    {
                        CPU.Instructions.OUT
                    },
                    new[] { typeof(RegisterArg) }
                },
                //LSL LSR
                // assigns register based on Binary shifts of existing register by 0 
                {
                    new[]
                    {
                        CPU.Instructions.LSL, CPU.Instructions.LSR
                    },
                    new[] { typeof(RegisterArg), typeof(RegisterArg), typeof(IntegerArg) }
                },
                // AND ORR EOR ADD SUB 
                // assign register based on an action to a register via another variable ( Register input ) 
                // e.g arithmetic or boolean addition with 2 Registers - assign result to a register 
                {
                    new[]
                    {
                        CPU.Instructions.AND, CPU.Instructions.ORR, CPU.Instructions.EOR, CPU.Instructions.ADD,
                        CPU.Instructions.SUB
                    },
                    new[] { typeof(RegisterArg), typeof(RegisterArg), typeof(RegisterArg) }
                },
                // doesnt accept any additional text or parameters to statement
                //B >> acts for all branches
                {
                    new[]
                    {
                        CPU.Instructions.B, CPU.Instructions.BEQ, CPU.Instructions.BLT, CPU.Instructions.BNE,
                        CPU.Instructions.BGT
                    },
                    new[] { typeof(LineLabel) }
                }
            };


        //add Parsed Argument takes takes the instruction its a
        public static void addParsedArgs(Instruction instruc, List<string> StringArguments)
        {
            //for each argument, create a new correspondent instance of argument type
            foreach (var StringArg in StringArguments) instruc.addArg(GenerateArg(StringArg));
            //line for debugging
            Trace.WriteLine($"successfully passed all {instruc.Tag} arguments");
        }

        protected internal static Argument GenerateArg(string argumentStringForm)
        {
            //switch case assigns argumentStringForm to s before checking if the temporary variable s is a match with any argument regex expressions
            //if it is a match, then it returns the required the type of child class required for the argument 
            //if there are no matches, it returns an error message
            switch (argumentStringForm)
            {
                // Integer Argument - # followed by 1 or more digits
                case var _ when Regex.IsMatch(argumentStringForm, "^#(\\d)*$"):
                    return new IntegerArg(argumentStringForm);
                // Register Argument - lower or uppercase R followed by a single digit number due to indexes 0 to 9
                case var _ when Regex.IsMatch(argumentStringForm, "^(R|r)\\d$"):
                    return new RegisterArg(argumentStringForm);
                // Label argument - any number of word characters
                case var _ when Regex.IsMatch(argumentStringForm, "^(\\w)*$"):
                    return new LineLabel(argumentStringForm);

                default:
                    throw new Exception(
                        $"\"{argumentStringForm}\" does not match any of the specified regexes for arguments");
            }
        }
        /*Checks if the argument passed is a valid argument to be passed to the instruction
        -- protected and stored in Instruction class so all child classes can inherit usage.
        -- internal used so the Console interface can access the method */
        protected internal void addArg(Argument arg)
        {
            ArgErrorThrow(arg);
            //if its a valid argument, add it to the objects Arguments list
            args.Add(arg);
            //else output error saying the argument type cant be used as the nth parameter ( +1 to counter 0 first index) 
        }
        protected void ArgErrorThrow(Argument arg)
        {
            if (!validArgType(arg))
                throw new Exception(
                    $"Invalid Argument \"{arg.Name}\" for {Tag} Instruction \n(R|r before registers and # before values)\n\n");
        }

//finds the Type of argument required for an Instruction at ArgIndex
       /*(whilst this method of solving the problem creates a public dictionary that takes up storage, 
        it vastly reduces number of repetitive methods and lines in the following child classes and programs 
        due to repetitive format of Instruction Parameters */
       public Type GetReqArgType(int ArgIndex)
        {
            //linear search through dictionary to find a correspondent tag in key
            foreach (var InstructGrouping in dictionaryOfValidParams)
                //if the key array contains the Instruction Tag
                if (InstructGrouping.Key.Contains(Tag))
                    // return the required type for an argument at the tag's nth index 
                    return InstructGrouping.Value[ArgIndex];
            return null;
        }

        

        protected internal bool validArgType(Argument arg)
        {
            //linear search through dictionary
            foreach (var InstructGrouping in dictionaryOfValidParams)
                //if the key array contains the Instruction Tag
                if (InstructGrouping.Key.Contains(Tag))
                    // check if Correspondent definition contains the passed argument type at index of the parameter 
                    if (arg.GetType() == InstructGrouping.Value[args.Count])
                        //therefore valid input type at index for instruction class tag
                        return true;
            return false;
        }


        //called by CPU Decode function to indicate how many bytes must be fetched to retrieve parameters
        protected internal int NumberOfParameters()
        {
            int paramCount;
            //linear search through dictionary
            foreach (var InstructGrouping in dictionaryOfValidParams)
                //if the key array contains the Instruction Tag
                if (InstructGrouping.Key.Contains(Tag))
                {
                    //retrieve the total count of parameters required, indicated by the length of the Key's array 
                    paramCount = InstructGrouping.Value.Count();
                    return paramCount;
                }

            //as compiled should eliminate all illegal tags, this should never be reached
            return 0;
        }

        // basic overridable call statement for all assembly operations to override to deal with individual arguments
        //means CPU can call executeInstruction regardless of Child class to get unique behaviour
        protected internal abstract CPUState executeInstruction(List<Argument> args, CPUState NewState);
        /*
        GENERALISED STRUCTURE 
        M
        string BasicChangeLog;
        NewState.changeLog.Add( BasicChangeLog );
        Trace.WriteLine( BasicChangeLog );
        NewState.DetailedChangeLog.Add( $"XXX instruction - {args[1].name} ... register {args[0].name} ");
        */
    }


    //---------------------------------------     HALT     Instruction ------------------------------------------------

    public class Halt : Instruction
    {
        public Halt() : base(CPU.Instructions.HALT)
        {
        }

        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //HALT Stop the execution of the program.

            NewState.PC.content = -1;
            NewState.changeLog.Add("Program Halted");
            NewState.DetailedChangeLog.Add("Program Halted");
            return NewState;
        }
    }
    
    //abstract Branch class acts as a grouping class for all Branch Instructions and inherits from the Instruction class 
    //as all variants, conditional is seperated and stored as a local attribute of the Branch statement to switch case action in execute Instruction
    public abstract class Branch : Instruction
    {
        protected string BranchFullName;

        // there are different branch types
        public Branch(CPU.Instructions bType) : base(bType)
        {
        }

        //B<condition>  <Label> Conditionally branch to the instruction at position <Label> in the program if the last comparison met the criteria specified by the <condition>.
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            return NewState;
        }
    }

//---------------------------------------     B     Instruction ------------------------------------------------
    //B <Label>
    //B class acts as an Unconditional Branch Instruction 
    public class B : Branch
    {
        public B() : base(CPU.Instructions.B)
        {
        }

        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //B <Label> Branch to the instruction at position <Label> Unconditionally
            //if Conditional Correctly Met, branch to label's indicated Memory Index 
            //Accumulator assigned temporary value of operation value
            NewState.ACC.content = ((LineLabel)args[0]).LabelDestination;
            NewState.PC.content = NewState.ACC.content;
            NewState.changeLog.Add($"Branched to {args[0].Name} ");
            Trace.WriteLine($"Branched to {args[0].Name} ");
            NewState.DetailedChangeLog.Add(
                $"{Tag} instruction - Branched to {args[0].Name} label at Memory index {NewState.PC.content} ");
            return NewState;
        }
    }

    public class Beq : Branch
    {
        public Beq() : base(CPU.Instructions.BEQ)
        {
            BranchFullName = "Equal To";
        }

        //BEQ <Label> Conditionally branch to the instruction at position <Label> in the program if the last comparison met the Equal To criteria

        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //check accumulator to find last CMP relationship
            //Accumulator Stores Last Comparison
            //EQ NE LT GT
            //0     1  2 
            //if Conditional Correctly Met, branch to label's indicated Memory Index 
            string BasicChangeLog;
            if (NewState.ACC.content == 0)
            {
                NewState.PC.content = ((LineLabel)args[0]).LabelDestination;
                BasicChangeLog = $"Branched to {args[0].Name} ";
                NewState.changeLog.Add(BasicChangeLog);
                NewState.DetailedChangeLog.Add(
                    $"{Tag} instruction - {BranchFullName} Branch Condition Met. Branched to {args[0].Name} label at Memory index {NewState.PC.content} ");
            }
            else
            {
                BasicChangeLog = $"{BranchFullName} Condition not met. ";
                NewState.changeLog.Add(BasicChangeLog);
                NewState.DetailedChangeLog.Add(
                    $"{Tag} instruction - {BranchFullName} Branch Condition was not met By Compare Statement. ");
            }

            Trace.WriteLine(BasicChangeLog);
            return NewState;
        }
    }

    // Branch if Not Equal to 
    public class Bne : Branch
    {
        public Bne() : base(CPU.Instructions.BNE)
        {
            BranchFullName = "'Not Equal To'";
        }


        //BNE <Label> Conditionally branch to the instruction at position <Label> in the program if the last comparison met the Not Equal To criteria

        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //check accumulator to find last CMP relationship
            //Accumulator Stores Last Comparison
            //EQ NE LT GT
            //0     1  2 
            //if Conditional Correctly Met, branch to label's indicated Memory Index 
            // If Content != Equal, Infer Not Equal / [ Less Than or Greater Than ]
            string BasicChangeLog;
            if (NewState.ACC.content != 0)
            {
                NewState.PC.content = ((LineLabel)args[0]).LabelDestination;
                BasicChangeLog = $"Branched to {args[0].Name} ";
                NewState.changeLog.Add(BasicChangeLog);
                NewState.DetailedChangeLog.Add(
                    $"{Tag} instruction - {BranchFullName} Branch Condition Met. Branched to {args[0].Name} label at Memory index {NewState.PC.content} ");
            }
            else
            {
                BasicChangeLog = $"{BranchFullName} Condition not met. ";
                NewState.changeLog.Add(BasicChangeLog);
                NewState.DetailedChangeLog.Add(
                    $"{Tag} instruction - {BranchFullName} Branch Condition was not met By Compare Statement. ");
            }

            Trace.WriteLine(BasicChangeLog);
            return NewState;
        }
    }

    // Branch if Less Than
    public class Blt : Branch
    {
        public Blt() : base(CPU.Instructions.BLT)
        {
            BranchFullName = "'Less Than'";
        }


        //BLT <Label> Conditionally branch to the instruction at position <Label> in the program if the last comparison met the Less Than criteria

        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //check accumulator to find last CMP relationship
            //Accumulator Stores Last Comparison
            //EQ NE LT GT
            //0     1  2
            //if Conditional Correctly Met, branch to label's indicated Memory Index 
            string BasicChangeLog;
            if (NewState.ACC.content == 1)
            {
                NewState.PC.content = ((LineLabel)args[0]).LabelDestination;
                BasicChangeLog = $"Branched to {args[0].Name} ";
                NewState.changeLog.Add(BasicChangeLog);
                NewState.DetailedChangeLog.Add(
                    $"{Tag} instruction - {BranchFullName} Branch Condition Met. Branched to {args[0].Name} label at Memory index {NewState.PC.content} ");
            }
            else
            {
                BasicChangeLog = $"{BranchFullName} Condition not met. ";
                NewState.changeLog.Add(BasicChangeLog);
                NewState.DetailedChangeLog.Add(
                    $"{Tag} instruction - {BranchFullName} Branch Condition was not met By Compare Statement. ");
            }

            Trace.WriteLine(BasicChangeLog);
            return NewState;
        }
    }

    public class Bgt : Branch
    {
        public Bgt() : base(CPU.Instructions.BGT)
        {
            BranchFullName = "Greater Than";
        }


        //BGT <Label> Conditionally branch to the instruction at position <Label> in the program if the last comparison met the Greater Than criteria
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //check accumulator to find last CMP relationship
            //Accumulator Stores Last Comparison
            //EQ NE LT GT
            //0     1  2 
            //if Conditional Correctly Met, branch to label's indicated Memory Index 
            string BasicChangeLog;
            if (NewState.ACC.content == 2)
            {
                NewState.PC.content = ((LineLabel)args[0]).LabelDestination;
                BasicChangeLog = $"Branched to {args[0].Name} ";
                NewState.changeLog.Add(BasicChangeLog);
                NewState.DetailedChangeLog.Add(
                    $"{Tag} instruction - {BranchFullName} Branch Condition Met. Branched to {args[0].Name} label at Memory index {NewState.PC.content} ");
            }
            else
            {
                BasicChangeLog = $"{BranchFullName} Condition not met. ";
                NewState.changeLog.Add(BasicChangeLog);
                NewState.DetailedChangeLog.Add(
                    $"{Tag} instruction - {BranchFullName} Branch Condition was not met By Compare Statement. ");
            }

            Trace.WriteLine(BasicChangeLog);
            return NewState;
        }
    }


    //---------------------------------------     MOV     Instruction ------------------------------------------------
    //MOV RegisterArg, IntegerArg


    public class Mov : Instruction
    {
        public Mov() : base(CPU.Instructions.MOV)
        {
        }


        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //MOV Rd, <operand2> Copy the value specified by <operand2> into register d.

            //Register content indicated by args[0] = value indicated by operand 
            NewState.Basic[((RegisterArg)args[0]).RetInt()].content = ((IntegerArg)args[1]).RetInt();
            var BasicChangeLog = $"{args[0].Name} assigned {args[1].Name} value ";
            NewState.changeLog.Add(BasicChangeLog);
            // Trace Line to test code 
            Trace.WriteLine(BasicChangeLog);
            NewState.DetailedChangeLog.Add(
                $"{Tag} instruction - copies over the value of {args[1].Name} into register {args[0].Name} ");

            return NewState;
        }
    }

    //---------------------------------------     CMP      Instruction ------------------------------------------------
    //CMP RegisterArg, IntegerArg

    public class Cmp : Instruction
    {
        public Cmp() : base(CPU.Instructions.CMP)
        {
        }


        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //CMP Rn, <operand2> Compare the value stored in register n with the value specified by <operand2>. 
            //stores resultant relation in accumulator for next instruction 

            //Accumulator Stores Last Comparison
            //EQ NE LT GT
            //0     1  2 
            //if equal to 
            var BasicChangeLog = $"{args[0].Name} and  {args[1].Name} compared";

            NewState.changeLog.Add(BasicChangeLog);
            Trace.WriteLine(BasicChangeLog);
            NewState.DetailedChangeLog.Add(
                $"{Tag} instruction - Compared value in {args[0].Name} with {args[1].Name} ");
            // Equal To
            if (NewState.Basic[((RegisterArg)args[0]).index].content == ((IntegerArg)args[1]).value)
                NewState.ACC.content = 0;
            else
                //else if Less Than
            if (NewState.Basic[((RegisterArg)args[0]).index].content <= ((IntegerArg)args[1]).value)
                NewState.ACC.content = 1;
            else //else if Greater Than
                NewState.ACC.content = 2;

            return NewState;
        }
    }

    //---------------------------------------     OUT      Instruction ------------------------------------------------
    //OUT RegisterArg
    public class Out : Instruction
    {
        public Out() : base(CPU.Instructions.OUT)
        {
        }


        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //OUT Rd, <memory ref> Load the value stored in the memory location specified by <memory ref> into register d. 
            NewState.Outputs = Convert.ToString(NewState.Basic[((RegisterArg)args[0]).RetInt()].content);
            Trace.WriteLine($"Output : {NewState.Outputs}");
            NewState.changeLog.Add($"Output : {NewState.Outputs}");
            NewState.DetailedChangeLog.Add(
                $"{Tag} used to output {NewState.Outputs} from register {((RegisterArg)args[0]).Name} ");
            return NewState;
        }
    }

    //---------------------------------------     LDR      Instruction ------------------------------------------------
    //LDR RegisterArg, RegisterArg

    public class Ldr : Instruction
    {
        public Ldr() : base(CPU.Instructions.LDR)
        {
        }


        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //LDR Rd, Rn Store the value that is in register d into register n.
            //Register content indicated by args[0] = value indicated by operand
            NewState.Basic[((RegisterArg)args[0]).RetInt()].content =
                NewState.Basic[((RegisterArg)args[1]).RetInt()].content;
            var BasicChangeLog = $"{args[0].Name} assigned {args[1].Name} value ";
            NewState.changeLog.Add(BasicChangeLog);
            Trace.WriteLine(BasicChangeLog);
            // Trace Line to test code 

            NewState.DetailedChangeLog.Add(
                $"{Tag} instruction - copies over the value of {args[1].Name} into register {args[0].Name} ");

            return NewState;
        }
    }

    //---------------------------------------     MVN      Instruction ------------------------------------------------
    //MVN RegisterArg, IntegerArg

    public class Mvn : Instruction
    {
        public Mvn() : base(CPU.Instructions.MVN)
        {
        }


        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //MVN Rd, <operand2> Perform a bitwise logical NOT operation on the value specified by <operand2> and store the result in register d.
            var b1 = (byte)NewState.Basic[args[1].RetInt()].content;
            //not b1
            var result = (byte)~b1;
            NewState.ACC.content = result;
            NewState.Basic[args[0].RetInt()].content = result;
            var BasicChangeLog =
                $"{args[0].Name} assigned {int.Parse(Convert.ToString(result, 2)):0000 0000} from NOT {args[1].Name}";
            NewState.changeLog.Add(BasicChangeLog);
            Trace.WriteLine(BasicChangeLog);
            NewState.DetailedChangeLog.Add(
                $"{Tag} instruction - preformed bitwise NOT on {args[1].Name} value {b1} ({int.Parse(Convert.ToString(b1, 2)).ToString("0000")}). Result ({int.Parse(Convert.ToString(result, 2)):0000 0000} = {result}) stored in {args[0].Name}");
            return NewState;
        }
    }

    //---------------------------------------     AND      Instruction ------------------------------------------------
    //AND RegisterArg, RegisterArg, IntegerArg
    //will have multiple acceptable types in second addArg index

    public class And : Instruction
    {
        public And() : base(CPU.Instructions.AND)
        {
        }


        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //AND Rd, Rn, <operand2> Perform a bitwise logical AND operation between the value in register n and the value specified by <operand2> and store the result in register d.
            var b1 = (byte)NewState.Basic[args[1].RetInt()].content;
            var b2 = (byte)NewState.Basic[args[2].RetInt()].content;
            var result = (byte)(b1 & b2);
            NewState.ACC.content = result;
            NewState.Basic[args[0].RetInt()].content = result;
            var BasicChangeLog =
                $"{args[0].Name} assigned {int.Parse(Convert.ToString(result, 2)):0000 0000} from AND {args[1].Name},{args[2].Name} ";
            NewState.changeLog.Add(BasicChangeLog);
            Trace.WriteLine(BasicChangeLog);
            NewState.DetailedChangeLog.Add(
                $"{Tag} instruction - {args[1].Name} value {b1} ({int.Parse(Convert.ToString(b1, 2)).ToString("0000")}) and {args[2].Name} value {b2} ({int.Parse(Convert.ToString(b2, 2)).ToString("0000")}) AND result ({int.Parse(Convert.ToString(result, 2)):0000 0000} = {result}) stored in {args[0].Name}");
            return NewState;
        }
    }

    //---------------------------------------     ORR      Instruction ------------------------------------------------
    //ORR RegisterArg, RegisterArg, IntegerArg
    //will have multiple acceptable types in second addArg index

    public class Orr : Instruction
    {
        public Orr() : base(CPU.Instructions.ORR)
        {
        }


        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //ORR Rd, Rn, <operand2> Perform a bitwise logical OR operation between the value in register n and the value specified by <operand2> and store the result in register d.
            var b1 = (byte)NewState.Basic[args[1].RetInt()].content;
            var b2 = (byte)NewState.Basic[args[2].RetInt()].content;
            var result = (byte)(b1 | b2);
            NewState.ACC.content = result;
            NewState.Basic[args[0].RetInt()].content = result;
            var BasicChangeLog =
                $"{args[0].Name} assigned {int.Parse(Convert.ToString(result, 2)):0000 0000} from OR {args[1].Name},{args[2].Name} ";
            NewState.changeLog.Add(BasicChangeLog);
            Trace.WriteLine(BasicChangeLog);
            NewState.DetailedChangeLog.Add(
                $"{Tag} instruction - {args[1].Name} value {b1} ({int.Parse(Convert.ToString(b1, 2)).ToString("0000")}) and {args[2].Name} value {b2} ({int.Parse(Convert.ToString(b2, 2)).ToString("0000")}) OR result ({int.Parse(Convert.ToString(result, 2)):0000 0000} = {result}) stored in {args[0].Name}");
            return NewState;
        }
    }

    //---------------------------------------     EOR      Instruction ------------------------------------------------
    //EOR RegisterArg, RegisterArg, IntegerArg
    //will have multiple acceptable types in second addArg index

    public class Eor : Instruction
    {
        public Eor() : base(CPU.Instructions.EOR)
        {
        }


        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //EOR Rd, Rn, <operand2> Perform a bitwise logical exclusive or (XOR) operation between the value in register n and the value specified by <operand2> and store the result in register d.
            var b1 = (byte)NewState.Basic[args[1].RetInt()].content;
            var b2 = (byte)NewState.Basic[args[2].RetInt()].content;
            var result = (byte)(b1 ^ b2);
            NewState.ACC.content = result;
            NewState.Basic[args[0].RetInt()].content = result;
            var BasicChangeLog =
                $"{args[0].Name} assigned {int.Parse(Convert.ToString(result, 2)):0000 0000} from EOR {args[1].Name},{args[2].Name} ";
            NewState.changeLog.Add(BasicChangeLog);
            Trace.WriteLine(BasicChangeLog);
            NewState.DetailedChangeLog.Add(
                $"{Tag} instruction - {args[1].Name} value {b1} ({int.Parse(Convert.ToString(b1, 2)).ToString("0000")}) and {args[2].Name} value {b2} ({int.Parse(Convert.ToString(b2, 2)).ToString("0000")}) Exclusive OR result ({int.Parse(Convert.ToString(result, 2)):0000 0000} = {result}) stored in {args[0].Name}");
            return NewState;
        }
    }

    //---------------------------------------     LSL      Instruction ------------------------------------------------
    //LSL RegisterArg, RegisterArg, IntegerArg
    //will have multiple acceptable types in second addArg index

    public class Lsl : Instruction
    {
        public Lsl() : base(CPU.Instructions.LSL)
        {
        }


        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //LSL Rd, Rn, <operand2> Logically shift left the value stored in register n by the number of bits specified by <operand2> and store the result in register d.
            //Basic Register at Rd assigned Rn value x 2 ^ <operand2>, aka binary shift left
            var orig = NewState.Basic[((RegisterArg)args[1]).RetInt()].content;
            var retInt = ((IntegerArg)args[2]).RetInt();
            var endValue = (byte)orig << retInt;
            NewState.ACC.content = endValue;
            NewState.Basic[args[0].RetInt()].content = NewState.ACC.content;
            var BasicChangeLog = $"{args[1].Name} binary shifted left by {args[2].Name}. Assigned to {args[0].Name}";
            NewState.changeLog.Add(BasicChangeLog);
            Trace.WriteLine(BasicChangeLog);
            NewState.DetailedChangeLog.Add(
                $"{Tag} instruction -  {args[1].Name} Register's value {orig} binary shifted Left by {args[2].Name}. End value of {endValue} assigned to Register {args[0].Name}");
            return NewState;
        }
    }

    //---------------------------------------     LSR      Instruction ------------------------------------------------
    //LSR RegisterArg, RegisterArg, IntegerArg
    //will have multiple acceptable types in second addArg index

    public class Lsr : Instruction
    {
        public Lsr() : base(CPU.Instructions.LSR)
        {
        }


        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //LSR Rd, Rn, <operand2> Logically shift right the value stored in register n by the number of bits specified by <operand2> and store the result in register d.
            //Basic Register at Rd assigned Rn value / ( 2 ^ <operand2> ) aka binary shift right
            //
            var orig = NewState.Basic[((RegisterArg)args[1]).RetInt()].content;
            var endValue = orig >> ((IntegerArg)args[2]).RetInt();
            NewState.ACC.content = endValue;
            NewState.Basic[args[0].RetInt()].content = NewState.ACC.content;
            var BasicChangeLog = $"{args[1].Name} binary shifted right by {args[2].Name}. Assigned to {args[0].Name}";
            NewState.changeLog.Add(BasicChangeLog);
            Trace.WriteLine(BasicChangeLog);
            NewState.DetailedChangeLog.Add(
                $"{Tag} instruction -  {args[1].Name} Register's value {orig} binary shifted Right by {args[2].Name}. End value of {endValue} assigned to Register {args[0].Name}");
            return NewState;
        }
    }

    //---------------------------------------     ADD      Instruction ------------------------------------------------
    //ADD RegisterArg, RegisterArg, IntegerArg
    //will have multiple acceptable types in second addArg index

    public class Add : Instruction
    {
        public Add() : base(CPU.Instructions.ADD)
        {
        }


        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //ADD Rd, Rn, <operand2> Add the value specified in n2 to the value in register n1 and store the result in register d.
            // Register d = value of Rn1 + Rn2
            var param1 = NewState.Basic[args[1].RetInt()].content;
            var param2 = NewState.Basic[args[2].RetInt()].content;
            var BasicChangeLog = $"{args[0].Name} = {args[1].Name} ({param1}) + {args[2].Name} ({param2})";
            NewState.ACC.content = param1 + param2;
            NewState.Basic[args[0].RetInt()].content = NewState.ACC.content;
            NewState.changeLog.Add(BasicChangeLog);
            Trace.WriteLine(BasicChangeLog);
            NewState.DetailedChangeLog.Add(
                $"{Tag} instruction -  {args[1].Name} value {param1} added to {args[2].Name} {param2} and value {NewState.ACC.content} assigned to Register {args[0].Name}");
            return NewState;
        }
    }

    //---------------------------------------     SUB     Instruction ------------------------------------------------
    //SUB RegisterArg, RegisterArg, IntegerArg
    //will have multiple acceptable types in second addArg index
    public class Sub : Instruction
    {
        public Sub() : base(CPU.Instructions.SUB)
        {
        }


        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //SUB Rd, Rn, <operand2> Subtract the value specified by <operand2> from the value in register n and store the result in register d.
            // Register d = value of Rn + operand
            var param1 = NewState.Basic[args[1].RetInt()].content;
            var param2 = NewState.Basic[args[2].RetInt()].content;

            NewState.ACC.content = param1 - param2;
            NewState.Basic[args[0].RetInt()].content = NewState.ACC.content;
            var BasicChangeLog =
                $"{args[0].Name} = {args[1].Name} ({args[1].RetInt()}) - {args[2].Name} ({((RegisterArg)args[2]).RetInt()}) ";
            NewState.changeLog.Add(BasicChangeLog);
            Trace.WriteLine(BasicChangeLog);
            NewState.DetailedChangeLog.Add(
                $"{Tag} instruction -  {args[1].Name} Register's value {NewState.Basic[args[1].RetInt()].content} subtracted by {args[2].Name} {NewState.Basic[args[2].RetInt()].content} value {NewState.ACC.content} assigned to Register {args[0].Name}");
            return NewState;
        }
    }
}