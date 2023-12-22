using BookmateApp.Entities;
using BookmateApp.Infrastructure.Data;
using BookmateApp.Infrastructure.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace BookmateApp.Infrastructure.Repositories.EFRepositoryImplementations;
public class EFUserRepository : IUserRepository
{
    private readonly BookmateAppDbContext _context;

    public EFUserRepository(BookmateAppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Participant entity)
    {
        await _context.Participants!.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Participant>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Participant?> GetAsync(Guid id)
    {
        var user = await _context.Participants!.AsNoTracking().SingleOrDefaultAsync(user => user.Id == id);
        return user; 
    }

    public async Task<Participant> GetUserByUsernameAsync(string username)
    {
        var user = await _context.Participants!.SingleOrDefaultAsync(
            entity => entity.Username == username);
        return user;
    }

    public async Task<bool> IsExistAsync(Guid id) =>
        await _context.Participants.AsNoTracking().AnyAsync(entity => entity.Id == id);

    public Task UpdateAsync(Participant entity)
    {
        throw new NotImplementedException();
    }
}

