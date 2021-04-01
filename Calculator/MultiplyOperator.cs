namespace Calculator
{
    public class MultiplyOperator : IOperator
    {
        public decimal doOperation(decimal num1, decimal num2)
        {
            return num1 * num2;
        }
    }
}
