using System.ComponentModel.DataAnnotations;

namespace BookmateApp.Entities;

public class Library : IEntity 
{
    public Guid Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = "Library";
    public float Rate { get; set; }
    public IList<BooksLibrary>? BooksLibrary { get; set; }
}