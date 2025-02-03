using System.Net;
using System.Xml.XPath;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CalculatorApp;

public class Calculator
{
    private readonly ILogger<Calculator> _logger;
    public Calculator(ILogger<Calculator> logger = null)
    {
        if (logger == null)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            logger = loggerFactory.CreateLogger<Calculator>();
        }

        _logger = logger;
    }
    public double Run(string? num1_input = null, 
        string? num2_input = null, string? 
        operation_input = null)
    {
        try
        {
            double num1, num2;
            string operation;

            _logger.LogInformation("Enter the first number:");
            if (num1_input == null)
                num1 = Convert.ToDouble(Console.ReadLine());
            else 
                num1 = Convert.ToDouble(num1_input);
            _logger.LogInformation($"{num1}");

            _logger.LogInformation("Enter the second number:");
            if (num2_input == null)
                num2 = Convert.ToDouble(Console.ReadLine());
            else
                num2 = Convert.ToDouble(num2_input);
            _logger.LogInformation($"{num2}");

            _logger.LogInformation("Enter the operation (add, subtract, multiply, divide):");
            if (operation_input == null)
                operation = Console.ReadLine()?.ToLower() ?? string.Empty;
            else
                operation = operation_input?.ToLower() ?? string.Empty;
            _logger.LogInformation($"{operation}");

            var calculator = new Calculator();
            double result = calculator.PerformOperation(num1, num2, operation);
            _logger.LogInformation($"The result is: {result}");
            return result;

        }
        catch (FormatException)
        {
            _logger.LogError("Invalid input. Please enter numeric values.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        finally
        {
            _logger.LogInformation("Calculation attempt finished.");
        }
        return 0;
    }
    public double PerformOperation(double num1, double num2, string operation)
    {
        switch(operation)
        {
            case "add":
                return num1+num2;
            case "subtract":
                return num1-num2;
            case "multiply":
                return num1*num2;
            case "divide":
                if(num2 == 0)
                    throw new DivideByZeroException("Cannot divide by zero.");
                return num1/num2;
            default:
                throw new UnsupportedOperationException();
        }
    }
}