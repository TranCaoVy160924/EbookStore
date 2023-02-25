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
                    EpubLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { new Guid("423e533c-d43d-4fd9-9676-e31af724522a"), "8e5907ff-d9e5-4f00-860d-55e7d200acd2", "Administrator role", "Admin", "admin" },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), "1ecbcad1-dcbe-4718-b2d7-868133616910", "User role", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"), 0, "cd5004cc-0ce3-427a-8934-d791e8f5405f", "user1@gmail.com", true, "Ten 1", true, "Ho 1", false, null, "user1@gmail.com", "user1", "AQAAAAEAACcQAAAAEPpfg2n/Rpic11CX59eCLmkpvT3hcBLUlYTx9COyeeQWLcpEsqiLbdre8TeWWe8CBg==", "123456781", false, "", false, "user1" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"), 0, "0b986c06-22b6-4df2-a044-eff8d92ebe2f", "user2@gmail.com", true, "Ten 2", true, "Ho 2", false, null, "user2@gmail.com", "user2", "AQAAAAEAACcQAAAAEGMR1gbbj1JmB1wFhpHvjlZ08lUHmZ4alDGcYLhLHnEEUCbGo4RBFRHajO2s1gOHtw==", "123456782", false, "", false, "user2" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), 0, "d17df1be-5847-471b-99e9-b6840af91355", "user3@gmail.com", true, "Ten 3", true, "Ho 3", false, null, "user3@gmail.com", "user3", "AQAAAAEAACcQAAAAEA3Y07AgXM6sUy+4dP4fle2/5qmV8BdWQw+BiXjHgL6rocFI+y9C53OPWtYFoYKI+A==", "123456783", false, "", false, "user3" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), 0, "e113c91a-9a2f-409a-bb6b-3707a84ad7f7", "user4@gmail.com", true, "Ten 4", true, "Ho 4", false, null, "user4@gmail.com", "user4", "AQAAAAEAACcQAAAAEFkGNsHgZ+wpx5+78HpzyjrNl7qE8ec0u3Xs9RXF4d/IGFXDJKwUwyDn1MYq5s4rAw==", "123456784", false, "", false, "user4" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), 0, "cd1769ce-afa3-46ed-a485-6c6c52d1fdf0", "user5@gmail.com", true, "Ten 5", true, "Ho 5", false, null, "user5@gmail.com", "user5", "AQAAAAEAACcQAAAAEOTiQiBJxWFI6rUBrcxJDYS47zTzM49onALGebrxkMM82vwShO9qgATafHHNrthMlA==", "123456785", false, "", false, "user5" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), 0, "11f274ac-e3f6-45f1-b926-71eeecaa96fa", "user6@gmail.com", true, "Ten 6", true, "Ho 6", false, null, "user6@gmail.com", "user6", "AQAAAAEAACcQAAAAEME4mrzYuWa7GegThDrUu5C60Di2bEz0fAtija0Yydm1u8ZgAUdR30NfoS8InNz2ZQ==", "123456786", false, "", false, "user6" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), 0, "c0a28324-65cf-4b24-92dd-caf65d49bec5", "user7@gmail.com", true, "Ten 7", true, "Ho 7", false, null, "user7@gmail.com", "user7", "AQAAAAEAACcQAAAAEMK2kpurY70ZHCziYzstxc5r/lne4ssHNjhBtXlwcdaMaMqLVvRjGwOWohhjIIBNOw==", "123456787", false, "", false, "user7" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), 0, "2d2176ef-20a8-4ed4-8c14-98773e27b6fc", "user8@gmail.com", true, "Ten 8", true, "Ho 8", false, null, "user8@gmail.com", "user8", "AQAAAAEAACcQAAAAEFhi6/RtNFC0Ps/DuQcvAsqnc7qZnOoPin7Kl08nnJzcnD6JitMbeYVRZQxZ/yG9+g==", "123456788", false, "", false, "user8" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), 0, "43d392b2-dfea-46dc-99a7-da0ac740ca2d", "user9@gmail.com", true, "Ten 9", true, "Ho 9", false, null, "user9@gmail.com", "user9", "AQAAAAEAACcQAAAAEFSQyeEDFmWw+QWkdBcWtm7A55fAnkDWPQXcl79z9BDp7UHapVshIufQWGx2pQW2uQ==", "123456789", false, "", false, "user9" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), 0, "fedf1872-929b-425b-9c05-4933c95dded0", "user10@gmail.com", true, "Ten 10", true, "Ho 10", false, null, "user10@gmail.com", "user10", "AQAAAAEAACcQAAAAEIWYX98zfyLEvQpkHyta3JC4cm+QeIzC66nhpKSatxsQCSwxpDEVT4yLgFWg0eD+9Q==", "1234567810", false, "", false, "user10" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 4, "cover 4", "Description 4", "EpubLink4", true, 400, "PdfLink 4", 40.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(333), null, "Book 4" },
                    { 8, "cover 8", "Description 8", "EpubLink8", true, 800, "PdfLink 8", 80.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(401), null, "Book 8" },
                    { 12, "cover 12", "Description 12", "EpubLink12", true, 1200, "PdfLink 12", 120.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(468), null, "Book 12" },
                    { 16, "cover 16", "Description 16", "EpubLink16", true, 1600, "PdfLink 16", 160.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(593), null, "Book 16" },
                    { 20, "cover 20", "Description 20", "EpubLink20", true, 2000, "PdfLink 20", 200.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(667), null, "Book 20" },
                    { 24, "cover 24", "Description 24", "EpubLink24", true, 2400, "PdfLink 24", 240.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(730), null, "Book 24" },
                    { 28, "cover 28", "Description 28", "EpubLink28", true, 2800, "PdfLink 28", 280.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(861), null, "Book 28" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Genre 1" },
                    { 2, "Genre 2" },
                    { 3, "Genre 3" },
                    { 4, "Genre 4" },
                    { 5, "Genre 5" },
                    { 6, "Genre 6" },
                    { 7, "Genre 7" },
                    { 8, "Genre 8" },
                    { 9, "Genre 9" },
                    { 10, "Genre 10" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "EndDate", "Name", "SalePercent", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(3), "Sale 1", 1.0, new DateTime(2023, 2, 23, 14, 38, 42, 316, DateTimeKind.Local).AddTicks(9986) },
                    { 2, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(28), "Sale 2", 2.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(27) },
                    { 3, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(44), "Sale 3", 3.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(43) },
                    { 4, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(63), "Sale 4", 4.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(61) },
                    { 5, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(98), "Sale 5", 5.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(97) },
                    { 6, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(119), "Sale 6", 6.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(118) },
                    { 7, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(133), "Sale 7", 7.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(132) },
                    { 8, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(147), "Sale 8", 8.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(147) },
                    { 9, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(162), "Sale 9", 9.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(161) },
                    { 10, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(179), "Sale 10", 10.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(178) }
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
                    { 4, 4 },
                    { 8, 8 },
                    { 12, 2 },
                    { 16, 6 },
                    { 20, 10 },
                    { 24, 4 },
                    { 28, 8 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 1, "cover 1", "Description 1", "EpubLink1", true, 100, "PdfLink 1", 10.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(205), 2, "Book 1" },
                    { 2, "cover 2", "Description 2", "EpubLink2", true, 200, "PdfLink 2", 20.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(226), 3, "Book 2" },
                    { 3, "cover 3", "Description 3", "EpubLink3", true, 300, "PdfLink 3", 30.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(312), 1, "Book 3" },
                    { 5, "cover 5", "Description 5", "EpubLink5", true, 500, "PdfLink 5", 50.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(350), 3, "Book 5" },
                    { 6, "cover 6", "Description 6", "EpubLink6", true, 600, "PdfLink 6", 60.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(369), 1, "Book 6" },
                    { 7, "cover 7", "Description 7", "EpubLink7", true, 700, "PdfLink 7", 70.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(385), 2, "Book 7" },
                    { 9, "cover 9", "Description 9", "EpubLink9", true, 900, "PdfLink 9", 90.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(416), 1, "Book 9" },
                    { 10, "cover 10", "Description 10", "EpubLink10", true, 1000, "PdfLink 10", 100.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(435), 2, "Book 10" },
                    { 11, "cover 11", "Description 11", "EpubLink11", true, 1100, "PdfLink 11", 110.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(451), 3, "Book 11" },
                    { 13, "cover 13", "Description 13", "EpubLink13", true, 1300, "PdfLink 13", 130.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(484), 2, "Book 13" },
                    { 14, "cover 14", "Description 14", "EpubLink14", true, 1400, "PdfLink 14", 140.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(500), 3, "Book 14" },
                    { 15, "cover 15", "Description 15", "EpubLink15", true, 1500, "PdfLink 15", 150.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(516), 1, "Book 15" },
                    { 17, "cover 17", "Description 17", "EpubLink17", true, 1700, "PdfLink 17", 170.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(614), 3, "Book 17" },
                    { 18, "cover 18", "Description 18", "EpubLink18", true, 1800, "PdfLink 18", 180.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(633), 1, "Book 18" },
                    { 19, "cover 19", "Description 19", "EpubLink19", true, 1900, "PdfLink 19", 190.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(650), 2, "Book 19" },
                    { 21, "cover 21", "Description 21", "EpubLink21", true, 2100, "PdfLink 21", 210.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(682), 1, "Book 21" },
                    { 22, "cover 22", "Description 22", "EpubLink22", true, 2200, "PdfLink 22", 220.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(698), 2, "Book 22" },
                    { 23, "cover 23", "Description 23", "EpubLink23", true, 2300, "PdfLink 23", 230.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(714), 3, "Book 23" },
                    { 25, "cover 25", "Description 25", "EpubLink25", true, 2500, "PdfLink 25", 250.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(746), 2, "Book 25" },
                    { 26, "cover 26", "Description 26", "EpubLink26", true, 2600, "PdfLink 26", 260.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(761), 3, "Book 26" },
                    { 27, "cover 27", "Description 27", "EpubLink27", true, 2700, "PdfLink 27", 270.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(843), 1, "Book 27" },
                    { 29, "cover 29", "Description 29", "EpubLink29", true, 2900, "PdfLink 29", 290.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(877), 3, "Book 29" },
                    { 30, "cover 30", "Description 30", "EpubLink30", true, 3000, "PdfLink 30", 300.0, new DateTime(2023, 2, 23, 14, 38, 42, 317, DateTimeKind.Local).AddTicks(893), 1, "Book 30" }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "BookId", "UserId", "IsActive" },
                values: new object[,]
                {
                    { 4, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), false },
                    { 8, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), false }
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
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 1 },
                    { 13, 3 },
                    { 14, 4 },
                    { 15, 5 },
                    { 17, 7 },
                    { 18, 8 },
                    { 19, 9 },
                    { 21, 1 },
                    { 22, 2 },
                    { 23, 3 },
                    { 25, 5 },
                    { 26, 6 },
                    { 27, 7 },
                    { 29, 9 },
                    { 30, 10 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "BookId", "UserId", "IsActive" },
                values: new object[,]
                {
                    { 1, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"), false },
                    { 2, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"), false },
                    { 3, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), false },
                    { 5, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), false },
                    { 6, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), false },
                    { 7, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), false },
                    { 9, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), false },
                    { 10, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), false }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "BookId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60") },
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
                    { 3, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), true }
                });

            migrationBuilder.InsertData(
                table: "WishItems",
                columns: new[] { "BookId", "UserId", "IsActive" },
                values: new object[,]
                {
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
