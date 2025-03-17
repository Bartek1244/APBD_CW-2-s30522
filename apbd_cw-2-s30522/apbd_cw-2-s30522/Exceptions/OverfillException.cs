namespace apbd_cw_2_s30522.Exceptions;

public class OverfillException : System.Exception
{
    public OverfillException()
    {
    }

    public OverfillException(string message) : base(message)
    {
    }
    
    public OverfillException(string message, Exception innerException) : base(message, innerException)
    {
    }
    
}