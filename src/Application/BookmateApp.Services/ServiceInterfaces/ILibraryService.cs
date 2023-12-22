using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using BookmateApp.Entities;

namespace BookmateApp.Services.ServiceInterfaces;

public interface ILibraryService
{
    // Commands
    Task CreateLibraryAsync(CreateLibraryRequest createLibraryRequest);
    Task UpdateLibraryAsync(UpdateLibraryRequest updateLibraryRequest);
    Task DeleteLibraryAsync(Guid libraryId);
    // Queries
    Task<IList<LibraryDisplayResponse>> GetAllLibrariesAsync();
    Task<LibraryDisplayResponse> GetLibraryByIdAsync(Guid libraryId);
}