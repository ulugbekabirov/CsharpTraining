using System.Numerics;

namespace Calculator
{
    public interface IOperator
    {
        public BigInteger doOperation(BigInteger num1, BigInteger num2);
    }
}
