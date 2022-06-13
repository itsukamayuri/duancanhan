using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

namespace BooksStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            BooksStoreDbContext context =
            app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService < BooksStoreDbContext > ();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Books.Any())
            {
                context.Books.AddRange(
               new Book
               {
                   Title = "GoSick",
                   Description = "https://upload.wikimedia.org/wikipedia/vi/thumb/b/b0/Gosick_vol_1.jpg/220px-Gosick_vol_1.jpg",
                   Genre = "Detective",               
                   Price = 20.000m
               },
                new Book
                {
                    Title = "Gintama",
                    Description = "https://truyenkinhdien.com/wp-content/uploads/2021/10/gintama.jpg",
                    Genre = "humor",
                    Price = 20.000m
                },
                new Book
                {
                    Title = "Golden kamuy",
                    Description = "https://d28hgpri8am2if.cloudfront.net/book_images/onix/cvr9781974714896/golden-kamuy-vol-17-9781974714896_hr.jpg",
                    Genre = "History",
                    Price = 2m
                },
                new Book
                {
                    Title = "Ookami To Koushinryou",
                    Description = "http://cdn5.truyentranh8.net/hdd2/u/Pmk/2438-Ookami_to_Koushinryou_Wolf_and_Spice/001-53057/004.jpg",
                    Genre = "History",
                    Price = 20.000m
                },
                new Book
                {
                    Title = "Dantalian No Shoka",
                    Description = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1405156429l/22711795.jpg",
                    Genre = "horrified",
                    
                    Price =20.000m
                }
                );

                context.SaveChanges();
            }
        }
    }
}