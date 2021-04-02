using Xunit;
using Calculator;

namespace UnitTests
{
    public class RPNCalculatorTests
    {
        [Fact]
        public void InfixToPostfix_PassInfix_ReturnsPostfix()
        {
            //Arrange
            var inputValue = new string[] { "(", "20", "+", "50", ")", "*", "(", "30", "+", "20", ")"};
            var expectedValue = new string[] { "20", "50", "+", "30",  "20", "+", "*"};

            //Act
            var postfix = RPNCalculator.InfixToPostfix(inputValue);

            //Assert
            Assert.Equal(postfix, expectedValue);
        }

        [Fact]
        public void EvaluatePostfix_PassIntegerInPostfix_ComputesExpression()
        {
            //Arrange
            var inputValue = new string[] { "20", "50", "+", "30", "20", "+", "*" };
            var expectedValue = new decimal(3500);

            //Act
            var result = RPNCalculator.EvaluatePostfix(inputValue);

            //Assert
            Assert.Equal(result, expectedValue);
        }

        [Fact]
        public void EvaluatePostfix_PassDoubleInPostfix_ComputesExpression()
        {
            //Arrange 
            var inputValue = new string[] { "2.3", "5.5", "+", "3.3", "2.2", "-", "*" };
            var expectedValue = new decimal(8.58);

            //Act
            var result = RPNCalculator.EvaluatePostfix(inputValue);

            //Assert
            Assert.Equal(result, expectedValue);
        }
    }
}
