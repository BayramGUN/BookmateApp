using BookmateApp.DTOs.Responses;
using BookmateApp.Mvc.CacheTools;
using BookmateApp.Mvc.Extensions;
using BookmateApp.Mvc.Models;
using BookmateApp.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace BookmateApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;
        private readonly IMemoryCache _memoryCache;
        public HomeController(
            ILogger<HomeController> logger,
            IBookService bookService,
            IMemoryCache memoryCache
        )
        {
            _logger = logger;
            _bookService = bookService;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index(int pageNo, Guid? id = null)
        {  

            var books = getBooksMemCacheOrDbAsync(id);
            var model = books.CreatePagination(pageNo);

            return View(model);
        }

        private async Task<IEnumerable<BookDisplayResponse>> getBooksMemCacheOrDbAsync(Guid? id = null)
        {
            if (!_memoryCache.TryGetValue("allBooks", out MemoryCacheData? cacheDataInfo))
            {
                var options = new MemoryCacheEntryOptions()
                                  .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                  .SetPriority(CacheItemPriority.Normal);

                cacheDataInfo = new MemoryCacheData
                {
                    CacheTime = DateTime.Now,
                    Books = await _bookService.GetAllBooksAsync()
                };

                _memoryCache.Set("allBooks", cacheDataInfo, options);
            }


            _logger.LogInformation($"{cacheDataInfo!.CacheTime.ToLongTimeString()} shows that created cache on this time");
            return (id == null) ? cacheDataInfo.Books :
                                await _bookService.GetBooksByGenreAsync(id.GetValueOrDefault());

        }
        public async Task<IActionResult> BookDetails(Guid id)
        {  

            var book = await _bookService.GetBookByIdAsync(id);

            return View(book);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogInformation("Something went wrong");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    
}