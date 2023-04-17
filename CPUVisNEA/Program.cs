// Define the TRACE directive, which enables trace output to the
// Trace.Listeners collection. Typically, this directive is defined
// as a compilation argument.

#define TRACE
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

// for Trace & Debug

// abstract data types 
// access to scope 

namespace CPUVisNEA
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //Message to display in Debug window to show successful initial compile of program
            Trace.WriteLine("Welcome to CPU - Debug window");

            // function to check for the file directory used for user premade files ( exists on school servers across computers) 
            PreMadeFolderCheck();
            PreMadeFilesCheck();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // I have created a new Instance of the CPU class to interact with my User Interface
            var cpu = new CPU();
            // the UI class has been modified to take a CPU as a parameter which uses the Instance above
            var ui = new UI(cpu);
            Application.Run(ui);
        }


        private static void PreMadeFolderCheck()
        {
            //create a basic folder within file path with guaranteed access by user's program
            var sAppPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\";

            if (!Directory.Exists(sAppPath))
            {
                Directory.CreateDirectory(sAppPath);
                Trace.WriteLine($"Directory Created [ path : {sAppPath} ] ");
            }
            else
            {
                Trace.WriteLine($"Directory [ path : {sAppPath} ] already exists");
            }
        }

        private static void PreMadeFilesCheck()
        {
            string[,] premadeFiles =
            {
                // creates for loop that iterates through outputs 1 to 100 
                {
                    "For100",
                    "MOV R1, #1\r\nMOV R0, #1\r\nstartloop: OUT R0\r\nADD R0, R0, R1\r\nCMP R0, #101\r\nBNE  startloop\r\nendloop: HALT\r\n "
                },
                //multiplies R0 and R1
                {
                    "Multiplication",
                    "\r\nMOV R0, #9 \r\nMOV R1, #12 \r\nMOV R2, #0 \r\nMOV R8, #1 \r\nOUT R0 \r\nOUT R1 \r\n" +
                    "startloop: AND R3, R0, R8 \r\nCMP R3, #1 \r\nBNE jump \r\nADD R2, R2, R1 \r\njump: LSR R0, R0, #1 \r\nLSL R1, R1, #1 \r\nCMP R0, #0 \r\nBEQ endloop " +
                    "\r\nB startloop \r\nendloop: OUT R2 \r\nHALT"
                },

                {
                    "Fibonnacci",
                    "MOV R0, #0\r\nMOV R1, #1\r\nMOV R2, #0\r\n" +
                    "FibonacciLoop: CMP R2, #500\r\nBGT FibonacciDone\r\nADD R2, R1, R0\r\n" +
                    "OUT R2\r\nLDR R0, R1\r\nLDR R1, R2\r\nB FibonacciLoop\r\n\nFibonacciDone: HALT"
                },

                // EveryInstruction - Test Vast Majority of all potential aspects
                // designed to test if ALL Instructions compiled and functioned.
                // Also used to test visual memory block with boundary size & storing extreme values
                {
                    "EveryInstruction",
                    //test of moving/storing/copying registers
                    "MOV R9, #244\r\nMOV R8, #1\r\nMOV R0, #10\r\nLDR R1, R0\r\nMOV R2, #5\r\nOUT R1\r\n" +
                    //test of add, sub and incidentally out 
                    "ADD R1, R1, R8\r\nOUT R1\r\nSUB R1, R1, R8\r\nOUT R1\r\n" +
                    //  tests branches, if EQ works, B and NE works. Test greater, hence lesser works 
                    "CMP R9, #244\r\nBEQ pass\r\nOUT R9\r\npass: CMP R2, #10\r\nBGT greater\r\nOUT R1\r\ngreater: OUT R2\r\n" +
                    // logic gate tests AND OR XOR
                    // using blank register 7 to test 
                    "AND R2, R2, R8\r\nOUT R2\r\nORR R2, R2, R7\r\nOUT R2\r\nEOR R2, R2, R7\r\nOUT R2\r\nOUT R0\r\n" +
                    //Binary shifts
                    "LSL R0, R0, #2\r\nOUT R0\r\nLSR R0, R0, #1\r\nOUT R0\r\nHALT"
                }
            };
            //used get length of 1st dimension in case New file manually appended later
            for (var i = 0; i < premadeFiles.GetLength(0); i++)
            {
                var PushPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\" +
                               premadeFiles[i, 0];
                //stop user maliciously modifying the default files via folder 
                File.Delete(PushPath);
                using (var sw = File.CreateText(PushPath))
                {
                    sw.WriteLine(premadeFiles[i, 1]);
                    sw.Close();
                }
            }
        }
    }
}