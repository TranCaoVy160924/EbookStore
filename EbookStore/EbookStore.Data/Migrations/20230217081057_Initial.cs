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
                    { new Guid("423e533c-d43d-4fd9-9676-e31af724522a"), "708e5b69-11c6-4024-a53a-04336ce04363", "Administrator role", "Admin", "admin" },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), "a2b132c1-20eb-4022-b753-d5ce80270430", "User role", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"), 0, "bfea14e4-1ce3-4b7b-a7c1-d5882d332841", "user1@gmail.com", true, "Ten 1", true, "Ho 1", false, null, "user1@gmail.com", "user1", "AQAAAAEAACcQAAAAEJuxlSd6fbdXMCKElL7sbvSulET4NhBn0wSVYR1ymDYiAcIeBYIciaTmYWMYcO+sOQ==", "123456781", false, "", false, "user1" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"), 0, "02d280a8-3164-4c92-8c45-295ba1c0166f", "user2@gmail.com", true, "Ten 2", true, "Ho 2", false, null, "user2@gmail.com", "user2", "AQAAAAEAACcQAAAAEG8DtIvUoS9qhVOpi5LEe7xq7/NsiX1P57L0n1AJhhg5z3fNPFDiFOzdlroBRWv59Q==", "123456782", false, "", false, "user2" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), 0, "2cd8f3cb-1d5a-4ef4-959a-0068e5028e97", "user3@gmail.com", true, "Ten 3", true, "Ho 3", false, null, "user3@gmail.com", "user3", "AQAAAAEAACcQAAAAEKaAYWZAcSOZATvZtGlcKdiscwqG1pRe3glzO28vbYLtYbye+3NKWoV4fbPDK3nKng==", "123456783", false, "", false, "user3" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), 0, "65b16324-9667-480a-ab76-c8ff4216ada6", "user4@gmail.com", true, "Ten 4", true, "Ho 4", false, null, "user4@gmail.com", "user4", "AQAAAAEAACcQAAAAEPe6dC5ejuZYFhA7bqqCHq0Yz77ia0V19reIVDvbtcDfvXh98/xeICc/6+7x2YsoZA==", "123456784", false, "", false, "user4" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), 0, "c3e5efa6-1b9e-4693-8f37-da9d50706944", "user5@gmail.com", true, "Ten 5", true, "Ho 5", false, null, "user5@gmail.com", "user5", "AQAAAAEAACcQAAAAEOPoZi/vHWWT0xx7A7ewCpsJtJATeGESYWJbEk4H2a8ENNVEVL/3nOhVMXyrq3gz7g==", "123456785", false, "", false, "user5" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), 0, "8375e2e0-eca7-4ca5-b974-f1f9372fb8be", "user6@gmail.com", true, "Ten 6", true, "Ho 6", false, null, "user6@gmail.com", "user6", "AQAAAAEAACcQAAAAEFQL3RLNnW4TEZkgmBJ9IDel1hMQ3XZDvIkaTQ9KQtJhN2pXyAjtd7N/0+q6EevtFg==", "123456786", false, "", false, "user6" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), 0, "8d6487e3-6bb1-47fc-bde7-455b5e225fd5", "user7@gmail.com", true, "Ten 7", true, "Ho 7", false, null, "user7@gmail.com", "user7", "AQAAAAEAACcQAAAAENAONBm6HL0flDx2P7DuUqBiIcyMwJ0ii+c9joOdWO3oDpvOVwD28wY/ek8AlyBVKQ==", "123456787", false, "", false, "user7" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), 0, "14cbe7d2-4ff1-47de-97f1-89c59b1c3e68", "user8@gmail.com", true, "Ten 8", true, "Ho 8", false, null, "user8@gmail.com", "user8", "AQAAAAEAACcQAAAAEAHGjW8bnifeSff1okZIL/0oKh+ZU17z5hFV9+bCdCqIW2MjXuekz0LkKAidF8a/Mg==", "123456788", false, "", false, "user8" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), 0, "092ac64d-3106-42b1-b4c0-7b25ba8acd03", "user9@gmail.com", true, "Ten 9", true, "Ho 9", false, null, "user9@gmail.com", "user9", "AQAAAAEAACcQAAAAELycO+2J0MrYajXj7HA696IHhXmmm+ULWdwaWWY3aOj0BSrWYdn3j76mvhUe3Q5igQ==", "123456789", false, "", false, "user9" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), 0, "3365340a-7d57-4ea6-b288-259fe43662a6", "user10@gmail.com", true, "Ten 10", true, "Ho 10", false, null, "user10@gmail.com", "user10", "AQAAAAEAACcQAAAAEEavyeM1bubR7g5GvwnmcWbsnkJ0U/hXTlgX8r4chLQ1QlOGL+Ev/eLnPwoShAqloA==", "1234567810", false, "", false, "user10" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 4, "cover 4", "Description 4", "EpubLink4", true, 400, "PdfLink 4", 40.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(445), null, "Book 4" },
                    { 8, "cover 8", "Description 8", "EpubLink8", true, 800, "PdfLink 8", 80.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(478), null, "Book 8" },
                    { 12, "cover 12", "Description 12", "EpubLink12", true, 1200, "PdfLink 12", 120.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(513), null, "Book 12" },
                    { 16, "cover 16", "Description 16", "EpubLink16", true, 1600, "PdfLink 16", 160.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(595), null, "Book 16" },
                    { 20, "cover 20", "Description 20", "EpubLink20", true, 2000, "PdfLink 20", 200.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(628), null, "Book 20" },
                    { 24, "cover 24", "Description 24", "EpubLink24", true, 2400, "PdfLink 24", 240.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(660), null, "Book 24" },
                    { 28, "cover 28", "Description 28", "EpubLink28", true, 2800, "PdfLink 28", 280.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(735), null, "Book 28" }
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
                    { 1, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(198), "Sale 1", 1.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(185) },
                    { 2, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(212), "Sale 2", 2.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(212) },
                    { 3, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(220), "Sale 3", 3.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(220) },
                    { 4, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(228), "Sale 4", 4.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(227) },
                    { 5, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(235), "Sale 5", 5.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(235) },
                    { 6, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(247), "Sale 6", 6.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(247) },
                    { 7, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(255), "Sale 7", 7.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(254) },
                    { 8, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(262), "Sale 8", 8.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(262) },
                    { 9, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(270), "Sale 9", 9.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(269) },
                    { 10, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(279), "Sale 10", 10.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(279) }
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
                    { 1, "cover 1", "Description 1", "EpubLink1", true, 100, "PdfLink 1", 10.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(411), 2, "Book 1" },
                    { 2, "cover 2", "Description 2", "EpubLink2", true, 200, "PdfLink 2", 20.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(428), 3, "Book 2" },
                    { 3, "cover 3", "Description 3", "EpubLink3", true, 300, "PdfLink 3", 30.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(437), 1, "Book 3" },
                    { 5, "cover 5", "Description 5", "EpubLink5", true, 500, "PdfLink 5", 50.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(453), 3, "Book 5" },
                    { 6, "cover 6", "Description 6", "EpubLink6", true, 600, "PdfLink 6", 60.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(462), 1, "Book 6" },
                    { 7, "cover 7", "Description 7", "EpubLink7", true, 700, "PdfLink 7", 70.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(470), 2, "Book 7" },
                    { 9, "cover 9", "Description 9", "EpubLink9", true, 900, "PdfLink 9", 90.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(486), 1, "Book 9" },
                    { 10, "cover 10", "Description 10", "EpubLink10", true, 1000, "PdfLink 10", 100.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(496), 2, "Book 10" },
                    { 11, "cover 11", "Description 11", "EpubLink11", true, 1100, "PdfLink 11", 110.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(504), 3, "Book 11" },
                    { 13, "cover 13", "Description 13", "EpubLink13", true, 1300, "PdfLink 13", 130.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(521), 2, "Book 13" },
                    { 14, "cover 14", "Description 14", "EpubLink14", true, 1400, "PdfLink 14", 140.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(576), 3, "Book 14" },
                    { 15, "cover 15", "Description 15", "EpubLink15", true, 1500, "PdfLink 15", 150.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(587), 1, "Book 15" },
                    { 17, "cover 17", "Description 17", "EpubLink17", true, 1700, "PdfLink 17", 170.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(604), 3, "Book 17" },
                    { 18, "cover 18", "Description 18", "EpubLink18", true, 1800, "PdfLink 18", 180.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(613), 1, "Book 18" },
                    { 19, "cover 19", "Description 19", "EpubLink19", true, 1900, "PdfLink 19", 190.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(620), 2, "Book 19" },
                    { 21, "cover 21", "Description 21", "EpubLink21", true, 2100, "PdfLink 21", 210.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(636), 1, "Book 21" },
                    { 22, "cover 22", "Description 22", "EpubLink22", true, 2200, "PdfLink 22", 220.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(644), 2, "Book 22" },
                    { 23, "cover 23", "Description 23", "EpubLink23", true, 2300, "PdfLink 23", 230.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(652), 3, "Book 23" },
                    { 25, "cover 25", "Description 25", "EpubLink25", true, 2500, "PdfLink 25", 250.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(709), 2, "Book 25" },
                    { 26, "cover 26", "Description 26", "EpubLink26", true, 2600, "PdfLink 26", 260.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(718), 3, "Book 26" },
                    { 27, "cover 27", "Description 27", "EpubLink27", true, 2700, "PdfLink 27", 270.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(727), 1, "Book 27" },
                    { 29, "cover 29", "Description 29", "EpubLink29", true, 2900, "PdfLink 29", 290.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(743), 3, "Book 29" },
                    { 30, "cover 30", "Description 30", "EpubLink30", true, 3000, "PdfLink 30", 300.0, new DateTime(2023, 2, 17, 15, 10, 56, 535, DateTimeKind.Local).AddTicks(751), 1, "Book 30" }
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
                    { 4, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), false },
                    { 8, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), false }
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
                    { 1, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"), false },
                    { 2, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"), false },
                    { 3, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), false }
                });

            migrationBuilder.InsertData(
                table: "WishItems",
                columns: new[] { "BookId", "UserId", "IsActive" },
                values: new object[,]
                {
                    { 5, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), false },
                    { 6, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), false },
                    { 7, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), false },
                    { 9, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), false },
                    { 10, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), false }
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
