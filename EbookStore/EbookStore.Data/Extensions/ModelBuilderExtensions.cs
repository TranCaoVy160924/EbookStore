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

namespace EbookStore.Data.Extensions
{
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

            for (int i = 1; i <= 10; i++)
            {
                userId[i - 1] = new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef6" + (i-1));

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

                //sales
                modelBuilder.Entity<Sale>().HasData(new Sale
                {
                    SaleId = i,
                    Name = "Sale " + i.ToString(),
                    SalePercent = i,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                });

                //book
                modelBuilder.Entity<Book>().HasData(new Book
                {
                    BookId = i,
                    Title = "Book " + i.ToString(),
                    IsActive = true,
                    SaleId = i,
                    NumberOfPage = i * 100,
                    Price = i * 10,
                    CoverImage = "cover " + i.ToString(),
                    PdfLink = "PdfLink " + i.ToString(),
                    EpubLink = "EpubLink" + i.ToString(),
                    ReleaseDate = DateTime.Now
                });

                //genre
                modelBuilder.Entity<Genre>().HasData(new Genre
                {
                    GenreId = i,
                    Name = "Genre " + i.ToString()
                });

                //wishItem
                modelBuilder.Entity<WishItem>().HasData(new WishItem
                {
                    UserId = userId[i - 1],
                    BookId = i,
                });

                //cartItem
                modelBuilder.Entity<CartItem>().HasData(new CartItem
                {
                    UserId = userId[i - 1],
                    BookId = i,
                });

                //libraryItem
                modelBuilder.Entity<LibraryItem>().HasData(new LibraryItem
                {
                    UserId = userId[i - 1],
                    BookId = i,
                });
            }



