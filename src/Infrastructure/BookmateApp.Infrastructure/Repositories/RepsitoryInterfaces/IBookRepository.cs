using BookmateApp.Entities;

namespace BookmateApp.Infrastructure.Repositories.RepositoryInterFaces;

public interface IBookRepository : IRepository<Book>
{
    Task<IList<Book>> GetBooksByTitleAsync(string title);
    Task<IList<Book>> GetBooksByGenreAsync(Guid genreId);
    Task<IList<Book>> GetBooksByAuthorAsync(Guid authorId);
}