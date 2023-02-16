using System;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;  
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
    //B <label>
    //B<condition> <label>
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
        protected void validParamType(Argument arg,  ) {
            if( !(  arg.GetType().IsInstanceOfType( typeof(RegisterArg) )  )  && args.Count == 0 } 
        }
        
        protected void addArg(Argument arg){
            if( validParamType( arg ) ) {  args.append( arg ) ;   } }
            
    */
    
    public interface Argument{}

    public class RegisterArg : Argument { public int index; } // requires index of register before calling to CPU to retrieve value of target
    
    public class IntegerArg : Argument {public int value; } // basic value passed
    
    public class label : Argument //todo maybe create linked class between label argument and desitnation location
    {   private int location; // destination
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
            this.Tag = tag;
            
        }


        protected static internal Dictionary<CPU.Instructions[], Type[]> dictionaryOfValidParams =
            new Dictionary<CPU.Instructions[], Type[]>()
            {
                //todo fill in 
                //MOV CMP MVN LDR STR
                {new CPU.Instructions[] { CPU.Instructions.MOV, CPU.Instructions.CMP , CPU.Instructions.MVN, CPU.Instructions.LDR, CPU.Instructions.STR   }
                ,new Type[]{ typeof(RegisterArg), typeof(IntegerArg) } },
                //AND ORR EOR LSL LSR ADD SUB
                {new CPU.Instructions[] { CPU.Instructions.AND, CPU.Instructions.ORR , CPU.Instructions.EOR, CPU.Instructions.LSL, CPU.Instructions.LSR, CPU.Instructions.ADD, CPU.Instructions.SUB }, 
                 new Type[]{ typeof(RegisterArg), typeof(RegisterArg), typeof(IntegerArg) } },
                {new CPU.Instructions[] { CPU.Instructions.HALT } , null }, // doesnt accept any additional text or parameters to statement
                //B >> acts for all branches
                {new CPU.Instructions[] { CPU.Instructions.B } , new Type[] {typeof(label)  } }
            };
    
        
        
        //add Parsed Argument takes 
        public static void addParsedArgs(Instruction instruc, List<string> arguments)
        {
            //for each argument, create a new correspondent instance of argument type
            foreach (var arg in arguments)
            {
                // todo try matching on different regex (or even just look at the first char or something)
                // return an instance of Register, Literal, etc
                // create function for GetArgType
                // string type = GetArgType(arg);
                // switch (type)
                // {
                //     case : "Register" { Argument parsed = new RegisterArg(); break;
                //     case : "Integer" { Argument parsed = new IntegerArg(); break;
                //     case : "label" { Argument parsed = new label(); break;
                //     default : new ErrorMessage("unrecognised")
                // }"/
               
                
                //temporary 
                Argument parsed = new IntegerArg();
                
                // empty Protected method that can be overriden to allow different 
                //todo check if below works
                instruc.addArg(parsed);
            }

            MessageBox.Show($"successfully passed all {instruc.Tag}");
            
        }
        //FAT Todo 

        protected internal void addArg(Argument arg)
        {
            if (validParamType(arg))
            { 
                //if its a valid argument, add it to the objects Arguments list
                args.Add( arg   );
            }//else output error saying the argument type cant be used as the nth parameter ( +1 to counter 0 first index) 
            else { throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} "); }
        }
        /*
        Checks if the arguement passed is a valid arguement to be passed to the instruction
        -- protected and stored in Instruction class so all child classes can inherit usage.
        -- internal used so the Console interface can access the method 
        (whilst this method of solving the problem creates a public dictionary that takes up storage, 
        it vastly reduces number of repetitive methods and lines in the following child classes and programs 
        due to repetitive format of Instruction Parameters */
        protected internal bool validParamType(Argument arg)
        {
            //linear search through dictionary
            foreach (var InstructGrouping in dictionaryOfValidParams)
            {
                //if the key array contains the Instruction Tag
                if (InstructGrouping.Key.Contains(Tag) ){
                    //now check if Correspondent defintion contains the passed argument type at index of the parameter 
                    if (arg.GetType() == InstructGrouping.Value[args.Count])
                    { //therefore valid input type at index for instruction class tag
                        return true;
                    }
                }  
            }
            //return false if requirements not met
            return false;
        }
        // basic overridable call statement for all assembly operations to override to deal with individual arguments
        //means CPU can call executeInstruction regardless of Child class to get unique behaviour
        protected internal abstract void executeInstruction(List<Argument> args, CPU cpu);

    }

    //---------------------------------------     HALT     Instruction ------------------------------------------------

    public class Halt : Instruction
    {
        public Halt() : base(CPU.Instructions.HALT)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override void executeInstruction(List<Argument> args, CPU cpu)
        {        
            //HALT Stop the execution of the program.

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
    //B <label>
    
    // todo special due to condition
    //B class acts as all variants, conditional is seperated and stored as a local attribute of the Branch statement to switch case action in execute Instruction
    public class B : Instruction
    {
        //Possible values for condition and their meaning are: EQ:Equal to, NE:Not equal to, GT:Greater than, LT:Less than.
        //assigned in the overriden parseArgs method of B class
        private string condition;
        //takes condition as a parameter 
        public B() : base(CPU.Instructions.B)
        {
            

        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        //B<condition>  <label> Conditionally branch to the instruction at position <label> in the program if the last comparison met the criteria specified by the <condition>.

        protected internal override void executeInstruction(List<Argument> args, CPU cpu)
        {
            int jump = 0;
            
            label label = (CPUVisNEA.label)args[0];
            //note to self, any executions they all do? e.g local variable assignement? SPR? 
            switch (condition)
            {
                // basic unconditional B statement always jumps to label 
                case null :
                    // return a jump command to indicated index by label in args[0]
                    
                    break;
                // conditional B statement dependent on condition 'Less Than'
                case "LT" :
                    
                    break;
                // conditional B statement dependent on condition 'Greater Than'
                case "GT" :
                    
                    break;
                // conditional B statement dependent on condition 'Equal To'
                case "EQ" :
                    
                    break;
                // conditional B statement dependent on condition 'Not Equal'
                case "NE" :
                    
                    break;
            }

            
        }
        /*held locally in class but never used by class. Is used by CPU to instantiate instance
         of Instruction type and pass arguments held by local CPU compiling function  */
        public static B parseArgs(List<string> args, string condition)
        {
            //creates new local instance of a blank object correspondent to class
            var b = new B();
            b.condition = condition;
            /*passes string version of arguments given by parameter to use
             Inherited addParsedArgs method to clean args and append to the 
             protected Instructions local attribute args */
            addParsedArgs(b, args);
            // return modified and filled Instruction
            return b;
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
        protected internal override void executeInstruction(List<Argument> args, CPU cpu)
        { 
            //MOV Rd, <operand2> Copy the value specified by <operand2> into register d.

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
        protected internal override void executeInstruction(List<Argument> args, CPU cpu)
        {
            //CMP Rn, <operand2> Compare the value stored in register n with the value specified by <operand2>. 
            
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
        protected internal override void executeInstruction(List<Argument> args, CPU cpu)
        {
            //MVN Rd, <operand2> Perform a bitwise logical NOT operation on the value specified by <operand2> and store the result in register d.
            
            

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
        protected internal override void executeInstruction(List<Argument> args, CPU cpu)
        {

            //LDR Rd, <memory ref> Load the value stored in the memory location specified by <memory ref> into register d. 

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
        protected internal override void executeInstruction(List<Argument> args, CPU cpu)
        {
            //STR Rd, <memory ref> Store the value that is in register d into the memory location specified by <memory ref>.
            
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
        protected internal override void executeInstruction(List<Argument> args, CPU cpu)
        {
            //AND Rd, Rn, <operand2> Perform a bitwise logical AND operation between the value in register n and the value specified by <operand2> and store the result in register d.
            
            
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
        protected internal override void executeInstruction(List<Argument> args, CPU cpu)
        {
            //ORR Rd, Rn, <operand2> Perform a bitwise logical OR operation between the value in register n and the value specified by <operand2> and store the result in register d.
            
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
        protected internal override void executeInstruction(List<Argument> args, CPU cpu)
        {
            //EOR Rd, Rn, <operand2> Perform a bitwise logical exclusive or (XOR) operation between the value in register n and the value specified by <operand2> and store the result in register d.

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
        protected internal override void executeInstruction(List<Argument> args, CPU cpu)
        {
            
            //LSL Rd, Rn, <operand2> Logically shift left the value stored in register n by the number of bits specified by <operand2> and store the result in register d.
            
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
        protected internal override void executeInstruction(List<Argument> args, CPU cpu)
        {
            //LSR Rd, Rn, <operand2> Logically shift right the value stored in register n by the number of bits specified by <operand2> and store the result in register d.
            
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
        protected internal override void executeInstruction(List<Argument> args, CPU cpu)
        {

            //ADD Rd, Rn, <operand2> Add the value specified in <operand2> to the value in register n and store the result in register d.
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
        protected internal override void executeInstruction(List<Argument> args, CPU cpu)
        {

            //SUB Rd, Rn, <operand2> Subtract the value specified by <operand2> from the value in register n and store the result in register d.
            
          
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