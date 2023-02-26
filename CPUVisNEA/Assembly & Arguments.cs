using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

//https://resources.jetbrains.com/storage/products/rider/docs/Rider_default_win_shortcuts.pdf?_gl=1*8v6mpv*_ga*Mzk0Njg2ODg3LjE2NjExMDU4MzA.*_ga_9J976DJZ68*MTY3NTAyNjgxNS4xNy4wLjE2NzUwMjY4MjAuMC4wLjA.&_ga=2.77451923.725299765.1675026816-394686887.1661105830

/* basic todo list
 General 
 ---->  Take old and new method of param get acceptable and do writeup
 ---->  ExecuteInstruction
 ---->  Change operands to Memory Or Int 
 --------->  returns CPUState
 --------->  Takes CPUState
 
 Specialised 
 ---->  ExecuteInstruction whatnot
 ---->  B parsedArgs errors( relates to general 1 ) 
 --------->  Compare Branch interactions
 --------->  Labels
 ---->  Halt business
 --------->  Check she doesnt Kill program w null list
  
 
 
*/

namespace CPUVisNEA
{
    //---------------------------------------- Argument classes ------------------------------------------------
    /*todo fill in arguement and acceptible RegArg and Literal value arguements, Add additonal types of parameters
    
    //HALT 
    //B <Label>
    //B<condition> <Label>
    //MOV RegisterArg, IntegerArg
    //CMP RegisterArg, IntegerArg
    //MVN RegisterArg, IntegerArg
    //LDR RegisterArg, RegisterArg
    //STR RegisterArg, RegisterArg
    // Below will have multiple acceptable types in second addArg index
    //AND RegisterArg, RegisterArg, IntegerArg
    //ORR RegisterArg, RegisterArg, IntegerArg
    //EOR RegisterArg, RegisterArg, IntegerArg
    //LSL RegisterArg, RegisterArg, IntegerArg
    //LSR RegisterArg, RegisterArg, IntegerArg
    //ADD RegisterArg, RegisterArg, IntegerArg
    //SUB RegisterArg, RegisterArg, IntegerArg
    
    todo compare old valid param w new in Write up
        protected void validArgType(Argument arg,  ) {
            if( !(  arg.GetType().IsInstanceOfType( typeof(RegisterArg) )  )  && args.Count == 0 } 
        }
        
        protected void addArg(Argument arg){
            if( validArgType( arg ) ) {  args.append( arg ) ;   } }
            
    */
    //todo Create operand Arguement 
    // when done refactor for (IntegerArgs)args[2] and (IntegerArgs)args[2]
    /*
    public class OperandArg : Argument
    {
        public bool RegOrInt;
        public OperandArg(string StringArg)
        {
            if(StringArg[0] == '#'){
                
            }
            else
            {
                index = (int) int.Parse(StringArg.Remove(0, 1)) ;
            }
            // from is R(index) or r(index) to allow for user Mistakes. Hence Memory Index is string minus first index of string 
            index = (int) int.Parse(StringArg.Remove(0, 1)) ;
        }
    } */

    public abstract class Argument
    {
        protected internal string name;
        //protected int byteLength ;
        // todo decide IntegerArg byteLength = ( value % 255 ) + 1; 1 for others 
        protected virtual internal byte ToByte()
        {
            return 0;
        }
        //all arguements have a 
        protected virtual internal int RetInt()
        {
            return 0;
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
            index = int.Parse(StringArg.Remove(0, 1)) ;
            name = $"R{index}";
        }

        //second constructor for FDE Cycle retrieving from RAM 
        public RegisterArg(byte ByteForm)
        {
            index = Convert.ToInt32(ByteForm);
            name = $"R{index}";
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
            name = $"{value}";
            //byte length isn't a parameter as it can be worked out from value
        }

