namespace GutCheck.Web.Models
{
    public class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; } = string.Empty;
    }
}
