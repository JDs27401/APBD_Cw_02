namespace MP01;
using System;

public class OverfillException : Exception
{
    public OverfillException()
    {
        
    }

    public OverfillException(string message) : base(message)
    {
        
    }

    public OverfillException(String message, Exception innerException) : base(message, innerException)
    {
        
    }
}