        public IntegerArg(byte ByteForm)
        {
            value = Convert.ToInt32(ByteForm);
            name = $"{value}";
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

    public class Label : Argument //todo maybe create linked class between Label argument and destination location
    {
        public int location; // destination
        public Label(string name)
        {
            this.name = name;
        }

        public int Location
        {
            get => location;
            set => location = value;
        }
        
        protected internal override byte ToByte()
        {
            return (byte)location;
        }
        protected internal override int RetInt()
        {
            return location;
        }

        
    }


    //----------------------------------------Instruction classes and generation------------------------------------------------


    public abstract class Instruction
    {
        //protected so all inherited classes have args attributes 
        // internal so TestConsole can access Instruction child class' args
        protected internal List<Argument> args = new List<Argument>(); //list of instruction arguments

        public CPU.Instructions Tag { get; } //use enum to get Tag ( instruction name ) 

        //sets instruction tag automatically to new instance of an Instruction class or child classes
        protected Instruction(CPU.Instructions tag)
        {
            Tag = tag;
        }


        protected internal static Dictionary<CPU.Instructions[], Type[]> dictionaryOfValidParams =
            new Dictionary<CPU.Instructions[], Type[]>
            {
                //MOV CMP MVN LDR STR
                {
                    new[]
                    {
                        CPU.Instructions.MOV, CPU.Instructions.CMP, CPU.Instructions.MVN, CPU.Instructions.LDR,
                        CPU.Instructions.STR
                    },
                    new[] { typeof(RegisterArg), typeof(IntegerArg) }
                },
                //AND ORR EOR LSL LSR ADD SUB
                {
                    new[]
                    {
                        CPU.Instructions.AND, CPU.Instructions.ORR, CPU.Instructions.EOR, CPU.Instructions.LSL,
                        CPU.Instructions.LSR, CPU.Instructions.ADD, CPU.Instructions.SUB
                    },
                    new[] { typeof(RegisterArg), typeof(RegisterArg), typeof(IntegerArg) }
                },
                // doesnt accept any additional text or parameters to statement
                //B >> acts for all branches
                { new[] { CPU.Instructions.B, CPU.Instructions.BEQ, CPU.Instructions.BLT, CPU.Instructions.BNE, CPU.Instructions.BGT   }, new[] { typeof(Label) } }
            };

        protected string label;


        //add Parsed Argument takes takes the instruction its a
        public static void addParsedArgs(Instruction instruc, List<string> StringArguments)
        {
            //for each argument, create a new correspondent instance of argument type
            foreach (var StringArg in StringArguments) instruc.addArg(GenerateArg(StringArg));

            Trace.WriteLine($"successfully passed all {instruc.Tag} arguements");
        }

        protected internal void addArg(Argument arg)
        {
            if (validArgType(arg))
                //if its a valid argument, add it to the objects Arguments list
                args.Add(arg);
            //else output error saying the argument type cant be used as the nth parameter ( +1 to counter 0 first index) 
            else
                throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
        }

        /*
        Checks if the arguement passed is a valid arguement to be passed to the instruction
        -- protected and stored in Instruction class so all child classes can inherit usage.
        -- internal used so the Console interface can access the method 
        (whilst this method of solving the problem creates a public dictionary that takes up storage, 
        it vastly reduces number of repetitive methods and lines in the following child classes and programs 
        due to repetitive format of Instruction Parameters */
        protected internal static Argument GenerateArg(string argumentStringForm)
        {
            //switch case assigns argumentStringForm to s before checking if the temporary variable s is a match with any argument regex expressions
            //if it is a match, then it returns the required the type of child class required for the argument 
            //if there are no matches, it returns an error message
            switch (argumentStringForm)
            {
                // Register Argument - lower or uppercase R followed by a single digit number
                
                case var s when Regex.IsMatch(s, "^(R|r)\\d$"):
                    return new RegisterArg(s);
                // Integer Argument - 1 or more digits
                case var s when Regex.IsMatch(s, "^#(\\d)*$"):
                    return new IntegerArg(s);
                // Label argument - 1 or more word characters
                case var s when Regex.IsMatch(s, "^(\\w)*$"):
                    return new Label(s);

                default:
                    throw new Exception("Input does not match any of the specified regexes for arguments");
            }
        }

        //finds the Type of argument required for an Instruction at ArgIndex
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
                    // check if Correspondent defintion contains the passed argument type at index of the parameter 
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
        string BasicChangeLog;
        
        NewState.changeLog.Add( BasicChangeLog );
        Trace.WriteLine( BasicChangeLog );
        NewState.DetailedChangeLog.Add( $"XXX instruction - {args[1].name} ... register {args[0].name} ");
        */
        

        public string Label
        {
            get => label;
            set => label = value;
        }
    }


    //---------------------------------------     HALT     Instruction ------------------------------------------------

    public class Halt : Instruction
    {
        public Halt() : base(CPU.Instructions.HALT)
        {
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //HALT Stop the execution of the program.

            NewState.PC.content = -1;
            return NewState;
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static  Halt parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var halt = new Halt();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(halt, args);
            // return modified and filled Instruction
            return halt;
        }
    }

    //---------------------------------------     B     Instruction ------------------------------------------------
    //B <Label>

    // todo special due to condition
    //B class acts as all variants, conditional is seperated and stored as a local attribute of the Branch statement to switch case action in execute Instruction
    public abstract class Branch : Instruction
    {
        protected string BranchFullName; 
        // there are different branch types
        public Branch(CPU.Instructions bType) : base(bType)
        {
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        //B<condition>  <Label> Conditionally branch to the instruction at position <Label> in the program if the last comparison met the criteria specified by the <condition>.

        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            return NewState;
        }
    }

    //Branch if Equal To
    public class B : Branch
    {
        public B() : base(CPU.Instructions.B)
        {
        }

        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //B <Label> Branch to the instruction at position <Label> Unconditionally
            //if Conditional Correctly Met, branch to label's indicated Memory Index 
            NewState.PC.content = ((Label)args[0]).location;
            NewState.changeLog.Add($" Branched to {args[0].name} ");
            Trace.WriteLine($" Branched to {args[0].name} ");
            NewState.DetailedChangeLog.Add($"{Tag} instruction - Branched to {args[0].name} label at Memory index {NewState.PC.content} ");
            return NewState;
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
 of Instruction type and pass arguments held by local CPU compiling function  */
        public static B parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var b = new B();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(b, args);
            // return modified and filled Instruction
            return b;
        }

    }
    public class Beq : Branch
    {
        public Beq() : base(CPU.Instructions.BEQ)
        {
            BranchFullName = "Equal To";
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup )
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
                NewState.PC.content = ((Label)args[0]).location;
                BasicChangeLog = $"Branched to {args[0].name} ";
                NewState.changeLog.Add( BasicChangeLog );
                NewState.DetailedChangeLog.Add( $"{Tag} instruction - {BranchFullName} Branch Condition Met. Branched to {args[0].name} label at Memory index {NewState.PC.content} ");
            }
            else {
                BasicChangeLog = $"{BranchFullName} Condition not met. ";
                NewState.changeLog.Add( BasicChangeLog );
                NewState.DetailedChangeLog.Add( $"{Tag} instruction - {BranchFullName} Branch Condition was not met By Compare Statement. "); 
            }
            Trace.WriteLine(BasicChangeLog);
            return NewState;
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Beq parseArgs(List<string> args, string condition)
        {
            //creates new local instance of a blank object correspondent to class
            var beq = new Beq();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(beq, args);
            // return modified and filled Instruction
            return beq;
        }
    }

