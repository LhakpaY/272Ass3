using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _272Ass3.Data;
using System;
using System.Linq;
namespace _272Ass3.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new _272Ass3Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<_272Ass3Context>>()))
            {
                // Look for any movies.
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                context.User.AddRange(
                    new User
                    {
                        Id = 1,
                        Username = "admin",
                        Password = "451",
                        Role = "admin",
                        Deleted = false,
                        CreatedDate = DateTime.Now,
                        LastEdit = DateTime.Now
                    },

                    new User
                    {
                        Id = 2,
                        Username = "organiser",
                        Password = "test",
                        Role = "organiser",
                        Deleted = false,
                        CreatedDate = DateTime.Now,
                        LastEdit = DateTime.Now
                    }
                ); ;
                context.SaveChanges();
            }
        }

    }
}
