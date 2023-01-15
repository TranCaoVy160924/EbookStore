using EbookStore.Contract.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Data.EF
{
    public class EbookStoreDbContext: DbContext
    {
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=.; Database=EbookStore; " +
                "Trusted_Connection=True; Trust Server Certificate=true";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WishItem>().HasKey(sc => new { sc.UserId, sc.BookId });
            builder.Entity<LibraryItem>().HasKey(sc => new { sc.UserId, sc.BookId });
            base.OnModelCreating(builder);
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<WishItem> WishItems { get; set; }

        public DbSet<LibraryItem> LibraryItems { get; set; }
    }
}
