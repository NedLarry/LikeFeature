using likeFeature.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace likeFeature.Services
{
    public static class DbInitializer
    {
        public static async void UseSeeding(this IApplicationBuilder applicationBuilder)
        {
            using var serviceScoped = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScoped.ServiceProvider.GetService<ApplicationDbContext>();
            if (context!.Database.GetMigrations().Any())
            {
                if ((await context.Database.GetPendingMigrationsAsync()).Any())
                    await context.Database.MigrateAsync();
                if (!context.Articles.Any())
                {
                    var articles = new List<Article>
                    {
                        new Article
                        {
                            Title = "Title one",
                            LikeCount = 0
                        },

                        new Article
                        {
                            Title= "Title two",
                            LikeCount = 0
                        },

                        new Article
                        {
                            Title = "Title three",
                            LikeCount = 0
                        }


                    };

                    await context.Articles.AddRangeAsync(articles);

                    await context.SaveChangesAsync();

                }
            }
        }
    }
}
