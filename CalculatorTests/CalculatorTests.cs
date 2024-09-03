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
            int result = Calculator.CalculateSum(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateSumTestWithMultipleNumbers()
        {
            // Arrange
            string input = "1,2,3,4,5,6,7,8,9,10,11,12";
            int expectedResult = 78;

            // Act
            int result = Calculator.CalculateSum(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateSumTestWithNewLineAsDelimiter()
        {
            // Arrange
            string input = "1\n2,3";
            int expectedResult = 6;

            // Act
            int result = Calculator.CalculateSum(input);

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
        [ExpectedException(typeof(OverflowException))]
        public void ShouldThrowOverflowExceptionForLargeSum()
        {
            Calculator.CalculateSum("2147483647, 2147483647");
        }
    }
}