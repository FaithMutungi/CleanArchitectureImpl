using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
{
    public class SocialDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Post> Posts { get; set; }
    }
}
