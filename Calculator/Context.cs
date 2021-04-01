using System.Numerics;

namespace Calculator
{
    public class Context
    {
        private IOperator _operator;

        public Context(IOperator _operator)
        {
            this._operator = _operator;
        }

        public decimal executeOperator(decimal num1, decimal num2)
        {
            return _operator.doOperation(num1, num2);
        }
    }
}
