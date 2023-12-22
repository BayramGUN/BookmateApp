using System.Linq.Expressions;
using BookmateApp.Entities;
using BookmateApp.Infrastructure.Data;
using BookmateApp.Infrastructure.Repositories.RepositoryInterFaces;
using Microsoft.EntityFrameworkCore;

namespace BookmateApp.Infrastructure.Repositories.EFRepositoryImplementations;

public class EFBookRepository : IBookRepository
{
    private readonly BookmateAppDbContext _context;

    public EFBookRepository(BookmateAppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Book entity)
    {
        await _context.Books!.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var author = await _context.Books!.FirstOrDefaultAsync(entity => entity.Id == id);
        _context.Remove(author);
        await _context.SaveChangesAsync();
    }

    public async Task<IList<Book>> GetAllAsync() =>
        await _context.Books!.AsNoTracking()
                             .Include(b => b.Author)
                             .Include(b => b.Genre)
                             .ToListAsync();

    public async Task<Book?> GetAsync(Guid id) => 
        await _context.Books!.AsNoTracking()
                             .Include(book => book.Author)
                             .Include(book => book.Genre)
                             .SingleOrDefaultAsync(movie => movie.Id == id);

    public async Task<IList<Book>> GetBooksByTitleAsync(string title) =>
        await _context.Books!.AsNoTracking()
                             .Where(a => a.Title.Contains(title))
                             .ToListAsync();

     public async Task<IList<Book>> GetBooksByGenreAsync(Guid genreId) =>
        await _context.Books!.AsNoTracking()
                             .Where(b => b.GenreId == genreId)
                             .ToListAsync();

    public async Task<IList<Book>> GetBooksByAuthorAsync(Guid authorId) =>
        await _context.Books!.AsNoTracking()
                             .Where(b => b.AuthorId == authorId)
                             .ToListAsync();
        
    public async Task<bool> IsExistAsync(Guid id) =>
        await _context.Books!.AnyAsync(entity => entity.Id == id);

    public async Task UpdateAsync(Book entity)
    {
         _context.Books.Update(entity);
        await _context.SaveChangesAsync();
    }
}