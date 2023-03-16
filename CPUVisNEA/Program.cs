// Define the TRACE directive, which enables trace output to the
// Trace.Listeners collection. Typically, this directive is defined
// as a compilation argument.
#define TRACE 
using System;
using System.Diagnostics; // for Trace & Debug

using System.Collections.Generic; // abstract data types 
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms; 
using CPUVisNEA.Properties; // access to scope 
using System.IO;

namespace CPUVisNEA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
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


        static void PreMadeFolderCheck()
        {
            //create a basic folder within file path with guaranteed access by user's program
            string sAppPath = Environment.GetFolderPath( Environment.SpecialFolder.Personal) + "\\CPU_Edu_UI\\" ;
            
            if (!System.IO.Directory.Exists(sAppPath))
            {
                System.IO.Directory.CreateDirectory(sAppPath);
                Trace.WriteLine($"Directory Created [ path : {sAppPath} ] ") ;
            }
            else
            {
                Trace.WriteLine($"Directory [ path : {sAppPath} ] already exists") ;
            }
        }

        static void PreMadeFilesCheck()
        {
            string[,] premadeFiles = { 
                // initial testing of premade files being used across network, kept for fun
                // used to test if labels worked correctly 
                {"Labeltest", "B Test\r\nMOV R0, #10\r\nOUT R0\r\nTest: MOV R0, #69\r\nOUT R0\r\nHALT"} ,
                
                // creates for loop that iterates through outputs 1 to 100 
                { "for100", "MOV R0, #1\r\nstartloop: OUT R0\r\nADD R0, R0, #1\r\nCMP R0, #101\r\nBNE  startloop\r\nendloop: HALT\r\n " } ,
                
                // EveryTest - Test Vast Majority of all potential aspects
                // designed to test if ALL Instructions compiled and functioned.
                // Also used to test visual memory block with boundary size & storing extreme values
                { "EveryTest",
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
        for(int i = 0; i < premadeFiles.GetLength(0); i++ )
            {
                string PushPath = Environment.GetFolderPath( Environment.SpecialFolder.Personal ) + "\\CPU_Edu_UI\\" + premadeFiles[i,0];
                //stop user maliciously modifiying the default files via folder 
                File.Delete( PushPath );
                using ( StreamWriter sw = File.CreateText( PushPath ) )
                {
                    sw.WriteLine( premadeFiles[i, 1] );
                    sw.Close();
                }
            }
        }
        
        
    }
}
