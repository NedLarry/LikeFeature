using Microsoft.EntityFrameworkCore;

namespace likeFeature.Domain
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> _options)
            :base(_options)
        {
            
        }

        public DbSet<Article> Articles { get; set; }
    }
}
