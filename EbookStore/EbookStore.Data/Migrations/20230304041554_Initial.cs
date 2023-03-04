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
                    { new Guid("423e533c-d43d-4fd9-9676-e31af724522a"), "6db9b339-79e2-4ee0-88e4-96dd5970f555", "Administrator role", "Admin", "admin" },
                    { new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"), "00b0f969-002c-43e9-a59f-be4e49451d36", "User role", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"), 0, "3d997d9f-a44b-4c27-971a-d27712902e1c", "user1@gmail.com", true, "Ten 1", true, "Ho 1", false, null, "user1@gmail.com", "user1", "AQAAAAEAACcQAAAAENp89zhICWH4GB22SyUjEuZzQbDXeY4dpDrjFOzSj1rx23BsGl2NxvrCoWAsg13dfw==", "123456781", false, "", false, "user1" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"), 0, "7eb70871-f7e8-4172-a189-b9303e38041c", "user2@gmail.com", true, "Ten 2", true, "Ho 2", false, null, "user2@gmail.com", "user2", "AQAAAAEAACcQAAAAEDOtTXxe8Q6MXvYK37JeTGud4tqT5H53AGC3I7fwrkQ3voRgbxaioUlXZyHV/MWAEw==", "123456782", false, "", false, "user2" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"), 0, "b87a0cc3-b8b1-4222-86d3-0fb78337b7b3", "user3@gmail.com", true, "Ten 3", true, "Ho 3", false, null, "user3@gmail.com", "user3", "AQAAAAEAACcQAAAAELLvoGQsb7PPO577/8hsa4g1whYS/6aUTpOmBqkx7OQq3uqgqA7kMmJ0ycOUSg2pXQ==", "123456783", false, "", false, "user3" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"), 0, "f6adcf9e-fd01-4298-b523-bd0cf9297772", "user4@gmail.com", true, "Ten 4", true, "Ho 4", false, null, "user4@gmail.com", "user4", "AQAAAAEAACcQAAAAEECBphQWv/weWaybKTOqGycIFC5okbGOlOduPxHGNc/B465xGALCJTFhIJk+eRcIkw==", "123456784", false, "", false, "user4" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"), 0, "ebd09353-c7f4-4e79-9e01-39d3d4ff800c", "user5@gmail.com", true, "Ten 5", true, "Ho 5", false, null, "user5@gmail.com", "user5", "AQAAAAEAACcQAAAAEJiwAQ6E/Jefg0cafvXHoknoj6C0AJH48STkLj02wPfTmehZtC7fKiXU1dMLkfUefQ==", "123456785", false, "", false, "user5" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"), 0, "abed1ba0-14fc-47c0-b0e5-003f70e39e66", "user6@gmail.com", true, "Ten 6", true, "Ho 6", false, null, "user6@gmail.com", "user6", "AQAAAAEAACcQAAAAEFV31794ldukOGg5wqx/nfEYef26BKrQX1PXSjK6v6KN3nkfG5BxNs50RwuLfmvksg==", "123456786", false, "", false, "user6" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"), 0, "ca7b8883-74c1-418d-98dc-0d4c30369906", "user7@gmail.com", true, "Ten 7", true, "Ho 7", false, null, "user7@gmail.com", "user7", "AQAAAAEAACcQAAAAEBqbKCRN7YEEcjlj1IGQs1bfxdV8H3VWGWz3LKmLQElrUtrXOTQKf5KYYE97KyP1UA==", "123456787", false, "", false, "user7" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"), 0, "6c44eb3a-c3df-493a-9c3e-59189c183459", "user8@gmail.com", true, "Ten 8", true, "Ho 8", false, null, "user8@gmail.com", "user8", "AQAAAAEAACcQAAAAELJDTBpjXRAvM/KWlRi/C6NmOJeFEsmfD94IMv9OshL+2iddHXRubise1koQhPT6Sw==", "123456788", false, "", false, "user8" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"), 0, "c7661a00-5b39-4b03-9b4f-be6e57320c9e", "user9@gmail.com", true, "Ten 9", true, "Ho 9", false, null, "user9@gmail.com", "user9", "AQAAAAEAACcQAAAAEK6fa8pJ16waRPZWfUb95PneuR8htDjxs8OtCiUGaDqo8PvTpTgaRUIJ2GriAQo6IQ==", "123456789", false, "", false, "user9" },
                    { new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"), 0, "53ac8470-5658-4366-9ebd-a74504111fb1", "user10@gmail.com", true, "Ten 10", true, "Ho 10", false, null, "user10@gmail.com", "user10", "AQAAAAEAACcQAAAAEPlAXfMBYBiVrjC1ANSy6gDbg/jYzUsVN07KUi20hXqHkSx7lCY+HFufqJlsWGpXPg==", "1234567810", false, "", false, "user10" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 4, "https://picsum.photos/seed/4/200/300", "Nostra, iaculis scelerisque fringilla neque molestie tortor fusce non nibh, dapibus sed lacus phasellus lobortis pulvinar,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 40.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(5720), null, "Curabitur tellus blandit" },
                    { 8, "https://picsum.photos/seed/8/200/300", "Nisl", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 80.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(8105), null, "Dignissim" },
                    { 12, "https://picsum.photos/seed/12/200/300", "Sociosqu hac molestie quis rhoncus nullam posuere, sed", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 120.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(497), null, "Torquent etiam ultricies" },
                    { 16, "https://picsum.photos/seed/16/200/300", "Orci, amet quam sapien hac rhoncus fringilla efficitur urna, id venenatis habitasse mollis turpis", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 160.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(2881), null, "A amet facilisis ultricies" },
                    { 20, "https://picsum.photos/seed/20/200/300", "Et vel volutpat enim odio nulla,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 200.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(5243), null, "Venenatis" },
                    { 24, "https://picsum.photos/seed/24/200/300", "Enim, vestibulum, nunc nunc,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 240.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(7581), null, "Gravida" },
                    { 28, "https://picsum.photos/seed/28/200/300", "Velit bibendum, semper litora nisl in, varius a, et, mollis nibh efficitur quam eu nisi integer porta, egestas", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 280.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(9895), null, "Et" },
                    { 32, "https://picsum.photos/seed/32/200/300", "Mauris nostra, luctus, blandit cursus, tempus vestibulum primis venenatis", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 320.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(2190), null, "Urna" },
                    { 36, "https://picsum.photos/seed/36/200/300", "Posuere, vulputate odio eu quisque sed, euismod amet, convallis sagittis placerat, sociosqu nunc ligula justo venenatis nibh,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 360.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(4587), null, "Conubia" },
                    { 40, "https://picsum.photos/seed/40/200/300", "Mollis dictumst nullam non, vestibulum, eros condimentum posuere dolor, curabitur accumsan lacinia ut gravida orci, placerat felis", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 400.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(7015), null, "Laoreet nulla varius" },
                    { 44, "https://picsum.photos/seed/44/200/300", "Est dignissim habitasse himenaeos lobortis libero mattis, eget nec", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 440.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(9407), null, "Venenatis vitae tincidunt felis" },
                    { 48, "https://picsum.photos/seed/48/200/300", "Pulvinar facilisis ad torquent etiam ut", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 480.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(1770), null, "Nam himenaeos rhoncus ultrices" },
                    { 52, "https://picsum.photos/seed/52/200/300", "In integer posuere, massa, ipsum porttitor vehicula vel, platea", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 520.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(4001), null, "Aenean ornare elementum ultricies" },
                    { 56, "https://picsum.photos/seed/56/200/300", "Nisi, dolor", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 560.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(6341), null, "Egestas sodales" },
                    { 60, "https://picsum.photos/seed/60/200/300", "Tortor sem auctor leo", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 600.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(8693), null, "Amet etiam" },
                    { 64, "https://picsum.photos/seed/64/200/300", "Elit, finibus, ad curabitur nibh, auctor tristique ligula,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 640.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(1164), null, "Volutpat dictum nec" },
                    { 68, "https://picsum.photos/seed/68/200/300", "Sollicitudin orci, fames", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 680.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(3572), null, "Orci porttitor facilisis" },
                    { 72, "https://picsum.photos/seed/72/200/300", "Mattis,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 720.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(6010), null, "Tortor lorem" },
                    { 76, "https://picsum.photos/seed/76/200/300", "Porta nullam adipiscing magna, turpis nibh, congue porttitor, ornare dolor", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 760.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(8462), null, "Lorem convallis" },
                    { 80, "https://picsum.photos/seed/80/200/300", "Nibh nulla fusce accumsan neque, vel, etiam nec, diam feugiat leo ante, posuere class justo orci, leo,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 800.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(814), null, "Venenatis fermentum" },
                    { 84, "https://picsum.photos/seed/84/200/300", "Mattis nunc faucibus quis adipiscing aenean magna, amet, eros, donec auctor, sem, tortor", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 840.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(3134), null, "Sit urna blandit" },
                    { 88, "https://picsum.photos/seed/88/200/300", "Nunc, laoreet litora bibendum, ante, auctor, eu, porta, ornare eros libero ex tellus velit class lorem, sed quis, conubia", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 880.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(5447), null, "Adipiscing mi et" },
                    { 92, "https://picsum.photos/seed/92/200/300", "Id interdum, habitasse dapibus fermentum mi aliquam pulvinar ad cursus ante, neque mattis, condimentum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 920.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(7801), null, "Urna" },
                    { 96, "https://picsum.photos/seed/96/200/300", "Tempor, nibh blandit ac, dolor, lectus, magna laoreet porta urna vitae, mollis neque, ut molestie at, facilisis", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 960.0, new DateTime(2023, 3, 4, 11, 15, 53, 628, DateTimeKind.Local).AddTicks(334), null, "Luctus sagittis vel interdum" },
                    { 100, "https://picsum.photos/seed/100/200/300", "Finibus nibh sollicitudin lobortis lacinia, ultrices mollis eu nec, himenaeos dui, bibendum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 1000.0, new DateTime(2023, 3, 4, 11, 15, 53, 628, DateTimeKind.Local).AddTicks(2790), null, "Mattis" }
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
                    { 1, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(463), "Interdum id", 20.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(455) },
                    { 2, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(812), "Metus maximus", 10.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(811) },
                    { 3, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(1108), "Primis", 10.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(1107) },
                    { 4, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(1450), "Sociosqu phasellus aliquet", 10.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(1449) },
                    { 5, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(1758), "Laoreet velit", 30.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(1757) },
                    { 6, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(2059), "Eget porta", 40.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(2058) },
                    { 7, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(2421), "Accumsan praesent", 10.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(2421) },
                    { 8, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(2698), "Ipsum", 40.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(2697) },
                    { 9, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(3016), "Primis nostra", 40.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(3015) },
                    { 10, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(3297), "Convallis", 20.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(3297) }
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
                    { 8, 4 },
                    { 12, 12 },
                    { 16, 11 },
                    { 20, 3 },
                    { 24, 7 },
                    { 28, 3 },
                    { 32, 8 },
                    { 36, 4 },
                    { 40, 2 },
                    { 44, 10 },
                    { 48, 11 },
                    { 52, 2 },
                    { 56, 6 },
                    { 60, 11 },
                    { 64, 2 },
                    { 68, 12 },
                    { 72, 11 },
                    { 76, 3 },
                    { 80, 11 },
                    { 84, 9 },
                    { 88, 6 },
                    { 92, 12 },
                    { 96, 7 },
                    { 100, 2 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 1, "https://picsum.photos/seed/1/200/300", "Neque", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 10.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(3930), 2, "Bibendum nec ut" },
                    { 2, "https://picsum.photos/seed/2/200/300", "Ac praesent proin sapien ipsum luctus, odio dui, nulla varius, nisi interdum lacus placerat, et", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 20.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(4493), 3, "Scelerisque" },
                    { 3, "https://picsum.photos/seed/3/200/300", "Nullam nostra, luctus eu, lectus tellus, odio, congue, litora sed, mi", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 30.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(5119), 1, "Tellus velit lorem" },
                    { 5, "https://picsum.photos/seed/5/200/300", "Inceptos felis porta fringilla", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 50.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(6387), 3, "Ultrices sapien ut interdum" },
                    { 6, "https://picsum.photos/seed/6/200/300", "Eros a, cursus, elit maximus dui, nec vestibulum, sem, in, luctus maecenas id rhoncus interdum,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 60.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(6957), 1, "Vel est" },
                    { 7, "https://picsum.photos/seed/7/200/300", "Risus hendrerit pulvinar, magna, vitae, lacinia ac eleifend,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 70.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(7555), 2, "Torquent nec" },
                    { 9, "https://picsum.photos/seed/9/200/300", "Vivamus morbi fermentum ultrices, posuere,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 90.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(8634), 1, "Elit" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 10, "https://picsum.photos/seed/10/200/300", "Massa, nam nulla erat eu posuere, varius, per tristique laoreet, lacus posuere ullamcorper felis adipiscing", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 100.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(9274), 2, "A" },
                    { 11, "https://picsum.photos/seed/11/200/300", "Consectetur dapibus finibus, quisque lorem, laoreet, porttitor, congue malesuada semper litora eros, suscipit nullam nostra, metus dui", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 110.0, new DateTime(2023, 3, 4, 11, 15, 53, 622, DateTimeKind.Local).AddTicks(9943), 3, "Tortor arcu etiam" },
                    { 13, "https://picsum.photos/seed/13/200/300", "Ornare congue porttitor, at, sem, nisl mattis, urna vitae, nulla aenean litora risus eros", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 130.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(1117), 2, "Lacinia consequat" },
                    { 14, "https://picsum.photos/seed/14/200/300", "Fringilla imperdiet erat, leo vel eleifend,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 140.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(1703), 3, "Ultrices" },
                    { 15, "https://picsum.photos/seed/15/200/300", "Gravida quis, arcu aenean lobortis ad accumsan consequat porttitor tempus feugiat", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 150.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(2262), 1, "Sociosqu" },
                    { 17, "https://picsum.photos/seed/17/200/300", "Euismod, dignissim facilisis ligula posuere, mauris, lacus cursus vivamus praesent magna, erat, rhoncus amet", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 170.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(3493), 3, "A maecenas rhoncus" },
                    { 18, "https://picsum.photos/seed/18/200/300", "Ac, laoreet euismod mauris, torquent vitae velit sodales hac nulla, interdum, turpis aliquam nam curabitur nec,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 180.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(4097), 1, "Diam massa in rhoncus" },
                    { 19, "https://picsum.photos/seed/19/200/300", "Maecenas interdum, tempus curabitur ipsum ut imperdiet leo, a, ligula feugiat, elit nullam sollicitudin nunc fusce ultrices, tellus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 190.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(4698), 2, "Sagittis tempus neque" },
                    { 21, "https://picsum.photos/seed/21/200/300", "Magna lectus nisi class dui, enim integer luctus,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 210.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(5821), 1, "Mauris odio amet lacinia" },
                    { 22, "https://picsum.photos/seed/22/200/300", "Tellus, scelerisque in consectetur quis congue neque varius mauris, nostra, donec elementum viverra eros tortor nec ante, ac, quam,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 220.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(6479), 2, "Vitae nunc" },
                    { 23, "https://picsum.photos/seed/23/200/300", "Congue, eleifend dui fermentum volutpat,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 230.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(7040), 3, "Pharetra tortor amet" },
                    { 25, "https://picsum.photos/seed/25/200/300", "Porta", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 250.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(8120), 2, "Neque a" },
                    { 26, "https://picsum.photos/seed/26/200/300", "Malesuada sociosqu nulla himenaeos porttitor, condimentum", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 260.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(8711), 3, "Massa bibendum donec rhoncus" },
                    { 27, "https://picsum.photos/seed/27/200/300", "Eu neque, rutrum est erat, molestie a, orci,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 270.0, new DateTime(2023, 3, 4, 11, 15, 53, 623, DateTimeKind.Local).AddTicks(9280), 1, "Ligula facilisis sit euismod" },
                    { 29, "https://picsum.photos/seed/29/200/300", "Blandit", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 290.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(452), 3, "Posuere duis nam in" },
                    { 30, "https://picsum.photos/seed/30/200/300", "Morbi", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 300.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(1032), 1, "Erat magna platea lacinia" },
                    { 31, "https://picsum.photos/seed/31/200/300", "Egestas dui, eu nisi sem est ex laoreet, ante", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 310.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(1623), 2, "Efficitur" },
                    { 33, "https://picsum.photos/seed/33/200/300", "Fringilla, a quis bibendum, class consequat dignissim molestie libero ac, taciti odio, congue, nibh faucibus ipsum tortor,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 330.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(2756), 1, "Luctus phasellus nunc a" },
                    { 34, "https://picsum.photos/seed/34/200/300", "Commodo fames consectetur donec taciti ullamcorper massa,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 340.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(3368), 2, "Orci lectus vitae quis" },
                    { 35, "https://picsum.photos/seed/35/200/300", "Feugiat nulla, arcu, consectetur in, lorem, mattis, dui, tristique ipsum ornare pharetra elit", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 350.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(4028), 3, "Eu" },
                    { 37, "https://picsum.photos/seed/37/200/300", "Purus varius, cursus, ligula venenatis ligula, lorem", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 370.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(5162), 2, "Pretium morbi blandit" },
                    { 38, "https://picsum.photos/seed/38/200/300", "Massa, eu et, fusce tempor eros proin blandit sem libero a, tristique sapien himenaeos aptent", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 380.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(5772), 3, "Hendrerit laoreet" },
                    { 39, "https://picsum.photos/seed/39/200/300", "Sollicitudin non fringilla, auctor viverra fames in litora tristique bibendum vel sit conubia nec,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 390.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(6401), 1, "Commodo est nullam" },
                    { 41, "https://picsum.photos/seed/41/200/300", "Diam urna maximus auctor sollicitudin efficitur", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 410.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(7619), 3, "Massa ultricies magna" },
                    { 42, "https://picsum.photos/seed/42/200/300", "Consequat eleifend sed bibendum, consectetur aenean tortor, elit, torquent non, vitae, in,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 420.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(8225), 1, "Ad" },
                    { 43, "https://picsum.photos/seed/43/200/300", "Feugiat erat ornare vitae, primis dolor id,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 430.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(8764), 2, "Faucibus ipsum eleifend ad" },
                    { 45, "https://picsum.photos/seed/45/200/300", "Metus congue,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 450.0, new DateTime(2023, 3, 4, 11, 15, 53, 624, DateTimeKind.Local).AddTicks(9986), 1, "Aenean scelerisque" },
                    { 46, "https://picsum.photos/seed/46/200/300", "Non pellentesque erat, commodo finibus, curabitur volutpat quisque molestie non, eget laoreet, dictumst odio, lacus elit euismod convallis", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 460.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(587), 2, "Id sodales lacinia interdum" },
                    { 47, "https://picsum.photos/seed/47/200/300", "Tortor, lacus sagittis, ut nulla, efficitur metus bibendum, nunc, at, tortor dapibus viverra congue, quisque aenean", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 470.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(1180), 3, "Pellentesque at dignissim tellus" },
                    { 49, "https://picsum.photos/seed/49/200/300", "A malesuada porttitor neque, condimentum nulla, purus et, orci, dictumst proin", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 490.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(2326), 2, "Mauris nulla eleifend laoreet" },
                    { 50, "https://picsum.photos/seed/50/200/300", "Quis, enim,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 500.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(2880), 3, "Semper molestie dui" },
                    { 51, "https://picsum.photos/seed/51/200/300", "Blandit", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 510.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(3402), 1, "Inceptos nibh diam" },
                    { 53, "https://picsum.photos/seed/53/200/300", "Laoreet aptent aliquam id elit", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 530.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(4629), 3, "Cras phasellus ligula" },
                    { 54, "https://picsum.photos/seed/54/200/300", "Aptent ac, rhoncus, tellus ultrices, placerat conubia dolor posuere a", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 540.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(5212), 1, "Nec venenatis porttitor" },
                    { 55, "https://picsum.photos/seed/55/200/300", "Eros rutrum justo", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 550.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(5763), 2, "Luctus phasellus eleifend" },
                    { 57, "https://picsum.photos/seed/57/200/300", "Scelerisque justo leo malesuada", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 570.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(6940), 1, "Dolor massa" },
                    { 58, "https://picsum.photos/seed/58/200/300", "Dui justo id, sociosqu phasellus dolor,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 580.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(7488), 2, "Ac" },
                    { 59, "https://picsum.photos/seed/59/200/300", "Sollicitudin eleifend, nibh orci ex, massa eros, felis suspendisse volutpat, praesent per a, blandit velit molestie mauris,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 590.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(8099), 3, "Eleifend odio" },
                    { 61, "https://picsum.photos/seed/61/200/300", "Nisi ac, odio, justo lobortis pulvinar, orci, mattis, vel, mauris a auctor vitae feugiat,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 610.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(9304), 2, "Odio dui nisi" },
                    { 62, "https://picsum.photos/seed/62/200/300", "Pharetra eu, eleifend eros, posuere, cursus, iaculis curabitur diam ante aliquam metus vel, dictum nulla dui, vestibulum, pellentesque", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 620.0, new DateTime(2023, 3, 4, 11, 15, 53, 625, DateTimeKind.Local).AddTicks(9966), 3, "Purus massa posuere" },
                    { 63, "https://picsum.photos/seed/63/200/300", "Cursus, hendrerit tellus, aliquet dolor libero gravida ullamcorper orci, ad dui praesent magna lorem id cras vel ex,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 630.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(527), 1, "Sociosqu" },
                    { 65, "https://picsum.photos/seed/65/200/300", "Enim scelerisque fames non, nisi nisi, vel vitae, dapibus class magna, sociosqu sagittis phasellus aenean mollis malesuada", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 650.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(1750), 3, "Non" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImage", "Description", "EpubLink", "IsActive", "NumberOfPage", "PdfLink", "Price", "ReleaseDate", "SaleId", "Title" },
                values: new object[,]
                {
                    { 66, "https://picsum.photos/seed/66/200/300", "Maximus nunc, consectetur dolor sagittis efficitur inceptos lacus lacinia diam tristique arcu porta,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 660.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(2442), 1, "Sociosqu bibendum maximus" },
                    { 67, "https://picsum.photos/seed/67/200/300", "Dignissim massa, metus magna praesent euismod, enim", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 670.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(3012), 2, "Arcu venenatis" },
                    { 69, "https://picsum.photos/seed/69/200/300", "Orci, vehicula porttitor facilisis elementum non, lacus nec, finibus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 690.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(4224), 1, "Elit velit litora" },
                    { 70, "https://picsum.photos/seed/70/200/300", "Blandit nibh elit, lacinia ultrices, tellus mollis non euismod, luctus primis ligula,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 700.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(4847), 2, "Erat nunc felis elit" },
                    { 71, "https://picsum.photos/seed/71/200/300", "Donec lorem", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 710.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(5427), 3, "Etiam tincidunt" },
                    { 73, "https://picsum.photos/seed/73/200/300", "Neque enim ac ipsum dapibus diam per", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 730.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(6600), 2, "Lorem congue dolor" },
                    { 74, "https://picsum.photos/seed/74/200/300", "Non, blandit neque enim, semper fusce congue,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 740.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(7260), 3, "Augue leo enim" },
                    { 75, "https://picsum.photos/seed/75/200/300", "Odio, hendrerit torquent morbi", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 750.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(7859), 1, "Sollicitudin eros" },
                    { 77, "https://picsum.photos/seed/77/200/300", "Fermentum amet, libero condimentum tincidunt justo porta varius fusce et orci, class sem, etiam sodales quam urna, sollicitudin", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 770.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(9044), 3, "Cursus" },
                    { 78, "https://picsum.photos/seed/78/200/300", "Leo nisi tincidunt urna, tortor urna", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 780.0, new DateTime(2023, 3, 4, 11, 15, 53, 626, DateTimeKind.Local).AddTicks(9657), 1, "Nam tristique ipsum risus" },
                    { 79, "https://picsum.photos/seed/79/200/300", "Dignissim", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 100, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 790.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(242), 2, "Sollicitudin scelerisque fringilla" },
                    { 81, "https://picsum.photos/seed/81/200/300", "Ex, ante, enim donec eget proin cursus porta lectus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 810.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(1382), 1, "Sed leo dolor" },
                    { 82, "https://picsum.photos/seed/82/200/300", "Maximus phasellus ut eu nisi maecenas non, faucibus ultrices massa vitae, fames", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 820.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(1936), 2, "Tincidunt vel dictumst sapien" },
                    { 83, "https://picsum.photos/seed/83/200/300", "Semper hac ullamcorper suspendisse integer urna pharetra placerat, purus pulvinar, malesuada nec nisl lorem, nisi, a", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 830.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(2532), 3, "Facilisis" },
                    { 85, "https://picsum.photos/seed/85/200/300", "Aptent suspendisse tristique nibh commodo,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 850.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(3704), 2, "Laoreet pharetra faucibus" },
                    { 86, "https://picsum.photos/seed/86/200/300", "Mauris at fringilla ultrices finibus, vitae, congue massa orci blandit scelerisque laoreet pulvinar sem, ligula finibus", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 860.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(4283), 3, "Per eros pharetra" },
                    { 87, "https://picsum.photos/seed/87/200/300", "Nec, suspendisse eros aliquam cras euismod, vitae,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 870.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(4872), 1, "Gravida" },
                    { 89, "https://picsum.photos/seed/89/200/300", "Neque, dignissim venenatis eros, odio, at, enim, auctor mauris massa, vestibulum,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 890.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(6049), 3, "Lectus" },
                    { 90, "https://picsum.photos/seed/90/200/300", "Lectus,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 900.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(6602), 1, "Sagittis" },
                    { 91, "https://picsum.photos/seed/91/200/300", "Eros, nec tincidunt quisque efficitur et, varius nam dictumst tempus luctus, non", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 910.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(7193), 2, "Orci" },
                    { 93, "https://picsum.photos/seed/93/200/300", "Lacus luctus, ex lorem, est aliquam neque, curabitur blandit, feugiat, sagittis ultricies efficitur mi, non,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 930.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(8434), 1, "Neque vitae fusce" },
                    { 94, "https://picsum.photos/seed/94/200/300", "Eros, tincidunt fringilla urna, mattis, dui dolor, erat, suscipit", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 940.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(9035), 2, "Laoreet" },
                    { 95, "https://picsum.photos/seed/95/200/300", "Pulvinar maecenas mauris, urna sagittis, fames purus venenatis volutpat, sit dolor leo, sapien nulla,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 200, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 950.0, new DateTime(2023, 3, 4, 11, 15, 53, 627, DateTimeKind.Local).AddTicks(9681), 3, "Commodo amet placerat blandit" },
                    { 97, "https://picsum.photos/seed/97/200/300", "Aptent augue porttitor, sed eu, egestas auctor, elit, at, id sagittis, lorem", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 400, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 970.0, new DateTime(2023, 3, 4, 11, 15, 53, 628, DateTimeKind.Local).AddTicks(990), 2, "Elit nunc lectus luctus" },
                    { 98, "https://picsum.photos/seed/98/200/300", "Rhoncus, convallis nunc ex tortor,", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 980.0, new DateTime(2023, 3, 4, 11, 15, 53, 628, DateTimeKind.Local).AddTicks(1595), 3, "Orci lobortis vitae" },
                    { 99, "https://picsum.photos/seed/99/200/300", "Justo nec vel massa iaculis magna, ligula", "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", true, 300, "https://www.dropbox.com/s/pbulz27qp62esx3/CubexCursedxCurious%20-%20Volume%2001.pdf?dl=0", 990.0, new DateTime(2023, 3, 4, 11, 15, 53, 628, DateTimeKind.Local).AddTicks(2161), 1, "A fusce" }
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
                    { 1, 8 },
                    { 2, 5 },
                    { 3, 2 },
                    { 5, 1 },
                    { 6, 7 },
                    { 7, 7 },
                    { 9, 11 },
                    { 10, 2 },
                    { 11, 1 },
                    { 13, 2 },
                    { 14, 9 },
                    { 15, 10 },
                    { 17, 6 },
                    { 18, 8 },
                    { 19, 7 },
                    { 21, 9 },
                    { 22, 8 },
                    { 23, 7 },
                    { 25, 12 },
                    { 26, 11 },
                    { 27, 5 },
                    { 29, 3 },
                    { 30, 9 },
                    { 31, 4 },
                    { 33, 10 },
                    { 34, 6 },
                    { 35, 10 },
                    { 37, 6 },
                    { 38, 1 },
                    { 39, 3 },
                    { 41, 6 },
                    { 42, 11 },
                    { 43, 5 },
                    { 45, 8 },
                    { 46, 3 },
                    { 47, 8 },
                    { 49, 3 },
                    { 50, 1 },
                    { 51, 3 },
                    { 53, 1 },
                    { 54, 4 },
                    { 55, 5 }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 57, 9 },
                    { 58, 3 },
                    { 59, 11 },
                    { 61, 8 },
                    { 62, 12 },
                    { 63, 5 },
                    { 65, 11 },
                    { 66, 9 },
                    { 67, 12 },
                    { 69, 8 },
                    { 70, 12 },
                    { 71, 6 },
                    { 73, 1 },
                    { 74, 4 },
                    { 75, 2 },
                    { 77, 11 },
                    { 78, 7 },
                    { 79, 2 },
                    { 81, 3 },
                    { 82, 8 },
                    { 83, 3 },
                    { 85, 10 },
                    { 86, 7 },
                    { 87, 3 },
                    { 89, 12 },
                    { 90, 11 },
                    { 91, 10 },
                    { 93, 7 },
                    { 94, 8 },
                    { 95, 7 },
                    { 97, 6 },
                    { 98, 3 },
                    { 99, 1 }
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
