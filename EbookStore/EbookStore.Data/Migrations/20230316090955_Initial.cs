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
                    { new Guid("423e533c-d43d-4fd9-9676-e31af724522a"), "f862637e-6d78-4fca-bc1e-ce30d482d181", "Administrator role", "Admin", "admin" },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), "67f458ef-2122-4e91-a837-6fc4fa4b4696", "User role", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"), 0, "f1f35b40-0365-440c-936e-9833c038f72d", "user1@gmail.com", true, "Ten 1", true, "Ho 1", false, null, "user1@gmail.com", "user1", "AQAAAAEAACcQAAAAEIiAeS64GTSHWhxkKbU40Y3TpenFQgbtsj4LMpJXYP+THUmxYecxLrInOEzIH1NIGg==", "123456781", false, "", false, "user1" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"), 0, "2a0d5cd8-03ad-4645-afa6-f9a0fabcac6a", "user2@gmail.com", true, "Ten 2", true, "Ho 2", false, null, "user2@gmail.com", "user2", "AQAAAAEAACcQAAAAEK3JuVZzv9aXygNrHo94s5k+s/6D/12EflzAEOkWGBCLTQPpM0axTO7pdb/OZg4uAQ==", "123456782", false, "", false, "user2" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), 0, "d029f936-60c5-4b2b-8e74-9786d0306e92", "user3@gmail.com", true, "Ten 3", true, "Ho 3", false, null, "user3@gmail.com", "user3", "AQAAAAEAACcQAAAAEGwsBov+UH9fQgReAz/4JUrKBN5EbPEtHamqj0HLBTobpU5U4TJGNVa7bdV72gfZxA==", "123456783", false, "", false, "user3" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), 0, "0eb13420-8ca3-4623-b174-1a1753d5a957", "user4@gmail.com", true, "Ten 4", true, "Ho 4", false, null, "user4@gmail.com", "user4", "AQAAAAEAACcQAAAAEF685KzX3Rq6Kx60GpibFIOEXccsFg6HNLiip3vPGiPtXhBXOolqWgJnx6jJms+2TA==", "123456784", false, "", false, "user4" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), 0, "585c878b-982c-4103-b9c1-aed4ea6f8c46", "user5@gmail.com", true, "Ten 5", true, "Ho 5", false, null, "user5@gmail.com", "user5", "AQAAAAEAACcQAAAAEKBXMUHafvJJ4qYL5P0l2oTJvBE/YDE1Lw9W9mgKxLNcXfL9Sm2y8r46Y3jHCMq7/A==", "123456785", false, "", false, "user5" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), 0, "c97273d0-ff1d-4f19-b5f1-cf10b938488d", "user6@gmail.com", true, "Ten 6", true, "Ho 6", false, null, "user6@gmail.com", "user6", "AQAAAAEAACcQAAAAEHP5AWXZucdxs1z+YOp+9D3QCSVO5PvIGNCQ7rhJ/K836N2rGipKQB/OXKzlKdTerQ==", "123456786", false, "", false, "user6" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), 0, "28d62360-5292-4ba4-a7a4-2a139f048db8", "user7@gmail.com", true, "Ten 7", true, "Ho 7", false, null, "user7@gmail.com", "user7", "AQAAAAEAACcQAAAAECgccFHpjW2K7MR9/VsBKv2330EJ+kmWqFTajCwG3T4Rt1wcgZkSCmLW52+mbf5buQ==", "123456787", false, "", false, "user7" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), 0, "274830f3-79c1-4e20-9c27-0aa23a780519", "user8@gmail.com", true, "Ten 8", true, "Ho 8", false, null, "user8@gmail.com", "user8", "AQAAAAEAACcQAAAAEC23Oay8oHwH8fIuqcouUnd/meT4BeFjSXC1H23PU0Cp5WKXr6aPGXr4Wk1cey/RwQ==", "123456788", false, "", false, "user8" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), 0, "9a4b277e-f3ab-401d-99fb-9bd2b688eb30", "user9@gmail.com", true, "Ten 9", true, "Ho 9", false, null, "user9@gmail.com", "user9", "AQAAAAEAACcQAAAAEMejFnewSfvUBF8AMdp+znTyaBmm1FvdVXds1rDV22fapn6INNKLHsQfQlgXPxZymQ==", "123456789", false, "", false, "user9" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), 0, "ed0bc46f-8f0a-4531-86d8-87b9383dfab7", "user10@gmail.com", true, "Ten 10", true, "Ho 10", false, null, "user10@gmail.com", "user10", "AQAAAAEAACcQAAAAEE/0H+krfq/saFxlZkPiuvCXAWMjKRpa8zbNlx7qnbU6VB+DBApXWxMcjR40uYDKQg==", "1234567810", false, "", false, "user10" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 4, "https://picsum.photos/seed/4/500/500", "Ut at, nulla himenaeos pretium efficitur orci justo sapien orci, eleifend, nec vestibulum, dignissim", true, 300, "Book.pdf", 40.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(5480), null, "Finibus laoreet odio imperdiet" },
                    { 8, "https://picsum.photos/seed/8/500/500", "Ante, velit amet, sem, ut morbi nibh metus conubia dolor dapibus", true, 300, "Book.pdf", 80.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(9330), null, "Rhoncus eleifend dolor mi" },
                    { 12, "https://picsum.photos/seed/12/500/500", "Nibh, non, ipsum diam mattis, mauris hac nulla, porttitor suspendisse nullam dui, ligula, nostra, odio, laoreet, phasellus class nec", true, 200, "Book.pdf", 120.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(1760), null, "Arcu ipsum" },
                    { 16, "https://picsum.photos/seed/16/500/500", "Per sollicitudin blandit conubia arcu, cursus turpis dapibus est porta, euismod, aptent a, pharetra", true, 300, "Book.pdf", 160.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(4042), null, "Libero tristique leo" },
                    { 20, "https://picsum.photos/seed/20/500/500", "Auctor turpis gravida bibendum, imperdiet varius velit dui morbi vulputate posuere, molestie commodo,", true, 100, "Book.pdf", 200.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(6316), null, "Ac euismod lacus" },
                    { 24, "https://picsum.photos/seed/24/500/500", "Eu id odio faucibus euismod quam, dui amet cursus magna, quis ex, pulvinar eros, non,", true, 200, "Book.pdf", 240.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(8667), null, "Orci" },
                    { 28, "https://picsum.photos/seed/28/500/500", "Euismod dolor ultrices eleifend varius, fringilla commodo tortor, ante dignissim duis turpis", true, 400, "Book.pdf", 280.0, new DateTime(2023, 3, 16, 16, 9, 54, 729, DateTimeKind.Local).AddTicks(819), null, "Metus" },
                    { 32, "https://picsum.photos/seed/32/500/500", "Morbi nibh accumsan euismod, porttitor consectetur vel eu, nulla, eleifend venenatis faucibus magna leo a praesent in", true, 100, "Book.pdf", 320.0, new DateTime(2023, 3, 16, 16, 9, 54, 729, DateTimeKind.Local).AddTicks(3171), null, "Lectus fringilla dignissim" },
                    { 36, "https://picsum.photos/seed/36/500/500", "Magna, ullamcorper eget urna metus id blandit felis tortor ultrices proin efficitur ex, vitae, risus dolor conubia odio", true, 400, "Book.pdf", 360.0, new DateTime(2023, 3, 16, 16, 9, 54, 729, DateTimeKind.Local).AddTicks(6872), null, "Faucibus elit ultrices eu" },
                    { 40, "https://picsum.photos/seed/40/500/500", "Lacinia eleifend, fringilla metus litora cursus nisi, ligula pulvinar, enim ac,", true, 100, "Book.pdf", 400.0, new DateTime(2023, 3, 16, 16, 9, 54, 729, DateTimeKind.Local).AddTicks(9681), null, "Neque pellentesque" },
                    { 44, "https://picsum.photos/seed/44/500/500", "In, dui, interdum", true, 400, "Book.pdf", 440.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(2344), null, "Pellentesque torquent" },
                    { 48, "https://picsum.photos/seed/48/500/500", "Lorem luctus, augue elit, rhoncus, ante, nec,", true, 400, "Book.pdf", 480.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(5038), null, "Ultrices lacinia amet" },
                    { 52, "https://picsum.photos/seed/52/500/500", "Efficitur lacinia, nisi, lectus tortor suscipit", true, 200, "Book.pdf", 520.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(7749), null, "Ac" },
                    { 56, "https://picsum.photos/seed/56/500/500", "Non, ornare congue, elementum dictum donec velit dignissim arcu, fames", true, 300, "Book.pdf", 560.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(376), null, "Libero porta" },
                    { 60, "https://picsum.photos/seed/60/500/500", "Platea eget eu, faucibus blandit feugiat nostra, eleifend, non nunc maecenas lacinia, dictumst donec euismod, ante,", true, 100, "Book.pdf", 600.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(2882), null, "Metus lectus cursus" },
                    { 64, "https://picsum.photos/seed/64/500/500", "Pellentesque egestas urna in gravida elit, vestibulum varius duis viverra integer volutpat, ultricies commodo", true, 200, "Book.pdf", 640.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(5485), null, "Aptent tellus" },
                    { 68, "https://picsum.photos/seed/68/500/500", "Magna, placerat tempus tellus, pretium ultrices, magna lacus mi, condimentum commodo", true, 300, "Book.pdf", 680.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(8069), null, "Pellentesque per nunc mi" },
                    { 72, "https://picsum.photos/seed/72/500/500", "Pretium vestibulum, lorem per non imperdiet odio vel, rhoncus lacinia taciti justo placerat, iaculis eros", true, 100, "Book.pdf", 720.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(832), null, "Orci congue" },
                    { 76, "https://picsum.photos/seed/76/500/500", "Luctus, congue, tellus, felis interdum,", true, 100, "Book.pdf", 760.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(3450), null, "Nam arcu neque vitae" },
                    { 80, "https://picsum.photos/seed/80/500/500", "Cursus, molestie aptent", true, 200, "Book.pdf", 800.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(6278), null, "Nisi venenatis erat eleifend" },
                    { 84, "https://picsum.photos/seed/84/500/500", "Tincidunt massa, dolor faucibus nec curabitur per leo leo, diam luctus praesent ultricies", true, 400, "Book.pdf", 840.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(9014), null, "Tempor tellus at" },
                    { 88, "https://picsum.photos/seed/88/500/500", "Iaculis platea dictum adipiscing", true, 200, "Book.pdf", 880.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(1719), null, "Adipiscing non luctus" },
                    { 92, "https://picsum.photos/seed/92/500/500", "Lobortis eros, urna", true, 200, "Book.pdf", 920.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(4186), null, "Lorem" },
                    { 96, "https://picsum.photos/seed/96/500/500", "Nam torquent proin auctor, eros, tellus, vulputate dui, aptent amet, at, vel, tincidunt nisi", true, 400, "Book.pdf", 960.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(6692), null, "Ex" },
                    { 100, "https://picsum.photos/seed/100/500/500", "Tempor pellentesque praesent lectus, platea class vehicula ex, euismod, molestie torquent", true, 400, "Book.pdf", 1000.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(9088), null, "Felis auctor lectus" }
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
                    { 1, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(7661), "Massa", 20.0, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(7653) },
                    { 2, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(8012), "At nullam", 40.0, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(8011) },
                    { 3, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(8310), "Dapibus enim turpis sagittis", 30.0, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(8309) },
                    { 4, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(8626), "Posuere tempus elementum", 10.0, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(8625) },
                    { 5, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(8907), "Mattis", 30.0, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(8907) },
                    { 6, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(9168), "Varius nibh metus", 10.0, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(9167) },
                    { 7, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(9447), "Varius nulla", 30.0, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(9446) },
                    { 8, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(9716), "Aptent enim ultricies", 40.0, new DateTime(2023, 3, 16, 16, 9, 54, 726, DateTimeKind.Local).AddTicks(9716) },
                    { 9, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(30), "Neque blandit neque", 10.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(30) },
                    { 10, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(332), "Congue tristique", 10.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(332) },
                    { 11, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(591), "Nulla class lacinia", 10.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(591) },
                    { 12, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(865), "Etiam", 20.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(865) },
                    { 13, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(1162), "Orci fringilla at egestas", 30.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(1161) },
                    { 14, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(1482), "Non maecenas", 40.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(1481) },
                    { 15, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(1813), "Maecenas bibendum interdum", 10.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(1813) },
                    { 16, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(2074), "Placerat", 10.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(2073) },
                    { 17, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(2335), "Pellentesque", 40.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(2334) },
                    { 18, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(2610), "Lacinia", 40.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(2609) },
                    { 19, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(2909), "Integer fusce", 10.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(2908) },
                    { 20, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(3166), "Elementum", 40.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(3166) }
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
                    { 8, 2 },
                    { 12, 8 },
                    { 16, 12 },
                    { 20, 4 },
                    { 24, 9 },
                    { 28, 9 },
                    { 32, 1 },
                    { 36, 10 },
                    { 40, 9 },
                    { 44, 7 },
                    { 48, 7 },
                    { 52, 11 },
                    { 56, 9 },
                    { 60, 1 },
                    { 64, 10 },
                    { 68, 3 },
                    { 72, 8 },
                    { 76, 7 },
                    { 80, 3 },
                    { 84, 3 },
                    { 88, 8 },
                    { 92, 5 },
                    { 96, 4 },
                    { 100, 5 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 1, "https://picsum.photos/seed/1/500/500", "Odio blandit, bibendum, nisi, condimentum", true, 100, "Book.pdf", 10.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(3768), 2, "Sed nisi" },
                    { 2, "https://picsum.photos/seed/2/500/500", "Non ad tincidunt volutpat dignissim platea iaculis nisi", true, 300, "Book.pdf", 20.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(4362), 3, "Nibh bibendum faucibus" },
                    { 3, "https://picsum.photos/seed/3/500/500", "Diam neque erat, lorem, semper etiam blandit nam eros id, vivamus tempor, primis nostra, sed, eget lorem finibus aliquet", true, 100, "Book.pdf", 30.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(4917), 1, "Mattis congue" },
                    { 5, "https://picsum.photos/seed/5/500/500", "Varius consequat nostra, felis ac sagittis, semper finibus, fusce dapibus habitasse scelerisque commodo, neque commodo eros,", true, 300, "Book.pdf", 50.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(6446), 3, "Urna mi" },
                    { 6, "https://picsum.photos/seed/6/500/500", "Ad aenean turpis orci leo, conubia vitae, euismod, euismod condimentum ac eleifend, lacus", true, 100, "Book.pdf", 60.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(7680), 1, "Nunc facilisis" },
                    { 7, "https://picsum.photos/seed/7/500/500", "Aliquet lectus, et neque, tellus ligula,", true, 400, "Book.pdf", 70.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(8560), 2, "Tellus imperdiet leo vestibulum" },
                    { 9, "https://picsum.photos/seed/9/500/500", "Ante,", true, 300, "Book.pdf", 90.0, new DateTime(2023, 3, 16, 16, 9, 54, 727, DateTimeKind.Local).AddTicks(9983), 1, "At" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 10, "https://picsum.photos/seed/10/500/500", "Diam metus sit placerat, eros, consequat", true, 100, "Book.pdf", 100.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(608), 2, "Dui in" },
                    { 11, "https://picsum.photos/seed/11/500/500", "At elit tortor, litora pharetra massa, dui mollis sem ligula lorem placerat ex ex, congue proin ipsum pulvinar, lacinia,", true, 300, "Book.pdf", 110.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(1164), 3, "Massa" },
                    { 13, "https://picsum.photos/seed/13/500/500", "Arcu morbi ligula vitae, vestibulum, etiam neque, eu nibh egestas", true, 100, "Book.pdf", 130.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(2332), 2, "Vitae sit" },
                    { 14, "https://picsum.photos/seed/14/500/500", "Sociosqu lectus, finibus, convallis tempor, consequat tempus varius scelerisque facilisis orci porta, cras", true, 400, "Book.pdf", 140.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(2884), 3, "Curabitur" },
                    { 15, "https://picsum.photos/seed/15/500/500", "Laoreet, enim, tincidunt velit placerat interdum, quis, commodo dui, mi, semper rutrum sit in, porttitor, etiam himenaeos quam, sem,", true, 400, "Book.pdf", 150.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(3475), 1, "Risus mollis est blandit" },
                    { 17, "https://picsum.photos/seed/17/500/500", "Praesent at vitae, tellus, laoreet, non semper nunc, eleifend, amet, curabitur felis dolor mauris porttitor, ultricies pellentesque", true, 400, "Book.pdf", 170.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(4614), 3, "Nullam posuere leo etiam" },
                    { 18, "https://picsum.photos/seed/18/500/500", "Euismod magna nunc sodales massa, ultrices pulvinar sit nisi nulla, ipsum nullam blandit,", true, 300, "Book.pdf", 180.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(5183), 1, "Rutrum" },
                    { 19, "https://picsum.photos/seed/19/500/500", "Vehicula ultrices ad fames eleifend, duis donec ante, pretium in, dui malesuada lacinia", true, 200, "Book.pdf", 190.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(5747), 2, "Accumsan fringilla pulvinar facilisis" },
                    { 21, "https://picsum.photos/seed/21/500/500", "Et,", true, 300, "Book.pdf", 210.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(6967), 1, "Quam erat" },
                    { 22, "https://picsum.photos/seed/22/500/500", "Nec, luctus ac, metus lorem, auctor, finibus, urna, tincidunt sit id nullam vel nibh accumsan posuere, lacus", true, 200, "Book.pdf", 220.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(7590), 2, "Praesent posuere accumsan massa" },
                    { 23, "https://picsum.photos/seed/23/500/500", "Posuere nec, tincidunt pharetra mattis, cras", true, 100, "Book.pdf", 230.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(8151), 3, "Erat a urna" },
                    { 25, "https://picsum.photos/seed/25/500/500", "Fringilla ex class pellentesque dictumst", true, 300, "Book.pdf", 250.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(9210), 2, "Fermentum fames" },
                    { 26, "https://picsum.photos/seed/26/500/500", "Sit consequat porttitor rutrum curabitur dignissim nunc ante nullam ultrices suspendisse tortor", true, 400, "Book.pdf", 260.0, new DateTime(2023, 3, 16, 16, 9, 54, 728, DateTimeKind.Local).AddTicks(9716), 3, "Euismod" },
                    { 27, "https://picsum.photos/seed/27/500/500", "Neque placerat amet, iaculis ligula justo varius, mauris, viverra nibh in luctus sagittis, donec pellentesque nibh, tristique maximus", true, 400, "Book.pdf", 270.0, new DateTime(2023, 3, 16, 16, 9, 54, 729, DateTimeKind.Local).AddTicks(315), 1, "Finibus massa" },
                    { 29, "https://picsum.photos/seed/29/500/500", "Auctor porttitor, vehicula mauris feugiat, dui, amet mollis viverra", true, 400, "Book.pdf", 290.0, new DateTime(2023, 3, 16, 16, 9, 54, 729, DateTimeKind.Local).AddTicks(1367), 3, "Eleifend" },
                    { 30, "https://picsum.photos/seed/30/500/500", "Id proin platea nibh feugiat fringilla, interdum convallis libero dui dapibus", true, 400, "Book.pdf", 300.0, new DateTime(2023, 3, 16, 16, 9, 54, 729, DateTimeKind.Local).AddTicks(1971), 1, "Sed" },
                    { 31, "https://picsum.photos/seed/31/500/500", "Odio, suscipit nunc, nam curabitur sodales", true, 200, "Book.pdf", 310.0, new DateTime(2023, 3, 16, 16, 9, 54, 729, DateTimeKind.Local).AddTicks(2602), 2, "Nam vestibulum eleifend" },
                    { 33, "https://picsum.photos/seed/33/500/500", "Integer nisi eros torquent per rhoncus, orci,", true, 300, "Book.pdf", 330.0, new DateTime(2023, 3, 16, 16, 9, 54, 729, DateTimeKind.Local).AddTicks(3966), 1, "A nam tellus" },
                    { 34, "https://picsum.photos/seed/34/500/500", "Massa, sem congue dolor, id", true, 300, "Book.pdf", 340.0, new DateTime(2023, 3, 16, 16, 9, 54, 729, DateTimeKind.Local).AddTicks(4829), 2, "Enim enim donec interdum" },
                    { 35, "https://picsum.photos/seed/35/500/500", "A laoreet, odio, dui, purus ornare curabitur suscipit sem,", true, 200, "Book.pdf", 350.0, new DateTime(2023, 3, 16, 16, 9, 54, 729, DateTimeKind.Local).AddTicks(6007), 3, "Lectus viverra" },
                    { 37, "https://picsum.photos/seed/37/500/500", "Porta, quis consectetur sit arcu, in, aliquet sollicitudin ante, et sagittis tristique habitasse maecenas ut orci,", true, 400, "Book.pdf", 370.0, new DateTime(2023, 3, 16, 16, 9, 54, 729, DateTimeKind.Local).AddTicks(7509), 2, "Rhoncus morbi ornare" },
                    { 38, "https://picsum.photos/seed/38/500/500", "Vestibulum, rhoncus consectetur eleifend dui,", true, 200, "Book.pdf", 380.0, new DateTime(2023, 3, 16, 16, 9, 54, 729, DateTimeKind.Local).AddTicks(8148), 3, "Dolor leo" },
                    { 39, "https://picsum.photos/seed/39/500/500", "Risus nunc non fringilla, orci, finibus nec, nisl magna nulla, quis,", true, 400, "Book.pdf", 390.0, new DateTime(2023, 3, 16, 16, 9, 54, 729, DateTimeKind.Local).AddTicks(8802), 1, "Cursus" },
                    { 41, "https://picsum.photos/seed/41/500/500", "Cursus", true, 100, "Book.pdf", 410.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(262), 3, "Varius tempor vestibulum" },
                    { 42, "https://picsum.photos/seed/42/500/500", "Consequat luctus, est eros, aptent condimentum quam, auctor pulvinar,", true, 300, "Book.pdf", 420.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(918), 1, "Sagittis odio tortor neque" },
                    { 43, "https://picsum.photos/seed/43/500/500", "Neque eros nunc eu, suspendisse massa feugiat quam, dapibus fermentum nisi, tristique odio nam molestie pharetra mi, leo,", true, 300, "Book.pdf", 430.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(1746), 2, "Convallis blandit metus nibh" },
                    { 45, "https://picsum.photos/seed/45/500/500", "Tempor eu, a, nunc, rhoncus ultricies ligula urna,", true, 400, "Book.pdf", 450.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(3061), 1, "Nec hac gravida enim" },
                    { 46, "https://picsum.photos/seed/46/500/500", "Metus eu volutpat suspendisse erat, urna laoreet dui, lacinia justo tempor, feugiat eget lectus ante, ipsum", true, 200, "Book.pdf", 460.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(3648), 2, "Posuere vestibulum" },
                    { 47, "https://picsum.photos/seed/47/500/500", "Placerat, etiam at, auctor litora quam, laoreet, dapibus", true, 200, "Book.pdf", 470.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(4389), 3, "Commodo" },
                    { 49, "https://picsum.photos/seed/49/500/500", "Eget phasellus vel,", true, 300, "Book.pdf", 490.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(5778), 2, "Nam tristique sit himenaeos" },
                    { 50, "https://picsum.photos/seed/50/500/500", "Urna, lacus bibendum, posuere nec risus efficitur proin cursus mattis duis ac, praesent", true, 100, "Book.pdf", 500.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(6424), 3, "Eleifend in cursus a" },
                    { 51, "https://picsum.photos/seed/51/500/500", "Lacus convallis posuere, sagittis quis, ullamcorper tellus curabitur tempus himenaeos sapien placerat, venenatis placerat elementum massa", true, 400, "Book.pdf", 510.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(7168), 1, "Mauris finibus" },
                    { 53, "https://picsum.photos/seed/53/500/500", "Amet curabitur quam, nostra, pulvinar, aptent etiam eleifend pellentesque", true, 100, "Book.pdf", 530.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(8342), 3, "Class" },
                    { 54, "https://picsum.photos/seed/54/500/500", "Elementum cursus, pulvinar aliquam tellus vitae porta, velit vulputate libero tincidunt commodo urna adipiscing", true, 100, "Book.pdf", 540.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(9084), 1, "Nec pharetra condimentum platea" },
                    { 55, "https://picsum.photos/seed/55/500/500", "At praesent dapibus risus ac, quam ligula tempus nulla, porta et, sagittis, feugiat sed, nibh urna, consectetur finibus per", true, 300, "Book.pdf", 550.0, new DateTime(2023, 3, 16, 16, 9, 54, 730, DateTimeKind.Local).AddTicks(9659), 2, "Eros efficitur at commodo" },
                    { 57, "https://picsum.photos/seed/57/500/500", "Aenean praesent eleifend, semper ex mi, eu, amet,", true, 200, "Book.pdf", 570.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(1015), 1, "Purus mollis ipsum lacinia" },
                    { 58, "https://picsum.photos/seed/58/500/500", "Non et posuere velit sollicitudin magna dapibus elit volutpat, laoreet, hac diam", true, 400, "Book.pdf", 580.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(1694), 2, "Ipsum massa" },
                    { 59, "https://picsum.photos/seed/59/500/500", "Nostra, leo aliquet dui, urna massa, magna dui interdum et inceptos vulputate per nibh, lacus", true, 300, "Book.pdf", 590.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(2316), 3, "Eu" },
                    { 61, "https://picsum.photos/seed/61/500/500", "Orci feugiat justo nulla, volutpat, nulla fusce erat, nec,", true, 400, "Book.pdf", 610.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(3620), 2, "Vestibulum in sagittis neque" },
                    { 62, "https://picsum.photos/seed/62/500/500", "Mattis diam placerat dictum bibendum quis rhoncus quam tortor, accumsan leo, nulla, interdum", true, 300, "Book.pdf", 620.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(4181), 3, "Ultrices leo" },
                    { 63, "https://picsum.photos/seed/63/500/500", "Dolor, consectetur maecenas aenean", true, 200, "Book.pdf", 630.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(4904), 1, "Nisi lectus aliquam dapibus" },
                    { 65, "https://picsum.photos/seed/65/500/500", "At lectus, ullamcorper elit, pretium finibus faucibus", true, 400, "Book.pdf", 650.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(6239), 3, "Dui integer mauris augue" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 66, "https://picsum.photos/seed/66/500/500", "Per lectus ac, mauris, lacinia", true, 100, "Book.pdf", 660.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(6858), 1, "Eros imperdiet dolor" },
                    { 67, "https://picsum.photos/seed/67/500/500", "Nec, posuere,", true, 300, "Book.pdf", 670.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(7395), 2, "Non nunc" },
                    { 69, "https://picsum.photos/seed/69/500/500", "Eleifend, mattis", true, 100, "Book.pdf", 690.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(8640), 1, "Non" },
                    { 70, "https://picsum.photos/seed/70/500/500", "Posuere, arcu et, congue dolor donec auctor", true, 100, "Book.pdf", 700.0, new DateTime(2023, 3, 16, 16, 9, 54, 731, DateTimeKind.Local).AddTicks(9435), 2, "Metus orci consequat bibendum" },
                    { 71, "https://picsum.photos/seed/71/500/500", "Ac, inceptos congue, rutrum mauris, fames primis per eu, eleifend odio nullam", true, 400, "Book.pdf", 710.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(34), 3, "Mi sagittis aliquam suscipit" },
                    { 73, "https://picsum.photos/seed/73/500/500", "Nunc, aenean sit fames sagittis ligula, vulputate nec, sapien vestibulum, orci,", true, 400, "Book.pdf", 730.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(1463), 2, "Et sem tellus" },
                    { 74, "https://picsum.photos/seed/74/500/500", "Mauris, bibendum, erat dui tortor cursus, cursus duis venenatis", true, 300, "Book.pdf", 740.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(2249), 3, "Urna blandit" },
                    { 75, "https://picsum.photos/seed/75/500/500", "Hac sed, tellus,", true, 300, "Book.pdf", 750.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(2910), 1, "Dapibus" },
                    { 77, "https://picsum.photos/seed/77/500/500", "Metus conubia congue cursus, mattis,", true, 400, "Book.pdf", 770.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(4192), 3, "Odio arcu imperdiet varius" },
                    { 78, "https://picsum.photos/seed/78/500/500", "Sagittis, non, dapibus dolor, et porttitor nullam interdum, vehicula per duis urna sapien ultrices, fringilla", true, 100, "Book.pdf", 780.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(4807), 1, "Bibendum est" },
                    { 79, "https://picsum.photos/seed/79/500/500", "Auctor, malesuada in dictumst", true, 300, "Book.pdf", 790.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(5585), 2, "Nullam volutpat lorem enim" },
                    { 81, "https://picsum.photos/seed/81/500/500", "Morbi", true, 200, "Book.pdf", 810.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(6995), 1, "Leo hac" },
                    { 82, "https://picsum.photos/seed/82/500/500", "Dictumst elit maximus urna, porttitor, per vitae ex, volutpat, aliquet hendrerit sollicitudin nulla, nostra,", true, 200, "Book.pdf", 820.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(7583), 2, "Tempor morbi" },
                    { 83, "https://picsum.photos/seed/83/500/500", "Ex, dictumst efficitur pellentesque finibus, vestibulum tellus est finibus magna, maecenas eleifend,", true, 400, "Book.pdf", 830.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(8261), 3, "Nec ut" },
                    { 85, "https://picsum.photos/seed/85/500/500", "Porta, posuere, diam odio, vestibulum commodo pellentesque turpis congue, leo, elementum", true, 300, "Book.pdf", 850.0, new DateTime(2023, 3, 16, 16, 9, 54, 732, DateTimeKind.Local).AddTicks(9647), 2, "Gravida" },
                    { 86, "https://picsum.photos/seed/86/500/500", "Leo, dictum amet, integer", true, 400, "Book.pdf", 860.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(362), 3, "Feugiat eros in" },
                    { 87, "https://picsum.photos/seed/87/500/500", "Lacus himenaeos etiam nibh, dictum et at sociosqu urna faucibus", true, 200, "Book.pdf", 870.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(985), 1, "Porta nulla duis" },
                    { 89, "https://picsum.photos/seed/89/500/500", "A, laoreet, ornare dapibus lorem convallis cursus interdum", true, 400, "Book.pdf", 890.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(2383), 3, "In sodales" },
                    { 90, "https://picsum.photos/seed/90/500/500", "Faucibus diam rutrum commodo ligula, metus primis per quisque tempus eu eros, tempor posuere praesent felis cursus, tellus tellus,", true, 200, "Book.pdf", 900.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(3001), 1, "Rhoncus" },
                    { 91, "https://picsum.photos/seed/91/500/500", "Nunc fringilla, mollis euismod quis, nibh neque, odio, orci cursus, tortor,", true, 400, "Book.pdf", 910.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(3646), 2, "Et augue commodo feugiat" },
                    { 93, "https://picsum.photos/seed/93/500/500", "Fringilla conubia placerat, quisque dui justo maximus tellus tortor, hac elementum ut", true, 300, "Book.pdf", 930.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(4862), 1, "Quisque dui" },
                    { 94, "https://picsum.photos/seed/94/500/500", "Porta odio laoreet, maximus pulvinar purus a, consequat vestibulum aliquam pretium dui, ac, per libero auctor, eleifend", true, 300, "Book.pdf", 940.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(5397), 2, "Purus vivamus" },
                    { 95, "https://picsum.photos/seed/95/500/500", "Tempor, maecenas odio, eros, bibendum, nostra, porttitor mollis fringilla, habitasse nullam hendrerit commodo interdum, tempus laoreet,", true, 300, "Book.pdf", 950.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(6146), 3, "Urna class nibh" },
                    { 97, "https://picsum.photos/seed/97/500/500", "Et, nibh", true, 200, "Book.pdf", 970.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(7354), 2, "Laoreet leo" },
                    { 98, "https://picsum.photos/seed/98/500/500", "Ac phasellus pharetra nunc feugiat dolor, ac, nisi, arcu in,", true, 100, "Book.pdf", 980.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(7931), 3, "Sed lacinia" },
                    { 99, "https://picsum.photos/seed/99/500/500", "Placerat, ex, himenaeos varius, litora aliquet eu massa nisi, volutpat, libero elit, tortor quisque amet, maximus", true, 400, "Book.pdf", 990.0, new DateTime(2023, 3, 16, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(8508), 1, "Habitasse risus" }
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
                    { 1, 12 },
                    { 2, 3 },
                    { 3, 7 },
                    { 5, 12 },
                    { 6, 7 },
                    { 7, 9 },
                    { 9, 1 },
                    { 10, 2 },
                    { 11, 11 },
                    { 13, 6 },
                    { 14, 3 },
                    { 15, 8 },
                    { 17, 1 },
                    { 18, 10 },
                    { 19, 5 },
                    { 21, 12 },
                    { 22, 9 },
                    { 23, 2 },
                    { 25, 5 },
                    { 26, 10 },
                    { 27, 10 },
                    { 29, 11 },
                    { 30, 8 },
                    { 31, 3 },
                    { 33, 10 },
                    { 34, 11 },
                    { 35, 6 },
                    { 37, 11 },
                    { 38, 10 },
                    { 39, 6 },
                    { 41, 1 },
                    { 42, 8 },
                    { 43, 5 },
                    { 45, 1 },
                    { 46, 12 },
                    { 47, 8 },
                    { 49, 6 },
                    { 50, 2 },
                    { 51, 10 },
                    { 53, 5 },
                    { 54, 6 },
                    { 55, 7 }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 57, 5 },
                    { 58, 2 },
                    { 59, 10 },
                    { 61, 9 },
                    { 62, 11 },
                    { 63, 12 },
                    { 65, 12 },
                    { 66, 12 },
                    { 67, 5 },
                    { 69, 5 },
                    { 70, 10 },
                    { 71, 7 },
                    { 73, 7 },
                    { 74, 8 },
                    { 75, 2 },
                    { 77, 4 },
                    { 78, 4 },
                    { 79, 4 },
                    { 81, 9 },
                    { 82, 8 },
                    { 83, 11 },
                    { 85, 8 },
                    { 86, 10 },
                    { 87, 5 },
                    { 89, 3 },
                    { 90, 12 },
                    { 91, 3 },
                    { 93, 2 },
                    { 94, 9 },
                    { 95, 12 },
                    { 97, 11 },
                    { 98, 9 },
                    { 99, 11 }
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
