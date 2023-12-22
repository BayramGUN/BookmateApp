using BookmateApp.DTOs.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookmateApp.Mvc.Models;
public class BookViewModel
{
    public UpdateBookRequest? UpdateRequest { get; set; }
    public CreateBookRequest? CreateRequest { get; set; } = new CreateBookRequest();
    public IEnumerable<SelectListItem>? AuthorItems { get; set; }
    public IEnumerable<SelectListItem>? GenreItems { get; set; }
}

