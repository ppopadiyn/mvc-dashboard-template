using System.ComponentModel.DataAnnotations;

namespace Dashboard.Mvc5
{
    public class LoginViewModel
    {
        [Required]
        [Display(Prompt = "Username")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Prompt = "Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}