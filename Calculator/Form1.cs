using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string input = String.Empty;
        private readonly string splitPattern = "([-+*/()])";
        private readonly char[] availableOperators = { '+', '-', '*', '/' };
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
            if (!availableOperators.Contains(input.Last()))
            {
                input += btn.Text;
                displayToTextBox(input);
            }
        }

        private void dot_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (char.IsDigit(input.LastOrDefault()))
            {
                input += btn.Text;
                displayToTextBox(input);
            }
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            if (input.Length > 0)
            {
                input = input.Remove(input.Length - 1, 1);
                displayToTextBox(input);
            }
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
            if (!string.IsNullOrEmpty(input))
            {
                try
                {
                    string[] infix = Regex.Split(input, splitPattern).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                    string[] postfix = RPNCalculator.infixToPostfix(infix);
                    decimal result = RPNCalculator.evaluatePostfix(postfix);
                    displayToTextBox(result.ToString());
                }
                catch (Exception ex)
                {
                    displayToTextBox(ex.Message);
                }
                finally
                {
                    input = string.Empty;
                }
            }
        }
    }
}
