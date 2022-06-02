using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Linq;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder application)
        {
            using (var serviceScope = application.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if(!context.Books.Any())
                {
                    context.Books.AddRange(
                    new Book()
                    {
                        Title = "Wings of fire",
                        Description = "Biography of A.P.J Abdul Kalam",
                        IsRead  = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "A.P.J Abdul Kalam",
                        CoverUrl = "https:// A.P.J Abdul Kalam.com",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "Karnataka Singam",
                        Description = "Biography of Atukutti Annamalai",
                        IsRead = false,
                        Rate = 0,
                        Genre = "Biography",
                        Author = "Atukutti Annamalai",
                        CoverUrl = "https:// Atukutti Annamalai.com",
                        DateAdded = DateTime.Now
                    }
                    );
                }
                context.SaveChanges();
            }
        }
    }
}
