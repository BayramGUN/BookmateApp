using BookmateApp.Entities;
using BookmateApp.Infrastructure.Data;
using BookmateApp.Infrastructure.Repositories.RepositoryInterFaces;
using Microsoft.EntityFrameworkCore;

namespace BookmateApp.Infrastructure.Repositories.EFRepositoryImplementations;


public class EFGenreRepository : IGenreRepository
{
    private readonly BookmateAppDbContext _context;

    public EFGenreRepository(BookmateAppDbContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(Genre entity)
    {
        await _context.Genres!.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Genres!.FirstOrDefaultAsync(e => e.Id == id);
        _context.Genres!.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IList<Genre>> GetAllAsync() =>
        await _context.Genres.AsNoTracking()
                             .Include(g => g.Books)
                             .ToListAsync();
    public async Task<Genre?> GetAsync(Guid id) => 
        await _context.Genres!.AsNoTracking()
                              .Include(g => g.Books)
                              .SingleOrDefaultAsync(genre => genre.Id == id);

    public async Task<bool> IsExistAsync(Guid id) =>
        await _context.Genres!.AnyAsync(entity => entity.Id == id);


    public async Task UpdateAsync(Genre entity)
    {
        _context.Genres?.Update(entity);
        await _context.SaveChangesAsync();
    }
}