namespace GutCheck.Web.Models
{
    public class BaseViewModel
    {
        public required string Subtitle { get; set; }

        public List<ServerMessage> Messages { get; set; } = new List<ServerMessage>();
    }
}
