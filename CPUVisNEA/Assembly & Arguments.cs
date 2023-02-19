using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

//https://resources.jetbrains.com/storage/products/rider/docs/Rider_default_win_shortcuts.pdf?_gl=1*8v6mpv*_ga*Mzk0Njg2ODg3LjE2NjExMDU4MzA.*_ga_9J976DJZ68*MTY3NTAyNjgxNS4xNy4wLjE2NzUwMjY4MjAuMC4wLjA.&_ga=2.77451923.725299765.1675026816-394686887.1661105830

/* basic todo list
 General 
 ---->  Take old and new method of param get acceptable and do writeup
 ---->  ExecuteInstruction 
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

    public abstract class Argument
    {
        
        //protected int byteLength ;
        // todo decide IntegerArg byteLength = ( value % 255 ) + 1; 1 for others 
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
            index = int.Parse(StringArg.Remove(1, 1));
        }

        //second constructor for FDE Cycle retrieving from RAM 
        public RegisterArg(byte ByteForm)
        {
            index = Convert.ToInt32(ByteForm);
        }
    }

    public class IntegerArg : Argument
    {
        public int value;

        //user may need to deal with integers above 255, therefore the required value representable value must be represented by variable bytes 

        public IntegerArg(string StringForm)
        {
            value = int.Parse(StringForm);
            //byte length isn't a parameter as it can be worked out from value
        }

        public IntegerArg(byte ByteForm)
        {
            value = Convert.ToInt32(ByteForm);
        }
    }

    public class Label : Argument //todo maybe create linked class between Label argument and desitnation location
    {
        public Label(string name)
        {
            this.name = name;
        }

        public void setLabelLocation(int LabelLocation)
        {
            location = LabelLocation;
        }

        private int location; // destination
        private string name; // correspondent string for display purpose
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
                //todo fill in 
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
                {
                    new[] { CPU.Instructions.HALT }, null
                }, // doesnt accept any additional text or parameters to statement
                //B >> acts for all branches
                { new[] { CPU.Instructions.B }, new[] { typeof(Label) } }
            };


        //add Parsed Argument takes takes the instruction its a
        public static void addParsedArgs(Instruction instruc, List<string> StringArguments)
        {
            //for each argument, create a new correspondent instance of argument type
            foreach (var StringArg in StringArguments) instruc.addArg(GenerateArg(StringArg));

            MessageBox.Show($"successfully passed all {instruc.Tag}");
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
                case var s when Regex.IsMatch(s, @"(R|r)\\d"):
                    return new RegisterArg(s);
                // Integer Argument - 1 or more digits
                case var s when Regex.IsMatch(s, @"(\\d)*"):
                    return new IntegerArg(s);
                // Label argument - 1 or more word characters
                case var s when Regex.IsMatch(s, @"(\\w)*"):
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
        protected internal abstract CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState);
    }


    //---------------------------------------     HALT     Instruction ------------------------------------------------

    public class Halt : Instruction
    {
        public Halt() : base(CPU.Instructions.HALT)
        {
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            //HALT Stop the execution of the program.
            CPUState NewState = CurrentCpuState;
            return NewState;
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static Halt parseArgs(List<string> args)
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
    public class B : Instruction
    {
        public B(CPU.Instructions instructions) : base(CPU.Instructions.B)
        {
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        //B<condition>  <Label> Conditionally branch to the instruction at position <Label> in the program if the last comparison met the criteria specified by the <condition>.

        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            CPUState NewState = CurrentCpuState;
            
            var jump = 0;

            var label = (Label)args[0];
            
            return NewState;
        }

        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static B parseArgs(List<string> args)
        {
            //creates new local instance of a blank object correspondent to class
            var b = new B(CPU.Instructions.B);
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(b, args);
            // return modified and filled Instruction
            return b;
        }
    }

    //Branch if Equal To
    public class Beq : B
    {
        public Beq() : base(CPU.Instructions.BEQ)
        {
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        //B<condition>  <Label> Conditionally branch to the instruction at position <Label> in the program if the last comparison met the criteria specified by the <condition>.

        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            CPUState NewState = CurrentCpuState;
            
            var jump = 0;

            var label = (Label)args[0];
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
    public class Bne : B
    {
        public Bne() : base(CPU.Instructions.BNE)
        {
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        //Bne<condition>  <Label> Conditionally branch to the instruction at position <Label> in the program if the last comparison met the criteria specified by the <condition>.

        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            CPUState NewState = CurrentCpuState;
            
            var jump = 0;

            var label = (Label)args[0];
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
    public class Blt : B
    {
        public Blt() : base(CPU.Instructions.BLT)
        {
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        //B<condition>  <Label> Conditionally branch to the instruction at position <Label> in the program if the last comparison met the criteria specified by the <condition>.

        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            CPUState NewState = CurrentCpuState;
            
            var jump = 0;

            var label = (Label)args[0];
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

    public class Bgt : B
    {
        public Bgt() : base(CPU.Instructions.BGT)
        {
        }

        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        //B<condition>  <Label> Conditionally branch to the instruction at position <Label> in the program if the last comparison met the criteria specified by the <condition>.

        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            CPUState NewState = CurrentCpuState;
            
            var jump = 0;

            var label = (Label)args[0];
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
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            //MOV Rd, <operand2> Copy the value specified by <operand2> into register d.
            CPUState NewState = CurrentCpuState;
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
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            //CMP Rn, <operand2> Compare the value stored in register n with the value specified by <operand2>. 
            CPUState NewState = CurrentCpuState;
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
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            //MVN Rd, <operand2> Perform a bitwise logical NOT operation on the value specified by <operand2> and store the result in register d.
            CPUState NewState = CurrentCpuState;
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
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            //LDR Rd, <memory ref> Load the value stored in the memory location specified by <memory ref> into register d. 
            CPUState NewState = CurrentCpuState;
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
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            //STR Rd, <memory ref> Store the value that is in register d into the memory location specified by <memory ref>.
            CPUState NewState = CurrentCpuState;
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
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            //AND Rd, Rn, <operand2> Perform a bitwise logical AND operation between the value in register n and the value specified by <operand2> and store the result in register d.
            CPUState NewState = CurrentCpuState;
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
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            //ORR Rd, Rn, <operand2> Perform a bitwise logical OR operation between the value in register n and the value specified by <operand2> and store the result in register d.
            CPUState NewState = CurrentCpuState;
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
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            //EOR Rd, Rn, <operand2> Perform a bitwise logical exclusive or (XOR) operation between the value in register n and the value specified by <operand2> and store the result in register d.
            CPUState NewState = CurrentCpuState;
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
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            //LSL Rd, Rn, <operand2> Logically shift left the value stored in register n by the number of bits specified by <operand2> and store the result in register d.
            CPUState NewState = CurrentCpuState;
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
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            //LSR Rd, Rn, <operand2> Logically shift right the value stored in register n by the number of bits specified by <operand2> and store the result in register d.
            CPUState NewState = CurrentCpuState;
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
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            //ADD Rd, Rn, <operand2> Add the value specified in <operand2> to the value in register n and store the result in register d.
            CPUState NewState = CurrentCpuState;
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
        protected internal override CPUState executeInstruction(List<Argument> args, CPUState CurrentCpuState)
        {
            //SUB Rd, Rn, <operand2> Subtract the value specified by <operand2> from the value in register n and store the result in register d.
            CPUState NewState = CurrentCpuState;
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