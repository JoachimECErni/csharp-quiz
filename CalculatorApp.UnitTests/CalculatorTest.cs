using NUnit.Framework;

using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Castle.Core.Configuration;

namespace CalculatorApp.UnitTests;

[TestFixture]
public class CalculatorTest
{
    private Calculator _calculator;
    private Mock<ILogger<Calculator>> _mockLogger;

    [SetUp]
    public void SetUp()
    {
        _mockLogger = new Mock<ILogger<Calculator>>();
        _calculator = new Calculator(_mockLogger.Object);
    }

    [TestCase("5","10", "add",15)]
    public void Successful_Calculation(string num1, string num2, string operation, double expected_value)
    {
        var result = _calculator.Run(num1,num2,operation);

        _mockLogger.Verify(
            logger => logger.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("The result is")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);

        Assert.That(result, Is.EqualTo(expected_value));
    }

    [TestCase("abc")]
    public void Invalid_Input(string num1)
    {
        _calculator.Run(num1);

        _mockLogger.Verify(
            logger => logger.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Invalid input. Please enter numeric values.")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [TestCase("10","0","divide")]
    public void Division_By_Zero(string num1, string num2, string operation)
    {
        _calculator.Run(num1, num2, operation);

        _mockLogger.Verify(
            logger => logger.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Cannot divide by zero.")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [TestCase("5", "0", "modulo")]
    public void Unsupported_Operation(string num1, string num2, string operation)
    {
        _calculator.Run(num1, num2, operation);

        _mockLogger.Verify(
            logger => logger.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.
                Contains("An error occurred: The specified operation is not supported.")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}