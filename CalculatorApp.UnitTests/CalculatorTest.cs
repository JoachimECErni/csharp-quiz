using NUnit.Framework;

namespace CalculatorApp.UnitTests;

[TestFixture]
public class CalculatorTest
{
    string NormalizeLineEndings(string input)
    {
        return input.Replace("\r\n", "\n").Replace("\r", "\n");
    }

    [Test]
    public void Successful_Calculation()
    {
        var calculator = new Calculator();

        var result = calculator.PerformOperation(10,5,"add");

        Assert.That(result, Is.EqualTo(15));
    }
    [Test]
    public void Invalid_Input()
    {
        // Arrange
        var input = "abc\n2\nadd\n";
        var expectedErrorMessage = "Invalid input. Please enter numeric values.\n";
        var expectedFinalMessage = "Enter the first number:\nCalculation attempt finished.\n";

        using (var stringReader = new StringReader(input))
        using (var stringWriter = new StringWriter())
        using (var errorWriter = new StringWriter())
        {
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);
            Console.SetError(errorWriter);

            // Act
            try
            {
                Console.WriteLine("Enter the first number:");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the second number:");
                double num2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");
                string operation = Console.ReadLine()?.ToLower() ?? string.Empty;

                var calculator = new Calculator();
                double result = calculator.PerformOperation(num1, num2, operation);
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid input. Please enter numeric values.");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                // Console.Error.WriteLine(e.Message); // Simulating Log.Error for this example
            }
            finally
            {
                Console.WriteLine("Calculation attempt finished.");
            }

            // Assert
            Assert.That(NormalizeLineEndings(errorWriter.ToString()), Is.EqualTo(expectedErrorMessage));
            Assert.That(NormalizeLineEndings(stringWriter.ToString()), Does.Contain(expectedFinalMessage));
        }
    }
    [Test]
    public void Division_By_Zero()
    {
        // Arrange
        var input = "10\n0\ndivide\n";
        var expectedErrorMessage = "Cannot divide by zero.\n";
        var expectedFinalMessage = "Enter the first number:\nEnter the second number:\nEnter the operation (add, subtract, multiply, divide):\nCalculation attempt finished.\n";

        using (var stringReader = new StringReader(input))
        using (var stringWriter = new StringWriter())
        using (var errorWriter = new StringWriter())
        {
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);
            Console.SetError(errorWriter);

            // Act
            try
            {
                Console.WriteLine("Enter the first number:");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the second number:");
                double num2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");
                string operation = Console.ReadLine()?.ToLower() ?? string.Empty;

                var calculator = new Calculator();
                double result = calculator.PerformOperation(num1, num2, operation);
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid input. Please enter numeric values.");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                // Console.Error.WriteLine(e.Message); // Simulating Log.Error for this example
            }
            finally
            {
                Console.WriteLine("Calculation attempt finished.");
            }

            // Assert
            Assert.That(NormalizeLineEndings(errorWriter.ToString()), Is.EqualTo(expectedErrorMessage));
            Assert.That(NormalizeLineEndings(stringWriter.ToString()), Does.Contain(expectedFinalMessage));
        }
    }
    [Test]
    public void Unsupported_Operation()
    {
        // Arrange
        var input = "10\n5\nmodulo\n";
        var expectedErrorMessage = "An error occurred: The specified operation is not supported.\n";
        var expectedFinalMessage = "Enter the first number:\nEnter the second number:\nEnter the operation (add, subtract, multiply, divide):\nCalculation attempt finished.\n";

        using (var stringReader = new StringReader(input))
        using (var stringWriter = new StringWriter())
        using (var errorWriter = new StringWriter())
        {
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);
            Console.SetError(errorWriter);

            // Act
            try
            {
                Console.WriteLine("Enter the first number:");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the second number:");
                double num2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");
                string operation = Console.ReadLine()?.ToLower() ?? string.Empty;

                var calculator = new Calculator();
                double result = calculator.PerformOperation(num1, num2, operation);
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid input. Please enter numeric values.");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                // Console.Error.WriteLine(e.Message); // Simulating Log.Error for this example
            }
            finally
            {
                Console.WriteLine("Calculation attempt finished.");
            }

            // Assert
            Assert.That(NormalizeLineEndings(errorWriter.ToString()), Is.EqualTo(expectedErrorMessage));
            Assert.That(NormalizeLineEndings(stringWriter.ToString()), Does.Contain(expectedFinalMessage));
        }
    }
}