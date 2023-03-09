using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbookStore.Data.Migrations
{
    public partial class Init : Migration
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
                    { new Guid("423e533c-d43d-4fd9-9676-e31af724522a"), "86aa0341-6cdc-45ab-bde3-2de6fd45f698", "Administrator role", "Admin", "admin" },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), "fee34bb5-9553-4d76-869d-9fa19ca6fb3c", "User role", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"), 0, "d34985dc-731f-4628-af96-749075fc901d", "user1@gmail.com", true, "Ten 1", true, "Ho 1", false, null, "user1@gmail.com", "user1", "AQAAAAEAACcQAAAAEAE9Om+5g/w3Yx67paLYmOIs6+xQ0D1m6YU8YrgOHsmlrpCT/IHTQRJ0T0u4R2V1JA==", "123456781", false, "", false, "user1" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"), 0, "bf4913c5-9b32-43ac-8af8-d9d0ef84724e", "user2@gmail.com", true, "Ten 2", true, "Ho 2", false, null, "user2@gmail.com", "user2", "AQAAAAEAACcQAAAAEFtCuhh7ST/XuF24bqDT08qJ+JzdZo4sC/62gCCmcdv7z6nQ8tieOht+uI38CVjrZA==", "123456782", false, "", false, "user2" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), 0, "ef7776ba-b936-473b-88b2-c22265ad7823", "user3@gmail.com", true, "Ten 3", true, "Ho 3", false, null, "user3@gmail.com", "user3", "AQAAAAEAACcQAAAAEKh70qqaDLyTxQ+44FOGcNVRcyL1qGkA2Of1XjGhIMy4Pm6zM9x0quSuLgqDnJKZ4g==", "123456783", false, "", false, "user3" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), 0, "4ca37ff6-18f7-4c32-8178-9fe99d78960a", "user4@gmail.com", true, "Ten 4", true, "Ho 4", false, null, "user4@gmail.com", "user4", "AQAAAAEAACcQAAAAEPQM0sbcr988P6X0FFsdV4HqISiRZ9BrFe0R4VJ4wZDXF0ESvaXjBw8RZXrFf3U0Lw==", "123456784", false, "", false, "user4" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), 0, "aa62c507-d945-43e0-af6b-d2376a4db625", "user5@gmail.com", true, "Ten 5", true, "Ho 5", false, null, "user5@gmail.com", "user5", "AQAAAAEAACcQAAAAEPPD+4h6MuBeMn8+IOiFud6r+71MMwkEX22loszzqXXYswlZNtbHY3JCraOcpvnKpQ==", "123456785", false, "", false, "user5" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), 0, "77ed627a-fe55-4afe-b16c-d8ce4a5e6ecf", "user6@gmail.com", true, "Ten 6", true, "Ho 6", false, null, "user6@gmail.com", "user6", "AQAAAAEAACcQAAAAELj1ntWO9Bf3WuEbXcMvfXQRfWSMXhzvp1m+wMRk6CK64udrq+baNCMkswq8bXEhXg==", "123456786", false, "", false, "user6" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), 0, "f94734dd-2251-4164-a86d-aa32d35fb7a8", "user7@gmail.com", true, "Ten 7", true, "Ho 7", false, null, "user7@gmail.com", "user7", "AQAAAAEAACcQAAAAENGJJJsmlAQFwzc8sj841oz3VvQKmsi5ME7RkafNZlO5ofDzMA/tGAVl+eAKeSfDAg==", "123456787", false, "", false, "user7" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), 0, "07a75ca6-b0df-4058-b83f-17251e3626b3", "user8@gmail.com", true, "Ten 8", true, "Ho 8", false, null, "user8@gmail.com", "user8", "AQAAAAEAACcQAAAAED6d+wZPd7Zljz/Z0hgEitxfKt9IiQ1s5e64IA+4tcVJpX05/lZf7kIfflKfDXZ5tg==", "123456788", false, "", false, "user8" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), 0, "b30135ac-c77b-4c1b-b541-2375da27e713", "user9@gmail.com", true, "Ten 9", true, "Ho 9", false, null, "user9@gmail.com", "user9", "AQAAAAEAACcQAAAAEEN2ekv9MDZU+9gUrhZXQ8BhsCP8ygsOpvzmRtvMRl63msGAfaamQOqVH4aOURlRoA==", "123456789", false, "", false, "user9" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), 0, "2fdd73b8-025a-4b99-9b68-e91a340aa215", "user10@gmail.com", true, "Ten 10", true, "Ho 10", false, null, "user10@gmail.com", "user10", "AQAAAAEAACcQAAAAEBZK4nFtYPtDRU4cz3QZN7i16T3AgO+Vs+w4lFhLnUqV6QjL0OebGbYziONyXeYPBg==", "1234567810", false, "", false, "user10" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 4, "https://picsum.photos/seed/4/200/300", "Nibh leo leo, congue blandit eu, proin volutpat sed mauris, id elit placerat urna", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 40.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(7773), null, "Commodo taciti praesent" },
                    { 8, "https://picsum.photos/seed/8/200/300", "Sollicitudin amet, malesuada orci, elit vestibulum ornare enim, nullam porta quam volutpat, semper platea mollis leo, risus rhoncus, hendrerit", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 80.0, new DateTime(2023, 3, 7, 11, 21, 54, 264, DateTimeKind.Local).AddTicks(1315), null, "Dictumst" },
                    { 12, "https://picsum.photos/seed/12/200/300", "Ipsum eget efficitur porttitor, suspendisse quisque euismod et,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 120.0, new DateTime(2023, 3, 7, 11, 21, 54, 264, DateTimeKind.Local).AddTicks(4705), null, "Neque" },
                    { 16, "https://picsum.photos/seed/16/200/300", "Ac, et, quis euismod porta himenaeos finibus vitae, congue, ex, aptent enim, leo", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 160.0, new DateTime(2023, 3, 7, 11, 21, 54, 264, DateTimeKind.Local).AddTicks(8291), null, "Dictumst hendrerit ullamcorper" },
                    { 20, "https://picsum.photos/seed/20/200/300", "Sagittis, eu, libero hendrerit", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 200.0, new DateTime(2023, 3, 7, 11, 21, 54, 265, DateTimeKind.Local).AddTicks(1716), null, "Fermentum eleifend" },
                    { 24, "https://picsum.photos/seed/24/200/300", "In pulvinar, nunc, ex, sapien commodo, ac, tristique risus ultrices class non arcu libero non, mollis", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 240.0, new DateTime(2023, 3, 7, 11, 21, 54, 265, DateTimeKind.Local).AddTicks(5357), null, "Hac fames" },
                    { 28, "https://picsum.photos/seed/28/200/300", "Nunc, tempor, sem, posuere ligula finibus quam lectus, placerat, nisi et", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 280.0, new DateTime(2023, 3, 7, 11, 21, 54, 265, DateTimeKind.Local).AddTicks(8817), null, "Etiam pulvinar mi quis" },
                    { 32, "https://picsum.photos/seed/32/200/300", "Tempor, molestie rhoncus erat, dictumst primis egestas ac mauris tempus fames aptent", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 320.0, new DateTime(2023, 3, 7, 11, 21, 54, 266, DateTimeKind.Local).AddTicks(2329), null, "Ante mauris urna hendrerit" },
                    { 36, "https://picsum.photos/seed/36/200/300", "Nam egestas ultrices, in feugiat nibh porttitor a, gravida ad tempor, vestibulum, nulla amet tellus congue suscipit finibus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 360.0, new DateTime(2023, 3, 7, 11, 21, 54, 266, DateTimeKind.Local).AddTicks(5589), null, "Hac congue sem amet" },
                    { 40, "https://picsum.photos/seed/40/200/300", "Mauris, ligula, consequat", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 400.0, new DateTime(2023, 3, 7, 11, 21, 54, 266, DateTimeKind.Local).AddTicks(9258), null, "Cursus convallis" },
                    { 44, "https://picsum.photos/seed/44/200/300", "Iaculis nec tristique pulvinar amet, neque et ornare lacinia", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 440.0, new DateTime(2023, 3, 7, 11, 21, 54, 267, DateTimeKind.Local).AddTicks(2984), null, "Quam vitae" },
                    { 48, "https://picsum.photos/seed/48/200/300", "Posuere, finibus, torquent viverra lorem malesuada taciti nam convallis neque,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 480.0, new DateTime(2023, 3, 7, 11, 21, 54, 267, DateTimeKind.Local).AddTicks(6618), null, "Placerat proin" },
                    { 52, "https://picsum.photos/seed/52/200/300", "Pharetra vestibulum,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 520.0, new DateTime(2023, 3, 7, 11, 21, 54, 268, DateTimeKind.Local).AddTicks(99), null, "Sem ad feugiat" },
                    { 56, "https://picsum.photos/seed/56/200/300", "Consectetur bibendum, maecenas nisl sem, dictumst eget ac sapien turpis nulla efficitur", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 560.0, new DateTime(2023, 3, 7, 11, 21, 54, 268, DateTimeKind.Local).AddTicks(3654), null, "Aptent vehicula eu pretium" },
                    { 60, "https://picsum.photos/seed/60/200/300", "Quis pulvinar eu fringilla dolor erat, magna luctus luctus, praesent erat auctor volutpat adipiscing at tristique velit ante quam", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 600.0, new DateTime(2023, 3, 7, 11, 21, 54, 268, DateTimeKind.Local).AddTicks(7139), null, "Amet placerat porttitor sed" },
                    { 64, "https://picsum.photos/seed/64/200/300", "Habitasse morbi nec lorem ante, consectetur neque, nulla, rhoncus, dignissim id", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 640.0, new DateTime(2023, 3, 7, 11, 21, 54, 269, DateTimeKind.Local).AddTicks(477), null, "Enim commodo odio aliquet" },
                    { 68, "https://picsum.photos/seed/68/200/300", "Dui, nam", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 680.0, new DateTime(2023, 3, 7, 11, 21, 54, 269, DateTimeKind.Local).AddTicks(3998), null, "Leo eros interdum bibendum" },
                    { 72, "https://picsum.photos/seed/72/200/300", "Condimentum faucibus rhoncus, sagittis enim, per pulvinar, non lacinia, pellentesque interdum, maximus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 720.0, new DateTime(2023, 3, 7, 11, 21, 54, 269, DateTimeKind.Local).AddTicks(7289), null, "Ullamcorper" },
                    { 76, "https://picsum.photos/seed/76/200/300", "Ex quam elit, tortor", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 760.0, new DateTime(2023, 3, 7, 11, 21, 54, 270, DateTimeKind.Local).AddTicks(885), null, "Nibh" },
                    { 80, "https://picsum.photos/seed/80/200/300", "Cursus,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 800.0, new DateTime(2023, 3, 7, 11, 21, 54, 270, DateTimeKind.Local).AddTicks(4486), null, "Metus velit tortor" },
                    { 84, "https://picsum.photos/seed/84/200/300", "Augue aliquet aenean ultricies aliquam elit, nulla accumsan porttitor, a, ac, ex, maecenas rhoncus erat,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 840.0, new DateTime(2023, 3, 7, 11, 21, 54, 270, DateTimeKind.Local).AddTicks(8037), null, "Vulputate tempor" },
                    { 88, "https://picsum.photos/seed/88/200/300", "Commodo nulla placerat, convallis sollicitudin fermentum dictumst quis arcu,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 880.0, new DateTime(2023, 3, 7, 11, 21, 54, 271, DateTimeKind.Local).AddTicks(1415), null, "Sit quis mollis" },
                    { 92, "https://picsum.photos/seed/92/200/300", "Arcu velit magna, cursus proin ultrices,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 920.0, new DateTime(2023, 3, 7, 11, 21, 54, 271, DateTimeKind.Local).AddTicks(4828), null, "Maximus tristique" },
                    { 96, "https://picsum.photos/seed/96/200/300", "Praesent mollis porttitor, accumsan curabitur urna, posuere tempor, bibendum, consequat", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 960.0, new DateTime(2023, 3, 7, 11, 21, 54, 271, DateTimeKind.Local).AddTicks(8300), null, "Ipsum vehicula eu laoreet" },
                    { 100, "https://picsum.photos/seed/100/200/300", "Dapibus habitasse fringilla vitae nam quam volutpat, commodo, nisi", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 1000.0, new DateTime(2023, 3, 7, 11, 21, 54, 272, DateTimeKind.Local).AddTicks(1682), null, "Orci" }
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
                    { 1, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(5213), "Proin efficitur amet rutrum", 20.0, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(5202) },
                    { 2, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(5828), "Taciti magna fames", 10.0, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(5827) },
                    { 3, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(6415), "Magna", 20.0, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(6414) },
                    { 4, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(6940), "Interdum primis", 40.0, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(6939) },
                    { 5, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(7410), "Amet mattis", 40.0, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(7410) },
                    { 6, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(7940), "Amet tempus nulla rhoncus", 10.0, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(7940) },
                    { 7, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(8376), "Conubia maecenas lacus porttitor", 10.0, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(8375) },
                    { 8, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(8887), "Nunc rutrum nostra pulvinar", 10.0, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(8886) },
                    { 9, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(9386), "Consectetur quis eleifend mi", 30.0, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(9386) },
                    { 10, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(9845), "Platea hac purus", 20.0, new DateTime(2023, 3, 7, 11, 21, 54, 262, DateTimeKind.Local).AddTicks(9844) },
                    { 11, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(284), "Tellus tempus", 30.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(284) },
                    { 12, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(728), "Nullam at", 30.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(728) },
                    { 13, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(1183), "Tortor conubia dictum cursus", 40.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(1182) },
                    { 14, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(1640), "Porttitor imperdiet", 40.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(1640) },
                    { 15, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(2107), "Risus et fringilla tellus", 20.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(2106) },
                    { 16, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(2532), "Sagittis", 40.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(2531) },
                    { 17, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(2939), "Suscipit molestie curabitur convallis", 40.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(2938) },
                    { 18, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(3367), "Porta velit bibendum id", 20.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(3366) },
                    { 19, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(3823), "Eros duis", 30.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(3822) },
                    { 20, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(4207), "Platea", 10.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(4207) }
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
                    { 4, 3 },
                    { 8, 10 },
                    { 12, 2 },
                    { 16, 5 },
                    { 20, 7 },
                    { 24, 4 },
                    { 28, 11 },
                    { 32, 9 },
                    { 36, 8 },
                    { 40, 11 },
                    { 44, 10 },
                    { 48, 12 },
                    { 52, 6 },
                    { 56, 10 },
                    { 60, 3 },
                    { 64, 5 },
                    { 68, 12 },
                    { 72, 12 },
                    { 76, 10 },
                    { 80, 7 },
                    { 84, 2 },
                    { 88, 2 },
                    { 92, 11 },
                    { 96, 4 },
                    { 100, 10 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 1, "https://picsum.photos/seed/1/200/300", "Iaculis praesent euismod, enim, amet sed hac tincidunt imperdiet urna pharetra in", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 10.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(5118), 2, "Faucibus pulvinar" },
                    { 2, "https://picsum.photos/seed/2/200/300", "Lectus primis sed, tristique", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 20.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(6000), 3, "Quis consequat tellus" },
                    { 3, "https://picsum.photos/seed/3/200/300", "Bibendum dignissim sagittis tincidunt nec, lectus, id, ex fringilla fames", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 30.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(6938), 1, "Sagittis varius eleifend class" },
                    { 5, "https://picsum.photos/seed/5/200/300", "Congue augue eros", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 50.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(8567), 3, "Mollis enim" },
                    { 6, "https://picsum.photos/seed/6/200/300", "Arcu nunc, viverra leo, luctus sapien et auctor tincidunt nam malesuada quis, nisi, vivamus nibh, ultrices, sit adipiscing elementum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 60.0, new DateTime(2023, 3, 7, 11, 21, 54, 263, DateTimeKind.Local).AddTicks(9444), 1, "Porta" },
                    { 7, "https://picsum.photos/seed/7/200/300", "Fermentum porttitor tellus, tellus ac consectetur mi, in arcu tortor, taciti diam", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 70.0, new DateTime(2023, 3, 7, 11, 21, 54, 264, DateTimeKind.Local).AddTicks(421), 2, "Quisque facilisis" },
                    { 9, "https://picsum.photos/seed/9/200/300", "Vestibulum, libero proin efficitur ultrices, interdum posuere, bibendum, lorem aenean in", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 90.0, new DateTime(2023, 3, 7, 11, 21, 54, 264, DateTimeKind.Local).AddTicks(2127), 1, "Eleifend" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 10, "https://picsum.photos/seed/10/200/300", "Quam, duis a, amet, praesent ex, nisi lacus dolor odio, dignissim commodo, ultrices, sem risus purus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 100.0, new DateTime(2023, 3, 7, 11, 21, 54, 264, DateTimeKind.Local).AddTicks(2994), 2, "Arcu" },
                    { 11, "https://picsum.photos/seed/11/200/300", "Fringilla, vel, scelerisque rhoncus, leo hendrerit ligula, urna fermentum posuere, fringilla facilisis finibus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 110.0, new DateTime(2023, 3, 7, 11, 21, 54, 264, DateTimeKind.Local).AddTicks(3869), 3, "Phasellus" },
                    { 13, "https://picsum.photos/seed/13/200/300", "Conubia pulvinar torquent varius rhoncus, eleifend, tellus adipiscing sodales rutrum in ligula venenatis sociosqu velit consequat per lectus,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 130.0, new DateTime(2023, 3, 7, 11, 21, 54, 264, DateTimeKind.Local).AddTicks(5523), 2, "Blandit mattis commodo velit" },
                    { 14, "https://picsum.photos/seed/14/200/300", "Nulla interdum, at,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 140.0, new DateTime(2023, 3, 7, 11, 21, 54, 264, DateTimeKind.Local).AddTicks(6382), 3, "Lorem vestibulum" },
                    { 15, "https://picsum.photos/seed/15/200/300", "Nulla, maecenas pretium congue integer consequat in, justo quis vivamus aliquam tellus, tellus id, volutpat", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 150.0, new DateTime(2023, 3, 7, 11, 21, 54, 264, DateTimeKind.Local).AddTicks(7305), 1, "Himenaeos fringilla lectus sociosqu" },
                    { 17, "https://picsum.photos/seed/17/200/300", "Nulla, proin consectetur mollis ac, vulputate", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 170.0, new DateTime(2023, 3, 7, 11, 21, 54, 264, DateTimeKind.Local).AddTicks(9144), 3, "Tempor erat commodo" },
                    { 18, "https://picsum.photos/seed/18/200/300", "Odio, mattis, tempus ligula justo maximus viverra sociosqu in finibus, fringilla auctor,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 180.0, new DateTime(2023, 3, 7, 11, 21, 54, 265, DateTimeKind.Local).AddTicks(45), 1, "Gravida phasellus" },
                    { 19, "https://picsum.photos/seed/19/200/300", "Est porta, nisi accumsan tortor tellus, mattis,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 190.0, new DateTime(2023, 3, 7, 11, 21, 54, 265, DateTimeKind.Local).AddTicks(824), 2, "Lorem" },
                    { 21, "https://picsum.photos/seed/21/200/300", "Eget adipiscing luctus, ad urna, rhoncus, velit lorem,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 210.0, new DateTime(2023, 3, 7, 11, 21, 54, 265, DateTimeKind.Local).AddTicks(2595), 1, "Ligula himenaeos leo lacinia" },
                    { 22, "https://picsum.photos/seed/22/200/300", "Porttitor, inceptos efficitur adipiscing vitae, id, gravida orci,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 220.0, new DateTime(2023, 3, 7, 11, 21, 54, 265, DateTimeKind.Local).AddTicks(3491), 2, "Donec magna malesuada" },
                    { 23, "https://picsum.photos/seed/23/200/300", "Ligula et, quis ac ipsum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 230.0, new DateTime(2023, 3, 7, 11, 21, 54, 265, DateTimeKind.Local).AddTicks(4370), 3, "Elementum nisi torquent" },
                    { 25, "https://picsum.photos/seed/25/200/300", "Volutpat porttitor elit, blandit porta justo viverra leo, faucibus nulla, laoreet dignissim suspendisse vel ut consequat nisi", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 250.0, new DateTime(2023, 3, 7, 11, 21, 54, 265, DateTimeKind.Local).AddTicks(6260), 2, "Torquent nisl pulvinar" },
                    { 26, "https://picsum.photos/seed/26/200/300", "Vestibulum vehicula mi, faucibus varius, arcu, habitasse interdum, dictum massa, vivamus placerat", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 260.0, new DateTime(2023, 3, 7, 11, 21, 54, 265, DateTimeKind.Local).AddTicks(7085), 3, "A vestibulum euismod odio" },
                    { 27, "https://picsum.photos/seed/27/200/300", "Integer bibendum, tempus vestibulum, leo, velit finibus mauris ligula, convallis enim, taciti finibus, elementum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 270.0, new DateTime(2023, 3, 7, 11, 21, 54, 265, DateTimeKind.Local).AddTicks(7939), 1, "Urna non adipiscing egestas" },
                    { 29, "https://picsum.photos/seed/29/200/300", "Finibus, ex nunc, efficitur elit a, eleifend, aliquam augue", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 290.0, new DateTime(2023, 3, 7, 11, 21, 54, 265, DateTimeKind.Local).AddTicks(9701), 3, "Vel taciti enim" },
                    { 30, "https://picsum.photos/seed/30/200/300", "Quis venenatis habitasse dui convallis vel nec, vitae dignissim purus posuere, egestas fusce vulputate", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 300.0, new DateTime(2023, 3, 7, 11, 21, 54, 266, DateTimeKind.Local).AddTicks(561), 1, "Habitasse per gravida" },
                    { 31, "https://picsum.photos/seed/31/200/300", "Feugiat dapibus amet tortor mauris, orci platea ac", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 310.0, new DateTime(2023, 3, 7, 11, 21, 54, 266, DateTimeKind.Local).AddTicks(1443), 2, "Maximus a" },
                    { 33, "https://picsum.photos/seed/33/200/300", "Consectetur ultrices, interdum, donec ac, hendrerit fringilla, lacinia sed congue, dolor,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 330.0, new DateTime(2023, 3, 7, 11, 21, 54, 266, DateTimeKind.Local).AddTicks(3131), 1, "Amet" },
                    { 34, "https://picsum.photos/seed/34/200/300", "Fusce diam bibendum aliquam tristique donec", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 340.0, new DateTime(2023, 3, 7, 11, 21, 54, 266, DateTimeKind.Local).AddTicks(3903), 2, "Enim" },
                    { 35, "https://picsum.photos/seed/35/200/300", "Diam tellus,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 350.0, new DateTime(2023, 3, 7, 11, 21, 54, 266, DateTimeKind.Local).AddTicks(4745), 3, "Eleifend dui" },
                    { 37, "https://picsum.photos/seed/37/200/300", "Porttitor, pulvinar, interdum, ultrices, conubia nec, in mi congue, fringilla, nibh aliquam suscipit ex,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 370.0, new DateTime(2023, 3, 7, 11, 21, 54, 266, DateTimeKind.Local).AddTicks(6617), 2, "Nulla ligula eros porttitor" },
                    { 38, "https://picsum.photos/seed/38/200/300", "Vulputate sagittis, imperdiet elit, hendrerit vel, libero ante, quis, volutpat, aliquam torquent scelerisque eu", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 380.0, new DateTime(2023, 3, 7, 11, 21, 54, 266, DateTimeKind.Local).AddTicks(7457), 3, "Tristique" },
                    { 39, "https://picsum.photos/seed/39/200/300", "Dignissim pulvinar lectus, pellentesque ante at, convallis maximus viverra dui, odio", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 390.0, new DateTime(2023, 3, 7, 11, 21, 54, 266, DateTimeKind.Local).AddTicks(8348), 1, "Ullamcorper dapibus sagittis" },
                    { 41, "https://picsum.photos/seed/41/200/300", "Risus cursus, sagittis consectetur ligula odio nostra, pharetra eleifend urna, nullam lobortis tristique ullamcorper eu magna", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 410.0, new DateTime(2023, 3, 7, 11, 21, 54, 267, DateTimeKind.Local).AddTicks(210), 3, "Placerat vulputate" },
                    { 42, "https://picsum.photos/seed/42/200/300", "Efficitur rhoncus, nostra, pulvinar faucibus viverra facilisis nec arcu interdum torquent feugiat, et, elit, fames", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 420.0, new DateTime(2023, 3, 7, 11, 21, 54, 267, DateTimeKind.Local).AddTicks(1034), 1, "Tempor hendrerit dui tempus" },
                    { 43, "https://picsum.photos/seed/43/200/300", "Fringilla ex congue turpis aenean varius, fermentum diam malesuada class interdum, laoreet eleifend,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 430.0, new DateTime(2023, 3, 7, 11, 21, 54, 267, DateTimeKind.Local).AddTicks(2008), 2, "Porttitor interdum" },
                    { 45, "https://picsum.photos/seed/45/200/300", "Diam vitae ullamcorper", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 450.0, new DateTime(2023, 3, 7, 11, 21, 54, 267, DateTimeKind.Local).AddTicks(3951), 1, "Magna fames" },
                    { 46, "https://picsum.photos/seed/46/200/300", "Morbi mi, nisi eros eu condimentum in ligula, consectetur nec rhoncus,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 460.0, new DateTime(2023, 3, 7, 11, 21, 54, 267, DateTimeKind.Local).AddTicks(4885), 2, "Non tortor class" },
                    { 47, "https://picsum.photos/seed/47/200/300", "Euismod, suscipit dui dignissim vestibulum, eu ultrices,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 470.0, new DateTime(2023, 3, 7, 11, 21, 54, 267, DateTimeKind.Local).AddTicks(5750), 3, "Ad dolor orci" },
                    { 49, "https://picsum.photos/seed/49/200/300", "A bibendum, sed, nullam odio, non, libero quisque semper ultrices", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 490.0, new DateTime(2023, 3, 7, 11, 21, 54, 267, DateTimeKind.Local).AddTicks(7511), 2, "Leo cursus sem" },
                    { 50, "https://picsum.photos/seed/50/200/300", "Interdum, ex, consequat imperdiet leo tempus fames sapien rhoncus, fermentum id, in", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 500.0, new DateTime(2023, 3, 7, 11, 21, 54, 267, DateTimeKind.Local).AddTicks(8362), 3, "Commodo in dictumst fermentum" },
                    { 51, "https://picsum.photos/seed/51/200/300", "Imperdiet sodales suspendisse rutrum mattis lobortis aliquam massa enim,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 510.0, new DateTime(2023, 3, 7, 11, 21, 54, 267, DateTimeKind.Local).AddTicks(9223), 1, "Aptent" },
                    { 53, "https://picsum.photos/seed/53/200/300", "Massa enim blandit non, scelerisque ligula malesuada", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 530.0, new DateTime(2023, 3, 7, 11, 21, 54, 268, DateTimeKind.Local).AddTicks(926), 3, "Eros ligula posuere suspendisse" },
                    { 54, "https://picsum.photos/seed/54/200/300", "Nulla per dolor sem ipsum scelerisque lobortis id lectus nullam feugiat donec mattis, porta, est magna ac congue, in", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 540.0, new DateTime(2023, 3, 7, 11, 21, 54, 268, DateTimeKind.Local).AddTicks(1848), 1, "Condimentum" },
                    { 55, "https://picsum.photos/seed/55/200/300", "Sed id dictum volutpat bibendum placerat sagittis ultrices orci, quam turpis non, inceptos mattis, lacinia lorem erat", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 550.0, new DateTime(2023, 3, 7, 11, 21, 54, 268, DateTimeKind.Local).AddTicks(2727), 2, "Sapien quam feugiat" },
                    { 57, "https://picsum.photos/seed/57/200/300", "Dolor, hendrerit vel, interdum, blandit", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 570.0, new DateTime(2023, 3, 7, 11, 21, 54, 268, DateTimeKind.Local).AddTicks(4517), 1, "Nibh massa" },
                    { 58, "https://picsum.photos/seed/58/200/300", "Ex, nisi, eleifend, tortor, suscipit vestibulum, dictum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 580.0, new DateTime(2023, 3, 7, 11, 21, 54, 268, DateTimeKind.Local).AddTicks(5378), 2, "Id" },
                    { 59, "https://picsum.photos/seed/59/200/300", "Sed, elit, nulla commodo, tempor a, dui, aenean ut", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 590.0, new DateTime(2023, 3, 7, 11, 21, 54, 268, DateTimeKind.Local).AddTicks(6189), 3, "Et" },
                    { 61, "https://picsum.photos/seed/61/200/300", "Sagittis, accumsan taciti conubia quisque himenaeos interdum finibus,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 610.0, new DateTime(2023, 3, 7, 11, 21, 54, 268, DateTimeKind.Local).AddTicks(7936), 2, "Arcu" },
                    { 62, "https://picsum.photos/seed/62/200/300", "Duis aliquam fames facilisis magna erat nulla orci, dapibus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 620.0, new DateTime(2023, 3, 7, 11, 21, 54, 268, DateTimeKind.Local).AddTicks(8843), 3, "Purus blandit" },
                    { 63, "https://picsum.photos/seed/63/200/300", "Vestibulum,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 630.0, new DateTime(2023, 3, 7, 11, 21, 54, 268, DateTimeKind.Local).AddTicks(9599), 1, "Ante" },
                    { 65, "https://picsum.photos/seed/65/200/300", "Porttitor, aptent dictumst sagittis faucibus nullam maximus lobortis finibus viverra iaculis pulvinar condimentum ac, aliquet", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 650.0, new DateTime(2023, 3, 7, 11, 21, 54, 269, DateTimeKind.Local).AddTicks(1442), 3, "Consectetur posuere pulvinar elit" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 66, "https://picsum.photos/seed/66/200/300", "Torquent ac maecenas finibus enim, erat, interdum, dui, at, vel, hendrerit curabitur convallis suscipit nulla auctor, cursus suspendisse iaculis", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 660.0, new DateTime(2023, 3, 7, 11, 21, 54, 269, DateTimeKind.Local).AddTicks(2271), 1, "Posuere hac" },
                    { 67, "https://picsum.photos/seed/67/200/300", "Id, justo donec tellus, laoreet, conubia vel varius, duis pulvinar, libero venenatis morbi augue", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 670.0, new DateTime(2023, 3, 7, 11, 21, 54, 269, DateTimeKind.Local).AddTicks(3116), 2, "Vel feugiat" },
                    { 69, "https://picsum.photos/seed/69/200/300", "Faucibus bibendum, eleifend neque, enim id", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 690.0, new DateTime(2023, 3, 7, 11, 21, 54, 269, DateTimeKind.Local).AddTicks(4830), 1, "Bibendum ligula nibh" },
                    { 70, "https://picsum.photos/seed/70/200/300", "Fusce dignissim consectetur", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 700.0, new DateTime(2023, 3, 7, 11, 21, 54, 269, DateTimeKind.Local).AddTicks(5646), 2, "Maecenas mauris" },
                    { 71, "https://picsum.photos/seed/71/200/300", "Nibh", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 710.0, new DateTime(2023, 3, 7, 11, 21, 54, 269, DateTimeKind.Local).AddTicks(6427), 3, "Fames" },
                    { 73, "https://picsum.photos/seed/73/200/300", "Maximus eros, turpis himenaeos ligula, libero ac inceptos elementum tincidunt", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 730.0, new DateTime(2023, 3, 7, 11, 21, 54, 269, DateTimeKind.Local).AddTicks(8244), 2, "Massa urna" },
                    { 74, "https://picsum.photos/seed/74/200/300", "Tempor, tincidunt eu eleifend auctor, amet, magna, justo imperdiet posuere faucibus lacinia", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 740.0, new DateTime(2023, 3, 7, 11, 21, 54, 269, DateTimeKind.Local).AddTicks(9086), 3, "Tristique" },
                    { 75, "https://picsum.photos/seed/75/200/300", "Convallis porttitor rutrum in, porta, quis, tellus, rhoncus, quam non massa at, tempor, augue", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 750.0, new DateTime(2023, 3, 7, 11, 21, 54, 270, DateTimeKind.Local).AddTicks(11), 1, "Donec libero eu" },
                    { 77, "https://picsum.photos/seed/77/200/300", "Metus habitasse magna", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 770.0, new DateTime(2023, 3, 7, 11, 21, 54, 270, DateTimeKind.Local).AddTicks(1820), 3, "Leo fames" },
                    { 78, "https://picsum.photos/seed/78/200/300", "Rutrum quam, inceptos ultrices egestas purus nisi, sed congue", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 780.0, new DateTime(2023, 3, 7, 11, 21, 54, 270, DateTimeKind.Local).AddTicks(2718), 1, "Enim nostra" },
                    { 79, "https://picsum.photos/seed/79/200/300", "Lacinia, facilisis fringilla, semper massa eget sem, sed, cursus euismod, vel, magna, aliquam adipiscing phasellus morbi suscipit in, bibendum,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 790.0, new DateTime(2023, 3, 7, 11, 21, 54, 270, DateTimeKind.Local).AddTicks(3644), 2, "Dui aliquet" },
                    { 81, "https://picsum.photos/seed/81/200/300", "Cursus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 810.0, new DateTime(2023, 3, 7, 11, 21, 54, 270, DateTimeKind.Local).AddTicks(5282), 1, "Laoreet nec porttitor tempus" },
                    { 82, "https://picsum.photos/seed/82/200/300", "Class etiam tempor, sem praesent aliquam nunc, metus vitae inceptos augue", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 820.0, new DateTime(2023, 3, 7, 11, 21, 54, 270, DateTimeKind.Local).AddTicks(6199), 2, "Porta ex diam" },
                    { 83, "https://picsum.photos/seed/83/200/300", "Nisi, ex, odio, morbi placerat, lacinia, rhoncus, orci elit, hendrerit", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 830.0, new DateTime(2023, 3, 7, 11, 21, 54, 270, DateTimeKind.Local).AddTicks(7097), 3, "Mi ante" },
                    { 85, "https://picsum.photos/seed/85/200/300", "Ultrices semper laoreet, fames mi luctus maecenas finibus, lacus justo taciti dolor ante lectus,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 850.0, new DateTime(2023, 3, 7, 11, 21, 54, 270, DateTimeKind.Local).AddTicks(8870), 2, "Lacinia elit tellus" },
                    { 86, "https://picsum.photos/seed/86/200/300", "Luctus platea porta, mi consequat", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 860.0, new DateTime(2023, 3, 7, 11, 21, 54, 270, DateTimeKind.Local).AddTicks(9759), 3, "Nostra" },
                    { 87, "https://picsum.photos/seed/87/200/300", "Vestibulum, tortor semper quis, tempor ante nibh luctus in neque", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 870.0, new DateTime(2023, 3, 7, 11, 21, 54, 271, DateTimeKind.Local).AddTicks(568), 1, "Finibus cursus urna magna" },
                    { 89, "https://picsum.photos/seed/89/200/300", "Ante varius, auctor aliquet hac praesent tellus aliquam sem vel blandit inceptos lectus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 890.0, new DateTime(2023, 3, 7, 11, 21, 54, 271, DateTimeKind.Local).AddTicks(2255), 3, "Accumsan aenean justo nunc" },
                    { 90, "https://picsum.photos/seed/90/200/300", "Cursus tempor a orci tortor, sagittis augue dignissim eros, platea lacus sociosqu feugiat, pulvinar", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 900.0, new DateTime(2023, 3, 7, 11, 21, 54, 271, DateTimeKind.Local).AddTicks(3132), 1, "Mollis lectus risus" },
                    { 91, "https://picsum.photos/seed/91/200/300", "Fames quis, ornare neque", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 910.0, new DateTime(2023, 3, 7, 11, 21, 54, 271, DateTimeKind.Local).AddTicks(3982), 2, "Dictum feugiat congue facilisis" },
                    { 93, "https://picsum.photos/seed/93/200/300", "Elementum vulputate massa, posuere interdum, tempor, habitasse libero sagittis, convallis rhoncus consectetur", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 930.0, new DateTime(2023, 3, 7, 11, 21, 54, 271, DateTimeKind.Local).AddTicks(5662), 1, "Eleifend nulla proin" },
                    { 94, "https://picsum.photos/seed/94/200/300", "Ac in,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 940.0, new DateTime(2023, 3, 7, 11, 21, 54, 271, DateTimeKind.Local).AddTicks(6536), 2, "Massa gravida" },
                    { 95, "https://picsum.photos/seed/95/200/300", "Fermentum ultrices, pulvinar iaculis sem nullam aliquet fringilla, lacinia", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 950.0, new DateTime(2023, 3, 7, 11, 21, 54, 271, DateTimeKind.Local).AddTicks(7474), 3, "Malesuada in sed condimentum" },
                    { 97, "https://picsum.photos/seed/97/200/300", "Ac, purus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 970.0, new DateTime(2023, 3, 7, 11, 21, 54, 271, DateTimeKind.Local).AddTicks(9156), 2, "Commodo donec condimentum rhoncus" },
                    { 98, "https://picsum.photos/seed/98/200/300", "Sociosqu mattis, molestie tellus, orci, eu, lorem elementum euismod vivamus nisi, sem consectetur vestibulum, arcu fusce dui, a euismod,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 980.0, new DateTime(2023, 3, 7, 11, 21, 54, 272, DateTimeKind.Local).AddTicks(22), 3, "Odio sed gravida" },
                    { 99, "https://picsum.photos/seed/99/200/300", "Et, accumsan facilisis aptent vitae, torquent porttitor a euismod nullam semper euismod, consequat sollicitudin", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 990.0, new DateTime(2023, 3, 7, 11, 21, 54, 272, DateTimeKind.Local).AddTicks(893), 1, "Nunc sapien pellentesque" }
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
                    { 1, 3 },
                    { 2, 6 },
                    { 3, 8 },
                    { 5, 8 },
                    { 6, 8 },
                    { 7, 11 },
                    { 9, 7 },
                    { 10, 9 },
                    { 11, 6 },
                    { 13, 6 },
                    { 14, 10 },
                    { 15, 8 },
                    { 17, 9 },
                    { 18, 5 },
                    { 19, 5 },
                    { 21, 9 },
                    { 22, 4 },
                    { 23, 7 },
                    { 25, 5 },
                    { 26, 2 },
                    { 27, 12 },
                    { 29, 6 },
                    { 30, 1 },
                    { 31, 4 },
                    { 33, 11 },
                    { 34, 3 },
                    { 35, 12 },
                    { 37, 7 },
                    { 38, 7 },
                    { 39, 10 },
                    { 41, 6 },
                    { 42, 3 },
                    { 43, 8 },
                    { 45, 5 },
                    { 46, 7 },
                    { 47, 7 },
                    { 49, 5 },
                    { 50, 2 },
                    { 51, 6 },
                    { 53, 11 },
                    { 54, 12 },
                    { 55, 6 }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 57, 12 },
                    { 58, 5 },
                    { 59, 2 },
                    { 61, 3 },
                    { 62, 12 },
                    { 63, 1 },
                    { 65, 5 },
                    { 66, 2 },
                    { 67, 7 },
                    { 69, 4 },
                    { 70, 3 },
                    { 71, 8 },
                    { 73, 5 },
                    { 74, 5 },
                    { 75, 8 },
                    { 77, 1 },
                    { 78, 10 },
                    { 79, 7 },
                    { 81, 10 },
                    { 82, 10 },
                    { 83, 1 },
                    { 85, 4 },
                    { 86, 9 },
                    { 87, 8 },
                    { 89, 6 },
                    { 90, 8 },
                    { 91, 3 },
                    { 93, 9 },
                    { 94, 3 },
                    { 95, 11 },
                    { 97, 11 },
                    { 98, 11 },
                    { 99, 10 }
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
