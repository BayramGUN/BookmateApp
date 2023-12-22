using AutoMapper;
using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using BookmateApp.Infrastructure.Repositories.RepositoryInterFaces;
using BookmateApp.Services.Mappings.Extensions;
using BookmateApp.Services.ServiceInterfaces;

namespace BookmateApp.Services.ServiceImplementations;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public GenreService(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task CreateGenreAsync(CreateGenreRequest createGenreRequest)
    {
        var request = createGenreRequest.ConvertFromCreateGenreRequest(_mapper);
        await _genreRepository.CreateAsync(request);
    }

    public async Task<IList<GenreDisplayResponse>> GetAllGenresAsync()
    {
        var genres = await _genreRepository.GetAllAsync();
        return genres.ConvertToGenreDisplayResponses(_mapper);
    }
}