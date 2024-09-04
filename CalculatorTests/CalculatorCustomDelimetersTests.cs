namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorCustomDelimetersTests
    {
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
        public void CalculateSumTestWithCustomDelimiter()
        {
            // Arrange
            string input = "//#\n2#5";
            int expectedResult = 7;

            // Act
            int result = Calculator.CalculateSum(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateSumTestWithCustom1CharOpenSquareParantisDelimiter()
        {
            // Arrange
            string input = "//[\n2[5";
            int expectedResult = 7;

            // Act
            int result = Calculator.CalculateSum(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateSumTestWithCustom1CharClosingSquareParantisDelimiter()
        {
            // Arrange
            string input = "//]\n2]5";
            int expectedResult = 7;

            // Act
            int result = Calculator.CalculateSum(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateSumTestWithCustomMultyCharEmptyDelimiter()
        {
            Calculator.CalculateSum("//[]\n11***22***33");
        }

        [TestMethod]
        public void CalculateSumTestWithCustomMultyCharDelimiter()
        {
            // Arrange
            string input = "//[***]\n11***22***33";
            int expectedResult = 66;

            // Act
            int result = Calculator.CalculateSum(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldHandleCustomDelimiterWithMultipleNewlines()
        {
            Assert.AreEqual(10, Calculator.CalculateSum("//[***]\n1***2\n3***4"));
        }

    }
}
