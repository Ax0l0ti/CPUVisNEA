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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*
             added new line in main entry point of application to instantiate new CPU object
             I have then edited the UI class to take a CPU class as a parameter
            */
            var cpu = new CPU();

            var ui = new UI(cpu);
            
            Application.Run(ui);
            
        }

    }
    
    
}
