using BookmateApp.Mvc.Extensions;
using BookmateApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookmateApp.Mvc.ViewComponents;

public class ListLinkViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var bookCollection = HttpContext.Session.GetJson<BookCollection>("library");
        return View(bookCollection);
    }
}