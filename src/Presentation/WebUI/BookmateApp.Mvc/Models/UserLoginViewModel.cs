using System.ComponentModel.DataAnnotations;

namespace BookmateApp.Mvc.Models;

public class UserLoginViewModel
{
    [Required(ErrorMessage = "Kullanıcı adı boş olamaz!")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Şifre boş olamaz!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string PageToGo { get; set; }
}

