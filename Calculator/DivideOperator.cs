using System;
using System.Numerics;

namespace Calculator
{
    public class DivideOperator : IOperator
    {
        public BigInteger doOperation(BigInteger num1, BigInteger num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            return num1 / num2;
        }
    }
}
