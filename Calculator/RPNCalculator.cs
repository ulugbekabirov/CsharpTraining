using System;
using System.Collections.Generic;

namespace Calculator
{
    public static class RPNCalculator
    {
        private static Context _context;

        public static decimal EvaluatePostfix(string[] postfix)
        {
            var stack = new Stack<decimal>();
            decimal val1, val2;
            for (int i = 0; i < postfix.Length; i++)
            {
                switch (postfix[i])
                {
                    case "+":
                        _context = new Context(new AddOperator());
                        stack.Push(_context.ExecuteOperator(stack.Pop(), stack.Pop()));
                        break;
                    case "-":
                        _context = new Context(new SubtractOperator());
                        val1 = stack.Pop();
                        val2 = stack.Pop();
                        stack.Push(_context.ExecuteOperator(val2, val1));
                        break;
                    case "*":
                        _context = new Context(new MultiplyOperator());
                        stack.Push(_context.ExecuteOperator(stack.Pop(), stack.Pop()));
                        break;
                    case "/":
                        _context = new Context(new DivideOperator());
                        val1 = stack.Pop();
                        val2 = stack.Pop();
                        stack.Push(_context.ExecuteOperator(val2, val1));
                        break;
                    default:
                        stack.Push(decimal.Parse(postfix[i]));
                        break;
                }
            }

            return stack.Pop();
        }

        public static string[] InfixToPostfix(string[] infix)
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
                    while (stack.Count > 0 && Precedence(c) <= Precedence(stack.Peek()))
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

        private static int Precedence(string ch)
        {
            return ch switch
            {
                "+" or "-" => 1,
                "*" or "/" => 2,
                "^" => 3,
                _ => -1,
            };
        }
    }
}
