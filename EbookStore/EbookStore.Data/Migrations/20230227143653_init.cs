using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbookStore.Data.Migrations
{
    public partial class init : Migration
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
                    { new Guid("423e533c-d43d-4fd9-9676-e31af724522a"), "991ddd4d-0679-489a-819d-70bfb8442630", "Administrator role", "Admin", "admin" },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), "611235ce-4717-4193-808c-fb6fe3cc440b", "User role", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"), 0, "ad3ccfe5-187d-4b4c-b3a8-d750a988b958", "user1@gmail.com", true, "Ten 1", true, "Ho 1", false, null, "user1@gmail.com", "user1", "AQAAAAEAACcQAAAAEBRLEgiQ7yesRDgS65jGu4gdYQM3OA7lODVfjCKXn3efK7Ueh8uJjDQMgi5qKTrt4g==", "123456781", false, "", false, "user1" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"), 0, "1ba95f86-2d3d-43d4-938b-b069e5151ff9", "user2@gmail.com", true, "Ten 2", true, "Ho 2", false, null, "user2@gmail.com", "user2", "AQAAAAEAACcQAAAAEGDLF2alC+rot1BjQ8KrqBEPqM+p2jAB2mWHeE6KumKXr0OEDiVn8/IyKDVYjBJNNA==", "123456782", false, "", false, "user2" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), 0, "1d7fb797-190d-491d-a81f-dc27290d945f", "user3@gmail.com", true, "Ten 3", true, "Ho 3", false, null, "user3@gmail.com", "user3", "AQAAAAEAACcQAAAAEC+Bdl6av349I31UllXXXnyXgZQJoqw11VlXgeaeMrSPqgGgkavFlq8cvvJOI4pHOQ==", "123456783", false, "", false, "user3" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), 0, "46e19a3f-52ab-432c-9045-4e08b0c03e2d", "user4@gmail.com", true, "Ten 4", true, "Ho 4", false, null, "user4@gmail.com", "user4", "AQAAAAEAACcQAAAAEGpU2ZWFgrMq2vP4i1494p0VFp8IISPxrN4mVZnj3k7jtbnEwnUjpzxoc7qXiSAI6A==", "123456784", false, "", false, "user4" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), 0, "b79cb1a3-6e88-4e95-b899-768a009402a2", "user5@gmail.com", true, "Ten 5", true, "Ho 5", false, null, "user5@gmail.com", "user5", "AQAAAAEAACcQAAAAEGlwV9QLJcZ70S5g+WehDeabmIb2dZx2kp7NlHKl2+pTPasL6cVTE9mYzDOsUwh6gQ==", "123456785", false, "", false, "user5" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), 0, "d3b661e2-f34c-4008-b146-22c33122d0d8", "user6@gmail.com", true, "Ten 6", true, "Ho 6", false, null, "user6@gmail.com", "user6", "AQAAAAEAACcQAAAAEAKnNQSdGMtwx7tOeKue5AnjsYtj2PQEWKzpvpEPj7bPqa6s/s6HYYirhP3TbDofLA==", "123456786", false, "", false, "user6" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), 0, "2e1840f1-2b5d-4f5b-8ff5-915c1817ff6c", "user7@gmail.com", true, "Ten 7", true, "Ho 7", false, null, "user7@gmail.com", "user7", "AQAAAAEAACcQAAAAENbYRxFMT8kUEG2QeNlC6Zv0hjI9TokGiQunoA73TNFXwAueyn1uxjrP2voXP+Mpcg==", "123456787", false, "", false, "user7" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), 0, "53967c34-4cc2-4a24-be3b-427652f5ec9e", "user8@gmail.com", true, "Ten 8", true, "Ho 8", false, null, "user8@gmail.com", "user8", "AQAAAAEAACcQAAAAEBOtITv6mbtsWTIkYlRIuZeWf5mCpXplLHJjpuSKgO5paxmHduzzy+MhtntxOmabsw==", "123456788", false, "", false, "user8" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), 0, "7d558395-e598-4d5a-8899-8b86d7876136", "user9@gmail.com", true, "Ten 9", true, "Ho 9", false, null, "user9@gmail.com", "user9", "AQAAAAEAACcQAAAAEOaMBjhAc1nEG280406rv7DLXycFrdnnnXMkDJDe+gMZu3CzAlPdC+6e1GSydkN53Q==", "123456789", false, "", false, "user9" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), 0, "e78191f0-9340-4956-825b-1229ef0b12fa", "user10@gmail.com", true, "Ten 10", true, "Ho 10", false, null, "user10@gmail.com", "user10", "AQAAAAEAACcQAAAAEKEUhpYcFf0JJ/VC2ZcWZorIfOXnaagP1u/WC2zqCYqvpgESVmsxOZsJcuyh70WBiw==", "1234567810", false, "", false, "user10" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 4, "cover 4", "A ultricies sociosqu nec vitae, dictum quam, id neque, morbi efficitur leo interdum lacus dapibus eu hac praesent pellentesque", "EpubLink4", true, 300, "PdfLink 4", 40.0, new DateTime(2023, 2, 27, 21, 36, 53, 1, DateTimeKind.Local).AddTicks(2926), null, "Rhoncus nisi" },
                    { 8, "cover 8", "Rhoncus sagittis elementum finibus, venenatis massa, dolor, tincidunt porta accumsan commodo platea libero", "EpubLink8", true, 200, "PdfLink 8", 80.0, new DateTime(2023, 2, 27, 21, 36, 53, 1, DateTimeKind.Local).AddTicks(6651), null, "Nulla et tempus ligula" },
                    { 12, "cover 12", "Lacus feugiat, consectetur torquent erat, vulputate lorem", "EpubLink12", true, 100, "PdfLink 12", 120.0, new DateTime(2023, 2, 27, 21, 36, 53, 2, DateTimeKind.Local).AddTicks(325), null, "Aptent" },
                    { 16, "cover 16", "Sit amet, dui a, mattis", "EpubLink16", true, 100, "PdfLink 16", 160.0, new DateTime(2023, 2, 27, 21, 36, 53, 2, DateTimeKind.Local).AddTicks(4093), null, "Et" },
                    { 20, "cover 20", "Justo integer dignissim volutpat vel nostra, vitae, phasellus cursus tempus mauris amet lacinia tempor torquent vivamus", "EpubLink20", true, 100, "PdfLink 20", 200.0, new DateTime(2023, 2, 27, 21, 36, 53, 2, DateTimeKind.Local).AddTicks(8199), null, "At dapibus orci" },
                    { 24, "cover 24", "Non, justo pharetra etiam dui, gravida scelerisque in, ullamcorper vulputate ex aptent primis a, nibh, nulla ad", "EpubLink24", true, 400, "PdfLink 24", 240.0, new DateTime(2023, 2, 27, 21, 36, 53, 3, DateTimeKind.Local).AddTicks(2119), null, "Erat pharetra" },
                    { 28, "cover 28", "Finibus, posuere, viverra a varius, dolor, magna neque, lacinia, venenatis nunc praesent", "EpubLink28", true, 100, "PdfLink 28", 280.0, new DateTime(2023, 2, 27, 21, 36, 53, 3, DateTimeKind.Local).AddTicks(5965), null, "Nisl tellus eros ex" },
                    { 32, "cover 32", "Vitae viverra hac ad lectus, litora arcu congue porttitor neque ex mattis commodo posuere, varius enim, aptent aenean", "EpubLink32", true, 100, "PdfLink 32", 320.0, new DateTime(2023, 2, 27, 21, 36, 53, 4, DateTimeKind.Local).AddTicks(130), null, "Lacus odio" },
                    { 36, "cover 36", "Odio, dignissim et pulvinar per quis nibh, commodo quisque pellentesque dictumst", "EpubLink36", true, 100, "PdfLink 36", 360.0, new DateTime(2023, 2, 27, 21, 36, 53, 4, DateTimeKind.Local).AddTicks(6483), null, "Ligula adipiscing suspendisse interdum" },
                    { 40, "cover 40", "Hac fames lobortis quam, nulla, vulputate nisi eu, libero ex tincidunt vestibulum torquent sociosqu class", "EpubLink40", true, 100, "PdfLink 40", 400.0, new DateTime(2023, 2, 27, 21, 36, 53, 5, DateTimeKind.Local).AddTicks(4017), null, "Nulla" },
                    { 44, "cover 44", "Porttitor convallis porttitor, in magna sem, sodales sed, aliquam risus dui, bibendum auctor sapien dignissim", "EpubLink44", true, 400, "PdfLink 44", 440.0, new DateTime(2023, 2, 27, 21, 36, 53, 6, DateTimeKind.Local).AddTicks(1024), null, "Fringilla" },
                    { 48, "cover 48", "Ultrices, mollis ad iaculis blandit, mattis, sociosqu sem, sapien sagittis, diam donec urna", "EpubLink48", true, 300, "PdfLink 48", 480.0, new DateTime(2023, 2, 27, 21, 36, 53, 6, DateTimeKind.Local).AddTicks(6879), null, "Fusce integer elit euismod" },
                    { 52, "cover 52", "Rhoncus, libero ante scelerisque nunc, convallis interdum erat consequat pharetra congue, inceptos nisi, id quis vulputate per luctus", "EpubLink52", true, 100, "PdfLink 52", 520.0, new DateTime(2023, 2, 27, 21, 36, 53, 7, DateTimeKind.Local).AddTicks(5690), null, "Lacinia et neque varius" },
                    { 56, "cover 56", "Orci, orci interdum diam", "EpubLink56", true, 200, "PdfLink 56", 560.0, new DateTime(2023, 2, 27, 21, 36, 53, 8, DateTimeKind.Local).AddTicks(5232), null, "Sapien commodo" },
                    { 60, "cover 60", "Pulvinar, fusce habitasse diam fermentum erat ultrices, eu lacus semper in feugiat, libero", "EpubLink60", true, 300, "PdfLink 60", 600.0, new DateTime(2023, 2, 27, 21, 36, 53, 9, DateTimeKind.Local).AddTicks(2583), null, "Cursus" },
                    { 64, "cover 64", "Porttitor, ultrices, ligula, sociosqu lorem, vestibulum dui diam et lobortis auctor, bibendum per quis ultrices", "EpubLink64", true, 300, "PdfLink 64", 640.0, new DateTime(2023, 2, 27, 21, 36, 53, 9, DateTimeKind.Local).AddTicks(7544), null, "Dignissim" },
                    { 68, "cover 68", "Porta, neque non dui, quam, viverra porttitor, pharetra", "EpubLink68", true, 100, "PdfLink 68", 680.0, new DateTime(2023, 2, 27, 21, 36, 53, 10, DateTimeKind.Local).AddTicks(3861), null, "Ac placerat lorem" },
                    { 72, "cover 72", "Molestie laoreet, neque, tortor vestibulum, placerat, et, ac, pulvinar phasellus torquent sollicitudin interdum, vulputate", "EpubLink72", true, 100, "PdfLink 72", 720.0, new DateTime(2023, 2, 27, 21, 36, 53, 10, DateTimeKind.Local).AddTicks(9369), null, "Maximus" },
                    { 76, "cover 76", "Bibendum commodo, ut ligula, lorem, congue, et, non lacinia, metus porta luctus, himenaeos erat class platea quis in", "EpubLink76", true, 400, "PdfLink 76", 760.0, new DateTime(2023, 2, 27, 21, 36, 53, 11, DateTimeKind.Local).AddTicks(6425), null, "Posuere in eleifend" },
                    { 80, "cover 80", "Platea luctus", "EpubLink80", true, 200, "PdfLink 80", 800.0, new DateTime(2023, 2, 27, 21, 36, 53, 12, DateTimeKind.Local).AddTicks(1877), null, "Pellentesque diam leo" },
                    { 84, "cover 84", "Amet porta, pharetra odio, quis, quis id sem, lacinia metus vulputate laoreet, dignissim", "EpubLink84", true, 100, "PdfLink 84", 840.0, new DateTime(2023, 2, 27, 21, 36, 53, 12, DateTimeKind.Local).AddTicks(9190), null, "Dui iaculis dolor" },
                    { 88, "cover 88", "Neque, enim bibendum auctor, lectus posuere,", "EpubLink88", true, 300, "PdfLink 88", 880.0, new DateTime(2023, 2, 27, 21, 36, 53, 13, DateTimeKind.Local).AddTicks(3352), null, "Porta" },
                    { 92, "cover 92", "Eu, porta, fermentum", "EpubLink92", true, 300, "PdfLink 92", 920.0, new DateTime(2023, 2, 27, 21, 36, 53, 13, DateTimeKind.Local).AddTicks(7005), null, "Massa" },
                    { 96, "cover 96", "Dolor dolor, tempor molestie rhoncus sit sem laoreet vitae, vestibulum lobortis gravida massa, nisl", "EpubLink96", true, 200, "PdfLink 96", 960.0, new DateTime(2023, 2, 27, 21, 36, 53, 14, DateTimeKind.Local).AddTicks(615), null, "Massa praesent leo commodo" },
                    { 100, "cover 100", "Volutpat consectetur sagittis porttitor leo quis dapibus varius scelerisque amet, mi, lobortis massa habitasse cras semper congue et,", "EpubLink100", true, 200, "PdfLink 100", 1000.0, new DateTime(2023, 2, 27, 21, 36, 53, 14, DateTimeKind.Local).AddTicks(4277), null, "Quam iaculis" }
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
                    { 1, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8487), "Sale 1", 20.0, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8471) },
                    { 2, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8512), "Sale 2", 20.0, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8511) },
                    { 3, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8525), "Sale 3", 40.0, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8524) },
                    { 4, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8537), "Sale 4", 40.0, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8536) },
                    { 5, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8549), "Sale 5", 40.0, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8548) },
                    { 6, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8565), "Sale 6", 10.0, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8564) },
                    { 7, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8576), "Sale 7", 40.0, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8576) },
                    { 8, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8589), "Sale 8", 40.0, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8588) },
                    { 9, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8601), "Sale 9", 30.0, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8600) },
                    { 10, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8615), "Sale 10", 20.0, new DateTime(2023, 2, 27, 21, 36, 53, 0, DateTimeKind.Local).AddTicks(8614) }
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
                    { 8, 5 },
                    { 12, 4 },
                    { 16, 10 },
                    { 20, 5 },
                    { 24, 11 },
                    { 28, 1 },
                    { 32, 8 },
                    { 36, 7 },
                    { 40, 8 },
                    { 44, 5 },
                    { 48, 5 },
                    { 52, 4 },
                    { 56, 8 },
                    { 60, 9 },
                    { 64, 9 },
                    { 68, 1 },
                    { 72, 7 },
                    { 76, 7 },
                    { 80, 4 },
                    { 84, 10 },
                    { 88, 3 },
                    { 92, 6 },
                    { 96, 9 },
                    { 100, 5 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 1, "cover 1", "Ac pellentesque rutrum ligula aptent magna ad id, aliquam odio, tortor", "EpubLink1", true, 400, "PdfLink 1", 10.0, new DateTime(2023, 2, 27, 21, 36, 53, 1, DateTimeKind.Local).AddTicks(45), 2, "Consectetur a" },
                    { 2, "cover 2", "Quam, eu orci aliquam congue, ligula torquent amet ex hendrerit", "EpubLink2", true, 300, "PdfLink 2", 20.0, new DateTime(2023, 2, 27, 21, 36, 53, 1, DateTimeKind.Local).AddTicks(1092), 3, "Condimentum duis rhoncus tincidunt" },
                    { 3, "cover 3", "Phasellus sem, luctus curabitur", "EpubLink3", true, 300, "PdfLink 3", 30.0, new DateTime(2023, 2, 27, 21, 36, 53, 1, DateTimeKind.Local).AddTicks(2027), 1, "Nulla quis" },
                    { 5, "cover 5", "Consectetur sollicitudin gravida placerat, nunc, eget habitasse quam consequat egestas lectus vestibulum lacus euismod,", "EpubLink5", true, 400, "PdfLink 5", 50.0, new DateTime(2023, 2, 27, 21, 36, 53, 1, DateTimeKind.Local).AddTicks(3885), 3, "Consequat gravida turpis laoreet" },
                    { 6, "cover 6", "Arcu sociosqu dui eros semper", "EpubLink6", true, 100, "PdfLink 6", 60.0, new DateTime(2023, 2, 27, 21, 36, 53, 1, DateTimeKind.Local).AddTicks(4811), 1, "Congue venenatis orci" },
                    { 7, "cover 7", "Mi nostra, vitae vulputate molestie sit sed cursus tempus blandit", "EpubLink7", true, 400, "PdfLink 7", 70.0, new DateTime(2023, 2, 27, 21, 36, 53, 1, DateTimeKind.Local).AddTicks(5713), 2, "Ipsum nisi sem mi" },
                    { 9, "cover 9", "Nisi, nibh, consequat turpis vivamus finibus, lorem, elit rutrum nostra, commodo aptent amet,", "EpubLink9", true, 300, "PdfLink 9", 90.0, new DateTime(2023, 2, 27, 21, 36, 53, 1, DateTimeKind.Local).AddTicks(7535), 1, "Congue" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 10, "cover 10", "In eleifend mauris hendrerit vitae cras ac nisi mollis risus blandit", "EpubLink10", true, 200, "PdfLink 10", 100.0, new DateTime(2023, 2, 27, 21, 36, 53, 1, DateTimeKind.Local).AddTicks(8536), 2, "Euismod nulla mattis elementum" },
                    { 11, "cover 11", "Eros, pretium sagittis, ante leo, massa neque, enim, rutrum rhoncus", "EpubLink11", true, 200, "PdfLink 11", 110.0, new DateTime(2023, 2, 27, 21, 36, 53, 1, DateTimeKind.Local).AddTicks(9424), 3, "Venenatis litora" },
                    { 13, "cover 13", "Ac", "EpubLink13", true, 400, "PdfLink 13", 130.0, new DateTime(2023, 2, 27, 21, 36, 53, 2, DateTimeKind.Local).AddTicks(1276), 2, "Maximus dolor sociosqu lacinia" },
                    { 14, "cover 14", "Efficitur elementum tincidunt vestibulum nam diam mi, sit erat, tortor, semper risus orci lectus", "EpubLink14", true, 400, "PdfLink 14", 140.0, new DateTime(2023, 2, 27, 21, 36, 53, 2, DateTimeKind.Local).AddTicks(2232), 3, "Vivamus lectus ligula" },
                    { 15, "cover 15", "Nec vestibulum arcu venenatis at,", "EpubLink15", true, 200, "PdfLink 15", 150.0, new DateTime(2023, 2, 27, 21, 36, 53, 2, DateTimeKind.Local).AddTicks(3179), 1, "Lorem dolor" },
                    { 17, "cover 17", "Ligula, mattis, commodo, placerat magna", "EpubLink17", true, 300, "PdfLink 17", 170.0, new DateTime(2023, 2, 27, 21, 36, 53, 2, DateTimeKind.Local).AddTicks(5013), 3, "Tristique" },
                    { 18, "cover 18", "Adipiscing nibh, habitasse integer in hac erat, commodo congue, ad vivamus litora leo, feugiat,", "EpubLink18", true, 300, "PdfLink 18", 180.0, new DateTime(2023, 2, 27, 21, 36, 53, 2, DateTimeKind.Local).AddTicks(6204), 1, "Maecenas nibh rhoncus" },
                    { 19, "cover 19", "Dictum varius, ad turpis malesuada rutrum dignissim finibus, a, placerat, orci, luctus, lorem, ultricies fermentum tellus, venenatis blandit nulla", "EpubLink19", true, 300, "PdfLink 19", 190.0, new DateTime(2023, 2, 27, 21, 36, 53, 2, DateTimeKind.Local).AddTicks(7176), 2, "Sollicitudin urna tellus diam" },
                    { 21, "cover 21", "Ligula vestibulum, proin et, in velit scelerisque est nisi, placerat ad", "EpubLink21", true, 200, "PdfLink 21", 210.0, new DateTime(2023, 2, 27, 21, 36, 53, 2, DateTimeKind.Local).AddTicks(9331), 1, "Sapien inceptos" },
                    { 22, "cover 22", "Lorem porttitor finibus dolor, vestibulum, at et, taciti ad lectus", "EpubLink22", true, 100, "PdfLink 22", 220.0, new DateTime(2023, 2, 27, 21, 36, 53, 3, DateTimeKind.Local).AddTicks(214), 2, "Est mauris" },
                    { 23, "cover 23", "Tempor, aliquam rhoncus etiam augue interdum velit auctor, nibh,", "EpubLink23", true, 300, "PdfLink 23", 230.0, new DateTime(2023, 2, 27, 21, 36, 53, 3, DateTimeKind.Local).AddTicks(1180), 3, "Porta nullam pulvinar" },
                    { 25, "cover 25", "Sociosqu lacus dictum lobortis volutpat platea elit maecenas", "EpubLink25", true, 300, "PdfLink 25", 250.0, new DateTime(2023, 2, 27, 21, 36, 53, 3, DateTimeKind.Local).AddTicks(3113), 2, "Ullamcorper" },
                    { 26, "cover 26", "Tellus mattis molestie bibendum conubia quam, leo, finibus, eros mauris, luctus, rhoncus egestas sociosqu felis sem volutpat bibendum, dignissim", "EpubLink26", true, 200, "PdfLink 26", 260.0, new DateTime(2023, 2, 27, 21, 36, 53, 3, DateTimeKind.Local).AddTicks(4037), 3, "Quam" },
                    { 27, "cover 27", "Amet metus odio,", "EpubLink27", true, 300, "PdfLink 27", 270.0, new DateTime(2023, 2, 27, 21, 36, 53, 3, DateTimeKind.Local).AddTicks(4956), 1, "Quam leo fusce" },
                    { 29, "cover 29", "Posuere, volutpat, tempus nam hac arcu, ligula amet sed, maximus lobortis", "EpubLink29", true, 100, "PdfLink 29", 290.0, new DateTime(2023, 2, 27, 21, 36, 53, 3, DateTimeKind.Local).AddTicks(6899), 3, "Eros" },
                    { 30, "cover 30", "Sed, sociosqu hendrerit et at, eleifend purus curabitur quisque pharetra tellus condimentum sem bibendum, eu, velit volutpat,", "EpubLink30", true, 200, "PdfLink 30", 300.0, new DateTime(2023, 2, 27, 21, 36, 53, 3, DateTimeKind.Local).AddTicks(7947), 1, "Non fermentum" },
                    { 31, "cover 31", "Diam posuere feugiat luctus cursus, suspendisse hendrerit dui, himenaeos gravida platea tortor, nam luctus, maecenas consequat facilisis congue dignissim", "EpubLink31", true, 300, "PdfLink 31", 310.0, new DateTime(2023, 2, 27, 21, 36, 53, 3, DateTimeKind.Local).AddTicks(9097), 2, "Urna nibh quam" },
                    { 33, "cover 33", "Dictumst aenean hendrerit duis arcu elit odio nunc, volutpat, nisi fringilla, aliquet mi, fames lorem", "EpubLink33", true, 400, "PdfLink 33", 330.0, new DateTime(2023, 2, 27, 21, 36, 53, 4, DateTimeKind.Local).AddTicks(1197), 1, "Eu" },
                    { 34, "cover 34", "Commodo, proin laoreet magna tellus, eros ad sodales congue tincidunt", "EpubLink34", true, 200, "PdfLink 34", 340.0, new DateTime(2023, 2, 27, 21, 36, 53, 4, DateTimeKind.Local).AddTicks(2684), 2, "Neque" },
                    { 35, "cover 35", "Luctus maecenas tristique inceptos euismod in, fringilla mollis", "EpubLink35", true, 200, "PdfLink 35", 350.0, new DateTime(2023, 2, 27, 21, 36, 53, 4, DateTimeKind.Local).AddTicks(4483), 3, "Tortor mi" },
                    { 37, "cover 37", "Convallis iaculis blandit pellentesque fames luctus, vitae pretium lobortis torquent lacinia habitasse fringilla nam semper quam, mi,", "EpubLink37", true, 200, "PdfLink 37", 370.0, new DateTime(2023, 2, 27, 21, 36, 53, 5, DateTimeKind.Local).AddTicks(497), 2, "Elementum" },
                    { 38, "cover 38", "Lacus sollicitudin blandit", "EpubLink38", true, 300, "PdfLink 38", 380.0, new DateTime(2023, 2, 27, 21, 36, 53, 5, DateTimeKind.Local).AddTicks(1779), 3, "Consectetur" },
                    { 39, "cover 39", "Ex faucibus conubia mattis, eget amet viverra turpis at, vel,", "EpubLink39", true, 200, "PdfLink 39", 390.0, new DateTime(2023, 2, 27, 21, 36, 53, 5, DateTimeKind.Local).AddTicks(2689), 1, "Nulla dictumst" },
                    { 41, "cover 41", "Varius quis curabitur porta placerat, accumsan semper urna diam amet purus varius, at pretium ornare nisi, elit mollis", "EpubLink41", true, 300, "PdfLink 41", 410.0, new DateTime(2023, 2, 27, 21, 36, 53, 5, DateTimeKind.Local).AddTicks(5047), 3, "Hendrerit eros ut" },
                    { 42, "cover 42", "Enim, auctor diam condimentum posuere", "EpubLink42", true, 300, "PdfLink 42", 420.0, new DateTime(2023, 2, 27, 21, 36, 53, 5, DateTimeKind.Local).AddTicks(6981), 1, "Nunc vitae augue ultrices" },
                    { 43, "cover 43", "Tellus sagittis ante massa, donec pharetra nec eleifend, id ex,", "EpubLink43", true, 300, "PdfLink 43", 430.0, new DateTime(2023, 2, 27, 21, 36, 53, 5, DateTimeKind.Local).AddTicks(9070), 2, "Aptent justo interdum nibh" },
                    { 45, "cover 45", "Quisque ac, risus hac per tellus, ornare odio vitae, tristique primis feugiat porta venenatis eu ipsum mi", "EpubLink45", true, 100, "PdfLink 45", 450.0, new DateTime(2023, 2, 27, 21, 36, 53, 6, DateTimeKind.Local).AddTicks(2708), 1, "Fringilla" },
                    { 46, "cover 46", "Platea vel leo, sem dignissim maximus vehicula pretium congue sagittis, vestibulum", "EpubLink46", true, 300, "PdfLink 46", 460.0, new DateTime(2023, 2, 27, 21, 36, 53, 6, DateTimeKind.Local).AddTicks(4012), 2, "Finibus convallis" },
                    { 47, "cover 47", "Arcu, quisque viverra enim rhoncus, hendrerit", "EpubLink47", true, 400, "PdfLink 47", 470.0, new DateTime(2023, 2, 27, 21, 36, 53, 6, DateTimeKind.Local).AddTicks(5032), 3, "Consectetur urna" },
                    { 49, "cover 49", "Pretium sociosqu euismod nibh, magna scelerisque", "EpubLink49", true, 400, "PdfLink 49", 490.0, new DateTime(2023, 2, 27, 21, 36, 53, 6, DateTimeKind.Local).AddTicks(8895), 2, "Pharetra" },
                    { 50, "cover 50", "Sem nisi, cras nec blandit lectus, vel", "EpubLink50", true, 400, "PdfLink 50", 500.0, new DateTime(2023, 2, 27, 21, 36, 53, 7, DateTimeKind.Local).AddTicks(1266), 3, "In sodales aliquam feugiat" },
                    { 51, "cover 51", "Eget neque, facilisis suspendisse ultrices libero commodo sed, porttitor molestie velit aenean", "EpubLink51", true, 400, "PdfLink 51", 510.0, new DateTime(2023, 2, 27, 21, 36, 53, 7, DateTimeKind.Local).AddTicks(3063), 1, "Est sollicitudin litora habitasse" },
                    { 53, "cover 53", "Elementum iaculis molestie pretium felis sem,", "EpubLink53", true, 200, "PdfLink 53", 530.0, new DateTime(2023, 2, 27, 21, 36, 53, 7, DateTimeKind.Local).AddTicks(9433), 3, "Class at blandit congue" },
                    { 54, "cover 54", "Orci finibus, interdum, blandit, eros semper turpis ultrices, mi ut purus sodales quam maecenas dolor,", "EpubLink54", true, 300, "PdfLink 54", 540.0, new DateTime(2023, 2, 27, 21, 36, 53, 8, DateTimeKind.Local).AddTicks(1994), 1, "Pulvinar" },
                    { 55, "cover 55", "Platea massa at, auctor litora mattis, amet id vehicula tempor", "EpubLink55", true, 200, "PdfLink 55", 550.0, new DateTime(2023, 2, 27, 21, 36, 53, 8, DateTimeKind.Local).AddTicks(3626), 2, "Id" },
                    { 57, "cover 57", "Ullamcorper tempus quam eros etiam ac, ultrices congue, rhoncus per", "EpubLink57", true, 200, "PdfLink 57", 570.0, new DateTime(2023, 2, 27, 21, 36, 53, 8, DateTimeKind.Local).AddTicks(7220), 1, "Fusce aliquet" },
                    { 58, "cover 58", "Commodo, orci", "EpubLink58", true, 200, "PdfLink 58", 580.0, new DateTime(2023, 2, 27, 21, 36, 53, 8, DateTimeKind.Local).AddTicks(9157), 2, "Nec convallis suscipit hac" },
                    { 59, "cover 59", "Orci, congue at pellentesque a, ac praesent diam eu, vitae integer erat, dictum hendrerit", "EpubLink59", true, 400, "PdfLink 59", 590.0, new DateTime(2023, 2, 27, 21, 36, 53, 9, DateTimeKind.Local).AddTicks(1331), 3, "Gravida pharetra tristique" },
                    { 61, "cover 61", "Orci lectus, ligula,", "EpubLink61", true, 100, "PdfLink 61", 610.0, new DateTime(2023, 2, 27, 21, 36, 53, 9, DateTimeKind.Local).AddTicks(3825), 2, "Nullam faucibus scelerisque" },
                    { 62, "cover 62", "Sapien fringilla, laoreet a, integer efficitur phasellus venenatis porttitor non,", "EpubLink62", true, 400, "PdfLink 62", 620.0, new DateTime(2023, 2, 27, 21, 36, 53, 9, DateTimeKind.Local).AddTicks(5178), 3, "Eleifend rhoncus vulputate leo" },
                    { 63, "cover 63", "Arcu, pulvinar amet, felis mi ac, mattis fermentum dui lacinia, tellus, ligula, semper leo dapibus tempor", "EpubLink63", true, 300, "PdfLink 63", 630.0, new DateTime(2023, 2, 27, 21, 36, 53, 9, DateTimeKind.Local).AddTicks(6507), 1, "Velit tincidunt" },
                    { 65, "cover 65", "Eros pellentesque donec dignissim porta, mattis, lorem adipiscing orci libero odio posuere, blandit dolor ante morbi", "EpubLink65", true, 400, "PdfLink 65", 650.0, new DateTime(2023, 2, 27, 21, 36, 53, 9, DateTimeKind.Local).AddTicks(9121), 3, "Hendrerit" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 66, "cover 66", "Massa cursus non ullamcorper interdum, elementum tristique viverra amet mattis mauris, lorem, nibh, mattis, primis nulla,", "EpubLink66", true, 300, "PdfLink 66", 660.0, new DateTime(2023, 2, 27, 21, 36, 53, 10, DateTimeKind.Local).AddTicks(368), 1, "Auctor urna nullam" },
                    { 67, "cover 67", "Dui, nisl tortor porta, aptent ipsum vivamus augue suspendisse commodo, class", "EpubLink67", true, 100, "PdfLink 67", 670.0, new DateTime(2023, 2, 27, 21, 36, 53, 10, DateTimeKind.Local).AddTicks(1727), 2, "Turpis" },
                    { 69, "cover 69", "Venenatis dui quis nulla diam euismod lacinia, et mattis volutpat fermentum dolor, porta, mi, eu, ac, efficitur nulla, blandit,", "EpubLink69", true, 300, "PdfLink 69", 690.0, new DateTime(2023, 2, 27, 21, 36, 53, 10, DateTimeKind.Local).AddTicks(5468), 1, "Amet nisl consequat felis" },
                    { 70, "cover 70", "Dapibus dictumst odio ad ligula, per a, ligula lorem quam erat, massa volutpat quisque urna ex tempor, euismod,", "EpubLink70", true, 100, "PdfLink 70", 700.0, new DateTime(2023, 2, 27, 21, 36, 53, 10, DateTimeKind.Local).AddTicks(6635), 2, "Euismod sem varius congue" },
                    { 71, "cover 71", "A mauris pretium urna erat, euismod, purus justo vehicula feugiat efficitur et, lorem finibus,", "EpubLink71", true, 400, "PdfLink 71", 710.0, new DateTime(2023, 2, 27, 21, 36, 53, 10, DateTimeKind.Local).AddTicks(7879), 3, "Et mauris id dolor" },
                    { 73, "cover 73", "Nunc, sem, a condimentum pellentesque vestibulum vestibulum, lacus blandit, suspendisse cursus non, id vehicula etiam at", "EpubLink73", true, 100, "PdfLink 73", 730.0, new DateTime(2023, 2, 27, 21, 36, 53, 11, DateTimeKind.Local).AddTicks(1193), 2, "Elit" },
                    { 74, "cover 74", "Dictumst accumsan augue nunc, pellentesque dapibus tortor, commodo nisl blandit lectus, vivamus sed, nunc cursus", "EpubLink74", true, 200, "PdfLink 74", 740.0, new DateTime(2023, 2, 27, 21, 36, 53, 11, DateTimeKind.Local).AddTicks(3282), 3, "Finibus blandit cursus facilisis" },
                    { 75, "cover 75", "Pretium nisl diam ipsum praesent eleifend nostra, orci risus per posuere mattis dignissim", "EpubLink75", true, 100, "PdfLink 75", 750.0, new DateTime(2023, 2, 27, 21, 36, 53, 11, DateTimeKind.Local).AddTicks(5314), 1, "Urna elementum" },
                    { 77, "cover 77", "Euismod ultrices congue quam, augue id neque, nibh", "EpubLink77", true, 300, "PdfLink 77", 770.0, new DateTime(2023, 2, 27, 21, 36, 53, 11, DateTimeKind.Local).AddTicks(7404), 3, "Tristique eleifend dui interdum" },
                    { 78, "cover 78", "Ante iaculis leo sem, mi, aenean augue lectus dignissim mattis nec adipiscing", "EpubLink78", true, 100, "PdfLink 78", 780.0, new DateTime(2023, 2, 27, 21, 36, 53, 11, DateTimeKind.Local).AddTicks(9054), 1, "Erat finibus vestibulum hac" },
                    { 79, "cover 79", "Ac", "EpubLink79", true, 400, "PdfLink 79", 790.0, new DateTime(2023, 2, 27, 21, 36, 53, 12, DateTimeKind.Local).AddTicks(451), 2, "Metus class" },
                    { 81, "cover 81", "Sagittis, interdum diam fames tempor, quis, dolor, erat, maecenas malesuada", "EpubLink81", true, 400, "PdfLink 81", 810.0, new DateTime(2023, 2, 27, 21, 36, 53, 12, DateTimeKind.Local).AddTicks(3553), 1, "Litora tristique" },
                    { 82, "cover 82", "Ac mi, tellus, mattis, justo duis lacinia in, proin malesuada nibh torquent nec urna vel, dui ligula leo elit,", "EpubLink82", true, 300, "PdfLink 82", 820.0, new DateTime(2023, 2, 27, 21, 36, 53, 12, DateTimeKind.Local).AddTicks(5742), 2, "Dolor fermentum convallis" },
                    { 83, "cover 83", "Morbi est mauris hac mi, nisi rhoncus congue ac,", "EpubLink83", true, 200, "PdfLink 83", 830.0, new DateTime(2023, 2, 27, 21, 36, 53, 12, DateTimeKind.Local).AddTicks(7540), 3, "Auctor" },
                    { 85, "cover 85", "Morbi convallis elit eu, laoreet libero interdum, mi,", "EpubLink85", true, 200, "PdfLink 85", 850.0, new DateTime(2023, 2, 27, 21, 36, 53, 13, DateTimeKind.Local).AddTicks(396), 2, "Leo cras risus finibus" },
                    { 86, "cover 86", "Laoreet odio non augue enim sit nunc, facilisis suspendisse eu, at, lorem, adipiscing", "EpubLink86", true, 400, "PdfLink 86", 860.0, new DateTime(2023, 2, 27, 21, 36, 53, 13, DateTimeKind.Local).AddTicks(1587), 3, "Bibendum vel" },
                    { 87, "cover 87", "Pulvinar, posuere fermentum urna varius, consectetur vulputate porta, sed mollis tellus tincidunt condimentum volutpat, maximus", "EpubLink87", true, 200, "PdfLink 87", 870.0, new DateTime(2023, 2, 27, 21, 36, 53, 13, DateTimeKind.Local).AddTicks(2519), 1, "Id ut vel" },
                    { 89, "cover 89", "Sagittis orci, arcu aliquet ante, non, nostra, viverra taciti tempus suspendisse mauris aenean mattis,", "EpubLink89", true, 400, "PdfLink 89", 890.0, new DateTime(2023, 2, 27, 21, 36, 53, 13, DateTimeKind.Local).AddTicks(4291), 3, "Enim tempus eu" },
                    { 90, "cover 90", "Commodo nostra, ligula", "EpubLink90", true, 400, "PdfLink 90", 900.0, new DateTime(2023, 2, 27, 21, 36, 53, 13, DateTimeKind.Local).AddTicks(5260), 1, "Interdum sapien arcu blandit" },
                    { 91, "cover 91", "Leo, neque ac, augue ligula, conubia praesent orci etiam enim inceptos", "EpubLink91", true, 200, "PdfLink 91", 910.0, new DateTime(2023, 2, 27, 21, 36, 53, 13, DateTimeKind.Local).AddTicks(6137), 2, "Arcu fringilla maecenas" },
                    { 93, "cover 93", "Sagittis tincidunt sed, lacinia elit orci, at adipiscing lobortis euismod, vivamus morbi", "EpubLink93", true, 200, "PdfLink 93", 930.0, new DateTime(2023, 2, 27, 21, 36, 53, 13, DateTimeKind.Local).AddTicks(7944), 1, "Tempor dictumst a congue" },
                    { 94, "cover 94", "Aenean congue", "EpubLink94", true, 300, "PdfLink 94", 940.0, new DateTime(2023, 2, 27, 21, 36, 53, 13, DateTimeKind.Local).AddTicks(8881), 2, "Volutpat mi augue" },
                    { 95, "cover 95", "Dapibus egestas vulputate sed, neque, molestie eget non euismod porttitor", "EpubLink95", true, 100, "PdfLink 95", 950.0, new DateTime(2023, 2, 27, 21, 36, 53, 13, DateTimeKind.Local).AddTicks(9755), 3, "Vulputate" },
                    { 97, "cover 97", "Sit ex, fusce lacinia, vel condimentum posuere, erat risus dui metus luctus,", "EpubLink97", true, 200, "PdfLink 97", 970.0, new DateTime(2023, 2, 27, 21, 36, 53, 14, DateTimeKind.Local).AddTicks(1628), 2, "Elementum litora" },
                    { 98, "cover 98", "Rhoncus vel, eros lectus vitae sem ornare litora elit ultrices, feugiat", "EpubLink98", true, 100, "PdfLink 98", 980.0, new DateTime(2023, 2, 27, 21, 36, 53, 14, DateTimeKind.Local).AddTicks(2554), 3, "At ac orci" },
                    { 99, "cover 99", "Commodo, bibendum blandit amet", "EpubLink99", true, 100, "PdfLink 99", 990.0, new DateTime(2023, 2, 27, 21, 36, 53, 14, DateTimeKind.Local).AddTicks(3396), 1, "Eget et" }
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
                    { 1, 6 },
                    { 2, 7 },
                    { 3, 5 },
                    { 5, 5 },
                    { 6, 4 },
                    { 7, 12 },
                    { 9, 8 },
                    { 10, 6 },
                    { 11, 4 },
                    { 13, 2 },
                    { 14, 10 },
                    { 15, 9 },
                    { 17, 10 },
                    { 18, 9 },
                    { 19, 12 },
                    { 21, 5 },
                    { 22, 4 },
                    { 23, 5 },
                    { 25, 11 },
                    { 26, 7 },
                    { 27, 7 },
                    { 29, 7 },
                    { 30, 6 },
                    { 31, 9 },
                    { 33, 4 },
                    { 34, 5 },
                    { 35, 2 },
                    { 37, 8 },
                    { 38, 10 },
                    { 39, 6 },
                    { 41, 12 },
                    { 42, 2 },
                    { 43, 2 },
                    { 45, 9 },
                    { 46, 5 },
                    { 47, 10 },
                    { 49, 10 },
                    { 50, 8 },
                    { 51, 5 },
                    { 53, 10 },
                    { 54, 10 },
                    { 55, 8 }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 57, 2 },
                    { 58, 10 },
                    { 59, 8 },
                    { 61, 8 },
                    { 62, 9 },
                    { 63, 12 },
                    { 65, 6 },
                    { 66, 4 },
                    { 67, 5 },
                    { 69, 1 },
                    { 70, 2 },
                    { 71, 2 },
                    { 73, 7 },
                    { 74, 7 },
                    { 75, 8 },
                    { 77, 7 },
                    { 78, 12 },
                    { 79, 12 },
                    { 81, 9 },
                    { 82, 1 },
                    { 83, 6 },
                    { 85, 9 },
                    { 86, 8 },
                    { 87, 11 },
                    { 89, 3 },
                    { 90, 6 },
                    { 91, 11 },
                    { 93, 3 },
                    { 94, 4 },
                    { 95, 7 },
                    { 97, 1 },
                    { 98, 9 },
                    { 99, 10 }
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
