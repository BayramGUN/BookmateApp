using AutoMapper;
using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using BookmateApp.Infrastructure.Repositories.RepositoryInterFaces;
using BookmateApp.Services.Mappings.Extensions;
using BookmateApp.Services.ServiceInterfaces;

namespace BookmateApp.Services.ServiceImplementations;

public class LibraryService : ILibraryService
{
    private readonly ILibraryRepository _libraryRepository;
    private readonly IMapper _mapper;

    public LibraryService(ILibraryRepository libraryRepository, IMapper mapper)
    {
        _libraryRepository = libraryRepository;
        _mapper = mapper;
    }

    public async Task CreateLibraryAsync(CreateLibraryRequest createLibraryRequest)
    {
        
        var request = createLibraryRequest.ConvertFromCreateLibraryRequest(_mapper);
        await _libraryRepository.CreateAsync(request);
    }

    public async Task DeleteLibraryAsync(Guid libraryId) => 
        await _libraryRepository.DeleteAsync(libraryId);

    public async Task<IList<LibraryDisplayResponse>> GetAllLibrariesAsync()
    {
        var responses = await _libraryRepository.GetAllAsync();
        return responses.ConvertToLibraryDisplayResponses(_mapper);
    }

    public async Task<LibraryDisplayResponse> GetLibraryByIdAsync(Guid libraryId)
    {
        var response = await _libraryRepository.GetAsync(libraryId);
        return response!.ConvertToLibraryDisplayResponse(_mapper);
    }

    public async Task UpdateLibraryAsync(UpdateLibraryRequest updateLibraryRequest)
    {
        var updateLibrary = updateLibraryRequest.ConvertFromUpdateLibraryRequest(_mapper);
        await _libraryRepository.UpdateAsync(updateLibrary);
    }
}