using System;
using Xunit;
using Calculator;

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
    }
}
