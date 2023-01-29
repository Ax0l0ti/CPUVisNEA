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
            Instruction.addParsedArgs(mov, new string[]{"R1", "1234"}.ToList());
            Assert.Equals(mov.Arguments.Count, 2);
            Instruction.addParsedArgs(mov, new string[]{"R1", "R1"}.ToList());
            
       }

        /* todo list of tests
        file handling  
        ---->  reading
        ---->  writing 
        ---->  creating
        
        Instructions 
        ---->  Valid
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