using System.Diagnostics;
using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using BookmateApp.Mvc.Extensions;
using BookmateApp.Mvc.Models;
using BookmateApp.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.AspNetCore.Authorization;

namespace BookmateApp.Mvc.Controllers;

public class LibraryController : Controller
{
    private readonly IBookService _bookService;
    private readonly ILibraryService _libraryService;
    private const string librarySesion = "library";
    public LibraryController(IBookService bookService, ILibraryService libraryService)
    {
        _bookService = bookService;
        _libraryService = libraryService;
    }

    public IActionResult Index()
    {
        var bookCollection = getBookCollectionFromSession();
        return View(bookCollection);
    }

    public async Task<IActionResult> AddBook([FromQuery]Guid bookId)
    {
        Debug.WriteLine(bookId);
        BookDisplayResponse selectedBook = await _bookService.GetBookByIdAsync(bookId);
        var bookListItem = new BookListItem {
            Book = selectedBook
        };
        BookCollection bookCollection = getBookCollectionFromSession();
        bookCollection.AddBook(bookListItem);
        saveToSession(bookCollection);
        return Json(new { message = $"{selectedBook.Title} kütüphaneye eklendi"});
    }
    public async Task<IActionResult> RemoveBook([FromRoute]Guid id)
    {
        Debug.WriteLine(id);
        
        BookCollection bookCollection = getBookCollectionFromSession();
        bookCollection.RemoveBook(id);
        saveToSession(bookCollection);

        return View(nameof(Index), bookCollection);
    }

    private BookCollection getBookCollectionFromSession() => 
        HttpContext.Session.GetJson<BookCollection>(librarySesion) ?? new BookCollection();
    private void saveToSession(BookCollection bookCollection) => 
        HttpContext.Session.SetJson(librarySesion, bookCollection);

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateLibraryAsync(Guid[] selectedBooks, BookCollection listItem)
    {
        var libraryRequest = new CreateLibraryRequest {
            Id = Guid.NewGuid(),
            Title = listItem.LibraryName,
            Books = selectedBooks,
        };
        await _libraryService.CreateLibraryAsync(libraryRequest);
        BookCollection bookCollection = getBookCollectionFromSession();

        return RedirectToAction(nameof(Index), bookCollection);
    }

}
