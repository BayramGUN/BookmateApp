using System.ComponentModel.DataAnnotations;

namespace BookmateApp.Entities;
public class Author : IEntity
{
    public Guid Id { get; set; }
    [Required]
    [MaxLength(35)]
    public string Firstname { get; set; } = string.Empty;
    [Required]
    public string Lastname { get; set; } = string.Empty;
    [MaxLength(350)]
    public string Info { get; set; } = string.Empty;
    public IList<Book>? Books { get; set; }
}
