using System.ComponentModel.DataAnnotations;

namespace BookmateApp.Entities;

public class Book : IEntity
{
    public Guid Id { get; set; }
    [Required]
    [MaxLength(75)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(750)]
    public string? Description { get; set; }
    public DateTime? PublishDate { get; set; }
    public Guid AuthorId { get; set; }
    public Author? Author { get; set; }
    public bool? IsRead { get; set; }
    public int? Rate { get; set; }
    public Guid GenreId { get; set; }
    public Genre? Genre { get; set; }
    public string? CoverImageUrl { get; set; } = "https://picsum.photos/200/300";

    public IList<BooksLibrary>? BooksLibrary { get; set; }
}