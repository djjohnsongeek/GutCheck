using GutCheck.Core.Errors;

namespace GutCheck.Web.Models
{
    public class ServerMessage
    {
        public string Message { get; set; }
        public ServerMessageCategory Category { get; set; }

        public ServerMessage(string msg, ServerMessageCategory category)
        {
            Message = msg;
            Category = category;
        }

        public ServerMessage(Error error)
        {
            Message = error.Message;
            Category = ServerMessageCategory.Error;
        }
    }

    public enum ServerMessageCategory
    {
        Info,
        Warning,
        Error
    }
}
