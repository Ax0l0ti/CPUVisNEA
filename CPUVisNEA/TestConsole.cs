using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

using CPUVisNEA.Properties;
namespace CPUVisNEA
{
    [TestFixture] 
    // for 
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
            cpu.Compiler.StringProgram = new List<string>() { "compile" , "text","for","this test", ""};
            cpu.Compile("addProgram\n\n test\nawooga");
            foreach (var line in cpu.Compiler.StringProgram)
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
            var Reg = mov.validArgType(new RegisterArg( "R1" ) );
            var Int  = mov.validArgType(new IntegerArg( "123" ) );
            Console.WriteLine($"1st param = register expected T ---  {Reg} ");
            Console.WriteLine($"1st param = integer expected F ---  {Int}" , '\n');
            
            // add to mov and tests second parameters if valid 
            mov.addArg(new RegisterArg("R1"));
            Reg = mov.validArgType(new RegisterArg( "R1" ) );
            Int  = mov.validArgType(new IntegerArg( "#10" ) );
            Console.WriteLine($"2nd param = register expected F ---  {Reg}");
            Console.WriteLine($"2nd param = integer expected T ---  {Int}" , '\n');

        }//Completed 

        [Test] // I am uncertain if  TypeAndByteToArg works or contains logic errors
        //proves Argument can be successfully generated with given arg type and byte data 
        public void UncertaintytestForByte2ArgCast()
        {
            Argument test = cpu.TypeAndByteToArg(typeof(RegisterArg), 2);
            Console.WriteLine(test.GetType().Name);
        } //Completed

        [Test] //Provides a Test Interface to individually test Execute of a single instruction successfully change a CPU state correctlly 
        //proves string to arguement works 
        //proves parse Arguements works
        //proves execute instruction works
        //proves Valid parameter dictionary methods work
        public void TestExecuteSingleInstruction()
        {
            // args to deal with
            string arg1 = "R0"; string arg2 = "#10";
            // cheap way of returning Register Index 
            int targetIndex = int.Parse(arg1.Remove(0, 1));
            
            var args = new List<string>() { arg1, arg2 };
            //CHANGE THIS LINE TO EDIT INSTRUCTION TESTED
            Mov Test = Mov.parseArgs(args);
            Console.WriteLine($" Test calls {Test.Tag} Instruction with parameters {arg1} and {arg2} ");
            // test Move on completely blank CPU 
            CPUState defaultState = new CPUState();
            Console.WriteLine($"The initial value stored in {arg1} is {defaultState.Basic[targetIndex].content} ");
            CPUState newCPUState = Test.executeInstruction(Test.args, defaultState);
            Console.WriteLine($"The end value stored in {arg1} after {Test.Tag} instruction is {newCPUState.Basic[targetIndex].content} ");

        }
        


        /* todo list of tests
        file handling  h
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
        -------------->  correctly take Label location followed by instruction     
        
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