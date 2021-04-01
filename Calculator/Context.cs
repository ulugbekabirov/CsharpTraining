namespace Calculator
{
    public class Context
    {
        private IOperator _operator;

        public Context(IOperator _operator)
        {
            this._operator = _operator;
        }

        public double executeOperator(double num1, double num2)
        {
            return _operator.doOperation(num1, num2);
        }
    }
}
