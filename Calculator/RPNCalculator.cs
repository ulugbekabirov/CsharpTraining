using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class RPNCalculator
    {
        private static Context _context;

        public static BigInteger evaluatePostfix(string[] postfix)
        {
            Stack<BigInteger> stack = new Stack<BigInteger>();
            BigInteger val1, val2;
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
                        stack.Push(BigInteger.Parse(postfix[i]));
                        break;
                }
            }

            return stack.Pop();
        }

        public static string[] infixToPostfix(string[] infix)
        {
            var result = new List<string>();
            var stack = new Stack<string>();

            for (int i = 0; i < infix.Length; ++i)
            {
                var c = infix[i];

                if (BigInteger.TryParse(c, out _))
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

        private static int precedence(string ch)
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
