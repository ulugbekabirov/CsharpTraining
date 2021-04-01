using Xunit;
using Calculator;
using System.Numerics;

namespace UnitTests
{
    public class RPNCalculatorTests
    {
        [Fact]
        public void infixToPostfix_PassInfix_ReturnsPostfix()
        {
            //Arrange
            var inputValue = new string[] { "(", "20", "+", "50", ")", "*", "(", "30", "+", "20", ")"};
            var expectedValue = new string[] { "20", "50", "+", "30",  "20", "+", "*"};

            //Act
            var postfix = RPNCalculator.infixToPostfix(inputValue);

            //Assert
            Assert.Equal(postfix, expectedValue);
        }

        [Fact]
        public void evaluatePostfix_PassIntegerInPostfix_ComputesExpression()
        {
            //Arrange
            var inputValue = new string[] { "20", "50", "+", "30", "20", "+", "*" };
            var expectedValue = new decimal(3500);

            //Act
            var result = RPNCalculator.evaluatePostfix(inputValue);

            //Assert
            Assert.Equal(result, expectedValue);
        }

        [Fact]
        public void evaluatePostfix_PassDoubleInPostfix_ComputesExpression()
        {
            //Arrange 
            var inputValue = new string[] { "2.3", "5.5", "+", "3.3", "2.2", "-", "*" };
            var expectedValue = new decimal(8.58);

            //Act
            var result = RPNCalculator.evaluatePostfix(inputValue);

            //Assert
            Assert.Equal(result, expectedValue);
        }
    }
}
