using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NUnit.Framework;

namespace CPUVisNEA
{
    [TestFixture]
    // for 
    public class TestConsole
    {
        //generating new CPU to work with for all tests
        private readonly CPU cpu = new CPU();

        [Test]
        public void TestOfTests()
        {
            Console.WriteLine("Thou doth work with great fanciness ");
        }

        [Test] //tests if Compile function can transform single string into string array 
        public void CompileTest()
        {
            cpu.Compiler.StringProgram = new List<string> { "compile", "text", "for", "this test", "" };
            cpu.Compile("addProgram\n\n test\nawooga");
            foreach (var line in cpu.Compiler.StringProgram) Console.WriteLine(line);
            cpu.Compile("MOV");
            foreach (var line in cpu.Compiler.StringProgram) Console.WriteLine(line);
        }

        [Test] //test if instruction argument parsing wont break on unexpected argument type
        public void testInstructionParse()
        {
            var mov = new Mov();
            Console.WriteLine(typeof(CPU.Instructions));
            Console.WriteLine(mov.Tag);
            //test if used method correctly validates a first parameter type
            var Reg = mov.validArgType(new RegisterArg("R1"));
            var Int = mov.validArgType(new IntegerArg("123"));
            Console.WriteLine($"1st param = register expected T ---  {Reg} ");
            Console.WriteLine($"1st param = integer expected F ---  {Int}", '\n');

            // add to mov and tests second parameters if valid 
            mov.addArg(new RegisterArg("R1"));
            Reg = mov.validArgType(new RegisterArg("R1"));
            Int = mov.validArgType(new IntegerArg("#10"));
            Console.WriteLine($"2nd param = register expected F ---  {Reg}");
            Console.WriteLine($"2nd param = integer expected T ---  {Int}", '\n');
        } //Completed 

        [Test] // I am uncertain if  TypeAndByteToArg works or contains logic errors
        //proves Argument can be successfully generated with given arg type and byte data 
        public void UncertaintyTestForByte2ArgCast()
        {
            var test = cpu.TypeAndByteToArg(typeof(RegisterArg), 2);
            Console.WriteLine(test.GetType().Name);
        } //Completed

        [Test] //Provides a Test Interface to individually test Execute of a single instruction successfully change a CPU state correctly 
        //proves string to argument works 
        //proves parse Arguments works
        //proves execute instruction works
        //proves Valid parameter dictionary methods work
        public void TestExecuteSingleInstruction()
        {
            // args to deal with
            var arg1 = "R0";
            var arg2 = "#10";
            // cheap way of returning Register Index 
            var targetIndex = int.Parse(arg1.Remove(0, 1));
            var args = new List<string> { arg1, arg2 };
            var Test = new Mov();
            Instruction.addParsedArgs(Test, args);
            Console.WriteLine($" Test calls {Test.Tag} Instruction with parameters {arg1} and {arg2} ");
            // test Move on completely blank CPU 
            var defaultState = new CPUState();
            Console.WriteLine($"The initial value stored in {arg1} is {defaultState.Basic[targetIndex].content} ");
            var newCPUState = Test.executeInstruction(Test.args, defaultState);
            Console.WriteLine(
                $"The end value stored in {arg1} after {Test.Tag} instruction is {newCPUState.Basic[targetIndex].content} ");
            //test cross ide
        }

        [Test]
        public void logicGateboolToBitTesting()
        {
            byte b1 = 7;
            byte b2 = 13;

            var AND = (byte)(b1 & b2);
            Console.WriteLine(
                $"vars | {b1}={int.Parse(Convert.ToString(b1, 2)).ToString("0000")} {b2}j={int.Parse(Convert.ToString(b2, 2)).ToString("0000")} ");
            Console.WriteLine($"and  | {b1} & {b2} = {AND} {int.Parse(Convert.ToString(AND, 2)).ToString("0000")}");
            var OR = (byte)(b1 | b2);
            Console.WriteLine($"or   | {b1} | {b2} = {OR} {int.Parse(Convert.ToString(OR, 2)).ToString("0000")}");
            var XOR = (byte)(b1 ^ b2);
            Console.WriteLine($"XOR  | {b1} ^ {b2} = {XOR} {int.Parse(Convert.ToString(XOR, 2)).ToString("0000")}");
        }

        [Test] // this was a throw away form to test all file handling before breaking it and creating individual forms 
        public void FileHandlingStartUp()
        {
            var FileHandling = new FileHandlingForm();
            Application.Run(FileHandling);
        }
        
        [Test] // 3.1 byte list to execution 
        public void bytelistExecution()
        {
            cpu.SetUpFresh();
            cpu.ram.Memory = new List<byte> {5, 9, 31, 0} ;
            cpu.FDECycle();
            
        }
    }
}