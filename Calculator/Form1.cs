using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string input = String.Empty;
        string operand1 = String.Empty;
        string operand2 = String.Empty;
        char operation;
        double result;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void two_Click(object sender, EventArgs e)
        {
            input += "2";
        }

        private void three_Click(object sender, EventArgs e)
        {
            input += "3";
        }

        private void plus_Click(object sender, EventArgs e)
        {
            input += "+";
        }

        private void four_Click(object sender, EventArgs e)
        {
            input += "4";
        }

        private void five_Click(object sender, EventArgs e)
        {
            input += "5";
        }

        private void six_Click(object sender, EventArgs e)
        {
            input += "6";
        }

        private void minus_Click(object sender, EventArgs e)
        {
            input += "-";
        }

        private void seven_Click(object sender, EventArgs e)
        {
            input += "7";
        }

        private void eight_Click(object sender, EventArgs e)
        {
            input += "8";
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            input += "*";
        }

        private void dot_Click(object sender, EventArgs e)
        {
            input += ".";
        }

        private void zero_Click(object sender, EventArgs e)
        {
            input += "0";
        }

        private void backspace_Click(object sender, EventArgs e)
        {
                
        }

        private void divide_Click(object sender, EventArgs e)
        {

        }

        private void leftParenthesis_Click(object sender, EventArgs e)
        {

        }

        private void rightParenthesis_Click(object sender, EventArgs e)
        {

        }

        private void compute_Click(object sender, EventArgs e)
        {

        }

        private void one_Click(object sender, EventArgs e)
        {

        }

        private void nine_Click(object sender, EventArgs e)
        {

        }
    }
}
