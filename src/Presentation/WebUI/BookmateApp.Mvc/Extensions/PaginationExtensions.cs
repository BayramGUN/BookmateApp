using BookmateApp.DTOs.Responses;
using BookmateApp.Mvc.Models;

namespace BookmateApp.Mvc.Extensions;

public static class PaginationExtensions
{
    public static PaginationBookViewModel CreatePagination(this Task<IEnumerable<BookDisplayResponse>> books, int pageNo)
    {
            var booksPerPage = 4;
            var booksCount = books.Result.Count();
            var totalPage = Math.Ceiling((decimal)booksCount / booksPerPage);

            var pagingInfo = new PagingInfoModel
            {
                CurrentPage = pageNo,
                ItemsPerPage = booksPerPage,
                TotalItems = booksCount
            };



            var paginatedBooks = books.Result.OrderBy(c => c.Id)
                                          .Skip((pageNo - 1) * booksPerPage)
                                          .Take(booksPerPage)
                                          .ToList();

            var model = new PaginationBookViewModel
            {
                Books = paginatedBooks,
                PagingInfoModel = pagingInfo
            };

            return model;
    }
}