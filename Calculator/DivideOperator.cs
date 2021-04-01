using System;

namespace Calculator
{
    public class DivideOperator : IOperator
    {
        public decimal doOperation(decimal num1, decimal num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            return num1 / num2;
        }
    }
}
