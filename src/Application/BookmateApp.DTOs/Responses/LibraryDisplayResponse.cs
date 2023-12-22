namespace BookmateApp.DTOs.Responses;
/* 
 public Guid Id { get; set; }
    public IList<BooksLibrary>? BooksLibrary { get; set; } */
public class LibraryDisplayResponse
{
    public string Title { get; set; } = "Library";
    public int Rate { get; set; }
    public IList<string>? Books { get; set; }    
}