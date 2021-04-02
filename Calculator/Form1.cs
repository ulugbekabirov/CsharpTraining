using System;
using System.Data;
using System.Linq;
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

        private void DisplayToTextBox(string text)
        {
            textBox.Text = "";
            textBox.Text += text;
        }

        private void Operand_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            input += btn.Text;
            DisplayToTextBox(input);
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (!availableOperators.Contains(input.Last()))
            {
                input += btn.Text;
                DisplayToTextBox(input);
            }
        }

        private void Dot_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (char.IsDigit(input.LastOrDefault()))
            {
                input += btn.Text;
                DisplayToTextBox(input);
            }
        }

        private void Backspace_Click(object sender, EventArgs e)
        {
            if (input.Length > 0)
            {
                input = input.Remove(input.Length - 1, 1);
                DisplayToTextBox(input);
            }
        }

        private void LeftParenthesis_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            input += btn.Text;
            DisplayToTextBox(input);
        }

        private void RightParenthesis_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            input += btn.Text;
            DisplayToTextBox(input);
        }

        private void Erase_Click(object sender, EventArgs e)
        {
            input = string.Empty;
            DisplayToTextBox(input);
        }

        private void Compute_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(input))
            {
                try
                {
                    var infix = Regex.Split(input, splitPattern).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                    var postfix = RPNCalculator.InfixToPostfix(infix);
                    var result = RPNCalculator.EvaluatePostfix(postfix);
                    DisplayToTextBox(result.ToString());
                }
                catch (Exception ex)
                {
                    DisplayToTextBox(ex.Message);
                }
                finally
                {
                    input = string.Empty;
                }
            }
        }
    }
}
