using BookmateApp.Entities;

namespace BookmateApp.Infrastructure.Repositories.RepositoryInterfaces;

public interface IUserRepository : IRepository<Participant>
{
    Task<Participant> GetUserByUsernameAsync(string username);
}

