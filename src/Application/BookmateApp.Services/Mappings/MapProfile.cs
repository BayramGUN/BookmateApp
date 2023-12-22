using System.Runtime.InteropServices;
using AutoMapper;
using BookmateApp.DTOs.Requests;
using BookmateApp.DTOs.Responses;
using BookmateApp.Entities;
using Microsoft.Data.SqlClient;

namespace BookmateApp.Services.Mappings;

public class MapProfile : Profile
{
    public MapProfile()
    {
        // For Queries
        
        // Book
        CreateMap<Book, BookDisplayResponse>()
            .ForMember(
                dest => dest.AuthorName,
                opt => opt.MapFrom(src => $"{src.Author!.Firstname} {src.Author.Lastname}"))
            .ForMember(
                dest => dest.Genre,
                opt => opt.MapFrom(src => $"{src.Genre!.Name}")
            )
            .ReverseMap();
        // Author
        CreateMap<Author, AuthorDisplayResponse>()
            .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.Firstname} {src.Lastname}"))
            .ForMember(
                dest => dest.Books, 
                opt => opt.MapFrom(src => src.Books!.Select(books => books.Title))
            ).ReverseMap();  
        // Genre
        CreateMap<Genre, GenreDisplayResponse>();

        // Library
        CreateMap<Library, LibraryDisplayResponse>()
            .ForMember(
                dest => dest.Books,
                opt => opt.MapFrom(src => src.BooksLibrary!.Select(bookLibrary => bookLibrary.Book!.Title))
            );

        // User
        CreateMap<Participant, UserResponse>();

        // For Commands
        // Author
        CreateMap<UpdateAuthorRequest, Author>().ReverseMap();
        CreateMap<CreateAuthorRequest, Author>();

        // Book
        CreateMap<CreateBookRequest, Book>();
        CreateMap<UpdateBookRequest, Book>().ReverseMap();

        // Genre
        CreateMap<CreateGenreRequest, Genre>();

        // Library
        CreateMap<CreateLibraryRequest, Library>()
            .ForMember(
                dest => dest.BooksLibrary,
                opt => opt.MapFrom(
                    src => (src.Books != null) ? 
                    src.Books.Select(
                        b => new BooksLibrary { BookId = b, LibraryId = src.Id })
                        : null 
                ));

        CreateMap<UpdateLibraryRequest, Library>();

        // User
        CreateMap<UserLoginRequest, Participant>();
    }
}