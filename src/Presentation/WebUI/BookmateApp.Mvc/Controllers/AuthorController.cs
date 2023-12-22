using Azure.Core;
using BookmateApp.DTOs.Requests;
using BookmateApp.Services.ServiceImplementations;
using BookmateApp.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookmateApp.Mvc.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return View(authors);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var authorForUpdate = await _authorService.GetAuthorForUpdateAsync(id);
            return View(authorForUpdate);
        }
        
        

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, UpdateAuthorRequest updateAuthorRequest)
        {
            if(await _authorService.IsAuthorExist(id))
            {
                if(ModelState.IsValid)
                {
                    await _authorService.UpdateAuthorAsync(updateAuthorRequest);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            return NotFound();
        }


        public IActionResult CreateAuthor()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorRequest createAuthorRequest)
        {
            if (ModelState.IsValid)
            {
                await _authorService.CreateAuthorAsync(createAuthorRequest);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _authorService.IsAuthorExist(id))
            {
                await _authorService.DeleteAuthorAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
        }
    }
}
