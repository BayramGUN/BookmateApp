using BookmateApp.DTOs.Responses;

namespace BookmateApp.Mvc.CacheTools;

public class MemoryCacheData
{
    public IList<BookDisplayResponse> Books { get;set; }
    public DateTime CacheTime { get; set; } 
}