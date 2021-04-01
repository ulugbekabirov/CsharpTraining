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
            string postfix = infixToPostfix(input);
            //double result = evaluatePostfix(postfix);
            displayToTextBox(postfix.ToString());
        }

        private double evaluatePostfix(string postfix)
        {

        }


        private string infixToPostfix(string infix)
        {
            string result = "";

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < infix.Length; ++i)
            {
                char c = infix[i];

                if (char.IsDigit(c))
                {
                    result += c;
                }

                else if (c == '(')
                {
                    stack.Push(c);
                }

                else if (c == ')')
                {
                    while (stack.Count > 0 &&
                            stack.Peek() != '(')
                    {
                        result += stack.Pop();
                    }

                    if (stack.Count > 0 && stack.Peek() != '(')
                    {
                        return "Invalid Expression"; 
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else 
                {
                    while (stack.Count > 0 && precedence(c) <= precedence(stack.Peek()))
                    {
                        result += stack.Pop();
                    }
                    stack.Push(c);
                }

            }

            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }

        internal static int precedence(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }
            return -1;
        }
    }
}
