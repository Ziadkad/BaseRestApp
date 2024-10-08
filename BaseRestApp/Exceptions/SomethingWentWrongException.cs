namespace BaseRestApp.Exceptions;

public class SomethingWentWrongException : Exception
{
    public SomethingWentWrongException() : base("Something went wrong.")
    {
    }
}