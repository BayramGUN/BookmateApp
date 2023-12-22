namespace BookmateApp.DTOs.Responses;

public class BookDisplayResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? AuthorName { get; set; }
    public string? Genre { get; set; }
    public int? Rate { get; set; }
    public string CoverImageUrl { get; set; } = "https://picsum.photos/200/300";
    public DateTime PublishDate { get; set; }

}