    // Branch if Not Equal to 
    public class Bne : Branch
    {
        public Bne() : base(CPU.Instructions.BNE)
        {
            BranchFullName = "Not Equal To";
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
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
                NewState.PC.content = ((Label)args[0]).location;
                BasicChangeLog = $"Branched to {args[0].name} ";
                NewState.changeLog.Add( BasicChangeLog );
                NewState.DetailedChangeLog.Add( $"{Tag} instruction - {BranchFullName} Branch Condition Met. Branched to {args[0].name} label at Memory index {NewState.PC.content} ");
            }
            else {
                BasicChangeLog = $"{BranchFullName} Condition not met. ";
                NewState.changeLog.Add( BasicChangeLog );
                NewState.DetailedChangeLog.Add( $"{Tag} instruction - {BranchFullName} Branch Condition was not met By Compare Statement. "); 
            }
            Trace.WriteLine(BasicChangeLog);
            return NewState;
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Bne parseArgs(List<string> args, string condition)
        {
            //creates new local instance of a blank object correspondent to class
            var bne = new Bne();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(bne, args);
            // return modified and filled Instruction
            return bne;
        }
    }

    // Branch if Less Than
    public class Blt : Branch
    {
        public Blt() : base(CPU.Instructions.BLT)
        {
            BranchFullName = "Less Than";
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
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
                NewState.PC.content = ((Label)args[0]).location;
                BasicChangeLog = $"Branched to {args[0].name} ";
                NewState.changeLog.Add( BasicChangeLog );
                NewState.DetailedChangeLog.Add( $"{Tag} instruction - {BranchFullName} Branch Condition Met. Branched to {args[0].name} label at Memory index {NewState.PC.content} ");
            }
            else {
                BasicChangeLog = $"{BranchFullName} Condition not met. ";
                NewState.changeLog.Add( BasicChangeLog );
                NewState.DetailedChangeLog.Add( $"{Tag} instruction - {BranchFullName} Branch Condition was not met By Compare Statement. "); 
            }
            Trace.WriteLine(BasicChangeLog);
            return NewState;
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Blt parseArgs(List<string> args, string condition)
        {
            //creates new local instance of a blank object correspondent to class
            var blt = new Blt();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(blt, args);
            // return modified and filled Instruction
            return blt;
        }
    }

