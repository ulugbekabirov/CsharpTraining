using System;

namespace Calculator
{
    public class DivideOperator : IOperator
    {
        public double doOperation(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            return num1 / num2;
        }
    }
}
