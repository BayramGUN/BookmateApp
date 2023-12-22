using System.Diagnostics;
using BookmateApp.Entities;
using BookmateApp.Infrastructure.Data;
using BookmateApp.Infrastructure.Repositories.RepositoryInterFaces;
using Microsoft.EntityFrameworkCore;

namespace BookmateApp.Infrastructure.Repositories.EFRepositoryImplementations;

public class EFLibraryRepository : ILibraryRepository
{
    private readonly BookmateAppDbContext _context;

    public EFLibraryRepository(BookmateAppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Library entity)
    {
        await _context.Libraries!.AddAsync(entity);
        Debug.WriteLine(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Libraries!.FirstOrDefaultAsync(e => e.Id == id);
        _context.Libraries!.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IList<Library>> GetAllAsync() =>
        await _context.Libraries!.AsNoTracking()
                             .Include(l => l.BooksLibrary)
                             .ToListAsync();

    public async Task<Library?> GetAsync(Guid id) =>
        await _context.Libraries!.AsNoTracking()
                             .Include(l => l.BooksLibrary)
                             .SingleOrDefaultAsync(Library => Library.Id == id);

    public async Task<bool> IsExistAsync(Guid id) =>
        await _context.Libraries!.AnyAsync(entity => entity.Id == id);

    public async Task UpdateAsync(Library entity)
    {
        _context.Libraries?.Update(entity);
        await _context.SaveChangesAsync();
    }
}