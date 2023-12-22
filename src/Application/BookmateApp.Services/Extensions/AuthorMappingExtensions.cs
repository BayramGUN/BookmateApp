using AutoMapper;
using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using BookmateApp.Entities;

namespace BookmateApp.Services.Mappings.Extensions;

public static class AuthorMappingExtensions
{
    public static TDestination ToEntity<TSource, TDestination>(this TSource source, IMapper mapper) => 
        mapper.Map<TDestination>(source);
    public static AuthorDisplayResponse ConvertToAuthorDisplayResponse(this Author author, IMapper mapper) => 
        mapper.Map<AuthorDisplayResponse>(author);
    public static IList<AuthorDisplayResponse> ConvertToAuthorDisplayResponses(this IList<Author> authors, IMapper mapper) => 
        mapper.Map<IList<AuthorDisplayResponse>>(authors);
    public static Author ConvertFromCreateAuthorRequest(this CreateAuthorRequest authorRequest, IMapper mapper) => 
        mapper.Map<Author>(authorRequest);
    public static Author ConvertFromUpdateAuthorRequest(this UpdateAuthorRequest updateAuthorRequest, IMapper mapper) => 
        mapper.Map<Author>(updateAuthorRequest);
    public static UpdateAuthorRequest ConvertToUpdateAuthorRequest(this Author author, IMapper mapper) => 
        mapper.Map<UpdateAuthorRequest>(author);
}