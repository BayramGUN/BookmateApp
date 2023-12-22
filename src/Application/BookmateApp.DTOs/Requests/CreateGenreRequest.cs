using System.ComponentModel.DataAnnotations;

namespace BookmateApp.DTOs.Requests;

public class CreateGenreRequest
{
    [Required(ErrorMessage = "Tür adı mutlaka girilmelidir!")]
    [MaxLength(20, ErrorMessage = "Tür adı en fazla 20 karakter içermelidir!")]
    public string? Name { get; set; }
}