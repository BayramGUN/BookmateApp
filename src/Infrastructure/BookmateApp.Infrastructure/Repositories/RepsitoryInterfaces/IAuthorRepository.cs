using BookmateApp.Entities;

namespace BookmateApp.Infrastructure.Repositories.RepositoryInterFaces;

public interface IAuthorRepository : IRepository<Author>
{
    Task<IList<Author>> GetAuthorsByNameAsync(string name);
}