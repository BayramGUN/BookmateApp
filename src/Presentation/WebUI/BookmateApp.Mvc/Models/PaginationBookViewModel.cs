

using BookmateApp.DTOs.Responses;

namespace BookmateApp.Mvc.Models;
public class PaginationBookViewModel
{
    public IEnumerable<BookDisplayResponse> Books { get; set; }
    public PagingInfoModel PagingInfoModel { get; set; }
}
