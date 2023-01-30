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
    
    
    //---------------------------------------- Argument classes ------------------------------------------------
    //todo fill in arguement and acceptible RegArg and Literal value arguements, Add additonal types of parameters
    
    
    
    public interface Argument
    {
    }
    /*Potential Parameters -
     
     Register Argument  ( memory reference is basically a Register Argument) 
     Integer Argument
     label ( label : Normal Line todo whilst filtering, if random string ( label ) , check valid b4 record index and label name - treat after : as instruction to be filtered
     condition ( on B if bla bla bla )
     */
    public class RegisterArg : Argument { public int index; } // requires index of register before calling to CPU to retrieve value of target
    
    public class IntegerArg : Argument {public int value; } // basic value passed
    
    public class label : Argument //todo maybe create linked class between label argument and desitnation location
    {   private int location; // destination
        private string name; // correspondent string for display purpose
    }
    public class condition : Argument
    {
        private string expression; // todo new class expression required that takes parameters and returns boolean
    } 
    
    
    //----------------------------------------Instruction classes and generation------------------------------------------------
    
    
    public abstract class Instruction
    {
        //protected so all inherited classes have args attributes 
        // internal so TestConsole can access child class' args
        protected internal List<Argument> args = new List<Argument>(); //list of instruction arguments
        public CPU.Instructions Tag { get; } //use enum to get Tag ( instruction name ) 
        //sets instruction tag automatically to new instance of an Instruction class or child classes
        protected Instruction(CPU.Instructions tag)
        {
            this.Tag = tag;
        }
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
                //     case : "condition" { Argument parsed = new condition(); break;
                //     default : new ErrorMessage("unrecognised")
                // }
                
                //temporary 
                Argument parsed = new IntegerArg();
                
                // empty Protected method that can be overriden to allow different 
                //todo check if below works
                instruc.addArg(parsed);
            }
        }

        protected abstract void addArg(Argument arg);

        protected abstract void executeInstruction( /*arguement type*/ List<Argument> args); //????????

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
    //AND RegisterArg, RegisterArg, IntorReg
    //ORR RegisterArg, RegisterArg, IntorReg
    //EOR RegisterArg, RegisterArg, IntorReg
    //LSL RegisterArg, RegisterArg, IntorReg
    //LSR RegisterArg, RegisterArg, IntorReg
    //ADD RegisterArg, RegisterArg, IntorReg
    //SUB RegisterArg, RegisterArg, IntorReg
    
    
    //todo create all instruction options
    
    //---------------------------------------     HALT     Instruction ------------------------------------------------
    public class Halt : Instruction
    {
        public Halt() : base(CPU.Instructions.HALT)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected override void executeInstruction(List<Argument> args )
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
        

        //overriden to only accept valid parameter types in specific positions
        
        protected override void addArg(Argument arg) //TODO LIESSSSSSSS 
        {
            //if argument added isn't an acceptable type of argument at 1st Instruction parameter
            if ( ( !arg.GetType().IsInstanceOfType(typeof(RegisterArg)) && args.Count == 0 ) 
                 ||  // or not acceptable type of argument at 2nd argument 
                 ( !arg.GetType().IsInstanceOfType(typeof(IntegerArg)) && args.Count == 1 )  )
            { throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
            }
            else //acceptable input 
            {
                
            }

        }
    }
    
    //---------------------------------------     B     Instruction ------------------------------------------------
    // todo special due to condition

    public class B : Instruction
    {
        public B() : base(CPU.Instructions.B)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected override void executeInstruction(List<Argument> args )
        {
            
        }
        
        public static B parseArgs(List<string> args)
        {
            var b = new B();
            //passes Instruction in Parameter 1 the arguments in args
            //calls modified version of addArg (below) in child class 
            addParsedArgs(b, args);
            return b;
        }
        

        //overriden to only accept valid parameter types in specific positions
        
        protected override void addArg(Argument arg) //TODO LIESSSSSSSS
        {
            //if argument added isn't an acceptable type of argument at 1st Instruction parameter
            if ( ( !arg.GetType().IsInstanceOfType(typeof(RegisterArg)) && args.Count == 0 ) 
                 ||  // or not acceptable type of argument at 2nd argument 
                 ( !arg.GetType().IsInstanceOfType(typeof(IntegerArg)) && args.Count == 1 )  )
            { throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
            }
            else //acceptable input 
            {
                
            }

        }
    }

    //---------------------------------------     MOV     Instruction ------------------------------------------------
    public class Mov : Instruction
    {
        public Mov() : base(CPU.Instructions.MOV)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected override void executeInstruction(List<Argument> args )
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
        

        //overriden to only accept valid parameter types in specific positions
        
        protected override void addArg(Argument arg) //TODO LIESSSSSSSS 
        {
            //if argument added isn't an acceptable type of argument at 1st Instruction parameter
            if ( ( !arg.GetType().IsInstanceOfType(typeof(RegisterArg)) && args.Count == 0 ) 
                 ||  // or not acceptable type of argument at 2nd argument 
                 ( !arg.GetType().IsInstanceOfType(typeof(IntegerArg)) && args.Count == 1 )  )
            { throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
            }
            else //acceptable input 
            {
                
            }

        }
    }

    //---------------------------------------     CMP      Instruction ------------------------------------------------
    public class Cmp : Instruction
    {
        public Cmp() : base(CPU.Instructions.CMP)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected override void executeInstruction(List<Argument> args )
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
        

        //overriden to only accept valid parameter types in specific positions
        
        protected override void addArg(Argument arg) //TODO LIESSSSSSSS 
        {
            //if argument added isn't an acceptable type of argument at 1st Instruction parameter
            if ( ( !arg.GetType().IsInstanceOfType(typeof(RegisterArg)) && args.Count == 0 ) 
                 ||  // or not acceptable type of argument at 2nd argument 
                 ( !arg.GetType().IsInstanceOfType(typeof(IntegerArg)) && args.Count == 1 )  )
            { throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
            }
            else //acceptable input 
            {
                
            }

        }
    }

    //---------------------------------------     MVN      Instruction ------------------------------------------------
    public class Mvn : Instruction
    {
        public Mvn() : base(CPU.Instructions.MVN)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected override void executeInstruction(List<Argument> args )
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
        

        //overriden to only accept valid parameter types in specific positions
        
        protected override void addArg(Argument arg) //TODO LIESSSSSSSS 
        {
            //if argument added isn't an acceptable type of argument at 1st Instruction parameter
            if ( ( !arg.GetType().IsInstanceOfType(typeof(RegisterArg)) && args.Count == 0 ) 
                 ||  // or not acceptable type of argument at 2nd argument 
                 ( !arg.GetType().IsInstanceOfType(typeof(IntegerArg)) && args.Count == 1 )  )
            { throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
            }
            else //acceptable input 
            {
                
            }

        }
    }

    //---------------------------------------     LDR      Instruction ------------------------------------------------
    public class Ldr : Instruction
    {
        public Ldr() : base(CPU.Instructions.LDR)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected override void executeInstruction(List<Argument> args )
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
        

        //overriden to only accept valid parameter types in specific positions
        
        protected override void addArg(Argument arg) //TODO LIESSSSSSSS 
        {
            //if argument added isn't an acceptable type of argument at 1st Instruction parameter
            if ( ( !arg.GetType().IsInstanceOfType(typeof(RegisterArg)) && args.Count == 0 ) 
                 ||  // or not acceptable type of argument at 2nd argument 
                 ( !arg.GetType().IsInstanceOfType(typeof(IntegerArg)) && args.Count == 1 )  )
            { throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
            }
            else //acceptable input 
            {
                
            }

        }
    }

    //---------------------------------------     AND      Instruction ------------------------------------------------
    public class And : Instruction
    {
        public And() : base(CPU.Instructions.AND)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected override void executeInstruction(List<Argument> args )
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
        

        //overriden to only accept valid parameter types in specific positions
        
        protected override void addArg(Argument arg) //TODO LIESSSSSSSS 
        {
            //if argument added isn't an acceptable type of argument at 1st Instruction parameter
            if ( ( !arg.GetType().IsInstanceOfType(typeof(RegisterArg)) && args.Count == 0 ) 
                 ||  // or not acceptable type of argument at 2nd argument 
                 ( !arg.GetType().IsInstanceOfType(typeof(IntegerArg)) && args.Count == 1 )  )
            { throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
            }
            else //acceptable input 
            {
                
            }

        }
    }

    //---------------------------------------     ORR      Instruction ------------------------------------------------
    public class Orr : Instruction
    {
        public Orr() : base(CPU.Instructions.ORR)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected override void executeInstruction(List<Argument> args )
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
        

        //overriden to only accept valid parameter types in specific positions
        
        protected override void addArg(Argument arg) //TODO LIESSSSSSSS 
        {
            //if argument added isn't an acceptable type of argument at 1st Instruction parameter
            if ( ( !arg.GetType().IsInstanceOfType(typeof(RegisterArg)) && args.Count == 0 ) 
                 ||  // or not acceptable type of argument at 2nd argument 
                 ( !arg.GetType().IsInstanceOfType(typeof(IntegerArg)) && args.Count == 1 )  )
            { throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
            }
            else //acceptable input 
            {
                
            }

        }
    }

    //---------------------------------------     EOR      Instruction ------------------------------------------------
    public class Eor : Instruction
    {
        public Eor() : base(CPU.Instructions.EOR)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected override void executeInstruction(List<Argument> args )
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
        

        //overriden to only accept valid parameter types in specific positions
        
        protected override void addArg(Argument arg) //TODO LIESSSSSSSS 
        {
            //if argument added isn't an acceptable type of argument at 1st Instruction parameter
            if ( ( !arg.GetType().IsInstanceOfType(typeof(RegisterArg)) && args.Count == 0 ) 
                 ||  // or not acceptable type of argument at 2nd argument 
                 ( !arg.GetType().IsInstanceOfType(typeof(IntegerArg)) && args.Count == 1 )  )
            { throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
            }
            else //acceptable input 
            {
                
            }

        }
    }

    //---------------------------------------     LSL      Instruction ------------------------------------------------
    public class Lsl : Instruction
    {
        public Lsl() : base(CPU.Instructions.LSL)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected override void executeInstruction(List<Argument> args )
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
        

        //overriden to only accept valid parameter types in specific positions
        
        protected override void addArg(Argument arg) //TODO LIESSSSSSSS 
        {
            //if argument added isn't an acceptable type of argument at 1st Instruction parameter
            if ( ( !arg.GetType().IsInstanceOfType(typeof(RegisterArg)) && args.Count == 0 ) 
                 ||  // or not acceptable type of argument at 2nd argument 
                 ( !arg.GetType().IsInstanceOfType(typeof(IntegerArg)) && args.Count == 1 )  )
            { throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
            }
            else //acceptable input 
            {
                
            }

        }
    }

    //---------------------------------------     LSR      Instruction ------------------------------------------------
    public class Lsr : Instruction
    {
        public Lsr() : base(CPU.Instructions.LSR)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected override void executeInstruction(List<Argument> args )
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
        

        //overriden to only accept valid parameter types in specific positions
        
        protected override void addArg(Argument arg) //TODO LIESSSSSSSS 
        {
            //if argument added isn't an acceptable type of argument at 1st Instruction parameter
            if ( ( !arg.GetType().IsInstanceOfType(typeof(RegisterArg)) && args.Count == 0 ) 
                 ||  // or not acceptable type of argument at 2nd argument 
                 ( !arg.GetType().IsInstanceOfType(typeof(IntegerArg)) && args.Count == 1 )  )
            { throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
            }
            else //acceptable input 
            {
                
            }

        }
    }

    //---------------------------------------     ADD      Instruction ------------------------------------------------
    public class Add : Instruction
    {
        public Add() : base(CPU.Instructions.ADD)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected override void executeInstruction(List<Argument> args )
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
        

        //overriden to only accept valid parameter types in specific positions
        
        protected override void addArg(Argument arg) //TODO LIESSSSSSSS 
        {
            //if argument added isn't an acceptable type of argument at 1st Instruction parameter
            if ( ( !arg.GetType().IsInstanceOfType(typeof(RegisterArg)) && args.Count == 0 ) 
                 ||  // or not acceptable type of argument at 2nd argument 
                 ( !arg.GetType().IsInstanceOfType(typeof(IntegerArg)) && args.Count == 1 )  )
            { throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
            }
            else //acceptable input 
            {
                
            }

        }
    }

    //---------------------------------------     SUB     Instruction ------------------------------------------------
    public class Sub : Instruction
    {
        public Sub() : base(CPU.Instructions.SUB)
        {
            
        }
        
        //todo create Instruction method to deal w input ( also add description of how operator works, from NEA writeup ) 
        protected override void executeInstruction(List<Argument> args )
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
        

        //overriden to only accept valid parameter types in specific positions
        
        protected override void addArg(Argument arg) //TODO LIESSSSSSSS 
        {
            //if argument added isn't an acceptable type of argument at 1st Instruction parameter
            if ( ( !arg.GetType().IsInstanceOfType(typeof(RegisterArg)) && args.Count == 0 ) 
                 ||  // or not acceptable type of argument at 2nd argument 
                 ( !arg.GetType().IsInstanceOfType(typeof(IntegerArg)) && args.Count == 1 )  )
            { throw new Exception($"= arg {args.Count + 1} can't be {arg.GetType()} ");
            }
            else //acceptable input 
            {
                
            }

        }
    }
}