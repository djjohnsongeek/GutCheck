using GutCheck.Core.Entities;
using GutCheck.Core.Errors;

namespace GutCheck.Core.Types
{
    public class AuthResult
    {
        public List<AuthenticationError> Errors { get; }
        public User? User { get; set; }
        public bool IsAuthenticated => User != null && !HasErrors;
        public bool HasErrors => Errors.Count > 0;

        public AuthResult()
        {
            User = null;
            Errors = new List<AuthenticationError>();
        }

        public AuthResult(User? user) : this()
        {
            User = user;
            if (user == null)
            {
                Errors.Add(new AuthenticationError("User could not be found."));
            }
        }

        public AuthResult(string errorMessage, User? user) : this(user)
        {
            Errors.Add(new AuthenticationError(errorMessage));
        }
    }
}
