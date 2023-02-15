using EbookStore.Contract.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static EbookStore.Data.Extensions.ModelBuilderExtensions;

namespace EbookStore.Data.EF;

public class EbookStoreDbContext : IdentityDbContext<User, AppRole, Guid>
{
    public EbookStoreDbContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<WishItem>().HasKey(sc => new { sc.UserId, sc.BookId });
        builder.Entity<LibraryItem>().HasKey(sc => new { sc.UserId, sc.BookId });
        builder.Entity<CartItem>().HasKey(sc => new { sc.UserId, sc.BookId });
        builder.Entity<BookGenre>().HasKey(sc => new { sc.BookId, sc.GenreId });

        builder.Seed();
        base.OnModelCreating(builder);
    }

    public DbSet<Book> Books { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<AppRole> AppRoles { get; set; }

    public DbSet<WishItem> WishItems { get; set; }

    public DbSet<LibraryItem> LibraryItems { get; set; }

    public DbSet<CartItem> CartItems { get; set; }

    public DbSet<BookGenre> BookGenres { get; set; }

    public DbSet<Sale> Sales { get; set; }
}
