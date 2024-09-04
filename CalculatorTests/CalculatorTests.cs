﻿namespace Calculator.Tests
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
        public void ShouldThowArgumentExceptionOnNegativeNumbers()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Calculator.CalculateSum("-5,2,-1"));
            Assert.AreEqual("Negative numbers found: -5,-1", exception.Message);
        }

        [TestMethod]
        public void ShouldTreatValuesMoreThan1000AsInvalid()
        {            // Arrange
            string input = "1,1001,2";
            int expectedResult = 3;

            // Act
            int result = Calculator.CalculateSum(input);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldHandleNullInput()
        {
            Assert.AreEqual(0, Calculator.CalculateSum(null));
        }

    }
}