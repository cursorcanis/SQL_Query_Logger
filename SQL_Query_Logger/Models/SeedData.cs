using Microsoft.EntityFrameworkCore;
using SQL_Query_Logger.Data;

namespace SQL_Query_Logger.Models;

public static class SeedData {
    public static void Initialize(IServiceProvider serviceProvider) {
        using (var context = new SQL_Query_LoggerContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<SQL_Query_LoggerContext>>())) {
            if (context == null || context.Query == null) {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Query.Any()) {
                return;   // DB has been seeded
            }

            context.Query.AddRange(
                new Query {
                    Title_of_Query = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Type_of_Query = "O Comedic Query"
                    //Price = 7.99M
                },

                new Query {
                    Title_of_Query = "Balloon busting ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Type_of_Query = "Comedy"
                   // Price = 8.99M
                },

                new Query {
                    Title_of_Query = "Ghouls of Nhederlandia",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Type_of_Query = "Comedy"
                    //Price = 9.99M
                },

                new Query {
                    Title_of_Query = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Type_of_Query = "Western"
                    //Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}