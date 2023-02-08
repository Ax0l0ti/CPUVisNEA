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
        //generating new CPU
        private CPU cpu = new CPU();
        [Test] public void TestofTests()
        {
            Console.WriteLine("Thou doth work with great fanciness ");
        }

        [Test]
        public void CompileTest()
        {
            cpu.Ram.UProgRAM = new List<string>() { "compile" , "text","for","this test", ""};
            cpu.Compile("addProgram\n\n test\nawooga");
            foreach (var line in cpu.Ram.UProgRAM)
            {
                Console.WriteLine(line);
            }

        }

        [Test]
        public void testInstructionParse()
        {
            Mov mov = new Mov();
            Console.WriteLine( typeof(CPU.Instructions) ) ; 
            Console.WriteLine(mov.Tag);
            var valid = mov.validParamType(new RegisterArg() );
            var notValid  = mov.validParamType(new IntegerArg() );
            Console.WriteLine($"1st param = register should pass  {valid} as true ");
            Console.WriteLine($"1st param = integer should pass  {notValid} as false ");
            
            // todo add more lines to test second param valid 
            
            // Instruction.addParsedArgs(mov, new string[]{"R1", "1234"}.ToList());
            // Assert.Equals(mov.args.Count, 2);
            // Instruction.addParsedArgs(mov, new string[]{"R1", "R1"}.ToList());
            // Console.WriteLine(mov.args[0].GetType());
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