    public class Bgt : Branch
    {
        public Bgt() : base(CPU.Instructions.BGT)
        {
            BranchFullName = "Greater Than";
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
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
                NewState.PC.content = ((Label)args[0]).location;
                BasicChangeLog = $"Branched to {args[0].name} ";
                NewState.changeLog.Add( BasicChangeLog );
                NewState.DetailedChangeLog.Add( $"{Tag} instruction - {BranchFullName} Branch Condition Met. Branched to {args[0].name} label at Memory index {NewState.PC.content} ");
            }
            else {
                BasicChangeLog = $"{BranchFullName} Condition not met. ";
                NewState.changeLog.Add( BasicChangeLog );
                NewState.DetailedChangeLog.Add( $"{Tag} instruction - {BranchFullName} Branch Condition was not met By Compare Statement. "); 
            }
            Trace.WriteLine(BasicChangeLog);
            return NewState;
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Bgt parseArgs(List<string> args, string condition)
        {
            //creates new local instance of a blank object correspondent to class
            var bgt = new Bgt();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(bgt, args);
            // return modified and filled Instruction
            return bgt;
        }
    }


    //---------------------------------------     MOV     Instruction ------------------------------------------------
    //MOV RegisterArg, IntegerArg


    public class Mov : Instruction
    {
        public Mov() : base(CPU.Instructions.MOV)
        {
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //MOV Rd, <operand2> Copy the value specified by <operand2> into register d.

            //Register content indicated by args[0] = value indicated by operand
            NewState.Basic[((RegisterArg)args[0]).RetInt()].content  =  ( (IntegerArg)args[1] ).RetInt() ;
            string BasicChangeLog = $" {args[0].name} assigned {args[1].name} value ";
            NewState.changeLog.Add( BasicChangeLog );
            Trace.WriteLine(BasicChangeLog);
            // Trace Line to test code 
            
            NewState.DetailedChangeLog.Add( $" {Tag} instruction - copies over the value of {args[1].name} into register {args[0].name} ");
            
            return NewState;
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Mov parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var mov = new Mov();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(mov, args);
            // return modified and filled Instruction
            return mov;
        }
        
    }

    //---------------------------------------     CMP      Instruction ------------------------------------------------
    //CMP RegisterArg, IntegerArg

    public class Cmp : Instruction
    {
        public Cmp() : base(CPU.Instructions.CMP)
        {
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //CMP Rn, <operand2> Compare the value stored in register n with the value specified by <operand2>. 
            //stores resultant relation in accumulator for next instruction 

            //Accumulator Stores Last Comparison
            //EQ NE LT GT
            //0     1  2 
            //if equal to 
            string BasicChangeLog = $"{args[0].name} and  {args[1].name} compared";
        
            NewState.changeLog.Add( BasicChangeLog );
            Trace.WriteLine( BasicChangeLog );
            NewState.DetailedChangeLog.Add( $"{Tag} instruction - Compared value in {args[0].name} with {args[1].name} ");
            // Equal To
            if (NewState.Basic[((RegisterArg)args[0]).index].content == ((IntegerArg)args[1]).value)
            {
                NewState.ACC.content = 0;
            } else 
                //else if Less Than
            if (NewState.Basic[((RegisterArg)args[0]).index].content <= ((IntegerArg)args[1]).value)
            {
                NewState.ACC.content = 1;
            } else //else if Greater Than
            {
                NewState.ACC.content = 2;
            }

            return NewState;
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Cmp parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var cmp = new Cmp();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(cmp, args);
            // return modified and filled Instruction
            return cmp;
        }
    }

    //---------------------------------------     MVN      Instruction ------------------------------------------------
    //MVN RegisterArg, IntegerArg

    public class Mvn : Instruction
    {
        public Mvn() : base(CPU.Instructions.MVN)
        {
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //MVN Rd, <operand2> Perform a bitwise logical NOT operation on the value specified by <operand2> and store the result in register d.

            
           //NewState.Basic[ ( (RegisterArg)args[0] ).RetInt() ] = args[1]. 
            return NewState;
        }

