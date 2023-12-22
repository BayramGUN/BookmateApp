using BookmateApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookmateApp.Infrastructure.Data;

public class BookmateAppDbContext : DbContext
{
    public DbSet<Book>? Books { get; set; }
    public DbSet<Author>? Authors { get; set; }
    public DbSet<Genre>? Genres { get; set; }
    public DbSet<Library>? Libraries { get; set; }
    public DbSet<BooksLibrary>? BooksLibraries { get; set; }

    public DbSet<Participant>? Participants { get; set; }

    public BookmateAppDbContext(DbContextOptions<BookmateAppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BooksLibrary>()
                    .HasOne(book => book.Book)
                    .WithMany(bookLibrary => bookLibrary.BooksLibrary)
                    .HasForeignKey(bookId => bookId.BookId);
        modelBuilder.Entity<BooksLibrary>()
                    .HasOne(book => book.Library)
                    .WithMany(bookLibrary => bookLibrary.BooksLibrary)
                    .HasForeignKey(libraryId => libraryId.LibraryId);

        // modelBuilder.Entity<Participant>().HasIndex(u => u.Username).IsUnique();

    }

}