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
                    { new Guid("423e533c-d43d-4fd9-9676-e31af724522a"), "a0c05400-b6c5-454d-b2ed-24b4cbda3af6", "Administrator role", "Admin", "admin" },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), "59de0315-072d-4f22-b8e4-b5c29cd3a68b", "User role", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"), 0, "408d9224-59ee-4f8e-9a4d-a566c361fe27", "user1@gmail.com", true, "Ten 1", true, "Ho 1", false, null, "user1@gmail.com", "user1", "AQAAAAEAACcQAAAAEHvFhO8euO3JWOuaPkFVtKe2Yk5Ab6GkY6MuUH/hFK3U1GnLWsVJRQVtpZYmumj8Kw==", "123456781", false, "", false, "user1" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"), 0, "70489530-c1af-4f72-973e-151b0e54a8eb", "user2@gmail.com", true, "Ten 2", true, "Ho 2", false, null, "user2@gmail.com", "user2", "AQAAAAEAACcQAAAAEP6y4zGz6F/SVkSMN0LZS4Rsu+r24ybeJvIIEXixk+wMgz/gIy97paGogG+YsTvovA==", "123456782", false, "", false, "user2" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), 0, "ad2ed5cc-235f-4ed2-99a6-a618651c1def", "user3@gmail.com", true, "Ten 3", true, "Ho 3", false, null, "user3@gmail.com", "user3", "AQAAAAEAACcQAAAAELJvvV31h38rRgYsO/GDCgJ8B/oQTPNgH1jNggJapbz6b7qtYR4hRLYUxmfZFslhog==", "123456783", false, "", false, "user3" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), 0, "03304762-d82e-46ac-8dfc-50d69bc7209d", "user4@gmail.com", true, "Ten 4", true, "Ho 4", false, null, "user4@gmail.com", "user4", "AQAAAAEAACcQAAAAEAklDf9IPSGLIamS29QhJrgSE81lA6EcnTLtWnpBdEuc0HqPul1G8W2krz4gUNnmoA==", "123456784", false, "", false, "user4" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), 0, "ce75650f-fa13-4566-8be6-f9718ed33bac", "user5@gmail.com", true, "Ten 5", true, "Ho 5", false, null, "user5@gmail.com", "user5", "AQAAAAEAACcQAAAAEFah3zfmswk9F5fknzOM6cTFV1WyWWpxAeHErXNT6s+ugQZNB6EwnahGU8BFsCzezQ==", "123456785", false, "", false, "user5" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), 0, "474d5e3a-ecaa-48d4-bf9a-f13204ec277c", "user6@gmail.com", true, "Ten 6", true, "Ho 6", false, null, "user6@gmail.com", "user6", "AQAAAAEAACcQAAAAEEIA2BgfYzh7Bu44G8ptS/s0vkiq1K8b0EDVX6Rofh9a3YdbHlomREWMAJWUZSspVw==", "123456786", false, "", false, "user6" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), 0, "ba1dbd5e-a927-4c71-926e-5d708ff2dcc4", "user7@gmail.com", true, "Ten 7", true, "Ho 7", false, null, "user7@gmail.com", "user7", "AQAAAAEAACcQAAAAEMiXzXddXFwFuVj9/7veHoK6FlKk3ykyG/+VzlgkHy6zGs84N/g1PXXsasuIdCRhYA==", "123456787", false, "", false, "user7" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), 0, "d4937f0f-96ce-4b9f-95b6-e3fa719edcd3", "user8@gmail.com", true, "Ten 8", true, "Ho 8", false, null, "user8@gmail.com", "user8", "AQAAAAEAACcQAAAAEIKoyUTJxuGXl7Cg3G/r8OxiF/P8DRoUe0TisirSNHBHbYoj879lK5f0MfqrwF5/dw==", "123456788", false, "", false, "user8" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), 0, "fa90b790-fe56-4fac-b3aa-bf10a609ed96", "user9@gmail.com", true, "Ten 9", true, "Ho 9", false, null, "user9@gmail.com", "user9", "AQAAAAEAACcQAAAAEAu/3JAZyuSGiwuQpzO4DY3h3Ydr8sg0CFLBCyZYumWsebgEwc0IiU4lW/bNicpHUA==", "123456789", false, "", false, "user9" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), 0, "e8d9cb05-7e3b-43df-85a0-1c6278a25738", "user10@gmail.com", true, "Ten 10", true, "Ho 10", false, null, "user10@gmail.com", "user10", "AQAAAAEAACcQAAAAECpiNQRfhy0hq54+Z9YOotCtXJ5COYNf3sJ51hR7lcbuy98L0BmQsCGL0pYc9I0o3g==", "1234567810", false, "", false, "user10" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 4, "https://picsum.photos/seed/4/500/500", "Tortor tincidunt sed a, sapien vestibulum platea sem mauris curabitur", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 40.0, new DateTime(2023, 3, 11, 11, 25, 58, 224, DateTimeKind.Local).AddTicks(5105), null, "Cursus maximus faucibus" },
                    { 8, "https://picsum.photos/seed/8/500/500", "Lacus tortor, aptent sem, facilisis consectetur volutpat ex scelerisque finibus, nullam ut a, dui condimentum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 80.0, new DateTime(2023, 3, 11, 11, 25, 58, 224, DateTimeKind.Local).AddTicks(9543), null, "Non eu commodo" },
                    { 12, "https://picsum.photos/seed/12/500/500", "Arcu vitae, platea", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 120.0, new DateTime(2023, 3, 11, 11, 25, 58, 225, DateTimeKind.Local).AddTicks(4194), null, "Consectetur pulvinar finibus" },
                    { 16, "https://picsum.photos/seed/16/500/500", "Luctus, primis et, nulla, fringilla amet malesuada velit hac feugiat rutrum urna ultrices,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 160.0, new DateTime(2023, 3, 11, 11, 25, 58, 225, DateTimeKind.Local).AddTicks(8015), null, "Viverra blandit ullamcorper" },
                    { 20, "https://picsum.photos/seed/20/500/500", "Euismod habitasse semper pulvinar nunc hendrerit morbi", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 200.0, new DateTime(2023, 3, 11, 11, 25, 58, 226, DateTimeKind.Local).AddTicks(2959), null, "Elit" },
                    { 24, "https://picsum.photos/seed/24/500/500", "Metus hac per orci, auctor quis scelerisque blandit luctus, ac, hendrerit ligula,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 240.0, new DateTime(2023, 3, 11, 11, 25, 58, 226, DateTimeKind.Local).AddTicks(6844), null, "Nec" },
                    { 28, "https://picsum.photos/seed/28/500/500", "Consectetur mattis, massa,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 280.0, new DateTime(2023, 3, 11, 11, 25, 58, 227, DateTimeKind.Local).AddTicks(670), null, "Inceptos" },
                    { 32, "https://picsum.photos/seed/32/500/500", "Luctus, fames urna at, amet nam a, quis, quam", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 320.0, new DateTime(2023, 3, 11, 11, 25, 58, 227, DateTimeKind.Local).AddTicks(4764), null, "Sit morbi nibh mauris" },
                    { 36, "https://picsum.photos/seed/36/500/500", "Feugiat, leo, mi massa, fames diam ac duis et proin", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 360.0, new DateTime(2023, 3, 11, 11, 25, 58, 227, DateTimeKind.Local).AddTicks(8986), null, "Vivamus consectetur lobortis et" },
                    { 40, "https://picsum.photos/seed/40/500/500", "Sagittis, facilisis venenatis blandit, fusce urna eleifend vivamus finibus, taciti tristique fermentum diam bibendum nullam commodo,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 400.0, new DateTime(2023, 3, 11, 11, 25, 58, 228, DateTimeKind.Local).AddTicks(3906), null, "Congue" },
                    { 44, "https://picsum.photos/seed/44/500/500", "Turpis quam, dolor faucibus vestibulum tempor, rhoncus nec orci, quam elit, leo,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 440.0, new DateTime(2023, 3, 11, 11, 25, 58, 228, DateTimeKind.Local).AddTicks(9570), null, "Dolor pulvinar" },
                    { 48, "https://picsum.photos/seed/48/500/500", "Neque class tincidunt finibus nulla, non leo, placerat malesuada nisi, dui vivamus volutpat, lorem", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 480.0, new DateTime(2023, 3, 11, 11, 25, 58, 229, DateTimeKind.Local).AddTicks(6108), null, "Nostra mi" },
                    { 52, "https://picsum.photos/seed/52/500/500", "Morbi", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 520.0, new DateTime(2023, 3, 11, 11, 25, 58, 230, DateTimeKind.Local).AddTicks(364), null, "Lacinia nec commodo bibendum" },
                    { 56, "https://picsum.photos/seed/56/500/500", "Rhoncus suspendisse varius varius, metus blandit lacus lectus, gravida quis urna pulvinar augue nunc, mi, interdum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 560.0, new DateTime(2023, 3, 11, 11, 25, 58, 230, DateTimeKind.Local).AddTicks(4356), null, "Curabitur ac taciti fusce" },
                    { 60, "https://picsum.photos/seed/60/500/500", "Nisl auctor, mi, ex, lacus diam feugiat suspendisse bibendum fames ultrices feugiat, arcu, curabitur dolor, ante, sapien orci, malesuada", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 600.0, new DateTime(2023, 3, 11, 11, 25, 58, 230, DateTimeKind.Local).AddTicks(8403), null, "At dapibus laoreet" },
                    { 64, "https://picsum.photos/seed/64/500/500", "Malesuada mi ligula, lacinia erat luctus volutpat tellus nisi, nisl eget integer ante, faucibus vel dignissim porttitor aliquam augue", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 640.0, new DateTime(2023, 3, 11, 11, 25, 58, 231, DateTimeKind.Local).AddTicks(2740), null, "Massa mi" },
                    { 68, "https://picsum.photos/seed/68/500/500", "Mauris ut ligula, varius, neque quis congue fringilla,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 680.0, new DateTime(2023, 3, 11, 11, 25, 58, 231, DateTimeKind.Local).AddTicks(6686), null, "A platea" },
                    { 72, "https://picsum.photos/seed/72/500/500", "Felis dolor, dolor porttitor tellus a laoreet ante neque, sit quis inceptos platea turpis convallis pretium vitae, maximus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 720.0, new DateTime(2023, 3, 11, 11, 25, 58, 232, DateTimeKind.Local).AddTicks(567), null, "Massa" },
                    { 76, "https://picsum.photos/seed/76/500/500", "Ultrices fames eleifend", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 760.0, new DateTime(2023, 3, 11, 11, 25, 58, 232, DateTimeKind.Local).AddTicks(4358), null, "Tempor mattis mauris varius" },
                    { 80, "https://picsum.photos/seed/80/500/500", "Donec nulla, magna sociosqu auctor odio, fermentum luctus, maximus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 800.0, new DateTime(2023, 3, 11, 11, 25, 58, 232, DateTimeKind.Local).AddTicks(8541), null, "Lacinia sollicitudin" },
                    { 84, "https://picsum.photos/seed/84/500/500", "Suspendisse phasellus torquent mattis, erat laoreet", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 840.0, new DateTime(2023, 3, 11, 11, 25, 58, 233, DateTimeKind.Local).AddTicks(2444), null, "Fusce ultrices nisi ipsum" },
                    { 88, "https://picsum.photos/seed/88/500/500", "Congue magna, volutpat, sit blandit", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 880.0, new DateTime(2023, 3, 11, 11, 25, 58, 233, DateTimeKind.Local).AddTicks(6762), null, "Et bibendum" },
                    { 92, "https://picsum.photos/seed/92/500/500", "Inceptos finibus bibendum suscipit ex", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 920.0, new DateTime(2023, 3, 11, 11, 25, 58, 234, DateTimeKind.Local).AddTicks(927), null, "Hendrerit ex volutpat" },
                    { 96, "https://picsum.photos/seed/96/500/500", "Tortor, est tempor, semper quam, ipsum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 960.0, new DateTime(2023, 3, 11, 11, 25, 58, 234, DateTimeKind.Local).AddTicks(5440), null, "Quisque" },
                    { 100, "https://picsum.photos/seed/100/500/500", "Elit, vel, ultricies quis efficitur fermentum vitae id, luctus nisi, proin ultrices suspendisse vitae, tempus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 1000.0, new DateTime(2023, 3, 11, 11, 25, 58, 234, DateTimeKind.Local).AddTicks(9438), null, "Eu vulputate sapien" }
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
                    { 1, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(1197), "Accumsan", 40.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(1176) },
                    { 2, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(1893), "Porta tellus ex", 30.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(1892) },
                    { 3, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(2431), "Vel arcu euismod metus", 10.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(2430) },
                    { 4, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(2930), "A dapibus", 20.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(2928) },
                    { 5, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(3524), "Porttitor orci inceptos", 20.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(3523) },
                    { 6, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(4013), "Integer nibh suspendisse", 40.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(4012) },
                    { 7, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(4627), "Eros aliquam sed commodo", 30.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(4626) },
                    { 8, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(5097), "Massa", 10.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(5096) },
                    { 9, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(5702), "Sollicitudin eu interdum", 40.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(5701) },
                    { 10, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(6227), "Ex placerat tempor", 10.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(6226) },
                    { 11, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(6686), "Eget placerat pulvinar hac", 30.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(6684) },
                    { 12, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(7252), "Urna nam inceptos congue", 40.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(7250) },
                    { 13, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(7691), "Vitae", 40.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(7690) },
                    { 14, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(8186), "Magna", 40.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(8185) },
                    { 15, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(8742), "Lorem commodo ac porta", 10.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(8741) },
                    { 16, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(9223), "Sapien vulputate rutrum", 40.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(9222) },
                    { 17, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(9678), "Nullam gravida neque placerat", 10.0, new DateTime(2023, 3, 11, 11, 25, 58, 223, DateTimeKind.Local).AddTicks(9676) },
                    { 18, new DateTime(2023, 3, 11, 11, 25, 58, 224, DateTimeKind.Local).AddTicks(119), "Litora", 10.0, new DateTime(2023, 3, 11, 11, 25, 58, 224, DateTimeKind.Local).AddTicks(118) },
                    { 19, new DateTime(2023, 3, 11, 11, 25, 58, 224, DateTimeKind.Local).AddTicks(621), "Scelerisque", 40.0, new DateTime(2023, 3, 11, 11, 25, 58, 224, DateTimeKind.Local).AddTicks(620) },
                    { 20, new DateTime(2023, 3, 11, 11, 25, 58, 224, DateTimeKind.Local).AddTicks(1113), "Id inceptos varius", 20.0, new DateTime(2023, 3, 11, 11, 25, 58, 224, DateTimeKind.Local).AddTicks(1112) }
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
                    { 4, 2 },
                    { 8, 2 },
                    { 12, 1 },
                    { 16, 2 },
                    { 20, 8 },
                    { 24, 1 },
                    { 28, 9 },
                    { 32, 11 },
                    { 36, 1 },
                    { 40, 1 },
                    { 44, 9 },
                    { 48, 7 },
                    { 52, 11 },
                    { 56, 1 },
                    { 60, 9 },
                    { 64, 11 },
                    { 68, 1 },
                    { 72, 4 },
                    { 76, 1 },
                    { 80, 5 },
                    { 84, 4 },
                    { 88, 5 },
                    { 92, 9 },
                    { 96, 4 },
                    { 100, 6 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 1, "https://picsum.photos/seed/1/500/500", "Mollis mauris luctus, mattis hac tellus, ex urna, porttitor convallis morbi in, nec, dolor aliquet donec vel lacinia imperdiet", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 10.0, new DateTime(2023, 3, 11, 11, 25, 58, 224, DateTimeKind.Local).AddTicks(2097), 2, "Sagittis" },
                    { 2, "https://picsum.photos/seed/2/500/500", "Erat, lectus, porttitor integer tempus mollis blandit interdum fringilla", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 20.0, new DateTime(2023, 3, 11, 11, 25, 58, 224, DateTimeKind.Local).AddTicks(3066), 3, "Dui nulla auctor" },
                    { 3, "https://picsum.photos/seed/3/500/500", "Nisi, sodales elementum maecenas ultricies lacus euismod, porttitor, finibus leo", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 30.0, new DateTime(2023, 3, 11, 11, 25, 58, 224, DateTimeKind.Local).AddTicks(4053), 1, "Ligula" },
                    { 5, "https://picsum.photos/seed/5/500/500", "Rhoncus tempor in accumsan odio justo nunc ultricies blandit, class arcu, et congue libero mauris", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 50.0, new DateTime(2023, 3, 11, 11, 25, 58, 224, DateTimeKind.Local).AddTicks(6104), 3, "Lacus neque erat leo" },
                    { 6, "https://picsum.photos/seed/6/500/500", "Tristique massa, posuere, nibh nam morbi lobortis cras per", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 60.0, new DateTime(2023, 3, 11, 11, 25, 58, 224, DateTimeKind.Local).AddTicks(7112), 1, "Vulputate blandit torquent" },
                    { 7, "https://picsum.photos/seed/7/500/500", "Maecenas sagittis, pulvinar urna, laoreet, cras dictum ultrices, accumsan hac at, blandit, scelerisque fringilla, aenean luctus, porta, quisque", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 70.0, new DateTime(2023, 3, 11, 11, 25, 58, 224, DateTimeKind.Local).AddTicks(8273), 2, "Elit urna aliquam" },
                    { 9, "https://picsum.photos/seed/9/500/500", "Venenatis viverra turpis praesent mauris donec congue sagittis,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 90.0, new DateTime(2023, 3, 11, 11, 25, 58, 225, DateTimeKind.Local).AddTicks(489), 1, "Neque magna ut" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 10, "https://picsum.photos/seed/10/500/500", "Mattis, mattis a, hendrerit lacinia tristique", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 100.0, new DateTime(2023, 3, 11, 11, 25, 58, 225, DateTimeKind.Local).AddTicks(1695), 2, "Dolor volutpat cursus" },
                    { 11, "https://picsum.photos/seed/11/500/500", "Vel urna porta ad mi, vel, ultricies laoreet, suspendisse hac euismod, finibus, eros quam", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 110.0, new DateTime(2023, 3, 11, 11, 25, 58, 225, DateTimeKind.Local).AddTicks(3075), 3, "Id nisl lorem" },
                    { 13, "https://picsum.photos/seed/13/500/500", "Class vitae, primis quis, placerat quisque tempus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 130.0, new DateTime(2023, 3, 11, 11, 25, 58, 225, DateTimeKind.Local).AddTicks(5074), 2, "Leo nisi" },
                    { 14, "https://picsum.photos/seed/14/500/500", "Sem, arcu, dolor,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 140.0, new DateTime(2023, 3, 11, 11, 25, 58, 225, DateTimeKind.Local).AddTicks(6049), 3, "Bibendum ullamcorper vehicula integer" },
                    { 15, "https://picsum.photos/seed/15/500/500", "Posuere, pulvinar mattis pretium fringilla sed sit tortor commodo, purus inceptos porttitor, feugiat erat,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 150.0, new DateTime(2023, 3, 11, 11, 25, 58, 225, DateTimeKind.Local).AddTicks(7018), 1, "Tristique fames tellus fringilla" },
                    { 17, "https://picsum.photos/seed/17/500/500", "Mauris, a, at amet, venenatis rutrum varius urna nunc, sollicitudin auctor inceptos vitae litora tincidunt bibendum, ut", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 170.0, new DateTime(2023, 3, 11, 11, 25, 58, 225, DateTimeKind.Local).AddTicks(9233), 3, "Augue" },
                    { 18, "https://picsum.photos/seed/18/500/500", "Feugiat, nisi vitae, orci imperdiet nec, lectus vitae curabitur lectus, turpis viverra dapibus varius, ultrices,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 180.0, new DateTime(2023, 3, 11, 11, 25, 58, 226, DateTimeKind.Local).AddTicks(959), 1, "Cursus fringilla" },
                    { 19, "https://picsum.photos/seed/19/500/500", "Quis velit dictum sollicitudin placerat pellentesque lectus, in, semper curabitur amet lorem, porttitor, eleifend, nisi massa, cursus,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 190.0, new DateTime(2023, 3, 11, 11, 25, 58, 226, DateTimeKind.Local).AddTicks(2053), 2, "Sed facilisis" },
                    { 21, "https://picsum.photos/seed/21/500/500", "Dapibus elit, iaculis sem enim, varius, nunc, sem, orci nec, odio,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 210.0, new DateTime(2023, 3, 11, 11, 25, 58, 226, DateTimeKind.Local).AddTicks(3932), 1, "Tempus" },
                    { 22, "https://picsum.photos/seed/22/500/500", "Eleifend porttitor, erat eros, mattis, faucibus auctor quam habitasse elit, ut", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 220.0, new DateTime(2023, 3, 11, 11, 25, 58, 226, DateTimeKind.Local).AddTicks(4897), 2, "Nostra eu inceptos" },
                    { 23, "https://picsum.photos/seed/23/500/500", "Neque lacus at, a", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 230.0, new DateTime(2023, 3, 11, 11, 25, 58, 226, DateTimeKind.Local).AddTicks(5970), 3, "Aenean interdum nulla id" },
                    { 25, "https://picsum.photos/seed/25/500/500", "Lacinia, vitae, dui, arcu imperdiet semper aliquam dapibus himenaeos", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 250.0, new DateTime(2023, 3, 11, 11, 25, 58, 226, DateTimeKind.Local).AddTicks(7763), 2, "Nulla aliquet pellentesque" },
                    { 26, "https://picsum.photos/seed/26/500/500", "Bibendum, interdum, urna libero rhoncus vestibulum, aenean habitasse leo placerat, gravida vel donec", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 260.0, new DateTime(2023, 3, 11, 11, 25, 58, 226, DateTimeKind.Local).AddTicks(8708), 3, "Interdum" },
                    { 27, "https://picsum.photos/seed/27/500/500", "Congue conubia urna, pellentesque nostra, diam porttitor nec imperdiet sociosqu nisi nulla, nisi, iaculis primis pharetra sollicitudin non, vivamus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 270.0, new DateTime(2023, 3, 11, 11, 25, 58, 226, DateTimeKind.Local).AddTicks(9798), 1, "Nulla vel id" },
                    { 29, "https://picsum.photos/seed/29/500/500", "Aptent blandit lectus, vel mauris porta, at lacinia, massa, pharetra", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 290.0, new DateTime(2023, 3, 11, 11, 25, 58, 227, DateTimeKind.Local).AddTicks(1568), 3, "Sociosqu" },
                    { 30, "https://picsum.photos/seed/30/500/500", "Pellentesque eu vitae, augue", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 300.0, new DateTime(2023, 3, 11, 11, 25, 58, 227, DateTimeKind.Local).AddTicks(2557), 1, "A tristique odio" },
                    { 31, "https://picsum.photos/seed/31/500/500", "Mauris, massa, volutpat, interdum, ad nulla id tempor, fusce semper hac leo", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 310.0, new DateTime(2023, 3, 11, 11, 25, 58, 227, DateTimeKind.Local).AddTicks(3525), 2, "Ex dictum nec" },
                    { 33, "https://picsum.photos/seed/33/500/500", "Ultricies lobortis nullam scelerisque velit tempor nostra, tempus mauris orci, convallis euismod iaculis odio, neque eu,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 330.0, new DateTime(2023, 3, 11, 11, 25, 58, 227, DateTimeKind.Local).AddTicks(5898), 1, "Donec placerat tempor" },
                    { 34, "https://picsum.photos/seed/34/500/500", "Sagittis, nunc libero sit curabitur erat porta per", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 340.0, new DateTime(2023, 3, 11, 11, 25, 58, 227, DateTimeKind.Local).AddTicks(6941), 2, "Fringilla dictum" },
                    { 35, "https://picsum.photos/seed/35/500/500", "Luctus, at ante odio, ligula sem, vestibulum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 350.0, new DateTime(2023, 3, 11, 11, 25, 58, 227, DateTimeKind.Local).AddTicks(7895), 3, "Enim ante" },
                    { 37, "https://picsum.photos/seed/37/500/500", "Sodales integer libero vulputate rhoncus mollis malesuada dapibus id tempor, non, massa, nam", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 370.0, new DateTime(2023, 3, 11, 11, 25, 58, 228, DateTimeKind.Local).AddTicks(770), 2, "Lectus et feugiat ligula" },
                    { 38, "https://picsum.photos/seed/38/500/500", "Elit mollis magna laoreet varius arcu ultrices, class platea efficitur vel,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 380.0, new DateTime(2023, 3, 11, 11, 25, 58, 228, DateTimeKind.Local).AddTicks(1831), 3, "Venenatis" },
                    { 39, "https://picsum.photos/seed/39/500/500", "Lectus, accumsan augue auctor, neque, porttitor sagittis, rutrum magna eleifend, fusce risus ut volutpat", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 390.0, new DateTime(2023, 3, 11, 11, 25, 58, 228, DateTimeKind.Local).AddTicks(2855), 1, "Porttitor quam nec" },
                    { 41, "https://picsum.photos/seed/41/500/500", "In facilisis fermentum vel, neque lectus vestibulum, amet hac tincidunt ex, dignissim nulla ultricies vehicula", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 410.0, new DateTime(2023, 3, 11, 11, 25, 58, 228, DateTimeKind.Local).AddTicks(4801), 3, "Nibh justo ligula" },
                    { 42, "https://picsum.photos/seed/42/500/500", "Lectus feugiat integer est dolor, at, urna", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 420.0, new DateTime(2023, 3, 11, 11, 25, 58, 228, DateTimeKind.Local).AddTicks(6416), 1, "Vitae nunc dolor" },
                    { 43, "https://picsum.photos/seed/43/500/500", "Id, justo nisl lectus, in erat nunc efficitur tristique congue ligula", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 430.0, new DateTime(2023, 3, 11, 11, 25, 58, 228, DateTimeKind.Local).AddTicks(7908), 2, "Lobortis sociosqu molestie sollicitudin" },
                    { 45, "https://picsum.photos/seed/45/500/500", "Mollis nulla, at, egestas odio ipsum lorem porttitor bibendum lacinia, augue ante laoreet, fringilla, tristique", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 450.0, new DateTime(2023, 3, 11, 11, 25, 58, 229, DateTimeKind.Local).AddTicks(1499), 1, "Luctus" },
                    { 46, "https://picsum.photos/seed/46/500/500", "Sit faucibus pharetra integer ac, ligula aenean lectus, volutpat, eu, dolor, quis, ultrices porttitor, nunc himenaeos et,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 460.0, new DateTime(2023, 3, 11, 11, 25, 58, 229, DateTimeKind.Local).AddTicks(3273), 2, "Ad non laoreet himenaeos" },
                    { 47, "https://picsum.photos/seed/47/500/500", "Neque urna, nunc cursus nec, pretium conubia", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 470.0, new DateTime(2023, 3, 11, 11, 25, 58, 229, DateTimeKind.Local).AddTicks(4706), 3, "Adipiscing elementum" },
                    { 49, "https://picsum.photos/seed/49/500/500", "Bibendum, fames eros dolor massa finibus, ipsum blandit posuere, tempor, convallis quam, purus ac mollis ante", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 490.0, new DateTime(2023, 3, 11, 11, 25, 58, 229, DateTimeKind.Local).AddTicks(7145), 2, "Laoreet ante et feugiat" },
                    { 50, "https://picsum.photos/seed/50/500/500", "In id torquent rhoncus amet, dapibus pulvinar, faucibus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 500.0, new DateTime(2023, 3, 11, 11, 25, 58, 229, DateTimeKind.Local).AddTicks(8348), 3, "Per finibus malesuada porttitor" },
                    { 51, "https://picsum.photos/seed/51/500/500", "Gravida vulputate volutpat, vel, nulla habitasse nam ex", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 510.0, new DateTime(2023, 3, 11, 11, 25, 58, 229, DateTimeKind.Local).AddTicks(9347), 1, "Pulvinar neque mi" },
                    { 53, "https://picsum.photos/seed/53/500/500", "Pulvinar, aliquet", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 530.0, new DateTime(2023, 3, 11, 11, 25, 58, 230, DateTimeKind.Local).AddTicks(1401), 3, "Pulvinar vestibulum tellus vitae" },
                    { 54, "https://picsum.photos/seed/54/500/500", "Torquent venenatis ad placerat sapien fringilla nullam lobortis morbi mattis, tellus, condimentum commodo", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 540.0, new DateTime(2023, 3, 11, 11, 25, 58, 230, DateTimeKind.Local).AddTicks(2352), 1, "Habitasse" },
                    { 55, "https://picsum.photos/seed/55/500/500", "Duis a sit elit, molestie massa, sed, commodo, gravida habitasse laoreet, luctus, tincidunt sagittis, integer lacinia, nec vulputate lacinia", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 550.0, new DateTime(2023, 3, 11, 11, 25, 58, 230, DateTimeKind.Local).AddTicks(3298), 2, "Aptent" },
                    { 57, "https://picsum.photos/seed/57/500/500", "Magna, vestibulum,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 570.0, new DateTime(2023, 3, 11, 11, 25, 58, 230, DateTimeKind.Local).AddTicks(5281), 1, "Maximus" },
                    { 58, "https://picsum.photos/seed/58/500/500", "At euismod, placerat, elementum dui", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 580.0, new DateTime(2023, 3, 11, 11, 25, 58, 230, DateTimeKind.Local).AddTicks(6283), 2, "Mi enim dui posuere" },
                    { 59, "https://picsum.photos/seed/59/500/500", "Morbi nibh, sed, hendrerit malesuada vitae class in tristique", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 590.0, new DateTime(2023, 3, 11, 11, 25, 58, 230, DateTimeKind.Local).AddTicks(7188), 3, "Ipsum" },
                    { 61, "https://picsum.photos/seed/61/500/500", "Dolor, auctor,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 610.0, new DateTime(2023, 3, 11, 11, 25, 58, 230, DateTimeKind.Local).AddTicks(9695), 2, "Per" },
                    { 62, "https://picsum.photos/seed/62/500/500", "Nunc lobortis erat tellus, lectus, sagittis, fringilla aenean class", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 620.0, new DateTime(2023, 3, 11, 11, 25, 58, 231, DateTimeKind.Local).AddTicks(832), 3, "Ante ex nostra himenaeos" },
                    { 63, "https://picsum.photos/seed/63/500/500", "Eleifend, donec ante, ornare tellus ultricies pellentesque nulla scelerisque enim, erat", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 630.0, new DateTime(2023, 3, 11, 11, 25, 58, 231, DateTimeKind.Local).AddTicks(1809), 1, "Sagittis feugiat ornare nam" },
                    { 65, "https://picsum.photos/seed/65/500/500", "Nisi, eros, mattis", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 650.0, new DateTime(2023, 3, 11, 11, 25, 58, 231, DateTimeKind.Local).AddTicks(3742), 3, "Congue dictum quisque posuere" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 66, "https://picsum.photos/seed/66/500/500", "Nam porttitor", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 660.0, new DateTime(2023, 3, 11, 11, 25, 58, 231, DateTimeKind.Local).AddTicks(4829), 1, "Quis sodales a tincidunt" },
                    { 67, "https://picsum.photos/seed/67/500/500", "Nisl molestie egestas class dignissim", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 670.0, new DateTime(2023, 3, 11, 11, 25, 58, 231, DateTimeKind.Local).AddTicks(5741), 2, "Vivamus fringilla bibendum" },
                    { 69, "https://picsum.photos/seed/69/500/500", "Nulla, rhoncus at sagittis, conubia tempor, ad cursus, venenatis", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 690.0, new DateTime(2023, 3, 11, 11, 25, 58, 231, DateTimeKind.Local).AddTicks(7654), 1, "Blandit eleifend lorem et" },
                    { 70, "https://picsum.photos/seed/70/500/500", "Urna primis iaculis ullamcorper facilisis magna magna, ante pulvinar, vehicula tortor,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 700.0, new DateTime(2023, 3, 11, 11, 25, 58, 231, DateTimeKind.Local).AddTicks(8725), 2, "Fames sagittis volutpat" },
                    { 71, "https://picsum.photos/seed/71/500/500", "Vitae, nisi inceptos mollis arcu, turpis", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 710.0, new DateTime(2023, 3, 11, 11, 25, 58, 231, DateTimeKind.Local).AddTicks(9597), 3, "Ut" },
                    { 73, "https://picsum.photos/seed/73/500/500", "Congue, dictumst iaculis eget nunc et, nostra, ipsum mi imperdiet lorem, mi, luctus ante tortor ultricies", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 730.0, new DateTime(2023, 3, 11, 11, 25, 58, 232, DateTimeKind.Local).AddTicks(1448), 2, "Neque" },
                    { 74, "https://picsum.photos/seed/74/500/500", "Neque, laoreet, fusce et massa taciti", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 740.0, new DateTime(2023, 3, 11, 11, 25, 58, 232, DateTimeKind.Local).AddTicks(2383), 3, "Odio" },
                    { 75, "https://picsum.photos/seed/75/500/500", "Mi elementum vitae sem ultricies morbi blandit nostra, ornare vestibulum vel sed, dignissim convallis tortor conubia", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 750.0, new DateTime(2023, 3, 11, 11, 25, 58, 232, DateTimeKind.Local).AddTicks(3418), 1, "Ante interdum eleifend quis" },
                    { 77, "https://picsum.photos/seed/77/500/500", "Orci, dictumst lorem aptent ligula non, et luctus tristique", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 770.0, new DateTime(2023, 3, 11, 11, 25, 58, 232, DateTimeKind.Local).AddTicks(5320), 3, "Ornare a amet praesent" },
                    { 78, "https://picsum.photos/seed/78/500/500", "Turpis ex quis vitae, euismod placerat ante, sollicitudin diam dolor", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 780.0, new DateTime(2023, 3, 11, 11, 25, 58, 232, DateTimeKind.Local).AddTicks(6327), 1, "Dui aliquet porttitor" },
                    { 79, "https://picsum.photos/seed/79/500/500", "Consectetur faucibus quam in, sollicitudin primis amet tortor est torquent ac, habitasse", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 790.0, new DateTime(2023, 3, 11, 11, 25, 58, 232, DateTimeKind.Local).AddTicks(7383), 2, "At a posuere" },
                    { 81, "https://picsum.photos/seed/81/500/500", "Mauris, ligula euismod posuere, pretium posuere ornare", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 810.0, new DateTime(2023, 3, 11, 11, 25, 58, 232, DateTimeKind.Local).AddTicks(9472), 1, "Sem eu" },
                    { 82, "https://picsum.photos/seed/82/500/500", "Class nisl id, vestibulum, donec sodales eros quis, nullam volutpat, ad purus scelerisque elit vehicula eleifend,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 820.0, new DateTime(2023, 3, 11, 11, 25, 58, 233, DateTimeKind.Local).AddTicks(470), 2, "Class" },
                    { 83, "https://picsum.photos/seed/83/500/500", "Tempor, proin lacinia,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 830.0, new DateTime(2023, 3, 11, 11, 25, 58, 233, DateTimeKind.Local).AddTicks(1373), 3, "Venenatis" },
                    { 85, "https://picsum.photos/seed/85/500/500", "Nulla adipiscing class mattis purus morbi pulvinar, quis, elit ut viverra commodo risus himenaeos placerat", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 850.0, new DateTime(2023, 3, 11, 11, 25, 58, 233, DateTimeKind.Local).AddTicks(3400), 2, "Magna" },
                    { 86, "https://picsum.photos/seed/86/500/500", "Urna, dapibus erat", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 860.0, new DateTime(2023, 3, 11, 11, 25, 58, 233, DateTimeKind.Local).AddTicks(4392), 3, "Placerat amet" },
                    { 87, "https://picsum.photos/seed/87/500/500", "Pharetra taciti rhoncus feugiat feugiat, fringilla odio, nisi, lobortis est", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 870.0, new DateTime(2023, 3, 11, 11, 25, 58, 233, DateTimeKind.Local).AddTicks(5445), 1, "Justo placerat" },
                    { 89, "https://picsum.photos/seed/89/500/500", "Dictum litora cras lobortis", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 890.0, new DateTime(2023, 3, 11, 11, 25, 58, 233, DateTimeKind.Local).AddTicks(7799), 3, "Nam sagittis" },
                    { 90, "https://picsum.photos/seed/90/500/500", "Sodales nibh, et, cras nec nullam convallis dignissim", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 900.0, new DateTime(2023, 3, 11, 11, 25, 58, 233, DateTimeKind.Local).AddTicks(9046), 1, "Congue ullamcorper" },
                    { 91, "https://picsum.photos/seed/91/500/500", "Lectus efficitur augue", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 910.0, new DateTime(2023, 3, 11, 11, 25, 58, 233, DateTimeKind.Local).AddTicks(9958), 2, "Ante in auctor maecenas" },
                    { 93, "https://picsum.photos/seed/93/500/500", "Ornare odio ex donec maecenas dapibus urna viverra lorem, metus magna,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 930.0, new DateTime(2023, 3, 11, 11, 25, 58, 234, DateTimeKind.Local).AddTicks(1886), 1, "Pulvinar dictum etiam" },
                    { 94, "https://picsum.photos/seed/94/500/500", "In, tempor tortor, amet nullam urna sagittis pulvinar venenatis at praesent nisi nisi, tincidunt", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 940.0, new DateTime(2023, 3, 11, 11, 25, 58, 234, DateTimeKind.Local).AddTicks(2807), 2, "Leo erat porta" },
                    { 95, "https://picsum.photos/seed/95/500/500", "Cursus dignissim ante, tempor in, accumsan nisi nec aliquam auctor nisl lorem viverra bibendum, in neque fringilla suscipit amet,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 950.0, new DateTime(2023, 3, 11, 11, 25, 58, 234, DateTimeKind.Local).AddTicks(4006), 3, "Ornare pulvinar luctus urna" },
                    { 97, "https://picsum.photos/seed/97/500/500", "Volutpat, erat duis euismod venenatis eu, nec dui, platea orci, ultricies et", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 970.0, new DateTime(2023, 3, 11, 11, 25, 58, 234, DateTimeKind.Local).AddTicks(6637), 2, "Tincidunt lacinia" },
                    { 98, "https://picsum.photos/seed/98/500/500", "Dictum porttitor cursus, velit magna, rutrum in, tempor vitae, pulvinar, posuere nunc nostra, eros", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 980.0, new DateTime(2023, 3, 11, 11, 25, 58, 234, DateTimeKind.Local).AddTicks(7554), 3, "Feugiat" },
                    { 99, "https://picsum.photos/seed/99/500/500", "Condimentum faucibus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 990.0, new DateTime(2023, 3, 11, 11, 25, 58, 234, DateTimeKind.Local).AddTicks(8386), 1, "Ac" }
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
                    { 2, 6 },
                    { 3, 8 },
                    { 5, 2 },
                    { 6, 5 },
                    { 7, 9 },
                    { 9, 12 },
                    { 10, 3 },
                    { 11, 2 },
                    { 13, 9 },
                    { 14, 5 },
                    { 15, 3 },
                    { 17, 12 },
                    { 18, 8 },
                    { 19, 10 },
                    { 21, 5 },
                    { 22, 4 },
                    { 23, 10 },
                    { 25, 7 },
                    { 26, 9 },
                    { 27, 5 },
                    { 29, 1 },
                    { 30, 11 },
                    { 31, 6 },
                    { 33, 7 },
                    { 34, 4 },
                    { 35, 5 },
                    { 37, 9 },
                    { 38, 7 },
                    { 39, 6 },
                    { 41, 9 },
                    { 42, 12 },
                    { 43, 10 },
                    { 45, 5 },
                    { 46, 9 },
                    { 47, 1 },
                    { 49, 8 },
                    { 50, 7 },
                    { 51, 1 },
                    { 53, 4 },
                    { 54, 8 },
                    { 55, 2 }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 57, 9 },
                    { 58, 12 },
                    { 59, 12 },
                    { 61, 3 },
                    { 62, 4 },
                    { 63, 6 },
                    { 65, 5 },
                    { 66, 2 },
                    { 67, 5 },
                    { 69, 11 },
                    { 70, 9 },
                    { 71, 12 },
                    { 73, 7 },
                    { 74, 3 },
                    { 75, 3 },
                    { 77, 12 },
                    { 78, 9 },
                    { 79, 11 },
                    { 81, 2 },
                    { 82, 1 },
                    { 83, 7 },
                    { 85, 3 },
                    { 86, 6 },
                    { 87, 5 },
                    { 89, 11 },
                    { 90, 8 },
                    { 91, 7 },
                    { 93, 6 },
                    { 94, 5 },
                    { 95, 3 },
                    { 97, 7 },
                    { 98, 5 },
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
