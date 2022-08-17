using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Data
{
    public class StoreContext : DbContext
    {
       
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public StoreContext(DbContextOptions<StoreContext> options)
             : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.Name });

            });
        }
    }
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=BookStore;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new StoreContext(optionsBuilder.Options);
        }
    }
}
