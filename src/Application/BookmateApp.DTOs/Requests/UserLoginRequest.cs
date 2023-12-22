using System.ComponentModel.DataAnnotations;

namespace BookmateApp.DTOs.Requests;

public class UserLoginRequest
{
    [Required(ErrorMessage = "Kullanıcı adı boş olamaz!")]
    public string Username { get; set;}
    [Required(ErrorMessage = "Şifre boş olamaz!")]
    public string Password { get; set;}
}