// Define the TRACE directive, which enables trace output to the
// Trace.Listeners collection. Typically, this directive is defined
// as a compilation argument.
#define TRACE
using System;
using System.Diagnostics;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPUVisNEA.Properties;

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
            Console.WriteLine("Hello console");
            Trace.WriteLine("Welcome to CPU sim 2000");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /* added new line in main entry point of application to instantiate new CPU object
                I have then edited the 
             
             */
            var cpu = new CPU();
            var ui = new UI(cpu);
            Application.Run(ui);
            
        }

    }
    
    
}
