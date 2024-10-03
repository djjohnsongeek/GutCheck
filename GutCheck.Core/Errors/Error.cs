namespace GutCheck.Core.Errors
{
    public class Error
    {
        public string Message { get; }

        public Error(string message = "Unkown Error")
        {
            Message = message;
        }
    }
}
