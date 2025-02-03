
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CalculatorApp;

class Program
{
    static void Main(string[] args)
    {
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        var logger = loggerFactory.CreateLogger<Program>();

        var CalculatorApp = new Calculator();

        CalculatorApp.Run();
    }
}