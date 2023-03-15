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
            string[,] premadeFiles = new string[,] { 
                {"Labeltest", "B Test\r\nMOV R0, #10\r\nOUT R0\r\nTest: MOV R0, #69\r\nOUT R0\r\nHALT"} ,
                { "for100", "MOV R0, #1\r\nstartloop: OUT R0\r\nADD R0, R0, #1\r\nCMP R0, #100\r\nBNE  startloop\r\nendloop: HALT\r\n " } 
                //{ "EveryTest", ""}
                /* MOV R9, #244
                MOV R8, #1
                MOV R0, #10
                LDR R1, R0
                MOV R2, #5
                OUT R1
                ADD R1, R1, R8
                OUT R1
                SUB R1, R1, R8
                OUT R1
                CMP R9, #244
                BEQ pass
                OUT R9
                pass: CMP R2, #10
                BGT greater
                OUT R1
                greater: OUT R2
                AND R2, R2, R8
                OUT R2
                ORR R2, R2, R7
                OUT R2
                EOR R2, R2, R7
                OUT R2
                OUT R0
                LSL R0, R0, #2
                OUT R0
                LSR R0, R0, #1
                OUT R0
                HALT */
            };
        for(int i = 0; i < premadeFiles.GetLength(0); i++ )
            {
                string PushPath = Environment.GetFolderPath( Environment.SpecialFolder.Personal ) + "\\CPU_Edu_UI\\" + premadeFiles[i,0];

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
