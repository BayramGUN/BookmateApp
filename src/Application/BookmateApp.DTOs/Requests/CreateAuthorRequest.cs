using System.ComponentModel.DataAnnotations;

namespace BookmateApp.DTOs.Requests;

public class CreateAuthorRequest
{
    [Required(ErrorMessage = "Yazar adı boş bırakılamaz!")]
    [MaxLength(35)]
    public string? Firstname { get; set; } 
    [Required(ErrorMessage = "Yazar soyadı boş bırakılamaz!")]
    public string? Lastname { get; set; } 
    [MaxLength(350, ErrorMessage = "Yazar bilgisi 350 karakterden fazla olmamalıdır!")]
    public string? Info { get; set; } 
}