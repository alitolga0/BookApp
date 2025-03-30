using BookApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookApp.Repository
{
    public class MainDbContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .Property(x => x.Name).IsRequired(true);

            builder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            builder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            builder.Entity<Category>()
                .Property(x => x.Name).IsRequired(true);

            builder.Entity<Author>(x => 
            {
                x.Property(y => y.FirstName).IsRequired(true);
                x.Property(y => y.LastName).IsRequired(true);
            });
        }
    }
}
