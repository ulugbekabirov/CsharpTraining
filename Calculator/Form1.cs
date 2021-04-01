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
        double result;
        string[] tokens = new string[] { };
        Stack<double> stack = new Stack<double>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void displayToTextBox(string text)
        {
            textBox.Text = "";
            textBox.Text += text;
        }

        private void operand_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            input += btn.Text;
            displayToTextBox(input);
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            input += btn.Text;
            displayToTextBox(input);
        }

        private void dot_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            input += btn.Text;
            displayToTextBox(input);
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            input = input.Remove(input.Length - 1, 1);
            displayToTextBox(input);
        }

        private void leftParenthesis_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            input += btn.Text;
            displayToTextBox(input);
        }

        private void rightParenthesis_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            input += btn.Text;
            displayToTextBox(input);
        }

        private void erase_Click(object sender, EventArgs e)
        {
            input = string.Empty;
            displayToTextBox(input);
        }

        private void compute_Click(object sender, EventArgs e)
        {
            string[] postfix = infixToPostfix(input);
            double result = evaluatePostfix(postfix);
        }

        private double evaluatePostfix(string[] postfix)
        {
            throw new NotImplementedException();
        }


        private string[] infixToPostfix(string infix)
        {
            throw new NotImplementedException();
        }
    }
}
