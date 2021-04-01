﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private Context _context;
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
            try
            {
                string[] infix = Regex.Split(input, splitPattern).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                string[] postfix = infixToPostfix(infix);
                double result = evaluatePostfix(postfix);
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

        private double evaluatePostfix(string[] postfix)
        {
            Stack<double> stack = new Stack<double>();
            double val1, val2;
            for (int i = 0; i < postfix.Length; i++)
            {
                switch (postfix[i])
                {
                    case "+":
                        _context = new Context(new AddOperator());
                        stack.Push(_context.executeOperator(stack.Pop(), stack.Pop()));
                        break;
                    case "-":
                        _context = new Context(new SubtractOperator());
                        val1 = stack.Pop();
                        val2 = stack.Pop();
                        stack.Push(_context.executeOperator(val2, val1));
                        break;
                    case "*":
                        _context = new Context(new MultiplyOperator());
                        stack.Push(_context.executeOperator(stack.Pop(), stack.Pop()));
                        break;
                    case "/":
                        _context = new Context(new DivideOperator());
                        val1 = stack.Pop();
                        val2 = stack.Pop();
                        stack.Push(_context.executeOperator(val2, val1));
                        break;
                    default:
                        stack.Push(double.Parse(postfix[i]));
                        break;
                }
            }

            return stack.Pop();
        }

        private string[] infixToPostfix(string[] infix)
        {
            var result = new List<string>();
            var stack = new Stack<string>();

            for (int i = 0; i < infix.Length; ++i)
            {
                var c = infix[i];

                if (decimal.TryParse(c, out _))
                {
                    result.Add(c);
                }

                else if (c == "(")
                {
                    stack.Push(c);
                }

                else if (c == ")")
                {
                    while (stack.Count > 0 &&
                            stack.Peek() != "(")
                    {
                        result.Add(stack.Pop());
                    }

                    if (stack.Count > 0 && stack.Peek() != "(")
                    {
                        throw new InvalidOperationException("Invalid Expression");
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
                        result.Add(stack.Pop());
                    }
                    stack.Push(c);
                }

            }

            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }

            return result.ToArray();
        }

        internal static int precedence(string ch)
        {
            switch (ch)
            {
                case "+":
                case "-":
                    return 1;

                case "*":
                case "/":
                    return 2;

                case "^":
                    return 3;
            }
            return -1;
        }
    }
}
