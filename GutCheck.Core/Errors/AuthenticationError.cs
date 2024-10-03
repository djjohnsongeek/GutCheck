namespace GutCheck.Core.Errors
{
    public class AuthenticationError : Error
    {
        public AuthenticationError(string message = "Unknown Authentication Error") : base(message) { }
    }
}
