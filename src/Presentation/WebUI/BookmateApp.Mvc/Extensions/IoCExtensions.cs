using BookmateApp.Infrastructure.Data;
using BookmateApp.Infrastructure.Repositories.EFRepositoryImplementations;
using BookmateApp.Infrastructure.Repositories.RepositoryInterfaces;
using BookmateApp.Infrastructure.Repositories.RepositoryInterFaces;
using BookmateApp.Services.ServiceImplementations;
using BookmateApp.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace BookmateApp.Mvc.Extensions;

public static class IoCExtensions
{
    public static IServiceCollection AddInjections(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IAuthorRepository, EFAuthorRepository>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IBookRepository, EFBookRepository>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IGenreRepository, EFGenreRepository>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<ILibraryRepository, EFLibraryRepository>();
        services.AddScoped<ILibraryService, LibraryService>();     
        services.AddScoped<IUserRepository, EFUserRepository>();
        services.AddScoped<IUserService, UserService>();     

        services.AddDbContext<BookmateAppDbContext>(opt => opt.UseSqlServer(connectionString));
        return services;
    }
    
}