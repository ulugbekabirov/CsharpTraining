using System.Numerics;

namespace Calculator
{
    public class MultiplyOperator : IOperator
    {
        public BigInteger doOperation(BigInteger num1, BigInteger num2)
        {
            return num1 * num2;
        }
    }
}
