using System.Numerics;

namespace Calculator
{
    public class SubtractOperator : IOperator
    {
        public BigInteger doOperation(BigInteger num1, BigInteger num2)
        {
            return num1 - num2;
        }
    }
}
