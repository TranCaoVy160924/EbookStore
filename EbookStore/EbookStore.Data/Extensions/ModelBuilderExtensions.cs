using EbookStore.Contract.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using LoremNET;

namespace EbookStore.Data.Extensions;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // guid

        var adminRoleId = new Guid("423e533c-d43d-4fd9-9676-e31af724522a");
        var userRoleId = new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19");

        var userId = new Guid[10];

        modelBuilder.Entity<AppRole>().HasData(new AppRole
        {
            Id = adminRoleId,
            Name = "Admin",
            NormalizedName = "admin",
            Description = "Administrator role"
        });

        modelBuilder.Entity<AppRole>().HasData(new AppRole
        {
            Id = userRoleId,
            Name = "User",
            NormalizedName = "user",
            Description = "User role"
        });

        var hasher = new PasswordHasher<User>();

        Random rand = new Random();

        for (int i = 1; i <= 20; i++)
        {
            //sales
            modelBuilder.Entity<Sale>().HasData(new Sale
            {
                SaleId = i,
                Name = LoremNET.Lorem.Words(1, 5, true, false),
                SalePercent = rand.Next(1, 5) * 10,
                StartDate = DateTime.Now,
                EndDate = new DateTime(2023, 10, 12)
            });
        }

        for (int i = 1; i <= 100; i++)
        {
            //book
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = i,
                Title = LoremNET.Lorem.Words(1, 5, true, false),
                IsActive = true,
                SaleId = (i % 4 == 0) ? null : (i % 3 + 1),
                NumberOfPage = rand.Next(1, 5) * 100,
                Price = i * 10,
                Description = LoremNET.Lorem.Words(1, 20, true, true),
                CoverImage = $"https://picsum.photos/seed/{i}/500/500",
                PdfLink = "Book.pdf",
                //EpubLink = "Book.pdf",
                ReleaseDate = DateTime.Now
            });
        }

        //genre
        #region genre
        modelBuilder.Entity<Genre>().HasData(new Genre
        {
            GenreId = 1,
            Name = "Action and Adventure"
        });

        modelBuilder.Entity<Genre>().HasData(new Genre
        {
            GenreId = 2,
            Name = "Classics"
        });

        modelBuilder.Entity<Genre>().HasData(new Genre
        {
            GenreId = 3,
            Name = "Comic Book/Graphic Novel"
        });

        modelBuilder.Entity<Genre>().HasData(new Genre
        {
            GenreId = 4,
            Name = "Detective and Mystery"
        });

        modelBuilder.Entity<Genre>().HasData(new Genre
        {
            GenreId = 5,
            Name = "Fantasy"
        });

        modelBuilder.Entity<Genre>().HasData(new Genre
        {
            GenreId = 6,
            Name = "Historical Fiction"
        });

        modelBuilder.Entity<Genre>().HasData(new Genre
        {
            GenreId = 7,
            Name = "Horror"
        });

        modelBuilder.Entity<Genre>().HasData(new Genre
        {
            GenreId = 8,
            Name = "Literary Fiction"
        });

        modelBuilder.Entity<Genre>().HasData(new Genre
        {
            GenreId = 9,
            Name = "Romance"
        });

        modelBuilder.Entity<Genre>().HasData(new Genre
        {
            GenreId = 10,
            Name = "Thrillers"
        });

        modelBuilder.Entity<Genre>().HasData(new Genre
        {
            GenreId = 11,
            Name = "Poetry"
        });

        modelBuilder.Entity<Genre>().HasData(new Genre
        {
            GenreId = 12,
            Name = "Sci-Fi"
        });
        #endregion

        for(int i = 1; i <= 100; i++)
        {
            modelBuilder.Entity<BookGenre>().HasData(
                new BookGenre
                {
                    BookId = i,
                    GenreId = rand.Next(1, 13)
                }
            );
        }


        for (int i = 1; i <= 10; i++)
        {
            userId[i - 1] = new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef6" + (i - 1));
            //user
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = userId[i - 1],
                UserName = "user" + i.ToString(),
                NormalizedUserName = "user" + i.ToString(),
                Email = "user" + i.ToString() + "@gmail.com",
                NormalizedEmail = "user" + i.ToString() + "@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456"),
                SecurityStamp = string.Empty,
                FirstName = "Ten " + i.ToString(),
                LastName = "Ho " + i.ToString(),
                PhoneNumber = "12345678" + i.ToString(),
                IsActive = true
            });

            if (i - 1 == 0)
            {
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
                {
                    RoleId = adminRoleId,
                    UserId = userId[i - 1]
                });
            }
            else
            {
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
                {
                    RoleId = userRoleId,
                    UserId = userId[i - 1]
                });
            }

            //wishItem
            modelBuilder.Entity<WishItem>().HasData(new WishItem
            {
                UserId = userId[i - 1],
                BookId = i,
                IsActive = true
            });

            //cartItem
            modelBuilder.Entity<CartItem>().HasData(new CartItem
            {
                UserId = userId[i - 1],
                BookId = i,
                IsActive = true
            });

            //libraryItem
            modelBuilder.Entity<LibraryItem>().HasData(new LibraryItem
            {
                UserId = userId[i - 1],
                BookId = i,
            });
        }
    }
}
