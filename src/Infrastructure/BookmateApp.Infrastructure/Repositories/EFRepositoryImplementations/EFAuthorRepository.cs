using System.Diagnostics;
using System.Linq.Expressions;
using BookmateApp.Entities;
using BookmateApp.Infrastructure.Data;
using BookmateApp.Infrastructure.Repositories.RepositoryInterFaces;
using Microsoft.EntityFrameworkCore;

namespace BookmateApp.Infrastructure.Repositories.EFRepositoryImplementations;

public class EFAuthorRepository : IAuthorRepository
{
    private readonly BookmateAppDbContext _context;

    public EFAuthorRepository(BookmateAppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Author entity)
    {
        var user = _context.Authors!.AddAsync(entity);
        var createdEntity = user.Result.Entity.Id;
    } 


    public async Task DeleteAsync(Guid id)
    {
        var author = await _context.Authors!.FirstOrDefaultAsync(entity => entity.Id == id);
        _context.Remove(author);
        await _context.SaveChangesAsync();
    }

    public async Task<IList<Author>> GetAllAsync() =>
        await _context.Authors!.AsNoTracking()
                               .Include(a => a.Books)
                               .ToListAsync(); 

    public async Task<Author?> GetAsync(Guid id)
    {
        var author = await _context.Authors!.FirstOrDefaultAsync(entity => entity.Id == id);
        _context.Entry(author).State = EntityState.Detached;
        return author;

    }

    public async Task<IList<Author>> GetAuthorsByNameAsync(string name) =>
        await _context.Authors!.AsNoTracking().Where(a => a.Firstname.Contains(name)).ToListAsync();
        
    public async Task<bool> IsExistAsync(Guid id) =>
        await _context.Authors!.AnyAsync(entity => entity.Id == id);
        
    public async Task UpdateAsync(Author entity)
    {
        _context.Authors.Update(entity);
        await _context.SaveChangesAsync();
    }
}