namespace GutCheck.Web.Models
{
    public class BaseViewModel
    {
        public required string Subtitle { get; set; }

        public ServerMessageCollection Messages { get; set; } = new ServerMessageCollection();
    }
}
