using System.ComponentModel.DataAnnotations;

namespace BookmateApp.DTOs.Requests;

public class UpdateLibraryRequest
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = "Library";
    public int Rate { get; set; }
    
}