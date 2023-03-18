using System.ComponentModel.DataAnnotations;

namespace Filmes_API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o Usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Password { get; set; }
    }
}
