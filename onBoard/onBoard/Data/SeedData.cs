using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using onBoard.Data;
using System;
using System.Linq;

//namespace onBoard.Data
//{
//    public class SeedData
//    {
//        public static void Initialize(IServiceProvider serviceProvider)
//        {
//            using (var context = new ProjectContext(
//                serviceProvider.GetRequiredService<
//                    DbContextOptions<ProjectContext>>()))
//            {
//                // Look for any movies.
//                if (context.ProjectContext.Any())
//                {
//                    return;   // DB has been seeded
//                }

//                context.Movie.AddRange(
//                    new Movie
//                    {
//                        Title = "When Harry Met Sally",
//                        ReleaseDate = DateTime.Parse("1989-2-12"),
//                        Genre = "Romantic Comedy",
//                        Price = 7.99M
//                    },

//                    new Movie
//                    {
//                        Title = "Ghostbusters ",
//                        ReleaseDate = DateTime.Parse("1984-3-13"),
//                        Genre = "Comedy",
//                        Price = 8.99M
//                    },

//                    new Movie
//                    {
//                        Title = "Ghostbusters 2",
//                        ReleaseDate = DateTime.Parse("1986-2-23"),
//                        Genre = "Comedy",
//                        Price = 9.99M
//                    },

//                    new Movie
//                    {
//                        Title = "Rio Bravo",
//                        ReleaseDate = DateTime.Parse("1959-4-15"),
//                        Genre = "Western",
//                        Price = 3.99M
//                    }
//                );
//                context.SaveChanges();
//            }
//        }
//}
