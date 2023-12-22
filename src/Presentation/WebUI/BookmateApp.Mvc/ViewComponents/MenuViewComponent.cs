using BookmateApp.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookmateApp.Mvc.ViewComponents;
public class MenuViewComponent : ViewComponent
{
    private readonly IGenreService _genreService;
    public MenuViewComponent(IGenreService genreService)
    {
        _genreService = genreService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var genres = await _genreService.GetAllGenresAsync();
        return View(genres);
    }
}
