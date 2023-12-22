using AutoMapper;
using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using BookmateApp.Entities;
using BookmateApp.Infrastructure.Repositories.RepositoryInterFaces;
using BookmateApp.Services.Mappings.Extensions;
using BookmateApp.Services.ServiceInterfaces;

namespace BookmateApp.Services.ServiceImplementations;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task CreateBookAsync(CreateBookRequest createBookRequest)
    {
        var bookEntity = createBookRequest.ConvertFromCreateBookRequest(_mapper);
        await _bookRepository.CreateAsync(bookEntity);
    }

    public async Task DeleteBookAsync(Guid id) =>
        await _bookRepository.DeleteAsync(id);
    

    public async Task<IList<BookDisplayResponse>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return books.ConvertToBookDisplayResponses(_mapper);;
    }

    public async Task<BookDisplayResponse> GetBookByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetAsync(id);
        return book.ConvertToBookDisplayResponse(_mapper);
    } 
    public async Task<UpdateBookRequest> GetBookForUpdateAsync(Guid id)
    {
        var book = await _bookRepository.GetAsync(id);
        return book.ConvertToUpdateBookRequest(_mapper);
    }

    public async Task<IEnumerable<BookDisplayResponse>> GetBooksByGenreAsync(Guid genreId)
    {
        var booksByGenre = await _bookRepository.GetBooksByGenreAsync(genreId);
        return booksByGenre.ConvertToBookDisplayResponses(_mapper);
    }

    public async Task<IEnumerable<BookDisplayResponse>> GetBooksByAuthorAsync(Guid authorId)
    {
        var booksByAuthor = await _bookRepository.GetBooksByAuthorAsync(authorId);
        return booksByAuthor.ConvertToBookDisplayResponses(_mapper);
    }

    public async Task<bool> IsBookExist(Guid id) => 
        await _bookRepository.IsExistAsync(id);
    

    public async Task<IList<BookDisplayResponse>> SearchBooksByTitleAsync(string title)
    {
        var booksByName = await _bookRepository.GetBooksByTitleAsync(title);
        return booksByName.ConvertToBookDisplayResponses(_mapper);
    }

    public async Task UpdateBookAsync(UpdateBookRequest updateBookRequest)
    {
        var updateBook = updateBookRequest.ConvertFromUpdateBookRequest(_mapper);
        await _bookRepository.UpdateAsync(updateBook);
    }
}