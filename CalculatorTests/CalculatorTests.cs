namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void CalculateSumTest()
        {
            // Arrange
            string input = "10,20";
            int expectedResult = 30;

            // Act
            int result = Calculator.CalculateSum(input); // Assuming CalculateSum is in Calculator class

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldIgnoreWhitespace()
        {
            Assert.AreEqual(5, Calculator.CalculateSum("  5,     "));
        }

        [TestMethod]
        public void ShouldHandleLeadingZeros()
        {
            Assert.AreEqual(5, Calculator.CalculateSum("005,0"));
        }

        [TestMethod]
        public void ShouldAddNegativeNumbersCorrectly()
        {
            Assert.AreEqual(-1, Calculator.CalculateSum("-5,4"));
        }

        [TestMethod]
        public void ShouldHandleLargeNumbers()
        {
            Assert.AreEqual(1000000000, Calculator.CalculateSum("500000000,500000000"));
        }

        [ExpectedException(typeof(FormatException))]
        public void ShouldThrowExceptionForInvalidInput()
        {
            Calculator.CalculateSum("abc,def");
        }

        [TestMethod]
        public void ShouldHandleNullInput()
        {
            Assert.AreEqual(0, Calculator.CalculateSum(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionForMoreThanTwoNumbers()
        {
            Calculator.CalculateSum("1,2,3");
        }
    }
}