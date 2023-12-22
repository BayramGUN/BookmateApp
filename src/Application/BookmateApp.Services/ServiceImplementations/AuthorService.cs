using AutoMapper;
using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using BookmateApp.Entities;
using BookmateApp.Infrastructure.Repositories.RepositoryInterFaces;
using BookmateApp.Services.Mappings.Extensions;
using BookmateApp.Services.ServiceInterfaces;

namespace BookmateApp.Services.ServiceImplementations;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task CreateAuthorAsync(CreateAuthorRequest createAuthorRequest)
    {
        var authorEntity = createAuthorRequest.ConvertFromCreateAuthorRequest(_mapper);
        await _authorRepository.CreateAsync(authorEntity);
    }

    public async Task DeleteAuthorAsync(Guid id) =>
        await _authorRepository.DeleteAsync(id);
    

    public async Task<IList<AuthorDisplayResponse>> GetAllAuthorsAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        return authors.ConvertToAuthorDisplayResponses(_mapper);;
    }

    public async Task<AuthorDisplayResponse> GetAuthorByIdAsync(Guid id)
    {
        var author = await _authorRepository.GetAsync(id);
        if(author is null)
            throw new ArgumentNullException($"There is no {typeof(AuthorDisplayResponse)} data with {id}");
        return author.ConvertToAuthorDisplayResponse(_mapper);
    }

    public async Task<UpdateAuthorRequest> GetAuthorForUpdateAsync(Guid id)
    {
        var author = await _authorRepository.GetAsync(id);
        return author.ConvertToUpdateAuthorRequest(_mapper);
    }

    public async Task<bool> IsAuthorExist(Guid id) => 
        await _authorRepository.IsExistAsync(id);
    

    public async Task<IList<AuthorDisplayResponse>> SearchAuthorsByNameAsync(string name)
    {
        var authorsByName = await _authorRepository.GetAuthorsByNameAsync(name);
        return authorsByName.ConvertToAuthorDisplayResponses(_mapper);
    }

    public async Task UpdateAuthorAsync(UpdateAuthorRequest updateAuthorRequest)
    {
        var updateAuthor = updateAuthorRequest.ConvertFromUpdateAuthorRequest(_mapper);
        await _authorRepository.UpdateAsync(updateAuthor);
    }
}