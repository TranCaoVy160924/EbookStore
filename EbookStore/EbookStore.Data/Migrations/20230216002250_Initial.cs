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
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    NumberOfPage = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PdfLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpubLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("423e533c-d43d-4fd9-9676-e31af724522a"), "5bb248b0-2ee3-4950-90ff-c92d529aa60f", "Administrator role", "Admin", "admin" },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), "c6966572-9edc-4740-ad7c-fee0031cd279", "User role", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"), 0, "3296ef38-3ca5-40ef-b036-8a5d306c411f", "user1@gmail.com", true, "Ten 1", true, "Ho 1", false, null, "user1@gmail.com", "user1", "AQAAAAEAACcQAAAAEHSOFJevWCysB2Ee11HcEoPc3/PsfZ71cZ1dP/eYUrDNmFUu4BSZncj8/n+2vDUSLQ==", "123456781", false, "", false, "user1" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"), 0, "30db40b7-c75a-43c5-9df6-c0ff184f1bc4", "user2@gmail.com", true, "Ten 2", true, "Ho 2", false, null, "user2@gmail.com", "user2", "AQAAAAEAACcQAAAAENhEFYSd9K5D5OlO7RRDvzcCa5O1CVyDEOxZ5CPIWxlmEaalsau4tmN1wv/5bObAIw==", "123456782", false, "", false, "user2" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), 0, "42990c4a-b530-443a-8034-4d401977c07a", "user3@gmail.com", true, "Ten 3", true, "Ho 3", false, null, "user3@gmail.com", "user3", "AQAAAAEAACcQAAAAEF2RS6PlpDBEq+fcFePGCPjuioTsDLZ9WvYfewTPbT98G3RTxdIgpyhOh4pH3NLG1w==", "123456783", false, "", false, "user3" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), 0, "c573101b-e256-4fdf-965e-32c982a92613", "user4@gmail.com", true, "Ten 4", true, "Ho 4", false, null, "user4@gmail.com", "user4", "AQAAAAEAACcQAAAAECVlJOuw3nthktHqUXrTX+RBYoJUYKfsmrUMU8qCJRfJmOBGPqch8Kxd2O6ArNAhmg==", "123456784", false, "", false, "user4" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), 0, "279c1356-d11e-43b3-9177-c4deb69615f7", "user5@gmail.com", true, "Ten 5", true, "Ho 5", false, null, "user5@gmail.com", "user5", "AQAAAAEAACcQAAAAEIszcxDJWHjfh4YGgw3lNc28DJjiSkg4ZyawBSjY47VaU8k711WeaHIv/cpdOSuCcg==", "123456785", false, "", false, "user5" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), 0, "904e11d7-b2dd-4f09-a4e3-0966043e611c", "user6@gmail.com", true, "Ten 6", true, "Ho 6", false, null, "user6@gmail.com", "user6", "AQAAAAEAACcQAAAAEARNtcZoYmsRsnDK3MN+cpjiEav+eCsva3wrh+0ZSOYDcT+KU1hcMVmfCNjcKgIemg==", "123456786", false, "", false, "user6" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), 0, "53e1c3f7-b5b8-4512-918b-4293912c6ed8", "user7@gmail.com", true, "Ten 7", true, "Ho 7", false, null, "user7@gmail.com", "user7", "AQAAAAEAACcQAAAAEFV6VilPrT1JttBXxaJXnSxb7rOWpdmq1rPCmDrsNuzTst6RSGVsWsN8u8fLZMPkaA==", "123456787", false, "", false, "user7" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), 0, "4dc29cd3-fc48-4a00-9ae5-493d56519606", "user8@gmail.com", true, "Ten 8", true, "Ho 8", false, null, "user8@gmail.com", "user8", "AQAAAAEAACcQAAAAEM++GT1IoZRV6ad/Hna30b5RSONt63euKS7Gvr2R8pJ3sM8MDxlaLFYaK8OaNpyvzQ==", "123456788", false, "", false, "user8" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), 0, "e8c7903f-539e-474f-8eba-7508c9c4707f", "user9@gmail.com", true, "Ten 9", true, "Ho 9", false, null, "user9@gmail.com", "user9", "AQAAAAEAACcQAAAAEMfPbzxZc46eky7M+keCQt7aBDZG+1+FIzMvPz31NKx1kIty5Qu9JEmzGl1WS+tJew==", "123456789", false, "", false, "user9" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), 0, "e19600b9-9f0a-4764-9c67-2e6648018b2e", "user10@gmail.com", true, "Ten 10", true, "Ho 10", false, null, "user10@gmail.com", "user10", "AQAAAAEAACcQAAAAEII+2bmt17vhIMjRvBrmXm7vaSDittIUi2tQgwmlpxl7jAjh7MB0ylnEl5F6oHE4+A==", "1234567810", false, "", false, "user10" }
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
                    { 1, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4464), "Sale 1", 1.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4446) },
                    { 2, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4483), "Sale 2", 2.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4483) },
                    { 3, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4496), "Sale 3", 3.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4495) },
                    { 4, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4507), "Sale 4", 4.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4507) },
                    { 5, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4520), "Sale 5", 5.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4519) },
                    { 6, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4535), "Sale 6", 6.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4534) },
                    { 7, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4548), "Sale 7", 7.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4546) },
                    { 8, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4582), "Sale 8", 8.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4581) },
                    { 9, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4603), "Sale 9", 9.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4603) },
                    { 10, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4619), "Sale 10", 10.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4618) }
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
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 1, "cover 1", "Description 1", "EpubLink1", true, 100, "PdfLink 1", 10.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4642), 2, "Book 1" },
                    { 2, "cover 2", "Description 2", "EpubLink2", true, 200, "PdfLink 2", 20.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4658), 3, "Book 2" },
                    { 3, "cover 3", "Description 3", "EpubLink3", true, 300, "PdfLink 3", 30.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4671), 1, "Book 3" },
                    { 4, "cover 4", "Description 4", "EpubLink4", true, 400, "PdfLink 4", 40.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4738), 2, "Book 4" },
                    { 5, "cover 5", "Description 5", "EpubLink5", true, 500, "PdfLink 5", 50.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4754), 3, "Book 5" },
                    { 6, "cover 6", "Description 6", "EpubLink6", true, 600, "PdfLink 6", 60.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4770), 1, "Book 6" },
                    { 7, "cover 7", "Description 7", "EpubLink7", true, 700, "PdfLink 7", 70.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4782), 2, "Book 7" },
                    { 8, "cover 8", "Description 8", "EpubLink8", true, 800, "PdfLink 8", 80.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4795), 3, "Book 8" },
                    { 9, "cover 9", "Description 9", "EpubLink9", true, 900, "PdfLink 9", 90.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4807), 1, "Book 9" },
                    { 10, "cover 10", "Description 10", "EpubLink10", true, 1000, "PdfLink 10", 100.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4823), 2, "Book 10" },
                    { 11, "cover 11", "Description 11", "EpubLink11", true, 1100, "PdfLink 11", 110.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4835), 3, "Book 11" },
                    { 12, "cover 12", "Description 12", "EpubLink12", true, 1200, "PdfLink 12", 120.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4848), 1, "Book 12" },
                    { 13, "cover 13", "Description 13", "EpubLink13", true, 1300, "PdfLink 13", 130.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4860), 2, "Book 13" },
                    { 14, "cover 14", "Description 14", "EpubLink14", true, 1400, "PdfLink 14", 140.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4873), 3, "Book 14" },
                    { 15, "cover 15", "Description 15", "EpubLink15", true, 1500, "PdfLink 15", 150.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4885), 1, "Book 15" },
                    { 16, "cover 16", "Description 16", "EpubLink16", true, 1600, "PdfLink 16", 160.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4951), 2, "Book 16" },
                    { 17, "cover 17", "Description 17", "EpubLink17", true, 1700, "PdfLink 17", 170.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4970), 3, "Book 17" },
                    { 18, "cover 18", "Description 18", "EpubLink18", true, 1800, "PdfLink 18", 180.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4986), 1, "Book 18" },
                    { 19, "cover 19", "Description 19", "EpubLink19", true, 1900, "PdfLink 19", 190.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(4998), 2, "Book 19" },
                    { 20, "cover 20", "Description 20", "EpubLink20", true, 2000, "PdfLink 20", 200.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(5011), 3, "Book 20" },
                    { 21, "cover 21", "Description 21", "EpubLink21", true, 2100, "PdfLink 21", 210.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(5024), 1, "Book 21" },
                    { 22, "cover 22", "Description 22", "EpubLink22", true, 2200, "PdfLink 22", 220.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(5037), 2, "Book 22" },
                    { 23, "cover 23", "Description 23", "EpubLink23", true, 2300, "PdfLink 23", 230.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(5050), 3, "Book 23" },
                    { 24, "cover 24", "Description 24", "EpubLink24", true, 2400, "PdfLink 24", 240.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(5063), 1, "Book 24" },
                    { 25, "cover 25", "Description 25", "EpubLink25", true, 2500, "PdfLink 25", 250.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(5076), 2, "Book 25" },
                    { 26, "cover 26", "Description 26", "EpubLink26", true, 2600, "PdfLink 26", 260.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(5088), 3, "Book 26" },
                    { 27, "cover 27", "Description 27", "EpubLink27", true, 2700, "PdfLink 27", 270.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(5154), 1, "Book 27" },
                    { 28, "cover 28", "Description 28", "EpubLink28", true, 2800, "PdfLink 28", 280.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(5171), 2, "Book 28" },
                    { 29, "cover 29", "Description 29", "EpubLink29", true, 2900, "PdfLink 29", 290.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(5184), 3, "Book 29" },
                    { 30, "cover 30", "Description 30", "EpubLink30", true, 3000, "PdfLink 30", 300.0, new DateTime(2023, 2, 16, 7, 22, 50, 381, DateTimeKind.Local).AddTicks(5196), 1, "Book 30" }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 1 },
                    { 12, 2 },
                    { 13, 3 },
                    { 14, 4 },
                    { 15, 5 },
                    { 16, 6 },
                    { 17, 7 },
                    { 18, 8 },
                    { 19, 9 },
                    { 20, 10 },
                    { 21, 1 },
                    { 22, 2 },
                    { 23, 3 },
                    { 24, 4 },
                    { 25, 5 },
                    { 26, 6 },
                    { 27, 7 },
                    { 28, 8 },
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
                    { 4, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), false },
                    { 5, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), false },
                    { 6, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), false },
                    { 7, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), false },
                    { 8, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), false },
                    { 9, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), false },
                    { 10, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), false }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "BookId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60") },
                    { 2, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61") }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "BookId", "UserId" },
                values: new object[,]
                {
                    { 3, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62") },
                    { 4, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63") },
                    { 5, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64") },
                    { 6, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65") },
                    { 7, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66") },
                    { 8, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67") },
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
                    { 3, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), false },
                    { 4, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), false },
                    { 5, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), false },
                    { 6, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), false },
                    { 7, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), false },
                    { 8, new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), false },
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
