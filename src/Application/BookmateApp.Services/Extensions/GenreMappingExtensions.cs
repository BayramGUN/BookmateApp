using AutoMapper;
using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using BookmateApp.Entities;

namespace BookmateApp.Services.Mappings.Extensions;

public static class GenreMappingExtensions
{

    public static IList<GenreDisplayResponse> ConvertToGenreDisplayResponses(this IList<Genre> genres, IMapper mapper) => 
        mapper.Map<IList<GenreDisplayResponse>>(genres);

    public static Genre ConvertFromCreateGenreRequest(this CreateGenreRequest genreRequest, IMapper mapper) => 
        mapper.Map<Genre>(genreRequest);

}