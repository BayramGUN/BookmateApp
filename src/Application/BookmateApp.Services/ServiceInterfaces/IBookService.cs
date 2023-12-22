using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;

namespace BookmateApp.Services.ServiceInterfaces;

public interface IBookService 
{
    Task CreateBookAsync(CreateBookRequest createBookRequest);
    //Task<Guid> CreateBookIdReturner(CreateBookRequest createBookRequest);

    Task<BookDisplayResponse> GetBookByIdAsync(Guid id);
    Task<IList<BookDisplayResponse>> GetAllBooksAsync();
    Task<UpdateBookRequest> GetBookForUpdateAsync(Guid id);

    Task<IList<BookDisplayResponse>> SearchBooksByTitleAsync(string title);
    Task UpdateBookAsync(UpdateBookRequest updateBookRequest);
    Task<bool> IsBookExist(Guid id);
    Task DeleteBookAsync(Guid id); 
    Task<IEnumerable<BookDisplayResponse>> GetBooksByGenreAsync(Guid genreId);
    Task<IEnumerable<BookDisplayResponse>> GetBooksByAuthorAsync(Guid authorId);
}