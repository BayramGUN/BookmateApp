using System.ComponentModel.DataAnnotations;

namespace BookmateApp.DTOs.Requests;
/* 
 public Guid Id { get; set; }
    public IList<BooksLibrary>? BooksLibrary { get; set; } */
public class CreateLibraryRequest
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Kütüphane ismi girmelisiniz!")]
    [MaxLength(100, ErrorMessage = "Kütüphane ismi en fazla 100 karakter içerebilir!")]
    public string Title { get; set; } = "Library";
    public float Rate { get; set; }
    public IList<Guid>? Books { get; set; }
    
}