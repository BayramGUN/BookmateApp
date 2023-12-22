using BookmateApp.Entities;
using System.Reflection.Metadata;

namespace BookmateApp.Infrastructure.Data;

public static class DbSeedOperations
{
    public static void SeedDatabase(BookmateAppDbContext dbContext)
    {
        seedGenreIfNotExist(dbContext);
        seedAuthorIfNotExist(dbContext);
        seedBookIfNotExist(dbContext);
        seedUserIFNotExist(dbContext);
    }

    private static void seedUserIFNotExist(BookmateAppDbContext dbContext)
    {
        if(!dbContext.Participants!.Any())
        {
            var participants = new List<Participant> {
                new()
                {
                    Id = new Guid("b59286b9-9915-4dc0-af94-a016327fed4c"),
                    Username = "defaultUser",
                    Password = "password",
                    Role = "User",
                    Email = "useremail@example.com",
                },
                new()
                {
                    Id = new Guid("e49d5f2b-d4f5-4724-967b-a8c2ebd81816"),
                    Username = "admin",
                    Password = "admin",
                    Role = "admin",
                    Email = "adminemail@example.com",
                },
                new()
                {
                    Id = new Guid("59e831d7-d9f3-4576-8198-fdba45159da7"),
                    Username = "bayramme",
                    Password = "günne",
                    Role = "logger",
                    Email = "loggeremail@example.com",
                }
            };
            dbContext.Participants!.AddRange(participants);
            dbContext.SaveChanges();
        }
    }

    private static void seedGenreIfNotExist(BookmateAppDbContext dbContext)
    {
        if(!dbContext.Genres!.Any())
        {
            var genres = new List<Genre> {
                new() { 
                    Id = new Guid("b649bcfa-914f-45cf-96ee-99817ba0dc1e"),
                    Name = "Şiir"
                },
                new() { 
                    Id = new Guid("d06b8306-4e43-4f2d-8c36-19af1c585e9d"),
                    Name = "Roman"
                },
                new() { 
                    Id = new Guid("7e2480f0-318f-408e-ada7-9a745e596184"),
                    Name = "Bilim Kurgu"
                },
                new() { 
                    Id = new Guid("aa4845e1-b059-4365-bb7d-194a75991afe"),
                    Name = "Felsefe"
                },
            };
            dbContext.Genres!.AddRange(genres);
            dbContext.SaveChanges();
        }
    }

    private static void seedAuthorIfNotExist(BookmateAppDbContext dbContext)
    {
        if(!dbContext.Authors!.Any())
        {
            var authors = new List<Author> {
                new() { 
                        Id = new Guid("bd01c4b4-2bbd-43f1-a1e7-08f661246e9a"),
                        Firstname = "Attilâ",
                        Lastname = "İlhan",
                        Info = "Sisli serüvenlerin kaptanı..."
                },  
                new() { 
                        Id = new Guid("43afff29-ae28-436b-9919-ae439d724480"),
                        Firstname = "Yaşar",
                        Lastname = "Kemal",
                        Info = "Çukurova kurdu..."
                },  
                new() { 
                        Id = new Guid("1f2a4d7c-6156-445d-babf-f35ce5cb66aa"),
                        Firstname = "Jules",
                        Lastname = "Verne",
                        Info = "Fransız yazar ve gezgin..."
                },  
                new() { 
                        Id = new Guid("27af25e8-7311-4192-94c3-d26eaff3ce0b"),
                        Firstname = "Jean-Paul",
                        Lastname = "Sartre",
                        Info = "Varoluşçu yazar"
                }  
            };
            dbContext.Authors!.AddRange(authors);
            dbContext.SaveChanges();
        }
    }

    private static void seedBookIfNotExist(BookmateAppDbContext dbContext)
    {
        if(!dbContext.Books!.Any())
        {
            var books = new List<Book> {
                new() { 
                    Id = new Guid("c1fdd97a-767e-4396-bedf-5ff4e2e73805"),
                    Title = "sisler bulvarı",
                    AuthorId = new Guid("1f2a4d7c-6156-445d-babf-f35ce5cb66aa"),
                    IsRead = true,
                    Description = "Emperyal Oteli şiiri bu kitabın 'kaptan' bölümünde bulunuyor.",
                    PublishDate = DateTime.Parse("01-01-1954"),
                    GenreId = new Guid("b649bcfa-914f-45cf-96ee-99817ba0dc1e"),
                    CoverImageUrl = "https://isyonet.iskultur.com.tr/dosyalar/2003/09/SISLER-BUL.png",
                    Rate = 10
                }, 
                new() { 
                    Id = new Guid("5c14a40b-ccec-4ffd-ae20-60ea9fdff0b7"),
                    Title = "İnce Memed",
                    AuthorId = new Guid("43afff29-ae28-436b-9919-ae439d724480"),
                    IsRead = true,
                    Description = "Çukurovada ağaların zulmünden bıkan memed eşkiya olup toroslara çıkar. Sevdasının ve işlediği cinayetin sorgu ve suaili içerisindedir. Ölümden korkan öldürür, korku canlı tutar cesareti.",
                    PublishDate = DateTime.Parse("01-01-1955"),
                    GenreId = new Guid("d06b8306-4e43-4f2d-8c36-19af1c585e9d"),
                    CoverImageUrl = "https://cdn.dsmcdn.com/ty531/product/media/images/20220915/13/175499215/6034213/1/1_org_zoom.jpg",
                    Rate = 10
                }, 
                new() { 
                    Id = new Guid("c53f7fa2-9b71-40bd-b8bb-84184b13b76d"),
                    Title = "Ay'a Yolculuk",
                    AuthorId = new Guid("1f2a4d7c-6156-445d-babf-f35ce5cb66aa"),
                    IsRead = true,
                    Description = "Ay yolculuğu hayali ile çeşitli toplar yapan ve bunları deneyen bilim insanı ve maceraperest yatırımcıların aya yaptıkları ilk yolcuğu anlatır ve insanlığın bu hayali gerçekleştirmesinden yaklaşık yüz yıl öncesinden bir ön görüyle yazılmıştır.",
                    PublishDate = DateTime.Parse("01-01-1865"),
                    GenreId = new Guid("7e2480f0-318f-408e-ada7-9a745e596184"),
                    CoverImageUrl = "https://i.dr.com.tr/cache/600x600-0/originals/0000000383006-1.jpg",
                    Rate = 10
                }, 
                new() { 
                    Id = new Guid("16c60c71-dfb3-489a-af67-58b9baf4a7cb"),
                    Title = "Akıl Çağı",
                    AuthorId = new Guid("27af25e8-7311-4192-94c3-d26eaff3ce0b"),
                    IsRead = false,
                    Description = "The Age of Reason is a 1945 novel by the philosopher Jean-Paul Sartre. It is the first part of the trilogy The Roads to Freedom.",
                    PublishDate = DateTime.Parse("01-01-1945"),
                    GenreId = new Guid("aa4845e1-b059-4365-bb7d-194a75991afe"),
                    CoverImageUrl = "https://img.kitapyurdu.com/v1/getImage/fn:11348584/wh:true/wi:800",
                    Rate = 8
                }
            };
            dbContext.Books!.AddRange(books);
            dbContext.SaveChanges();
        }
    }
}