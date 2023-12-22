using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;

namespace BookmateApp.Services.ServiceInterfaces;

public interface IAuthorService
{
    Task CreateAuthorAsync(CreateAuthorRequest createAuthorRequest);
    //Task<Guid> CreateAuthorIdReturner(CreateAuthorRequest createAuthorRequest);

    Task<AuthorDisplayResponse> GetAuthorByIdAsync(Guid id);
    Task<UpdateAuthorRequest> GetAuthorForUpdateAsync(Guid id);
    Task<IList<AuthorDisplayResponse>> GetAllAuthorsAsync();

    Task<IList<AuthorDisplayResponse>> SearchAuthorsByNameAsync(string name);
    Task UpdateAuthorAsync(UpdateAuthorRequest updateAuthorRequest);
    Task<bool> IsAuthorExist(Guid id);
    Task DeleteAuthorAsync(Guid id); 
}