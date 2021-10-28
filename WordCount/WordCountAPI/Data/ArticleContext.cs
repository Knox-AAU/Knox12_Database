using Microsoft.EntityFrameworkCore;
using WordCount.Data.Models;
using WordCount.DataAccess;
using WordCount.Models;

namespace WordCount.Data
{
    public class ArticleContext : DbContext
    {
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<JsonSchemaModel> JsonSchemas { get; set; }
        public DbSet<WordRatio> WordRatios { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("UserID=postgres;Password=Sysadmins.;Host=db;Port=5432;Database=wordcount;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Term>().HasKey(a => new { a.ArticleId, a.Word });
            modelBuilder
                .Entity<WordRatio>()
                .ToView(nameof(WordRatio))
                .HasNoKey();

        }
    }
}