        //todo move all comments to all valid loc - create, passes string... ,return modified
        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Mvn parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var mvn = new Mvn();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(mvn, args);
            // return modified and filled Instruction
            return mvn;
        }
    }

    //---------------------------------------     LDR      Instruction ------------------------------------------------
    //LDR RegisterArg, RegisterArg
    public class Ldr : Instruction
    {
        public Ldr() : base(CPU.Instructions.LDR)
        {
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //LDR Rd, <memory ref> Load the value stored in the memory location specified by <memory ref> into register d. 
            return NewState;
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Ldr parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var ldr = new Ldr();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(ldr, args);
            // return modified and filled Instruction
            return ldr;
        }
    }

    //---------------------------------------     STR      Instruction ------------------------------------------------
    //STR RegisterArg, RegisterArg

    public class Str : Instruction
    {
        public Str() : base(CPU.Instructions.STR)
        {
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //STR Rd, <memory ref> Store the value that is in register d into the memory location specified by <memory ref>.
            
            return NewState;
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Str parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var str = new Str();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(str, args);
            // return modified and filled Instruction
            return str;
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

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //AND Rd, Rn, <operand2> Perform a bitwise logical AND operation between the value in register n and the value specified by <operand2> and store the result in register d.
            return NewState;
            
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static And parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var and = new And();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(and, args);
            // return modified and filled Instruction
            return and;
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

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //ORR Rd, Rn, <operand2> Perform a bitwise logical OR operation between the value in register n and the value specified by <operand2> and store the result in register d.
            return NewState;
            
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Orr parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var orr = new Orr();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(orr, args);
            // return modified and filled Instruction
            return orr;
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

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //EOR Rd, Rn, <operand2> Perform a bitwise logical exclusive or (XOR) operation between the value in register n and the value specified by <operand2> and store the result in register d.
            return NewState;
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Eor parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var eor = new Eor();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(eor, args);
            // return modified and filled Instruction
            return eor;
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

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //LSL Rd, Rn, <operand2> Logically shift left the value stored in register n by the number of bits specified by <operand2> and store the result in register d.
            //Basic Register at Rd assigned Rn value x 2 ^ <operand2>, aka binary shift left
            NewState.Basic[args[0].RetInt()].content = NewState.Basic[args[1].RetInt()].content * 2 ^ args[2].RetInt();
            string BasicChangeLog = $"{args[1].RetInt()} binary shifted by {args[2].name}. Assigned to {args[0].name}";
            NewState.changeLog.Add( BasicChangeLog );
            Trace.WriteLine( BasicChangeLog );
            NewState.DetailedChangeLog.Add( $" {Tag} instruction -  {args[1].name} Register's value {args[1].RetInt()} binary shifted Value by {args[2].name} and value assigned to Register {args[0].name}");
            return NewState;
            
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Lsl parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var lsl = new Lsl();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(lsl, args);
            // return modified and filled Instruction
            return lsl;
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

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //LSR Rd, Rn, <operand2> Logically shift right the value stored in register n by the number of bits specified by <operand2> and store the result in register d.
            //Basic Register at Rd assigned Rn value / ( 2 ^ <operand2> ) aka binary shift right
            //todo needs to round 
            NewState.Basic[args[0].RetInt()].content = ( NewState.Basic[args[1].RetInt()].content / (2 ^ args[2].RetInt() ) )    ;
            string BasicChangeLog = $"{args[1].RetInt()} binary shifted by {args[2].name}. Assigned to {args[0].name}";
            NewState.changeLog.Add( BasicChangeLog );
            Trace.WriteLine( BasicChangeLog );
            NewState.DetailedChangeLog.Add( $" {Tag} instruction -  {args[1].name} Register's value {args[1].RetInt()} binary shifted Value by {args[2].name} and value assigned to Register {args[0].name}");
            return NewState;
            return NewState;
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Lsr parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var lsr = new Lsr();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(lsr, args);
            // return modified and filled Instruction
            return lsr;
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

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //ADD Rd, Rn, <operand2> Add the value specified in <operand2> to the value in register n and store the result in register d.
            return NewState;
            
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Add parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var add = new Add();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(add, args);
            // return modified and filled Instruction
            return add;
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

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState NewState)
        {
            //SUB Rd, Rn, <operand2> Subtract the value specified by <operand2> from the value in register n and store the result in register d.
            return NewState;
            
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Sub parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var sub = new Sub();
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(sub, args);
            // return modified and filled Instruction
            return sub;
        }
    }
}