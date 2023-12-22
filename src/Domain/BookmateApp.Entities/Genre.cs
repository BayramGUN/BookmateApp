using System.ComponentModel.DataAnnotations;

namespace BookmateApp.Entities;

public class Genre : IEntity
{
    public Guid Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;
    public IList<Book>? Books { get; set; }
}
