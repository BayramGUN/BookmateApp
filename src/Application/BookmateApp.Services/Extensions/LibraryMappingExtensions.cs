using AutoMapper;
using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using BookmateApp.Entities;

namespace BookmateApp.Services.Mappings.Extensions;

public static class LibraryMappingExtensions
{
    public static TDestination ToEntity<TSource, TDestination>(this TSource source, IMapper mapper) => 
        mapper.Map<TDestination>(source);
    public static LibraryDisplayResponse ConvertToLibraryDisplayResponse(this Library library, IMapper mapper) => 
        mapper.Map<LibraryDisplayResponse>(library);
    public static IList<LibraryDisplayResponse> ConvertToLibraryDisplayResponses(this IList<Library> library, IMapper mapper) => 
        mapper.Map<IList<LibraryDisplayResponse>>(library);
    public static Library ConvertFromCreateLibraryRequest(this CreateLibraryRequest libraryRequest, IMapper mapper) => 
        mapper.Map<Library>(libraryRequest);
    public static Library ConvertFromUpdateLibraryRequest(this UpdateLibraryRequest updateLibraryRequest, IMapper mapper) => 
        mapper.Map<Library>(updateLibraryRequest);

    public static Library CreateLibraryHandle(this CreateLibraryRequest request, IMapper mapper)
    {
        var library = new Library {
            Title = request.Title,
            Rate = request.Rate
        };
        return library;
    }
}