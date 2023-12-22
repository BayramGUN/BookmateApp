namespace BookmateApp.DTOs.Responses;


public class AuthorDisplayResponse
{
    public Guid Id { get; set; }
    public string? FullName { get; set; } 
    public IList<string>? Books { get; set; }
    public string? Info { get; set; } 
}