            //modelBuilder.Entity<AppUser>().HasData(new AppUser
            //{
            //    Id = adminHcmId,
            //    UserName = "adminhcm",
            //    NormalizedUserName = "adminhcm",
            //    Email = "adminhcm@gmail.com",
            //    NormalizedEmail = "adminhcm@gmail.com",
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "12345678"),
            //    SecurityStamp = string.Empty,
            //    FirstName = "Toan",
            //    LastName = "Bach",
            //    Dob = new DateTime(2000, 01, 31),
            //    IsLoginFirstTime = false,
            //    CreatedDate = DateTime.Now,
            //    Gender = Domain.Enums.AppUser.UserGender.Male,
            //    Location = Domain.Enums.AppUser.AppUserLocation.HoChiMinh,
            //    StaffCode = "SD0001"
            //});

            //modelBuilder.Entity<AppUser>().HasData(new AppUser
            //{
            //    Id = adminHNId,
            //    UserName = "adminhn",
            //    NormalizedUserName = "adminhn",
            //    Email = "adminhn@gmail.com",
            //    NormalizedEmail = "adminhn@gmail.com",
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "12345678"),
            //    SecurityStamp = string.Empty,
            //    FirstName = "Toan",
            //    LastName = "Bach",
            //    Dob = new DateTime(2000, 01, 31),
            //    IsLoginFirstTime = true,
            //    CreatedDate = DateTime.Now,
            //    Gender = Domain.Enums.AppUser.UserGender.Male,
            //    Location = Domain.Enums.AppUser.AppUserLocation.HaNoi,
            //    StaffCode = "SD0002"
            //});

            //modelBuilder.Entity<AppUser>().HasData(new AppUser
            //{
            //    Id = staffAbleId1,
            //    UserName = "staff1",
            //    NormalizedUserName = "staff1",
            //    Email = "staff@gmail.com",
            //    NormalizedEmail = "staff@gmail.com",
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "12345678"),
            //    SecurityStamp = string.Empty,
            //    FirstName = "Toan",
            //    LastName = "Bach",
            //    Dob = new DateTime(2000, 01, 31),
            //    IsLoginFirstTime = true,
            //    CreatedDate = DateTime.Now,
            //    Gender = Domain.Enums.AppUser.UserGender.Female,
            //    Location = Domain.Enums.AppUser.AppUserLocation.HaNoi,
            //    StaffCode = "SD0003"
            //});

            //modelBuilder.Entity<AppUser>().HasData(new AppUser
            //{
            //    Id = staffAbleId2,
            //    UserName = "staff2",
            //    NormalizedUserName = "staff2",
            //    Email = "staff@gmail.com",
            //    NormalizedEmail = "staff@gmail.com",
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "12345678"),
            //    SecurityStamp = string.Empty,
            //    FirstName = "Toan",
            //    LastName = "Bach",
            //    Dob = new DateTime(2000, 01, 31),
            //    IsLoginFirstTime = true,
            //    CreatedDate = DateTime.Now,
            //    Gender = Domain.Enums.AppUser.UserGender.Female,
            //    Location = Domain.Enums.AppUser.AppUserLocation.HaNoi,
            //    StaffCode = "SD0004"
            //});

            //modelBuilder.Entity<AppUser>().HasData(new AppUser
            //{
            //    Id = staffUnableId,
            //    UserName = "staffDis",
            //    NormalizedUserName = "staffdis",
            //    Email = "staffdis@gmail.com",
            //    NormalizedEmail = "staffdis@gmail.com",
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "12345678"),
            //    SecurityStamp = string.Empty,
            //    FirstName = "Toan",
            //    LastName = "Bach",
            //    Dob = new DateTime(2000, 01, 31),
            //    IsLoginFirstTime = true,
            //    CreatedDate = DateTime.Now,
            //    Gender = Domain.Enums.AppUser.UserGender.Female,
            //    Location = Domain.Enums.AppUser.AppUserLocation.HaNoi,
            //    StaffCode = "SD0005",
            //    IsDeleted = true,
            //});

            //modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            //{
            //    RoleId = adminRoleId,
            //    UserId = adminHcmId
            //});

            //modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            //{
            //    RoleId = adminRoleId,
            //    UserId = adminHNId,
            //});

            //modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            //{
            //    RoleId = staffRoleId,
            //    UserId = staffUnableId
            //});

            //modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            //{
            //    RoleId = staffRoleId,
            //    UserId = staffAbleId1
            //});

            //modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            //{
            //    RoleId = staffRoleId,
            //    UserId = staffAbleId2
            //});

            //modelBuilder.Entity<Category>().HasData(new Category
            //{
            //    Id = 1,
            //    Name = "Laptop",
            //    Prefix = "LA",
            //    IsDeleted = false,
            //});

            //modelBuilder.Entity<Category>().HasData(new Category
            //{
            //    Id = 2,
            //    Name = "Monitor",
            //    Prefix = "MO",
            //    IsDeleted = false,
            //});

            //modelBuilder.Entity<Category>().HasData(new Category
            //{
            //    Id = 3,
            //    Name = "Personal Computer",
            //    Prefix = "PC",
            //    IsDeleted = false,
            //});

            //for (int i = 1; i <= 10; i++)
            //{
            //    modelBuilder.Entity<Asset>().HasData(new Asset
            //    {
            //        Id = i,
            //        Name = "Laptop " + i,
            //        AssetCode = "LA10000" + i,
            //        Specification = $"Core i{i}, {i}GB RAM, {i}50 GB HDD, Window {i}",
            //        CategoryId = i % 2 == 0 ? 1 : 2,
            //        InstalledDate = DateTime.Now,
            //        State = i % 2 == 0 ? State.Available : State.NotAvailable,
            //        IsDeleted = i % 2 == 0 ? true : false,
            //    });
            //}

            //for (int i = 11; i <= 15; i++)
            //{
            //    modelBuilder.Entity<Asset>().HasData(new Asset
            //    {
            //        Id = i,
            //        Name = "Laptop " + i,
            //        AssetCode = "LA10000" + i,
            //        Specification = $"Core i{i}, {i}GB RAM, {i}50 GB HDD, Window {i}",
            //        CategoryId = i % 2 == 0 ? 1 : 2,
            //        InstalledDate = DateTime.Now,
            //        State = i % 2 == 0 ? State.Assigned : State.NotAvailable,
            //        IsDeleted = i % 2 == 0 ? true : false,
            //    });
            //}

            //for (int i = 1; i <= 10; i++)
            //{
            //    modelBuilder.Entity<Assignment>().HasData(new Assignment
            //    {
            //        Id = i,
            //        Note = $"Note for assignment {i}",
            //        AssignedDate = DateTime.Today,
            //        ReturnedDate = DateTime.Today.AddDays(i),
            //        AssetId = i,
            //        State = i % 2 == 0 ? Domain.Enums.Assignment.State.Accepted : Domain.Enums.Assignment.State.WaitingForAcceptance,
            //        AssignedTo = staffAbleId1,
            //        AssignedBy = adminHcmId,
            //    });
            //}

            //modelBuilder.Entity<Assignment>().HasData(new Assignment
            //{
            //    Id = 11,
            //    Note = $"Note for assignment {11}",
            //    AssignedDate = DateTime.Today,
            //    ReturnedDate = DateTime.Today.AddDays(11),
            //    AssetId = 4,
            //    State = Domain.Enums.Assignment.State.WaitingForAcceptance,
            //    AssignedTo = staffAbleId1,
            //    AssignedBy = adminHcmId,
            //});

            //for (int i = 12; i <= 15; i++)
            //{
            //    modelBuilder.Entity<Assignment>().HasData(new Assignment
            //    {
            //        Id = i,
            //        Note = $"Note for assignment {i}",
            //        AssignedDate = DateTime.Today,
            //        ReturnedDate = DateTime.Today.AddDays(i),
            //        AssetId = i,
            //        State = i % 2 == 0 ? Domain.Enums.Assignment.State.WaitingForReturning : Domain.Enums.Assignment.State.Returned,
            //        AssignedTo = staffAbleId1,
            //        AssignedBy = adminHcmId,
            //    });
            //}

            //for (int i = 1; i <= 10; i++)
            //{
            //    modelBuilder.Entity<ReturnRequest>().HasData(new ReturnRequest
            //    {
            //        Id = i,
            //        AssignedBy = staffAbleId1,
            //        AssignedDate = DateTime.Today,
            //        ReturnedDate = DateTime.Today,
            //        State = Domain.Enums.ReturnRequest.State.WaitingForReturning,
            //        AssignmentId = i,
            //    });
            //}

            //for (int i = 11; i <= 15; i++)
            //{
            //    modelBuilder.Entity<ReturnRequest>().HasData(new ReturnRequest
            //    {
            //        Id = i,
            //        AssignedBy = staffAbleId1,
            //        AssignedDate = DateTime.Today,
            //        ReturnedDate = DateTime.Today,
            //        State = Domain.Enums.ReturnRequest.State.WaitingForReturning,
            //        AssignmentId = i,
            //    });
            //}
        }
    }
}
