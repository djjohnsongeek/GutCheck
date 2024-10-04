using GutCheck.Core.Errors;
using System.Collections;

namespace GutCheck.Web.Models
{

    public class ServerMessageCollection : IEnumerable<ServerMessage>
    {
        private readonly List<ServerMessage> _messages;

        public ServerMessageCollection()
        {
            _messages = new List<ServerMessage>();
        }

        public ServerMessageCollection(List<Error> errors) : this()
        {
            AddErrors(errors);
        }

        public IEnumerator<ServerMessage> GetEnumerator()
        {
            return _messages.GetEnumerator();
        }

        public void AddErrors(IEnumerable<Error> errors)
        {
            foreach (var error in errors)
            {
                AddMessage(new ServerMessage(error));
            }
        }

        public void AddMessage(ServerMessage message)
        {
            _messages.Add(message);
        }

        public void Clear()
        {
            _messages.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _messages.GetEnumerator();
        }
    }

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
