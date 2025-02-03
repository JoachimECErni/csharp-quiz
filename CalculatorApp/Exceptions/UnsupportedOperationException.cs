namespace CalculatorApp;


class UnsupportedOperationException: Exception
{
    public const string DefaultErrorMessage = "An error occurred: The specified operation is not supported.";
    public UnsupportedOperationException(): base(DefaultErrorMessage){}

    public UnsupportedOperationException(string message) : base(message){}

    public UnsupportedOperationException(string message, Exception inner): base(message,inner){}
}