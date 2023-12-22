using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;

namespace BookmateApp.Services.ServiceInterfaces;

public interface IGenreService
{
    Task<IList<GenreDisplayResponse>> GetAllGenresAsync();
    
    Task CreateGenreAsync(CreateGenreRequest createGenreRequest);
}