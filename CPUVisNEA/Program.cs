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
            PreMadePrograms_FileCheck();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // I have created a new Instance of the CPU class to interact with my User Interface
            var cpu = new CPU();
            // the UI class has been modified to take a CPU as a parameter which uses the Instance above
            var ui = new UI(cpu);
            Application.Run(ui);
        }


        static void PreMadePrograms_FileCheck()
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
        
        
    }
}
