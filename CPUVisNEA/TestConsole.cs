using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

using CPUVisNEA.Properties;

namespace CPUVisNEA
{
    [TestFixture] 
    
    public class TestConsole
    {
        //generating new CPU to work with for all tests
        private CPU cpu = new CPU();
        [Test] public void TestofTests()
        {
            Console.WriteLine("Thou doth work with great fanciness ");
        }

        [Test] //tests if Compile function can transform single string into string array 
        public void CompileTest()
        {
            cpu.Ram.UStringProgRam = new List<string>() { "compile" , "text","for","this test", ""};
            cpu.Compile("addProgram\n\n test\nawooga");
            foreach (var line in cpu.Ram.UStringProgRam)
            {
                Console.WriteLine(line);
            }

        }

        [Test] //test if instruction argument parsing wont break on unexpected argument type
        public void testInstructionParse()
        {
            Mov mov = new Mov();
            Console.WriteLine( typeof(CPU.Instructions) ) ; 
            Console.WriteLine(mov.Tag);
            //test if used method correctly validates a first parameter type
            var Reg = mov.validParamType(new RegisterArg() );
            var Int  = mov.validParamType(new IntegerArg() );
            Console.WriteLine($"1st param = register expected T ---  {Reg} ");
            Console.WriteLine($"1st param = integer expected F ---  {Int}" , '\n');
            
            // add to mov and tests second parameters if valid 
            mov.addArg(new RegisterArg());
             Reg = mov.validParamType(new RegisterArg() );
             Int  = mov.validParamType(new IntegerArg() );
            Console.WriteLine($"2nd param = register expected F ---  {Reg}");
            Console.WriteLine($"2nd param = integer expected T ---  {Int}" , '\n');

        }
        

        /* todo list of tests
        file handling  
        ---->  reading
        ---->  writing 
        ---->  creating
        
        Instructions 
        ---->  Test if split works properly on a string 
        ---->  Computation 
        --------->  take the params and work w???
        ---->  Branch
        --------->  Conditional
        --------->  Labels locations 
        -------------->  correctly take label location followed by instruction     
        
        general Outputs LATER
        ---->  FDE Cycle
        --------->  Long
        --------->  Short
        ---->  Special Purpose Register update 
        --------->  Int 
        --------->  Instruction
         */
        
    }
}