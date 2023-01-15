﻿// <auto-generated />
using System;
using EbookStore.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EbookStore.Data.Migrations
{
    [DbContext(typeof(EbookStoreDbContext))]
    [Migration("20230115093952_Add_Properties")]
    partial class AddProperties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.Property<int>("BooksBookID")
                        .HasColumnType("int");

                    b.Property<int>("GenresGenreID")
                        .HasColumnType("int");

                    b.HasKey("BooksBookID", "GenresGenreID");

                    b.HasIndex("GenresGenreID");

                    b.ToTable("BookGenre");
                });

            modelBuilder.Entity("EbookStore.Contract.Model.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"));

                    b.Property<string>("CoverImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EpubLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfPage")
                        .HasColumnType("int");

                    b.Property<string>("PdfLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SaleID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookID");

                    b.HasIndex("SaleID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("EbookStore.Contract.Model.CartItem", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.HasKey("UserID", "BookID");

                    b.HasIndex("BookID");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("EbookStore.Contract.Model.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("EbookStore.Contract.Model.LibraryItem", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.HasKey("UserID", "BookID");

                    b.HasIndex("BookID");

                    b.ToTable("LibraryItems");
                });

            modelBuilder.Entity("EbookStore.Contract.Model.Sale", b =>
                {
                    b.Property<int>("SaleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleID"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SalePercent")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SaleID");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("EbookStore.Contract.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EbookStore.Contract.Model.WishItem", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.HasKey("UserID", "BookID");

                    b.HasIndex("BookID");

                    b.ToTable("WishItems");
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.HasOne("EbookStore.Contract.Model.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbookStore.Contract.Model.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresGenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EbookStore.Contract.Model.Book", b =>
                {
                    b.HasOne("EbookStore.Contract.Model.Sale", "Sale")
                        .WithMany("OnSaleBooks")
                        .HasForeignKey("SaleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("EbookStore.Contract.Model.CartItem", b =>
                {
                    b.HasOne("EbookStore.Contract.Model.Book", "Book")
                        .WithMany("Shoppers")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbookStore.Contract.Model.User", "User")
                        .WithMany("Cart")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EbookStore.Contract.Model.LibraryItem", b =>
                {
                    b.HasOne("EbookStore.Contract.Model.Book", "Book")
                        .WithMany("Owners")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbookStore.Contract.Model.User", "User")
                        .WithMany("Library")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EbookStore.Contract.Model.WishItem", b =>
                {
                    b.HasOne("EbookStore.Contract.Model.Book", "Book")
                        .WithMany("Wisher")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbookStore.Contract.Model.User", "User")
                        .WithMany("WishList")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EbookStore.Contract.Model.Book", b =>
                {
                    b.Navigation("Owners");

                    b.Navigation("Shoppers");

                    b.Navigation("Wisher");
                });

            modelBuilder.Entity("EbookStore.Contract.Model.Sale", b =>
                {
                    b.Navigation("OnSaleBooks");
                });

            modelBuilder.Entity("EbookStore.Contract.Model.User", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("Library");

                    b.Navigation("WishList");
                });
#pragma warning restore 612, 618
        }
    }
}
