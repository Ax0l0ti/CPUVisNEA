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
 ---->  Deal w parseArgs()
 --------->  Seems kinda wacko 
 ---->  Take old and new method of param get acceptable
 
 
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
                //B *=( acts for all branches
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
                // }
                
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
                args.Add(arg);
            }
            else
            {
                throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
            }
        }
        /*
        Checks if the arguement passed is a valid arguement to be passed to the instruction
        protected and stored in Instruction class so all child classes can inherit
        internal used so the Console interface can access the method 
        whilst this method of solving the problem creates a public dictionary that takes up storage, it vastly reduces number
        of repetitive methods and lines in the following child classes and programs in code below due to repetitive format of Instruction Parameters */
        protected internal bool validParamType(Argument arg)
        {
            foreach (var InstructGrouping in dictionaryOfValidParams)
            {
                if (InstructGrouping.Key.Contains(Tag) ){
                    if (arg.GetType() == InstructGrouping.Value[args.Count])
                    {
                        return true;
                    }
                }  
            }
            return false;
        }
        // basic overridable call statement for all assembly operations to override to deal with individual arguments 
        protected internal abstract void executeInstruction( List<Argument> args); 

    }
    // total acceptable statements 
    // condition label IntegerArg RegisterArg, IntorReg = IntegerArg RegisterArg
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
    
    
    //todo create all instruction options
    
    //---------------------------------------     HALT     Instruction ------------------------------------------------

    public class Halt : Instruction
    {
        public Halt() : base(CPU.Instructions.HALT)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override void executeInstruction(List<Argument> args )
        {
            //break out of program and enter frozen/ return to edit state
        }
        
        public static Halt parseArgs(List<string> args)
        {
            var halt = new Halt();
            //passes Instruction in Parameter 1 the arguments in args
            //calls modified version of addArg (below) in child class 
            addParsedArgs(halt, args);
            return halt;
        }
        
    }
    
    //---------------------------------------     B     Instruction ------------------------------------------------
    //B <label>
    
    // todo special due to condition
    //B class acts as all variants, conditional is seperated and stored as a local attribute of the Branch statement to switch case action in execute Instruction
    public class B : Instruction
    {
        private string condition;
        //takes condition as a parameter 
        public B(string condition) : base(CPU.Instructions.B)
        {
            this.condition = condition;
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override void executeInstruction(List<Argument> args )
        {
            switch (condition)
            {
                case "LT" :
                    break;
                case "GT" :
                    break;
                case "EQ" :
                    break;
                case "NE" :
                    break;
            }
            
                
        }
        
        public B parseArgs(List<string> args)
        {
            var b = new B(condition );
            addParsedArgs( b , args);
            return b;
        }
        
    }
    //todo all braches 

    

    //---------------------------------------     MOV     Instruction ------------------------------------------------
    //MOV RegisterArg, IntegerArg


    public class Mov : Instruction
    {
        public Mov() : base(CPU.Instructions.MOV)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected internal override void executeInstruction(List<Argument> args )
        {
            
        }
        
        public static Mov parseArgs(List<string> args)
        {
            var mov = new Mov();
            //passes Instruction in Parameter 1 the arguments in args
            //calls modified version of addArg (below) in child class 
            addParsedArgs(mov, args);
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
        protected internal override void executeInstruction(List<Argument> args )
        {
            
        }
        
        public static Cmp parseArgs(List<string> args)
        {
            var cmp = new Cmp();
            //passes Instruction in Parameter 1 the arguments in args
            //calls modified version of addArg (below) in child class 
            addParsedArgs(cmp, args);
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
        protected internal override void executeInstruction(List<Argument> args )
        {
            
        }
        
        public static Mvn parseArgs(List<string> args)
        {
            var mvn = new Mvn();
            //passes Instruction in Parameter 1 the arguments in args
            //calls modified version of addArg (below) in child class 
            addParsedArgs(mvn, args);
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
        protected internal override void executeInstruction(List<Argument> args )
        {
            
        }
        
        public static Ldr parseArgs(List<string> args)
        {
            var ldr = new Ldr();
            //passes Instruction in Parameter 1 the arguments in args
            //calls modified version of addArg (below) in child class 
            addParsedArgs(ldr, args);
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
        protected internal override void executeInstruction(List<Argument> args )
        {
            
        }
        
        public static Str parseArgs(List<string> args)
        {
            var str = new Str();
            //passes Instruction in Parameter 1 the arguments in args
            //calls modified version of addArg (below) in child class 
            addParsedArgs(str, args);
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
        protected internal override void executeInstruction(List<Argument> args )
        {
            
        }
        
        public static And parseArgs(List<string> args)
        {
            var and = new And();
            //passes Instruction in Parameter 1 the arguments in args
            //calls modified version of addArg (below) in child class 
            addParsedArgs(and, args);
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
        protected internal override void executeInstruction(List<Argument> args )
        {
            
        }
        
        public static Orr parseArgs(List<string> args)
        {
            var orr = new Orr();
            //passes Instruction in Parameter 1 the arguments in args
            //calls modified version of addArg (below) in child class 
            addParsedArgs(orr, args);
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
        protected internal override void executeInstruction(List<Argument> args )
        {
            
        }
        
        public static Eor parseArgs(List<string> args)
        {
            var eor = new Eor();
            //passes Instruction in Parameter 1 the arguments in args
            //calls modified version of addArg (below) in child class 
            addParsedArgs(eor, args);
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
        protected internal override void executeInstruction(List<Argument> args )
        {
            
        }
        
        public static Lsl parseArgs(List<string> args)
        {
            var lsl = new Lsl();
            //passes Instruction in Parameter 1 the arguments in args
            //calls modified version of addArg (below) in child class 
            addParsedArgs(lsl, args);
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
        protected internal override void executeInstruction(List<Argument> args )
        {
            
        }
        
        public static Lsr parseArgs(List<string> args)
        {
            var lsr = new Lsr();
            //passes Instruction in Parameter 1 the arguments in args
            //calls modified version of addArg (below) in child class 
            addParsedArgs(lsr, args);
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
        protected internal override void executeInstruction(List<Argument> args )
        {
            
        }
        
        public static Add parseArgs(List<string> args)
        {
            var add = new Add();
            //passes Instruction in Parameter 1 the arguments in args
            //calls modified version of addArg (below) in child class 
            addParsedArgs(add, args);
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
        protected internal override void executeInstruction(List<Argument> args )
        {
            
        }
        
        public static Sub parseArgs(List<string> args)
        {
            var sub = new Sub();
            //passes Instruction in Parameter 1 the arguments in args
            //calls modified version of addArg (below) in child class 
            addParsedArgs(sub, args);
            return sub;
        }
        
    }
}