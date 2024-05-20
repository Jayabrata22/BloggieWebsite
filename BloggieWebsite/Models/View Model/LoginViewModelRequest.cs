namespace BloggieWebsite.Models.View_Model
{
    public class LoginViewModelRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
    
}
