using System;
using System.Drawing;
using System.Windows.Forms;

/*

Notes Section

User Program

    2 states, edit and run state. Run state has added RAM display and step button 

    File Handling - 
        Creat dictionary that is maps executable file names to description/displayName of loadable files.
        stick files in the Bin > Debug > 
        messagebox.show
        

    USER RAM 
        need to find

    Compile //is there error?
        yes --> output error line, reason for error and line content. Also return edit state 
        no --> Compile next Line OR return run state, remove edit access to User Program TextBox. 
               Compile Button turns to "return to edit" button 
               
               Calculate number of RAM Lines Required
               Remove FDE Log Texts

        Create Method to read Line and check if acceptable structure, ?regular expression?

FDE Cycle Console Logs
    
Short FDE Cycle Log 

Set structure for all FDE cycles
Erase Text after complete FDE log

Detailed FDE Cycle Log 
Scrollable and continuously add to log. Only remove after Compile

*/






namespace CPUVisNEA
{
    public partial class Form1 : Form
    {
        
        private bool flip = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(flip ? Pens.Blue : Pens.Brown, 10, 10, 100, 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello changed!");
            flip = !flip;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        { Console.WriteLine("Checkbox");
            // hello
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserCodeOrRAM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void gb_userInput_Enter(object sender, EventArgs e)
        {

        }

        private void pnl_uCodeManip_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DropDownTest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}