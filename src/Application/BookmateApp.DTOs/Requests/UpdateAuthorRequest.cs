using System.ComponentModel.DataAnnotations;

namespace BookmateApp.DTOs.Requests;

public class UpdateAuthorRequest
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Yazar adını mutlaka girmelisiniz!")]
    [MaxLength(35, ErrorMessage = "Yazar adı en fazla 35 karakter içerebilir!")]
    public string? Firstname { get; set; }
    [Required(ErrorMessage = "Yazar adını mutlaka girmelisiniz!")]
    [MaxLength(35, ErrorMessage = "Yazar adı en fazla 35 karakter içerebilir!")]
    public string? Lastname { get; set; } 
    [MaxLength(350, ErrorMessage = "Yazar bilgisi en fazla 350 karakter içerebilir!")]
    public string? Info { get; set; } 
}