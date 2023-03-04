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
                    { new Guid("423e533c-d43d-4fd9-9676-e31af724522a"), "a917665e-e3b6-48d4-b1d6-19c7744a03b9", "Administrator role", "Admin", "admin" },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), "b22d7ea1-7848-41fa-98cc-1c82c10e4cf5", "User role", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"), 0, "77822122-9f22-43d9-b78e-95d004b34a76", "user1@gmail.com", true, "Ten 1", true, "Ho 1", false, null, "user1@gmail.com", "user1", "AQAAAAEAACcQAAAAEELoCicJyccG3dp8gt5AHKeMTGrvld8A0VGOZkL/0fFGLcwwdFZTN7Cn6hV1ipjHDQ==", "123456781", false, "", false, "user1" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"), 0, "ce5c565b-06e4-4946-a9b3-90ec0a516693", "user2@gmail.com", true, "Ten 2", true, "Ho 2", false, null, "user2@gmail.com", "user2", "AQAAAAEAACcQAAAAEIKxFYXI8peORdyZ+J6V6unWidSDzYn2R6aUC+1jk3lgQqhXo9Y5VHm7aJDYLHZndg==", "123456782", false, "", false, "user2" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), 0, "03331e25-d306-4bc5-8a8b-cb863071304e", "user3@gmail.com", true, "Ten 3", true, "Ho 3", false, null, "user3@gmail.com", "user3", "AQAAAAEAACcQAAAAEHGsC5uw/rdwuzpwNMljZ7Fa3k762PFyNds5PBXtEb82ctjaM/oGDpmDcCYnQcrKlw==", "123456783", false, "", false, "user3" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), 0, "cef246a2-92cb-4a1c-86f5-322069bf9029", "user4@gmail.com", true, "Ten 4", true, "Ho 4", false, null, "user4@gmail.com", "user4", "AQAAAAEAACcQAAAAEMeqLmyuS3lmbeOvFFIHKYjOgES3VFR+JMSBukoHFYXm2nmio++QePSVXiZXnA9XNQ==", "123456784", false, "", false, "user4" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), 0, "97bedae3-8e16-4ae0-bef4-2e536c012734", "user5@gmail.com", true, "Ten 5", true, "Ho 5", false, null, "user5@gmail.com", "user5", "AQAAAAEAACcQAAAAEBkTJj1WSi0shOdl55xJ5J3jNJKddtZC8hOdjFjZyNiBllPQMmh2CDzobsRiV34/Eg==", "123456785", false, "", false, "user5" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), 0, "b1ce2702-6765-416b-8f3e-cd80835984a9", "user6@gmail.com", true, "Ten 6", true, "Ho 6", false, null, "user6@gmail.com", "user6", "AQAAAAEAACcQAAAAEAkvPvherMe12VCgsmbFKrUIJa9oDNjoUweM3Z+ZMakg10FwkPoH5jKJn/tuXAfuVA==", "123456786", false, "", false, "user6" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), 0, "4ec158d9-2c20-486b-812b-b6b8796c33b2", "user7@gmail.com", true, "Ten 7", true, "Ho 7", false, null, "user7@gmail.com", "user7", "AQAAAAEAACcQAAAAECMT1q+nvXTd38BXkDqMmg4L2cBERDeUVUMnSsizKaeKMtLZwY9Ks+bX8sqsHvYclQ==", "123456787", false, "", false, "user7" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), 0, "0b583b55-c5ea-4da6-8ca4-87e68d621463", "user8@gmail.com", true, "Ten 8", true, "Ho 8", false, null, "user8@gmail.com", "user8", "AQAAAAEAACcQAAAAEBIe7PxXvHKCN9vpZDYNxO4IvdwJkaAQdZUXRzBpIi6eu07ulWNIr0wrmTv0v0A6/A==", "123456788", false, "", false, "user8" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), 0, "065681e8-f770-4a90-bac4-62a2a7b8bf43", "user9@gmail.com", true, "Ten 9", true, "Ho 9", false, null, "user9@gmail.com", "user9", "AQAAAAEAACcQAAAAEDziulj9qarlOf5xNVtU+VvKTvr+wtEGOZg0fVUrp3J2RyPa3jaWIP8LIV0MvnCjpA==", "123456789", false, "", false, "user9" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), 0, "a188ac0d-e568-4ae3-b4ac-d1863ac39040", "user10@gmail.com", true, "Ten 10", true, "Ho 10", false, null, "user10@gmail.com", "user10", "AQAAAAEAACcQAAAAEEpYqkw8kfA2I71HZ0mhwd62iQ0ukdkjUjbTM29w5fvFxiQb/aWiNqe58GyibzcOWg==", "1234567810", false, "", false, "user10" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 4, "https://picsum.photos/seed/4/200/300", "Vulputate cras porta in nisl", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 40.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(1742), null, "Suspendisse" },
                    { 8, "https://picsum.photos/seed/8/200/300", "Dapibus magna sodales ante, finibus, elit, luctus, conubia iaculis", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 80.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(4244), null, "Justo sem neque taciti" },
                    { 12, "https://picsum.photos/seed/12/200/300", "Euismod, amet nisi placerat felis ut", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 120.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(6737), null, "Risus scelerisque elementum suspendisse" },
                    { 16, "https://picsum.photos/seed/16/200/300", "Massa, auctor cras mi, nec eget auctor, turpis dictumst odio, eu praesent mauris volutpat, sodales magna,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 160.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(9124), null, "Rhoncus mattis eleifend dignissim" },
                    { 20, "https://picsum.photos/seed/20/200/300", "Maecenas pharetra", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 200.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(2090), null, "Vulputate praesent egestas" },
                    { 24, "https://picsum.photos/seed/24/200/300", "Sed, efficitur cras luctus, sollicitudin integer vitae erat, luctus eu, diam", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 240.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(4580), null, "Enim ligula euismod" },
                    { 28, "https://picsum.photos/seed/28/200/300", "Sagittis bibendum donec libero fringilla, fringilla nam", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 280.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(7140), null, "Ultricies vestibulum gravida egestas" },
                    { 32, "https://picsum.photos/seed/32/200/300", "Himenaeos congue pulvinar, diam imperdiet bibendum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 320.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(9625), null, "Condimentum risus phasellus" },
                    { 36, "https://picsum.photos/seed/36/200/300", "Duis imperdiet nam inceptos litora semper vehicula integer auctor nunc", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 360.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(2355), null, "Dictum imperdiet" },
                    { 40, "https://picsum.photos/seed/40/200/300", "Turpis non tortor, efficitur cursus blandit,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 400.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(5267), null, "Porttitor vehicula aliquet" },
                    { 44, "https://picsum.photos/seed/44/200/300", "Ullamcorper suscipit tristique in, pulvinar neque", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 440.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(7757), null, "Ultricies" },
                    { 48, "https://picsum.photos/seed/48/200/300", "Nulla, euismod eleifend, luctus tortor, himenaeos cras aliquam egestas torquent non urna interdum, a fermentum feugiat, nunc,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 480.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(329), null, "Volutpat taciti viverra" },
                    { 52, "https://picsum.photos/seed/52/200/300", "Eros sodales eleifend, varius est turpis eros, lorem, ultrices, ex", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 520.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(3005), null, "Ligula venenatis" },
                    { 56, "https://picsum.photos/seed/56/200/300", "Eleifend interdum, quis neque vivamus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 560.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(5557), null, "Tempus sollicitudin" },
                    { 60, "https://picsum.photos/seed/60/200/300", "Posuere, et, litora varius, fames neque, phasellus at, odio non porttitor lacinia per", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 600.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(8284), null, "Lacinia sem maximus bibendum" },
                    { 64, "https://picsum.photos/seed/64/200/300", "Vitae vestibulum, ultricies posuere velit sed", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 640.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(913), null, "Pellentesque magna at non" },
                    { 68, "https://picsum.photos/seed/68/200/300", "Phasellus nulla, risus ad vitae tortor erat, pulvinar", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 680.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(3420), null, "Sapien lacus" },
                    { 72, "https://picsum.photos/seed/72/200/300", "Conubia tempus pellentesque velit arcu, pulvinar lacinia dapibus phasellus et, at viverra porta", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 720.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(5939), null, "At morbi" },
                    { 76, "https://picsum.photos/seed/76/200/300", "Dapibus nulla libero sociosqu", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 760.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(8548), null, "Diam non" },
                    { 80, "https://picsum.photos/seed/80/200/300", "Non, a inceptos quam mattis rutrum fringilla, vivamus orci, vestibulum eleifend, condimentum amet bibendum, nulla", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 800.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(1136), null, "Nisi" },
                    { 84, "https://picsum.photos/seed/84/200/300", "Tempus mollis ullamcorper pulvinar, feugiat, dictumst ornare quisque cras nisi at, sollicitudin lacinia", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 840.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(3527), null, "Fringilla urna nibh" },
                    { 88, "https://picsum.photos/seed/88/200/300", "Vivamus semper sed nunc nulla, quis, efficitur vel, mauris, nibh, eleifend porta, lacinia pellentesque ligula, ac", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 880.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(6103), null, "Conubia finibus volutpat" },
                    { 92, "https://picsum.photos/seed/92/200/300", "Tempus ex arcu, dignissim pulvinar, taciti fames dictumst semper nec", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 920.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(8873), null, "Eget vulputate maecenas" },
                    { 96, "https://picsum.photos/seed/96/200/300", "Torquent primis enim ante erat varius, maecenas pulvinar ut lacinia, tortor tempus ultrices viverra luctus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 960.0, new DateTime(2023, 3, 4, 17, 15, 30, 275, DateTimeKind.Local).AddTicks(1180), null, "Etiam" },
                    { 100, "https://picsum.photos/seed/100/200/300", "Integer quisque ultrices, curabitur etiam euismod,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 1000.0, new DateTime(2023, 3, 4, 17, 15, 30, 275, DateTimeKind.Local).AddTicks(3671), null, "Mollis in sit neque" }
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
                    { 1, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(342), "Placerat efficitur", 40.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(331) },
                    { 2, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(829), "Nisi felis eget", 30.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(827) },
                    { 3, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(1395), "Lectus in adipiscing", 40.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(1393) },
                    { 4, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(2042), "Litora nisl ultrices suspendisse", 20.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(2040) },
                    { 5, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(2619), "Velit", 30.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(2616) },
                    { 6, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(3449), "Metus nisi", 40.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(3447) },
                    { 7, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(4023), "Erat non ut", 30.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(4021) },
                    { 8, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(4493), "Leo sociosqu quisque nulla", 20.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(4491) },
                    { 9, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(4833), "Scelerisque per", 20.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(4832) },
                    { 10, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(5155), "Feugiat", 30.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(5151) },
                    { 11, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(5534), "Massa", 20.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(5531) },
                    { 12, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(5848), "Accumsan", 40.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(5847) },
                    { 13, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(6134), "Elit vitae", 20.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(6134) },
                    { 14, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(6429), "Nisi justo litora", 10.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(6429) },
                    { 15, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(6697), "Urna", 40.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(6697) },
                    { 16, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(6947), "Lorem", 20.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(6947) },
                    { 17, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(7356), "Habitasse sodales viverra ligula", 30.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(7355) },
                    { 18, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(7772), "Elit finibus sapien leo", 40.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(7770) },
                    { 19, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(8336), "Interdum tincidunt", 30.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(8333) },
                    { 20, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(8940), "Placerat", 10.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(8938) }
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
                    { 8, 9 },
                    { 12, 10 },
                    { 16, 7 },
                    { 20, 5 },
                    { 24, 8 },
                    { 28, 11 },
                    { 32, 9 },
                    { 36, 3 },
                    { 40, 4 },
                    { 44, 11 },
                    { 48, 11 },
                    { 52, 2 },
                    { 56, 1 },
                    { 60, 6 },
                    { 64, 4 },
                    { 68, 12 },
                    { 72, 12 },
                    { 76, 4 },
                    { 80, 3 },
                    { 84, 10 },
                    { 88, 8 },
                    { 92, 10 },
                    { 96, 11 },
                    { 100, 2 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 1, "https://picsum.photos/seed/1/200/300", "Felis congue mattis, lacus consequat faucibus lectus nulla, libero nam proin elit ipsum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 10.0, new DateTime(2023, 3, 4, 17, 15, 30, 268, DateTimeKind.Local).AddTicks(9590), 2, "Habitasse vel tellus ad" },
                    { 2, "https://picsum.photos/seed/2/200/300", "Tortor, quam posuere, integer fames posuere id feugiat quis, consequat et, dictum cras bibendum, porta, aenean ante,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 20.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(364), 3, "Laoreet massa pulvinar sagittis" },
                    { 3, "https://picsum.photos/seed/3/200/300", "Nisi, tellus per porttitor, nisl blandit eu sem, ultrices et platea praesent varius tempor,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 30.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(1137), 1, "Odio" },
                    { 5, "https://picsum.photos/seed/5/200/300", "Elit odio, per dignissim auctor sed, cursus nunc, praesent egestas ut tellus, tincidunt morbi aliquet", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 50.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(2351), 3, "Consectetur nec accumsan massa" },
                    { 6, "https://picsum.photos/seed/6/200/300", "Vehicula volutpat, semper dignissim enim orci, lectus, varius, aptent gravida class diam mi consequat turpis donec faucibus commodo, praesent", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 60.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(3079), 1, "Sed diam sagittis laoreet" },
                    { 7, "https://picsum.photos/seed/7/200/300", "Risus pellentesque per massa,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 70.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(3678), 2, "Taciti" },
                    { 9, "https://picsum.photos/seed/9/200/300", "Amet, efficitur fringilla, lorem", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 90.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(4843), 1, "Congue quis rhoncus" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 10, "https://picsum.photos/seed/10/200/300", "Vel et", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 100.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(5560), 2, "Laoreet" },
                    { 11, "https://picsum.photos/seed/11/200/300", "Nulla, placerat non, quis, orci, primis eget augue consequat mi,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 110.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(6182), 3, "Quam" },
                    { 13, "https://picsum.photos/seed/13/200/300", "Dolor lorem in, et, in id,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 130.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(7380), 2, "Commodo blandit" },
                    { 14, "https://picsum.photos/seed/14/200/300", "Ultrices mauris, neque, ante, viverra efficitur malesuada nisi, varius eros quam, ultricies nisi nullam et, tortor, faucibus non, phasellus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 140.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(7944), 3, "Vehicula" },
                    { 15, "https://picsum.photos/seed/15/200/300", "Placerat porttitor, efficitur imperdiet rhoncus, ac commodo, nunc sociosqu primis", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 150.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(8513), 1, "Lobortis convallis cursus" },
                    { 17, "https://picsum.photos/seed/17/200/300", "Hac quam, sollicitudin eu, sed, feugiat, erat, tempor, viverra sem metus justo quis neque iaculis himenaeos est auctor", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 170.0, new DateTime(2023, 3, 4, 17, 15, 30, 269, DateTimeKind.Local).AddTicks(9928), 3, "Feugiat lacinia" },
                    { 18, "https://picsum.photos/seed/18/200/300", "Et curabitur leo tristique ipsum litora aptent vulputate sodales sociosqu laoreet,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 180.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(671), 1, "Lacinia elit" },
                    { 19, "https://picsum.photos/seed/19/200/300", "Libero porttitor, tellus, lorem, auctor, himenaeos et, venenatis nisi, ex, massa feugiat, ligula sollicitudin morbi", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 190.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(1463), 2, "Tortor ut placerat convallis" },
                    { 21, "https://picsum.photos/seed/21/200/300", "Donec justo posuere, metus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 210.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(2734), 1, "Arcu sagittis" },
                    { 22, "https://picsum.photos/seed/22/200/300", "Venenatis", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 220.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(3415), 2, "Eget cursus lacinia convallis" },
                    { 23, "https://picsum.photos/seed/23/200/300", "Vitae eros convallis arcu lobortis donec volutpat, nulla, lectus dui tempus ultrices, imperdiet duis feugiat, massa,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 230.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(3992), 3, "Suscipit" },
                    { 25, "https://picsum.photos/seed/25/200/300", "Mattis sagittis eleifend quis primis placerat a tellus proin risus erat, enim bibendum maximus iaculis aliquam", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 250.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(5285), 2, "Egestas diam accumsan" },
                    { 26, "https://picsum.photos/seed/26/200/300", "Ultricies non auctor nam turpis lectus at maecenas elit, feugiat,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 260.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(5906), 3, "Fames tempor" },
                    { 27, "https://picsum.photos/seed/27/200/300", "Integer aliquet phasellus porta, sem at, a, suscipit", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 270.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(6413), 1, "Lectus" },
                    { 29, "https://picsum.photos/seed/29/200/300", "Cursus, mauris turpis vivamus accumsan blandit, nisi dignissim", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 290.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(7746), 3, "Integer leo semper in" },
                    { 30, "https://picsum.photos/seed/30/200/300", "Hac blandit rhoncus, vehicula nibh vivamus feugiat, volutpat, lorem, congue, placerat curabitur et", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 300.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(8316), 1, "Ullamcorper ac duis" },
                    { 31, "https://picsum.photos/seed/31/200/300", "Auctor volutpat, leo fringilla, sed", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 310.0, new DateTime(2023, 3, 4, 17, 15, 30, 270, DateTimeKind.Local).AddTicks(8949), 2, "Tortor enim nec nam" },
                    { 33, "https://picsum.photos/seed/33/200/300", "Ultrices libero nibh, ex mattis, consequat semper velit dapibus lectus ornare lorem magna dolor sociosqu vestibulum, egestas", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 330.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(294), 1, "Suscipit" },
                    { 34, "https://picsum.photos/seed/34/200/300", "Orci quis, commodo, dolor vel, aenean nisi, laoreet vestibulum, tempor, morbi integer sagittis, elit ac, dui maximus ut", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 340.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(1068), 2, "Pulvinar quam" },
                    { 35, "https://picsum.photos/seed/35/200/300", "Rhoncus, non massa,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 350.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(1754), 3, "Eleifend lobortis" },
                    { 37, "https://picsum.photos/seed/37/200/300", "Congue tincidunt nulla, quam praesent efficitur euismod, inceptos urna ante porta sapien quis, finibus conubia rhoncus sed condimentum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 370.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(3077), 2, "Orci posuere in" },
                    { 38, "https://picsum.photos/seed/38/200/300", "Ultrices, condimentum porttitor luctus, non, dignissim sollicitudin", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 380.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(3681), 3, "Auctor" },
                    { 39, "https://picsum.photos/seed/39/200/300", "Mi euismod, in, sapien conubia cursus vitae,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 390.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(4278), 1, "Ante massa facilisis" },
                    { 41, "https://picsum.photos/seed/41/200/300", "Donec nec arcu massa non felis sollicitudin ultricies fames vehicula dui venenatis ex mollis eu", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 410.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(5924), 3, "Gravida mattis" },
                    { 42, "https://picsum.photos/seed/42/200/300", "Bibendum, vehicula sem class tellus etiam", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 420.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(6596), 1, "Urna" },
                    { 43, "https://picsum.photos/seed/43/200/300", "Mi, dignissim non", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 430.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(7225), 2, "Nec congue tempor volutpat" },
                    { 45, "https://picsum.photos/seed/45/200/300", "Aptent justo sociosqu", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 450.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(8371), 1, "Vitae tincidunt" },
                    { 46, "https://picsum.photos/seed/46/200/300", "Finibus fames per erat, quis, torquent ad", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 460.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(9016), 2, "Auctor nam enim" },
                    { 47, "https://picsum.photos/seed/47/200/300", "Bibendum litora eget", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 470.0, new DateTime(2023, 3, 4, 17, 15, 30, 271, DateTimeKind.Local).AddTicks(9630), 3, "Fusce convallis laoreet lobortis" },
                    { 49, "https://picsum.photos/seed/49/200/300", "Feugiat, dui inceptos", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 490.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(1011), 2, "Ex rhoncus etiam vulputate" },
                    { 50, "https://picsum.photos/seed/50/200/300", "At, leo, habitasse enim luctus ex, vestibulum, dignissim nunc magna, interdum, varius risus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 500.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(1565), 3, "Ligula congue class torquent" },
                    { 51, "https://picsum.photos/seed/51/200/300", "Lacinia eleifend purus feugiat", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 510.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(2258), 1, "Venenatis blandit eros volutpat" },
                    { 53, "https://picsum.photos/seed/53/200/300", "Morbi donec commodo interdum velit", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 530.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(3608), 3, "Lobortis arcu ut tincidunt" },
                    { 54, "https://picsum.photos/seed/54/200/300", "Mi vitae finibus, mattis suspendisse nisi, fringilla, lacus porta, egestas class aliquam neque, id porta", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 540.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(4308), 1, "Commodo tincidunt" },
                    { 55, "https://picsum.photos/seed/55/200/300", "Placerat velit pulvinar augue aliquam tempus non, quam, vitae neque convallis nibh, eget", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 550.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(4976), 2, "Phasellus class dolor congue" },
                    { 57, "https://picsum.photos/seed/57/200/300", "Faucibus ullamcorper mollis platea volutpat, eleifend ligula, in cursus, magna, id, imperdiet purus inceptos rhoncus,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 570.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(6201), 1, "Sagittis" },
                    { 58, "https://picsum.photos/seed/58/200/300", "Mattis, metus congue, ullamcorper morbi vivamus amet ligula aptent finibus risus mi pulvinar, eget curabitur", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 580.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(6838), 2, "Auctor sagittis" },
                    { 59, "https://picsum.photos/seed/59/200/300", "Ipsum massa a, cursus, at, vivamus magna, urna, purus consequat at euismod, lacus lorem, nisl mattis, amet", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 590.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(7528), 3, "Mattis pellentesque" },
                    { 61, "https://picsum.photos/seed/61/200/300", "Sociosqu bibendum risus duis interdum, nisl neque, fames sapien interdum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 610.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(8912), 2, "Nisl" },
                    { 62, "https://picsum.photos/seed/62/200/300", "Sem, dignissim erat, eleifend, justo commodo, volutpat,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 620.0, new DateTime(2023, 3, 4, 17, 15, 30, 272, DateTimeKind.Local).AddTicks(9514), 3, "Ullamcorper duis" },
                    { 63, "https://picsum.photos/seed/63/200/300", "Non placerat consequat sem leo, orci nibh, mattis massa gravida lacinia luctus auctor vel, dictum euismod", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 630.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(264), 1, "At faucibus lacinia luctus" },
                    { 65, "https://picsum.photos/seed/65/200/300", "Lectus iaculis eleifend, duis ante semper rutrum nisi, praesent erat cursus, quam, nulla sapien scelerisque sit class", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 650.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(1454), 3, "Platea" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 66, "https://picsum.photos/seed/66/200/300", "Vulputate fames blandit magna, ex habitasse imperdiet primis odio, at, bibendum eros, vitae, metus morbi", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 660.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(2227), 1, "Commodo tortor" },
                    { 67, "https://picsum.photos/seed/67/200/300", "Faucibus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 670.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(2871), 2, "Facilisis pretium elementum" },
                    { 69, "https://picsum.photos/seed/69/200/300", "Litora", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 690.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(4100), 1, "Neque vitae" },
                    { 70, "https://picsum.photos/seed/70/200/300", "Ante magna commodo, risus interdum fermentum velit eleifend, cursus, odio diam orci proin efficitur amet", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 700.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(4684), 2, "Sed inceptos" },
                    { 71, "https://picsum.photos/seed/71/200/300", "Orci quis vestibulum, arcu imperdiet tempor, congue ac, pulvinar, sodales placerat, lacinia efficitur iaculis rhoncus eu, odio", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 710.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(5239), 3, "Vel" },
                    { 73, "https://picsum.photos/seed/73/200/300", "Venenatis accumsan posuere bibendum suspendisse litora vestibulum malesuada nibh, laoreet sit ornare at, sagittis nulla et vestibulum, urna", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 730.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(6536), 2, "Nulla hendrerit lorem" },
                    { 74, "https://picsum.photos/seed/74/200/300", "Dui proin", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 740.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(7078), 3, "Ullamcorper convallis" },
                    { 75, "https://picsum.photos/seed/75/200/300", "Nibh amet", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 750.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(7673), 1, "Himenaeos mattis aliquam" },
                    { 77, "https://picsum.photos/seed/77/200/300", "Nunc ad sodales nam laoreet, fusce feugiat nec mauris taciti porttitor, dignissim varius, nunc, facilisis ac", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 770.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(9165), 3, "Luctus ex vivamus nisi" },
                    { 78, "https://picsum.photos/seed/78/200/300", "Quam, lobortis lacus at leo, volutpat varius, facilisis felis rutrum mollis sollicitudin molestie massa, orci, porta blandit diam condimentum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 780.0, new DateTime(2023, 3, 4, 17, 15, 30, 273, DateTimeKind.Local).AddTicks(9850), 1, "Taciti etiam" },
                    { 79, "https://picsum.photos/seed/79/200/300", "Tellus libero nam cras primis leo augue posuere, rhoncus lacinia, elementum risus nibh,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 790.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(540), 2, "Adipiscing tempor" },
                    { 81, "https://picsum.photos/seed/81/200/300", "Auctor sodales cursus nunc commodo justo maecenas", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 810.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(1673), 1, "Eros" },
                    { 82, "https://picsum.photos/seed/82/200/300", "Lacinia, odio", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 820.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(2288), 2, "Sapien fames interdum malesuada" },
                    { 83, "https://picsum.photos/seed/83/200/300", "Posuere metus ac taciti quam libero molestie", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 830.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(2933), 3, "Per porttitor pulvinar erat" },
                    { 85, "https://picsum.photos/seed/85/200/300", "Urna dolor, morbi egestas placerat, ante fermentum integer elit massa, tortor amet", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 850.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(4139), 2, "Morbi" },
                    { 86, "https://picsum.photos/seed/86/200/300", "Nostra, massa torquent nisi, leo ultricies fringilla placerat vestibulum, et neque arcu ad est", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 860.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(4875), 3, "Neque finibus" },
                    { 87, "https://picsum.photos/seed/87/200/300", "Dolor, cursus himenaeos scelerisque viverra lacus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 870.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(5420), 1, "Dignissim" },
                    { 89, "https://picsum.photos/seed/89/200/300", "Scelerisque porta neque nisl accumsan facilisis luctus, platea", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 890.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(6896), 3, "Libero curabitur ad" },
                    { 90, "https://picsum.photos/seed/90/200/300", "Mi pharetra", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 900.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(7484), 1, "Eleifend varius" },
                    { 91, "https://picsum.photos/seed/91/200/300", "Quam, dolor varius, tortor", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 910.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(8211), 2, "In sapien orci venenatis" },
                    { 93, "https://picsum.photos/seed/93/200/300", "Nam nec, hac pharetra nec nisl sed curabitur fermentum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 930.0, new DateTime(2023, 3, 4, 17, 15, 30, 274, DateTimeKind.Local).AddTicks(9428), 1, "Volutpat nisi" },
                    { 94, "https://picsum.photos/seed/94/200/300", "Commodo fermentum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 940.0, new DateTime(2023, 3, 4, 17, 15, 30, 275, DateTimeKind.Local).AddTicks(38), 2, "Euismod sodales" },
                    { 95, "https://picsum.photos/seed/95/200/300", "Malesuada efficitur a viverra congue, fermentum felis quisque ante, eros vulputate nibh, tristique condimentum tellus elementum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 950.0, new DateTime(2023, 3, 4, 17, 15, 30, 275, DateTimeKind.Local).AddTicks(600), 3, "Feugiat duis vitae" },
                    { 97, "https://picsum.photos/seed/97/200/300", "Ligula, odio class mi,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 970.0, new DateTime(2023, 3, 4, 17, 15, 30, 275, DateTimeKind.Local).AddTicks(1764), 2, "Consequat orci posuere varius" },
                    { 98, "https://picsum.photos/seed/98/200/300", "Posuere, est euismod, blandit finibus, sit varius, sagittis, amet sollicitudin molestie magna tempor dapibus porttitor, placerat bibendum himenaeos", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 980.0, new DateTime(2023, 3, 4, 17, 15, 30, 275, DateTimeKind.Local).AddTicks(2484), 3, "Nostra consectetur" },
                    { 99, "https://picsum.photos/seed/99/200/300", "Quam congue, eleifend a, rhoncus, maximus semper orci urna fermentum metus fringilla et suspendisse laoreet nec nam", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 990.0, new DateTime(2023, 3, 4, 17, 15, 30, 275, DateTimeKind.Local).AddTicks(3120), 1, "Phasellus amet tempor lacinia" }
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
                    { 1, 12 },
                    { 2, 5 },
                    { 3, 6 },
                    { 5, 10 },
                    { 6, 10 },
                    { 7, 10 },
                    { 9, 11 },
                    { 10, 8 },
                    { 11, 6 },
                    { 13, 10 },
                    { 14, 7 },
                    { 15, 7 },
                    { 17, 2 },
                    { 18, 6 },
                    { 19, 11 },
                    { 21, 2 },
                    { 22, 9 },
                    { 23, 3 },
                    { 25, 11 },
                    { 26, 6 },
                    { 27, 9 },
                    { 29, 5 },
                    { 30, 2 },
                    { 31, 5 },
                    { 33, 3 },
                    { 34, 2 },
                    { 35, 7 },
                    { 37, 9 },
                    { 38, 11 },
                    { 39, 8 },
                    { 41, 2 },
                    { 42, 1 },
                    { 43, 11 },
                    { 45, 12 },
                    { 46, 7 },
                    { 47, 7 },
                    { 49, 4 },
                    { 50, 12 },
                    { 51, 6 },
                    { 53, 7 },
                    { 54, 3 },
                    { 55, 5 }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 57, 7 },
                    { 58, 5 },
                    { 59, 6 },
                    { 61, 8 },
                    { 62, 2 },
                    { 63, 3 },
                    { 65, 11 },
                    { 66, 3 },
                    { 67, 3 },
                    { 69, 12 },
                    { 70, 12 },
                    { 71, 4 },
                    { 73, 3 },
                    { 74, 4 },
                    { 75, 8 },
                    { 77, 2 },
                    { 78, 6 },
                    { 79, 11 },
                    { 81, 5 },
                    { 82, 10 },
                    { 83, 3 },
                    { 85, 9 },
                    { 86, 12 },
                    { 87, 6 },
                    { 89, 1 },
                    { 90, 11 },
                    { 91, 6 },
                    { 93, 2 },
                    { 94, 10 },
                    { 95, 10 },
                    { 97, 7 },
                    { 98, 3 },
                    { 99, 8 }
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
