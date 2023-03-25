using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbookStore.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalePercent = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfPage = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PdfLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId");
                });

            migrationBuilder.CreateTable(
                name: "BookGenres",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenres", x => new { x.BookId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_BookGenres_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.UserId, x.BookId });
                    table.ForeignKey(
                        name: "FK_CartItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryItems",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryItems", x => new { x.UserId, x.BookId });
                    table.ForeignKey(
                        name: "FK_LibraryItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishItems",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishItems", x => new { x.UserId, x.BookId });
                    table.ForeignKey(
                        name: "FK_WishItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("423e533c-d43d-4fd9-9676-e31af724522a"), "67304947-eab1-49c4-9964-bee1356bcd1a", "Administrator role", "Admin", "admin" },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), "5886f151-634e-4f6d-990f-0f70e22e784b", "User role", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"), 0, "6179fb41-2178-4cae-ac90-6cc416fd1e56", "user1@gmail.com", true, "Ten 1", true, "Ho 1", false, null, "user1@gmail.com", "user1", "AQAAAAEAACcQAAAAEBOOQ2GW6VeZYZSMhshlO9GH5/IF+x/X/Yuv51yU5DsE84AAtK07KwTp2JTbmpaxsQ==", "123456781", false, "", false, "user1" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"), 0, "6e407690-e7f5-4ad3-9f28-9c9ba5e714f5", "user2@gmail.com", true, "Ten 2", true, "Ho 2", false, null, "user2@gmail.com", "user2", "AQAAAAEAACcQAAAAENDG5gQgT7Qzp2LuKMJ+Jrp1int4RTFFDIaqDRayvUW5CsgKOuU6bsdkmgOpTRfAPQ==", "123456782", false, "", false, "user2" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), 0, "425e5553-58ae-4e48-85ec-984ef4638eea", "user3@gmail.com", true, "Ten 3", true, "Ho 3", false, null, "user3@gmail.com", "user3", "AQAAAAEAACcQAAAAEDvk5/9DaD1WpwaMRKjcEPq1HwP5SzmCJl6wWMp1WuQgY+PfcYweHy0dOfMalDKudw==", "123456783", false, "", false, "user3" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), 0, "8b22eda5-4a6d-4378-b0ef-c54662dcc54e", "user4@gmail.com", true, "Ten 4", true, "Ho 4", false, null, "user4@gmail.com", "user4", "AQAAAAEAACcQAAAAEDsoDkLDjwlul/WFwiAPKjZW5qQDphyJscSpvmeHPyAlmdylohTjNF2d7sokX3uNtg==", "123456784", false, "", false, "user4" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), 0, "dc8b5208-a774-45eb-af7a-0381ca4990f3", "user5@gmail.com", true, "Ten 5", true, "Ho 5", false, null, "user5@gmail.com", "user5", "AQAAAAEAACcQAAAAEJNJ31k3xwwY0JE2djqBoHB8A81elapJEbwVKSOAuUm9kRbF0RADZbTaiB9qH8a+3w==", "123456785", false, "", false, "user5" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), 0, "4fadb5bc-b332-4f49-98d0-7e4775ededc6", "user6@gmail.com", true, "Ten 6", true, "Ho 6", false, null, "user6@gmail.com", "user6", "AQAAAAEAACcQAAAAEFxtkEwHMMMOojRcZqpaHH0r3lZVAgriqYYsqQ2ppEkd0lIbO9NNDYu6rnYmS/4Kag==", "123456786", false, "", false, "user6" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), 0, "2b94c23b-bfb7-466b-94dc-7e9e2005cf19", "user7@gmail.com", true, "Ten 7", true, "Ho 7", false, null, "user7@gmail.com", "user7", "AQAAAAEAACcQAAAAEFiq1Y3xxjVgWveu7iVUwJ8EotE5UIgdB34cL/BIoe8OnbH9OaKoH9oaQkWfNHHllQ==", "123456787", false, "", false, "user7" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), 0, "37fb77ff-f2b3-4aea-b3a9-400eba9efd27", "user8@gmail.com", true, "Ten 8", true, "Ho 8", false, null, "user8@gmail.com", "user8", "AQAAAAEAACcQAAAAEAzUas5WsyDYsT2lMi61luiD9oyYrPFUOywKz5+1J0oujTZF0Ftcfy+FT4iKKz6KMQ==", "123456788", false, "", false, "user8" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), 0, "d23b9eaa-0a0e-45fd-bf15-d6df734ff19a", "user9@gmail.com", true, "Ten 9", true, "Ho 9", false, null, "user9@gmail.com", "user9", "AQAAAAEAACcQAAAAECOg3AdPGwGAJNBQ1njmcC5UY8+hMI8y83ZajrQMQbN1gVbWz66BxggrviTcRJQ90Q==", "123456789", false, "", false, "user9" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), 0, "2111e650-8176-4cc7-a8b4-423d1b571cf4", "user10@gmail.com", true, "Ten 10", true, "Ho 10", false, null, "user10@gmail.com", "user10", "AQAAAAEAACcQAAAAEDjMbZg+tsa6+UCIxXlXGqv2gvHbA7gEedB6k9AXNo3BYwlaff/fcrsZqEG3u+tG9g==", "1234567810", false, "", false, "user10" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 4, "https://picsum.photos/seed/4/500/500", "Lectus quisque", true, 400, "Book.pdf", 40.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(2756), null, "Cursus" },
                    { 8, "https://picsum.photos/seed/8/500/500", "Gravida lorem, fringilla ultrices vel, pulvinar nulla, nullam maecenas per feugiat laoreet dapibus vulputate finibus, quisque", true, 300, "Book.pdf", 80.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(5958), null, "Lectus" },
                    { 12, "https://picsum.photos/seed/12/500/500", "Sed, ut primis odio, tellus nulla eros tortor, platea sagittis, orci, fames lectus", true, 100, "Book.pdf", 120.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(8251), null, "Lorem" },
                    { 16, "https://picsum.photos/seed/16/500/500", "Conubia class nam mattis, leo lacinia, leo, orci, vestibulum, sagittis, sociosqu placerat auctor, massa,", true, 300, "Book.pdf", 160.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(514), null, "Eleifend" },
                    { 20, "https://picsum.photos/seed/20/500/500", "Litora", true, 100, "Book.pdf", 200.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(2794), null, "Sed mauris" },
                    { 24, "https://picsum.photos/seed/24/500/500", "Ut sociosqu velit nulla, interdum at nostra, lobortis sed maximus", true, 100, "Book.pdf", 240.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(5045), null, "Tempor" },
                    { 28, "https://picsum.photos/seed/28/500/500", "Eu vitae velit vehicula", true, 200, "Book.pdf", 280.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(7388), null, "Orci mauris" },
                    { 32, "https://picsum.photos/seed/32/500/500", "Dictum", true, 300, "Book.pdf", 320.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(9766), null, "Ante hac nisi at" },
                    { 36, "https://picsum.photos/seed/36/500/500", "A, lacinia, cras ex, nulla, commodo, nibh,", true, 100, "Book.pdf", 360.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(2036), null, "Mauris ante auctor porttitor" },
                    { 40, "https://picsum.photos/seed/40/500/500", "Fermentum molestie bibendum cursus massa imperdiet suscipit bibendum, iaculis eros, sem non euismod, pellentesque maecenas congue inceptos id, sagittis", true, 400, "Book.pdf", 400.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(4424), null, "Auctor" },
                    { 44, "https://picsum.photos/seed/44/500/500", "Euismod", true, 200, "Book.pdf", 440.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(6712), null, "Leo duis" },
                    { 48, "https://picsum.photos/seed/48/500/500", "Conubia finibus, luctus et nunc, fames fermentum porttitor, ex proin orci, turpis nisl porta convallis quisque mattis", true, 100, "Book.pdf", 480.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(9081), null, "Risus nec" },
                    { 52, "https://picsum.photos/seed/52/500/500", "Hac cras malesuada", true, 300, "Book.pdf", 520.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(1316), null, "Lorem" },
                    { 56, "https://picsum.photos/seed/56/500/500", "Interdum, sodales platea dictum elit semper neque at, aliquet adipiscing sed, tempor, purus posuere, hendrerit", true, 200, "Book.pdf", 560.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(3457), null, "Tortor" },
                    { 60, "https://picsum.photos/seed/60/500/500", "Arcu, conubia eleifend himenaeos dictum aptent vel, nunc, volutpat fermentum", true, 100, "Book.pdf", 600.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(5790), null, "Finibus rhoncus volutpat sagittis" },
                    { 64, "https://picsum.photos/seed/64/500/500", "Pretium mi sollicitudin lacinia, viverra mattis, nibh massa, taciti", true, 300, "Book.pdf", 640.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(8031), null, "Sem" },
                    { 68, "https://picsum.photos/seed/68/500/500", "Elit ultricies nullam fringilla, arcu, pulvinar, vitae lacinia", true, 400, "Book.pdf", 680.0, new DateTime(2023, 3, 25, 13, 59, 56, 860, DateTimeKind.Local).AddTicks(567), null, "Ipsum hac" },
                    { 72, "https://picsum.photos/seed/72/500/500", "Ornare lectus eu erat, lectus, ultrices", true, 200, "Book.pdf", 720.0, new DateTime(2023, 3, 25, 13, 59, 56, 860, DateTimeKind.Local).AddTicks(2761), null, "Erat ex" },
                    { 76, "https://picsum.photos/seed/76/500/500", "Ultrices, lobortis risus dapibus luctus, interdum sociosqu proin congue enim, blandit, enim litora pharetra ad nisi, elit, ipsum", true, 400, "Book.pdf", 760.0, new DateTime(2023, 3, 25, 13, 59, 56, 860, DateTimeKind.Local).AddTicks(5002), null, "Tristique mi vehicula" },
                    { 80, "https://picsum.photos/seed/80/500/500", "Tortor quis luctus posuere congue, cras ante nisi ut lorem, finibus, suscipit", true, 100, "Book.pdf", 800.0, new DateTime(2023, 3, 25, 13, 59, 56, 860, DateTimeKind.Local).AddTicks(9789), null, "Lorem laoreet sodales viverra" },
                    { 84, "https://picsum.photos/seed/84/500/500", "Aptent urna eu, fames amet, elit, euismod, ligula erat platea feugiat, rhoncus, ut fusce neque", true, 100, "Book.pdf", 840.0, new DateTime(2023, 3, 25, 13, 59, 56, 861, DateTimeKind.Local).AddTicks(6128), null, "Class curabitur lacinia commodo" },
                    { 88, "https://picsum.photos/seed/88/500/500", "Fames in, maximus erat, urna, curabitur tempor,", true, 300, "Book.pdf", 880.0, new DateTime(2023, 3, 25, 13, 59, 56, 862, DateTimeKind.Local).AddTicks(770), null, "Sem" },
                    { 92, "https://picsum.photos/seed/92/500/500", "Arcu, metus posuere, vestibulum, porttitor, laoreet volutpat eros", true, 200, "Book.pdf", 920.0, new DateTime(2023, 3, 25, 13, 59, 56, 862, DateTimeKind.Local).AddTicks(3090), null, "Ligula nulla" },
                    { 96, "https://picsum.photos/seed/96/500/500", "Non, vehicula pellentesque", true, 200, "Book.pdf", 960.0, new DateTime(2023, 3, 25, 13, 59, 56, 862, DateTimeKind.Local).AddTicks(5953), null, "Laoreet malesuada mattis venenatis" },
                    { 100, "https://picsum.photos/seed/100/500/500", "Bibendum per nam hac quam, lectus a urna justo ex, quisque consectetur euismod, finibus est auctor,", true, 200, "Book.pdf", 1000.0, new DateTime(2023, 3, 25, 13, 59, 56, 862, DateTimeKind.Local).AddTicks(8212), null, "Congue" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Action and Adventure" },
                    { 2, "Classics" },
                    { 3, "Comic Book/Graphic Novel" },
                    { 4, "Detective and Mystery" },
                    { 5, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 6, "Historical Fiction" },
                    { 7, "Horror" },
                    { 8, "Literary Fiction" },
                    { 9, "Romance" },
                    { 10, "Thrillers" },
                    { 11, "Poetry" },
                    { 12, "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "EndDate", "Name", "SalePercent", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tincidunt", 40.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(4533) },
                    { 2, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et", 20.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(4874) },
                    { 3, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elit", 10.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(5146) },
                    { 4, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lacinia non", 10.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(5484) },
                    { 5, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magna nisi orci dui", 40.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(5785) },
                    { 6, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolor accumsan tortor phasellus", 20.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(6106) },
                    { 7, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adipiscing tortor", 10.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(6399) },
                    { 8, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Molestie", 30.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(6648) },
                    { 9, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malesuada ultricies", 10.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(6953) },
                    { 10, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Felis curabitur et enim", 10.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(7216) },
                    { 11, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vel felis", 40.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(7552) },
                    { 12, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nisi urna tortor volutpat", 30.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(7850) },
                    { 13, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce", 30.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(8099) },
                    { 14, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Massa", 30.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(8377) },
                    { 15, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Imperdiet tellus", 10.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(8660) },
                    { 16, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bibendum", 30.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(8909) },
                    { 17, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Habitasse mattis", 40.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(9189) },
                    { 18, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nibh", 30.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(9518) },
                    { 19, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auctor ante tristique", 10.0, new DateTime(2023, 3, 25, 13, 59, 56, 855, DateTimeKind.Local).AddTicks(9797) },
                    { 20, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulvinar blandit", 10.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(54) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("423e533c-d43d-4fd9-9676-e31af724522a"), new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60") },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61") },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62") },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63") },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64") },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65") },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66") },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67") },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68") },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69") }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 4, 12 },
                    { 8, 7 },
                    { 12, 10 },
                    { 16, 3 },
                    { 20, 3 },
                    { 24, 5 },
                    { 28, 9 },
                    { 32, 1 },
                    { 36, 2 },
                    { 40, 3 },
                    { 44, 2 },
                    { 48, 7 },
                    { 52, 9 },
                    { 56, 2 },
                    { 60, 6 },
                    { 64, 11 },
                    { 68, 2 },
                    { 72, 10 },
                    { 76, 8 },
                    { 80, 3 },
                    { 84, 11 },
                    { 88, 8 },
                    { 92, 10 },
                    { 96, 12 },
                    { 100, 4 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 1, "https://picsum.photos/seed/1/500/500", "Lacinia, erat, mauris, nunc, sollicitudin iaculis consequat imperdiet sapien justo", true, 100, "Book.pdf", 10.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(678), 2, "Viverra" },
                    { 2, "https://picsum.photos/seed/2/500/500", "Imperdiet egestas et, orci, cursus platea est elementum quam lacinia proin in", true, 400, "Book.pdf", 20.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(1327), 3, "Integer tortor" },
                    { 3, "https://picsum.photos/seed/3/500/500", "Porta, nibh, nunc amet, dui facilisis torquent enim, urna tempus", true, 400, "Book.pdf", 30.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(2153), 1, "Elit finibus erat sapien" },
                    { 5, "https://picsum.photos/seed/5/500/500", "Orci vestibulum, taciti felis elit feugiat himenaeos nisi, nam dignissim nunc,", true, 200, "Book.pdf", 50.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(3742), 3, "Erat magna curabitur porttitor" },
                    { 6, "https://picsum.photos/seed/6/500/500", "Sodales fringilla, aliquet elit, auctor, eu dapibus duis id integer aptent ligula, semper bibendum, convallis mattis congue", true, 100, "Book.pdf", 60.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(4592), 1, "Consequat" },
                    { 7, "https://picsum.photos/seed/7/500/500", "Vestibulum eget posuere blandit, magna, suscipit semper etiam faucibus congue cras a, urna", true, 300, "Book.pdf", 70.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(5376), 2, "Congue urna taciti" },
                    { 9, "https://picsum.photos/seed/9/500/500", "Urna tellus a mauris, mauris dictum odio libero bibendum diam non, sapien fringilla", true, 300, "Book.pdf", 90.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(6555), 1, "Felis efficitur nibh eros" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 10, "https://picsum.photos/seed/10/500/500", "Magna, enim, nibh nisi velit cursus posuere sem malesuada", true, 300, "Book.pdf", 100.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(7151), 2, "Vitae finibus" },
                    { 11, "https://picsum.photos/seed/11/500/500", "Sodales id nostra, vitae nisi lacinia vel malesuada dignissim ornare", true, 300, "Book.pdf", 110.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(7693), 3, "Sagittis" },
                    { 13, "https://picsum.photos/seed/13/500/500", "Tempor, magna, consectetur velit nec, amet, volutpat, vitae nisi orci risus urna finibus, tortor pulvinar, eros diam", true, 200, "Book.pdf", 130.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(8769), 2, "Platea" },
                    { 14, "https://picsum.photos/seed/14/500/500", "Urna, mauris, ultrices, felis id, varius erat tincidunt ligula, per", true, 100, "Book.pdf", 140.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(9382), 3, "Tincidunt erat feugiat" },
                    { 15, "https://picsum.photos/seed/15/500/500", "Tortor, urna massa libero conubia accumsan", true, 300, "Book.pdf", 150.0, new DateTime(2023, 3, 25, 13, 59, 56, 856, DateTimeKind.Local).AddTicks(9948), 1, "Cursus leo orci" },
                    { 17, "https://picsum.photos/seed/17/500/500", "Tempus dictum vestibulum metus arcu, porttitor, sodales euismod", true, 200, "Book.pdf", 170.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(1068), 3, "Mi tempus mattis" },
                    { 18, "https://picsum.photos/seed/18/500/500", "Sagittis nostra, bibendum, nec, nullam sapien iaculis auctor dictumst morbi ante, porta lectus, commodo fusce luctus, vivamus dolor, quam,", true, 300, "Book.pdf", 180.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(1721), 1, "Ac ante non habitasse" },
                    { 19, "https://picsum.photos/seed/19/500/500", "Nisi, diam porta dapibus vitae, ipsum bibendum,", true, 400, "Book.pdf", 190.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(2290), 2, "Primis mattis" },
                    { 21, "https://picsum.photos/seed/21/500/500", "Posuere, litora neque eu nullam semper mi, tempor,", true, 100, "Book.pdf", 210.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(3370), 1, "Fermentum dapibus pharetra eros" },
                    { 22, "https://picsum.photos/seed/22/500/500", "Feugiat, mi", true, 200, "Book.pdf", 220.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(3923), 2, "Placerat risus" },
                    { 23, "https://picsum.photos/seed/23/500/500", "Venenatis interdum orci, fringilla porta congue, convallis", true, 300, "Book.pdf", 230.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(4503), 3, "Hac" },
                    { 25, "https://picsum.photos/seed/25/500/500", "Blandit, feugiat,", true, 300, "Book.pdf", 250.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(5599), 2, "Auctor turpis in" },
                    { 26, "https://picsum.photos/seed/26/500/500", "Ultricies lectus nam varius, fringilla himenaeos arcu fringilla, habitasse tristique ac justo class", true, 300, "Book.pdf", 260.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(6202), 3, "Posuere turpis maximus conubia" },
                    { 27, "https://picsum.photos/seed/27/500/500", "Ligula cursus pulvinar imperdiet", true, 300, "Book.pdf", 270.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(6769), 1, "Vitae efficitur blandit proin" },
                    { 29, "https://picsum.photos/seed/29/500/500", "Phasellus gravida praesent ultricies pulvinar sit tempor interdum, bibendum consequat neque,", true, 100, "Book.pdf", 290.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(7976), 3, "Urna" },
                    { 30, "https://picsum.photos/seed/30/500/500", "Venenatis magna,", true, 400, "Book.pdf", 300.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(8551), 1, "At massa orci" },
                    { 31, "https://picsum.photos/seed/31/500/500", "Nulla posuere, rutrum ornare arcu vel, aenean nisl at, porta urna tellus, nostra, ante, diam commodo in ac, cursus", true, 100, "Book.pdf", 310.0, new DateTime(2023, 3, 25, 13, 59, 56, 857, DateTimeKind.Local).AddTicks(9189), 2, "Ex massa inceptos mauris" },
                    { 33, "https://picsum.photos/seed/33/500/500", "Dapibus nibh et lectus, urna lacus himenaeos convallis", true, 200, "Book.pdf", 330.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(320), 1, "Proin" },
                    { 34, "https://picsum.photos/seed/34/500/500", "Blandit, tellus laoreet at, ultricies conubia tortor, dictumst ultrices, imperdiet", true, 100, "Book.pdf", 340.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(885), 2, "Scelerisque eros laoreet" },
                    { 35, "https://picsum.photos/seed/35/500/500", "Luctus, porttitor sed, varius fermentum imperdiet praesent sollicitudin mauris, faucibus turpis", true, 300, "Book.pdf", 350.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(1432), 3, "Ex integer ad congue" },
                    { 37, "https://picsum.photos/seed/37/500/500", "Ligula eleifend, aptent volutpat, nunc magna quisque hac", true, 200, "Book.pdf", 370.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(2595), 2, "Magna" },
                    { 38, "https://picsum.photos/seed/38/500/500", "Taciti diam facilisis at pretium dui, sed, leo consectetur per feugiat, quis, sapien eros, quis a, eu sed", true, 300, "Book.pdf", 380.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(3168), 3, "Nunc" },
                    { 39, "https://picsum.photos/seed/39/500/500", "Bibendum nisl sapien eget porttitor, suscipit", true, 200, "Book.pdf", 390.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(3790), 1, "Condimentum posuere arcu" },
                    { 41, "https://picsum.photos/seed/41/500/500", "Curabitur lacinia ligula semper fermentum pellentesque faucibus porta lobortis non, gravida in, urna, ac, ultricies", true, 300, "Book.pdf", 410.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(4989), 3, "Eros erat" },
                    { 42, "https://picsum.photos/seed/42/500/500", "Feugiat cras scelerisque ac convallis nunc laoreet,", true, 400, "Book.pdf", 420.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(5561), 1, "Porta" },
                    { 43, "https://picsum.photos/seed/43/500/500", "In ac, inceptos viverra interdum,", true, 300, "Book.pdf", 430.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(6171), 2, "Nullam vulputate tempor rhoncus" },
                    { 45, "https://picsum.photos/seed/45/500/500", "Commodo porta, blandit, amet magna, fames ante, placerat auctor faucibus", true, 200, "Book.pdf", 450.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(7370), 1, "Massa sem" },
                    { 46, "https://picsum.photos/seed/46/500/500", "Nunc, odio, laoreet, bibendum, commodo commodo, quis, pharetra in, vivamus mi", true, 100, "Book.pdf", 460.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(7937), 2, "Blandit ex mattis vitae" },
                    { 47, "https://picsum.photos/seed/47/500/500", "Maecenas placerat, aptent habitasse feugiat morbi aliquam leo eget viverra", true, 100, "Book.pdf", 470.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(8484), 3, "Integer" },
                    { 49, "https://picsum.photos/seed/49/500/500", "Ligula, vitae ante, luctus condimentum dignissim faucibus cursus mi proin pulvinar, vel, lectus phasellus sagittis eu, mattis,", true, 100, "Book.pdf", 490.0, new DateTime(2023, 3, 25, 13, 59, 56, 858, DateTimeKind.Local).AddTicks(9712), 2, "Lorem porta" },
                    { 50, "https://picsum.photos/seed/50/500/500", "Rhoncus enim, primis non, volutpat, ornare quam, sed volutpat", true, 400, "Book.pdf", 500.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(236), 3, "Erat" },
                    { 51, "https://picsum.photos/seed/51/500/500", "At dui, et,", true, 400, "Book.pdf", 510.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(824), 1, "Nibh lacus purus" },
                    { 53, "https://picsum.photos/seed/53/500/500", "Praesent vestibulum magna, sagittis, auctor euismod, mattis, molestie neque, dui quis fermentum", true, 200, "Book.pdf", 530.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(1844), 3, "Nostra" },
                    { 54, "https://picsum.photos/seed/54/500/500", "Proin porta, ultrices, hac inceptos sagittis, pellentesque commodo, arcu elit sit massa aliquet", true, 300, "Book.pdf", 540.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(2397), 1, "Rhoncus porta aenean" },
                    { 55, "https://picsum.photos/seed/55/500/500", "Elementum", true, 400, "Book.pdf", 550.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(2942), 2, "Finibus fusce fames" },
                    { 57, "https://picsum.photos/seed/57/500/500", "Interdum nisi, taciti maecenas ornare in, eros diam mauris, placerat, id, hac vitae, dui, sit in suspendisse lacinia,", true, 300, "Book.pdf", 570.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(4052), 1, "Sit maximus volutpat" },
                    { 58, "https://picsum.photos/seed/58/500/500", "Luctus vel lorem purus leo lobortis nibh, pharetra placerat", true, 300, "Book.pdf", 580.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(4621), 2, "Placerat eros diam" },
                    { 59, "https://picsum.photos/seed/59/500/500", "Ipsum risus nibh, aliquet posuere ornare elit, a mattis at, varius taciti commodo porta, mauris, ante, praesent fusce", true, 200, "Book.pdf", 590.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(5190), 3, "Tristique aenean placerat" },
                    { 61, "https://picsum.photos/seed/61/500/500", "Posuere eros, vestibulum, lacinia, euismod, neque suspendisse", true, 200, "Book.pdf", 610.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(6336), 2, "Vehicula" },
                    { 62, "https://picsum.photos/seed/62/500/500", "Vel, primis erat, fringilla, a pellentesque volutpat, imperdiet id, lacinia quisque augue mi, massa", true, 300, "Book.pdf", 620.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(6923), 3, "Pellentesque massa" },
                    { 63, "https://picsum.photos/seed/63/500/500", "Leo vitae placerat, congue amet, accumsan quam,", true, 400, "Book.pdf", 630.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(7472), 1, "Condimentum sodales" },
                    { 65, "https://picsum.photos/seed/65/500/500", "Eget mattis euismod,", true, 400, "Book.pdf", 650.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(8672), 3, "Nec lobortis" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 66, "https://picsum.photos/seed/66/500/500", "Dapibus donec vestibulum, metus mollis laoreet sollicitudin sem, feugiat nec tincidunt ligula, molestie non arcu himenaeos rhoncus", true, 200, "Book.pdf", 660.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(9423), 1, "Quam commodo lacus eros" },
                    { 67, "https://picsum.photos/seed/67/500/500", "Aliquet pretium", true, 300, "Book.pdf", 670.0, new DateTime(2023, 3, 25, 13, 59, 56, 859, DateTimeKind.Local).AddTicks(9991), 2, "Habitasse suspendisse" },
                    { 69, "https://picsum.photos/seed/69/500/500", "Eget aliquet fusce at", true, 300, "Book.pdf", 690.0, new DateTime(2023, 3, 25, 13, 59, 56, 860, DateTimeKind.Local).AddTicks(1092), 1, "Ante faucibus orci" },
                    { 70, "https://picsum.photos/seed/70/500/500", "Urna nisi integer nunc, posuere lectus finibus fringilla tellus maecenas dolor", true, 300, "Book.pdf", 700.0, new DateTime(2023, 3, 25, 13, 59, 56, 860, DateTimeKind.Local).AddTicks(1634), 2, "Urna" },
                    { 71, "https://picsum.photos/seed/71/500/500", "Enim odio, feugiat, egestas hendrerit", true, 400, "Book.pdf", 710.0, new DateTime(2023, 3, 25, 13, 59, 56, 860, DateTimeKind.Local).AddTicks(2214), 3, "Primis odio eros tellus" },
                    { 73, "https://picsum.photos/seed/73/500/500", "Iaculis massa, arcu sagittis eleifend, litora tempor lacinia, vitae venenatis enim vestibulum dictum consequat quis, laoreet, posuere sapien ligula,", true, 200, "Book.pdf", 730.0, new DateTime(2023, 3, 25, 13, 59, 56, 860, DateTimeKind.Local).AddTicks(3320), 2, "Id commodo urna" },
                    { 74, "https://picsum.photos/seed/74/500/500", "Amet, massa fermentum erat, proin dictum", true, 300, "Book.pdf", 740.0, new DateTime(2023, 3, 25, 13, 59, 56, 860, DateTimeKind.Local).AddTicks(3862), 3, "Faucibus suscipit metus ultrices" },
                    { 75, "https://picsum.photos/seed/75/500/500", "Turpis nisi, luctus risus habitasse at, justo mi et nec, morbi himenaeos viverra mattis, sagittis a bibendum", true, 200, "Book.pdf", 750.0, new DateTime(2023, 3, 25, 13, 59, 56, 860, DateTimeKind.Local).AddTicks(4456), 1, "Per tortor orci hac" },
                    { 77, "https://picsum.photos/seed/77/500/500", "Nulla primis egestas arcu magna ultrices, fusce id, nullam massa consequat interdum, porttitor,", true, 300, "Book.pdf", 770.0, new DateTime(2023, 3, 25, 13, 59, 56, 860, DateTimeKind.Local).AddTicks(6599), 3, "Platea" },
                    { 78, "https://picsum.photos/seed/78/500/500", "Accumsan amet tempor, condimentum", true, 100, "Book.pdf", 780.0, new DateTime(2023, 3, 25, 13, 59, 56, 860, DateTimeKind.Local).AddTicks(7517), 1, "Mauris" },
                    { 79, "https://picsum.photos/seed/79/500/500", "Magna dignissim fringilla, tortor massa, mauris, suscipit elit auctor,", true, 400, "Book.pdf", 790.0, new DateTime(2023, 3, 25, 13, 59, 56, 860, DateTimeKind.Local).AddTicks(8654), 2, "Tortor id ultrices velit" },
                    { 81, "https://picsum.photos/seed/81/500/500", "Bibendum, volutpat,", true, 200, "Book.pdf", 810.0, new DateTime(2023, 3, 25, 13, 59, 56, 861, DateTimeKind.Local).AddTicks(1537), 1, "Consectetur ultricies neque" },
                    { 82, "https://picsum.photos/seed/82/500/500", "Sagittis est et, tortor integer quis, risus turpis auctor, scelerisque porttitor, iaculis vestibulum interdum", true, 400, "Book.pdf", 820.0, new DateTime(2023, 3, 25, 13, 59, 56, 861, DateTimeKind.Local).AddTicks(3104), 2, "Amet at" },
                    { 83, "https://picsum.photos/seed/83/500/500", "Nibh nec sociosqu non eget sit tellus, dolor purus hac proin", true, 200, "Book.pdf", 830.0, new DateTime(2023, 3, 25, 13, 59, 56, 861, DateTimeKind.Local).AddTicks(4566), 3, "Non" },
                    { 85, "https://picsum.photos/seed/85/500/500", "Tristique", true, 200, "Book.pdf", 850.0, new DateTime(2023, 3, 25, 13, 59, 56, 861, DateTimeKind.Local).AddTicks(7469), 2, "Nam" },
                    { 86, "https://picsum.photos/seed/86/500/500", "Posuere, odio, id, id eleifend, aenean felis ultricies", true, 300, "Book.pdf", 860.0, new DateTime(2023, 3, 25, 13, 59, 56, 861, DateTimeKind.Local).AddTicks(8940), 3, "Class" },
                    { 87, "https://picsum.photos/seed/87/500/500", "Volutpat, rutrum vehicula", true, 300, "Book.pdf", 870.0, new DateTime(2023, 3, 25, 13, 59, 56, 862, DateTimeKind.Local).AddTicks(100), 1, "Interdum" },
                    { 89, "https://picsum.photos/seed/89/500/500", "Libero sagittis, gravida ipsum bibendum neque elementum quis suscipit mollis fringilla, lacinia elit varius, et, sapien cursus", true, 100, "Book.pdf", 890.0, new DateTime(2023, 3, 25, 13, 59, 56, 862, DateTimeKind.Local).AddTicks(1383), 3, "Tempus" },
                    { 90, "https://picsum.photos/seed/90/500/500", "Erat, integer varius interdum, vel, morbi nulla, hendrerit congue, ad volutpat, tempor eu viverra odio ultricies", true, 300, "Book.pdf", 900.0, new DateTime(2023, 3, 25, 13, 59, 56, 862, DateTimeKind.Local).AddTicks(1992), 1, "Aptent dictumst vehicula" },
                    { 91, "https://picsum.photos/seed/91/500/500", "Aptent dolor taciti mattis, commodo, magna, dolor, nec pellentesque fringilla,", true, 400, "Book.pdf", 910.0, new DateTime(2023, 3, 25, 13, 59, 56, 862, DateTimeKind.Local).AddTicks(2535), 2, "Varius laoreet mollis" },
                    { 93, "https://picsum.photos/seed/93/500/500", "Quisque sagittis, porta, magna amet eu convallis donec per vestibulum dui facilisis arcu fringilla, morbi posuere, pretium felis", true, 300, "Book.pdf", 930.0, new DateTime(2023, 3, 25, 13, 59, 56, 862, DateTimeKind.Local).AddTicks(3816), 1, "Convallis suscipit eleifend" },
                    { 94, "https://picsum.photos/seed/94/500/500", "Cursus posuere morbi pharetra", true, 400, "Book.pdf", 940.0, new DateTime(2023, 3, 25, 13, 59, 56, 862, DateTimeKind.Local).AddTicks(4478), 2, "Arcu luctus ullamcorper orci" },
                    { 95, "https://picsum.photos/seed/95/500/500", "Posuere, platea tellus non ante vitae", true, 400, "Book.pdf", 950.0, new DateTime(2023, 3, 25, 13, 59, 56, 862, DateTimeKind.Local).AddTicks(5068), 3, "Tempus elit curabitur" },
                    { 97, "https://picsum.photos/seed/97/500/500", "Laoreet, lacinia molestie curabitur mauris massa, rhoncus", true, 400, "Book.pdf", 970.0, new DateTime(2023, 3, 25, 13, 59, 56, 862, DateTimeKind.Local).AddTicks(6561), 2, "Blandit" },
                    { 98, "https://picsum.photos/seed/98/500/500", "Ornare pretium donec sit eleifend, congue tellus,", true, 300, "Book.pdf", 980.0, new DateTime(2023, 3, 25, 13, 59, 56, 862, DateTimeKind.Local).AddTicks(7138), 3, "Quis non maecenas odio" },
                    { 99, "https://picsum.photos/seed/99/500/500", "Nisi, congue, pellentesque", true, 100, "Book.pdf", 990.0, new DateTime(2023, 3, 25, 13, 59, 56, 862, DateTimeKind.Local).AddTicks(7669), 1, "Pulvinar nisl" }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "BookId", "UserId", "IsActive" },
                values: new object[,]
                {
                    { 4, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), true },
                    { 8, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), true }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "BookId", "UserId" },
                values: new object[,]
                {
                    { 4, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63") },
                    { 8, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67") }
                });

            migrationBuilder.InsertData(
                table: "WishItems",
                columns: new[] { "BookId", "UserId", "IsActive" },
                values: new object[,]
                {
                    { 4, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), true },
                    { 8, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), true }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 1, 7 },
                    { 2, 12 },
                    { 3, 4 },
                    { 5, 12 },
                    { 6, 11 },
                    { 7, 10 },
                    { 9, 2 },
                    { 10, 5 },
                    { 11, 3 },
                    { 13, 8 },
                    { 14, 1 },
                    { 15, 11 },
                    { 17, 12 },
                    { 18, 3 },
                    { 19, 9 },
                    { 21, 7 },
                    { 22, 1 },
                    { 23, 5 },
                    { 25, 3 },
                    { 26, 10 },
                    { 27, 8 },
                    { 29, 10 },
                    { 30, 3 },
                    { 31, 10 },
                    { 33, 7 },
                    { 34, 2 },
                    { 35, 2 },
                    { 37, 3 },
                    { 38, 9 },
                    { 39, 8 },
                    { 41, 8 },
                    { 42, 8 },
                    { 43, 2 },
                    { 45, 2 },
                    { 46, 5 },
                    { 47, 10 },
                    { 49, 12 },
                    { 50, 3 },
                    { 51, 1 },
                    { 53, 1 },
                    { 54, 6 },
                    { 55, 12 }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 57, 7 },
                    { 58, 8 },
                    { 59, 10 },
                    { 61, 9 },
                    { 62, 10 },
                    { 63, 10 },
                    { 65, 7 },
                    { 66, 7 },
                    { 67, 12 },
                    { 69, 2 },
                    { 70, 4 },
                    { 71, 11 },
                    { 73, 6 },
                    { 74, 2 },
                    { 75, 5 },
                    { 77, 1 },
                    { 78, 8 },
                    { 79, 12 },
                    { 81, 9 },
                    { 82, 4 },
                    { 83, 5 },
                    { 85, 8 },
                    { 86, 1 },
                    { 87, 11 },
                    { 89, 9 },
                    { 90, 12 },
                    { 91, 8 },
                    { 93, 8 },
                    { 94, 9 },
                    { 95, 4 },
                    { 97, 11 },
                    { 98, 9 },
                    { 99, 7 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "BookId", "UserId", "IsActive" },
                values: new object[,]
                {
                    { 1, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"), true },
                    { 2, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"), true },
                    { 3, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), true },
                    { 5, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), true },
                    { 6, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), true },
                    { 7, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), true },
                    { 9, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), true },
                    { 10, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), true }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "BookId", "UserId" },
                values: new object[] { 1, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60") });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "BookId", "UserId" },
                values: new object[,]
                {
                    { 2, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61") },
                    { 3, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62") },
                    { 5, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64") },
                    { 6, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65") },
                    { 7, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66") },
                    { 9, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68") },
                    { 10, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69") }
                });

            migrationBuilder.InsertData(
                table: "WishItems",
                columns: new[] { "BookId", "UserId", "IsActive" },
                values: new object[,]
                {
                    { 1, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"), true },
                    { 2, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"), true },
                    { 3, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), true },
                    { 5, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), true },
                    { 6, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), true },
                    { 7, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), true },
                    { 9, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), true },
                    { 10, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_GenreId",
                table: "BookGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_SaleId",
                table: "Books",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookId",
                table: "CartItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryItems_BookId",
                table: "LibraryItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_WishItems_BookId",
                table: "WishItems",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookGenres");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "LibraryItems");

            migrationBuilder.DropTable(
                name: "WishItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
