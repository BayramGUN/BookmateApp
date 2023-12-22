using AutoMapper;
using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using BookmateApp.Entities;

namespace BookmateApp.Services.Mappings.Extensions;

public static class BookMappingExtensions
{
    public static TDestination ToEntity<TSource, TDestination>(this TSource source, IMapper mapper)
    {
        return mapper.Map<TDestination>(source);
    }

    public static BookDisplayResponse ConvertToBookDisplayResponse(this Book book, IMapper mapper) => 
        mapper.Map<BookDisplayResponse>(book);
    public static IList<BookDisplayResponse> ConvertToBookDisplayResponses(this IList<Book> book, IMapper mapper) => 
        mapper.Map<IList<BookDisplayResponse>>(book);
    public static Book ConvertFromCreateBookRequest(this CreateBookRequest bookRequest, IMapper mapper) => 
        mapper.Map<Book>(bookRequest);
    public static Book ConvertFromUpdateBookRequest(this UpdateBookRequest updateBookRequest, IMapper mapper) => 
        mapper.Map<Book>(updateBookRequest);

    public static UpdateBookRequest ConvertToUpdateBookRequest(this Book book, IMapper mapper) => 
        mapper.Map<UpdateBookRequest>(book);
}