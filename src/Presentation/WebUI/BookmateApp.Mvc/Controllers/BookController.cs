using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using BookmateApp.Entities;
using BookmateApp.Mvc.Models;
using BookmateApp.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookmateApp.Mvc.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;

        public BookController(
                IBookService bookService, 
                IAuthorService authorService, 
                IGenreService genreService
            )
        {
            _bookService = bookService;
            _authorService = authorService;
            _genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooksAsync();
            return View(books);
        }

        public async Task<IActionResult> CreateBook()
        {

            var createBookViewModel = await bookViewModelGenerator();

            return View(createBookViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var bookForUpdate = await _bookService.GetBookForUpdateAsync(id);
            var updateBookModel = await bookViewModelGenerator(bookForUpdate);
            return View(updateBookModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, UpdateBookRequest updateBookRequest)
        {
            if (await _bookService.IsBookExist(id))
            {
                if (ModelState.IsValid)
                {
                    await _bookService.UpdateBookAsync(updateBookRequest);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            return NotFound();
        }
        private async Task<BookViewModel> bookViewModelGenerator(UpdateBookRequest? updateBookRequest = null)
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            var genres = await _genreService.GetAllGenresAsync();
            BookViewModel bookViewModel = new BookViewModel
            {
                CreateRequest = new CreateBookRequest(),
                AuthorItems = authors.Select(a => new SelectListItem { Text = a.FullName, Value = a.Id.ToString() }),
                GenreItems = genres.Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString() }),
            };
            if(updateBookRequest is not null) bookViewModel.UpdateRequest = updateBookRequest;
            return bookViewModel;
        }
    

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookRequest request)
        {
            if(ModelState.IsValid)
            {
                await _bookService.CreateBookAsync(request);
                return RedirectToAction("Index");
            }
            var createBookViewModel = await bookViewModelGenerator();
            return View(createBookViewModel); 
           
        }
    }
}
