namespace Calculator
{
    public class Context
    {
        private IOperator _operator;

        public Context(IOperator _operator)
        {
            this._operator = _operator;
        }

        public decimal ExecuteOperator(decimal num1, decimal num2)
        {
            return _operator.DoOperation(num1, num2);
        }
    }
}
