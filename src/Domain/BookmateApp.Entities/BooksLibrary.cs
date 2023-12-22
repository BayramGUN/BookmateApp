namespace BookmateApp.Entities;

public class BooksLibrary
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Book? Book { get; set; }
    public Guid LibraryId { get; set; }
    public Library? Library { get; set; }
}
