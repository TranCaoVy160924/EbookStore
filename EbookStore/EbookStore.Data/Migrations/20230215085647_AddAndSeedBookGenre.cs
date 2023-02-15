using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbookStore.Data.Migrations
{
    public partial class AddAndSeedBookGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenre");

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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("423e533c-d43d-4fd9-9676-e31af724522a"),
                column: "ConcurrencyStamp",
                value: "5b1e2fee-733e-4270-a5c3-ded64579e2c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"),
                column: "ConcurrencyStamp",
                value: "1c3969c2-651f-484b-bc45-56f872e0aed8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c16d027c-9e6d-4b4f-88be-7fe9be4975c0", "AQAAAAEAACcQAAAAEMpWZthA8hvr87xJEWvZBo96plzALS4zSmwHp4XYHy9tCR3J9tsH2bLGSS+JJ7+Imw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1c35c1c1-9df8-4376-82d2-ccb2363dbf56", "AQAAAAEAACcQAAAAEF0lnmCXLFhKoonS1EEdzFE3PgcOn9e99p3TkX4+UnW38Rl5v0BdkOHHRImKHf/BqQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e53493ee-cda3-41be-a228-2349ead319df", "AQAAAAEAACcQAAAAEJz2GibzXcs0NzfELHKamoonRxiJgGtbTpuBsutXZaA4HYU8gyjajwXGRh2A/0pd9Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a21dff9f-a5e6-4070-845a-64b6907e3a49", "AQAAAAEAACcQAAAAEB2wTeC5TSBZwUEtJ9Sen7HBEo6kS1PqmjQFkfY/aMwrvO8J7VdsmfqBuZZpVJwRTw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "500d5148-2bc5-4f05-8966-a781c0e0b0a1", "AQAAAAEAACcQAAAAEM9KnXglFFG2zpzRjehYAbLiP6nYlI4/briYGbD6nCN34vaKz0ewZbCatZG1cfJNIg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c512ac2f-7716-4d52-8cfd-f9f6c0371cd9", "AQAAAAEAACcQAAAAEC1R/KBdHOKpeyCYDy0Zz1owyZTg54La2IzsgEt45xPm/X+Qkq8YyfKNOdU+n+ZbHg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22e2e356-5994-4301-9c55-17d886f9ac67", "AQAAAAEAACcQAAAAEJ4AbftoDKsWlSsFrEmZNkUAIrvb8BLqUj3RHO2z+0Isp2b0zA+4/+aohclO3fRFwA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae876bd0-fedb-4c4c-be78-78be1eaf5449", "AQAAAAEAACcQAAAAEEASs9WczxGEGDisGzBBLfKWH8Iu6nu2ccxLSRnwN0NEJAffBu/SoyGDxSeLVQY5jQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b5883455-cfea-4aa3-9fd2-573508b16be0", "AQAAAAEAACcQAAAAEALlgDtBy1kzpqZ7xOSmITqH3MFLoDGh6cFSlhc30DUtdPqzC8KF8F4+CdOz9UQ+0g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "475a6803-0a2e-4214-90a1-27910f326d28", "AQAAAAEAACcQAAAAELvzo/hDy0is9nzlfrJj2k0hav2zkdJLS+I35PIbc15lKtWF63L8QvfZ5Dqkru/DvQ==" });

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
                    { 10, 10 }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 15, 56, 45, 891, DateTimeKind.Local).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 15, 56, 45, 898, DateTimeKind.Local).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 15, 56, 45, 908, DateTimeKind.Local).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 15, 56, 45, 916, DateTimeKind.Local).AddTicks(2669));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 15, 56, 45, 923, DateTimeKind.Local).AddTicks(7105));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 15, 56, 45, 931, DateTimeKind.Local).AddTicks(3225));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 15, 56, 45, 941, DateTimeKind.Local).AddTicks(2823));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 15, 56, 45, 951, DateTimeKind.Local).AddTicks(7899));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 9,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 15, 56, 45, 962, DateTimeKind.Local).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 10,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 15, 56, 45, 972, DateTimeKind.Local).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 15, 56, 45, 891, DateTimeKind.Local).AddTicks(6288), new DateTime(2023, 2, 15, 15, 56, 45, 891, DateTimeKind.Local).AddTicks(6276) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 15, 56, 45, 898, DateTimeKind.Local).AddTicks(7801), new DateTime(2023, 2, 15, 15, 56, 45, 898, DateTimeKind.Local).AddTicks(7793) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 15, 56, 45, 908, DateTimeKind.Local).AddTicks(4151), new DateTime(2023, 2, 15, 15, 56, 45, 908, DateTimeKind.Local).AddTicks(4083) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 15, 56, 45, 916, DateTimeKind.Local).AddTicks(2646), new DateTime(2023, 2, 15, 15, 56, 45, 916, DateTimeKind.Local).AddTicks(2632) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 15, 56, 45, 923, DateTimeKind.Local).AddTicks(7080), new DateTime(2023, 2, 15, 15, 56, 45, 923, DateTimeKind.Local).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 15, 56, 45, 931, DateTimeKind.Local).AddTicks(3150), new DateTime(2023, 2, 15, 15, 56, 45, 931, DateTimeKind.Local).AddTicks(3124) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 15, 56, 45, 941, DateTimeKind.Local).AddTicks(2706), new DateTime(2023, 2, 15, 15, 56, 45, 941, DateTimeKind.Local).AddTicks(2627) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 15, 56, 45, 951, DateTimeKind.Local).AddTicks(7754), new DateTime(2023, 2, 15, 15, 56, 45, 951, DateTimeKind.Local).AddTicks(7669) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 15, 56, 45, 962, DateTimeKind.Local).AddTicks(3456), new DateTime(2023, 2, 15, 15, 56, 45, 962, DateTimeKind.Local).AddTicks(3432) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 15, 56, 45, 972, DateTimeKind.Local).AddTicks(187), new DateTime(2023, 2, 15, 15, 56, 45, 972, DateTimeKind.Local).AddTicks(172) });

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_GenreId",
                table: "BookGenres",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenres");

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "int", nullable: false),
                    GenresGenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BooksBookId, x.GenresGenreId });
                    table.ForeignKey(
                        name: "FK_BookGenre_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genres_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("423e533c-d43d-4fd9-9676-e31af724522a"),
                column: "ConcurrencyStamp",
                value: "37e7f001-e332-42a7-a245-c1e126715860");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"),
                column: "ConcurrencyStamp",
                value: "46f6b089-506a-45d8-8e40-f8d6023982a4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "933ca9bd-efff-4033-a075-d8fe40851745", "AQAAAAEAACcQAAAAEBUY5H6Pz1evbKWhaqX4F09GyF+j+tsPq5FJ5/j642NvVWrTSsInhGXJeEhYkwJwJA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3c32e7d9-fef3-48c2-a5f3-c0795f98f2ad", "AQAAAAEAACcQAAAAEEBqczvLLPwu7HFsLqGVVWjy7rX4zZZZLz9KttCc3oRZBWWJnNArtUTlzt0uoi9Tgg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f8a71934-adee-451c-bc1d-ce8c704a73b7", "AQAAAAEAACcQAAAAENMq8IBurT7WeSffswcN5PkWe3iDIgCJ9N/lECBQO+EYwYaBkuZTnsNZFKAhPrEZTA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4f662376-6ae9-4c01-8ee6-15e17dbcbd37", "AQAAAAEAACcQAAAAEMJqfhMKa6POMbdfJEEiybDkPcf6zSbK2kgzjuPZCxvdIGM4pTJAwWMDj8Oq9Hw+eQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "89a2011b-ba5a-4b83-916a-8555678647b9", "AQAAAAEAACcQAAAAEH2znZMi+Hy23RRXzEy8WDmqMHYq6kPuYhu3lO7oqPPqaW035p9uXUop4WlwiRUJLg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "39c535d1-dbbf-4958-bd79-678878405df9", "AQAAAAEAACcQAAAAEJy9SevqFFb8moaaNg0MztC9pimuR9/ysfcUaOM1g66z/gz8Oi6t1LaojY4mAhhY+Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bf7768c3-4a92-4270-b18c-8d73ee915277", "AQAAAAEAACcQAAAAEIuMj4SHIasUqGE6N/ALPJZXcAKGxyBgKcKtOGQMWGEmNWvCetgvyc3rv8k0W5GUYg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "60df29b0-078a-4566-b6c2-efd65ef9b211", "AQAAAAEAACcQAAAAEJTtJ2FKdodUab5en0Phs+Vq4yI5bn1yiJAt4s0N3/qoDT7a8yteV1tqL/h2pElp8A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "51ec3460-1a95-4916-bc36-e056634adf63", "AQAAAAEAACcQAAAAELZwPMmJUFm0XNjpJyvK5zYjIF9QzD8Sldd6GleQ86vtoB/hpQG9+F5PIvUhPCn2hA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d6782091-c69f-42bb-ac07-68dd4f9bc2af", "AQAAAAEAACcQAAAAEB/daZM4OCjE8Dm1O0xqabjRZp3gX3/vR9M6zFzPEnsj/1zNB35FMZlcPnwM9tY7uA==" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 10, 39, 55, 492, DateTimeKind.Local).AddTicks(6452));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 10, 39, 55, 499, DateTimeKind.Local).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 10, 39, 55, 507, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 10, 39, 55, 518, DateTimeKind.Local).AddTicks(8653));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 10, 39, 55, 530, DateTimeKind.Local).AddTicks(5071));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 10, 39, 55, 541, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 10, 39, 55, 552, DateTimeKind.Local).AddTicks(9687));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 10, 39, 55, 563, DateTimeKind.Local).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 9,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 10, 39, 55, 572, DateTimeKind.Local).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 10,
                column: "ReleaseDate",
                value: new DateTime(2023, 2, 15, 10, 39, 55, 579, DateTimeKind.Local).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 39, 55, 492, DateTimeKind.Local).AddTicks(6427), new DateTime(2023, 2, 15, 10, 39, 55, 492, DateTimeKind.Local).AddTicks(6413) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 39, 55, 499, DateTimeKind.Local).AddTicks(5170), new DateTime(2023, 2, 15, 10, 39, 55, 499, DateTimeKind.Local).AddTicks(5167) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 39, 55, 507, DateTimeKind.Local).AddTicks(504), new DateTime(2023, 2, 15, 10, 39, 55, 507, DateTimeKind.Local).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 39, 55, 518, DateTimeKind.Local).AddTicks(8606), new DateTime(2023, 2, 15, 10, 39, 55, 518, DateTimeKind.Local).AddTicks(8593) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 39, 55, 530, DateTimeKind.Local).AddTicks(5038), new DateTime(2023, 2, 15, 10, 39, 55, 530, DateTimeKind.Local).AddTicks(5024) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 39, 55, 541, DateTimeKind.Local).AddTicks(8168), new DateTime(2023, 2, 15, 10, 39, 55, 541, DateTimeKind.Local).AddTicks(8152) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 39, 55, 552, DateTimeKind.Local).AddTicks(9652), new DateTime(2023, 2, 15, 10, 39, 55, 552, DateTimeKind.Local).AddTicks(9643) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 39, 55, 563, DateTimeKind.Local).AddTicks(9673), new DateTime(2023, 2, 15, 10, 39, 55, 563, DateTimeKind.Local).AddTicks(9661) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 39, 55, 572, DateTimeKind.Local).AddTicks(9495), new DateTime(2023, 2, 15, 10, 39, 55, 572, DateTimeKind.Local).AddTicks(9478) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 15, 10, 39, 55, 579, DateTimeKind.Local).AddTicks(8786), new DateTime(2023, 2, 15, 10, 39, 55, 579, DateTimeKind.Local).AddTicks(8777) });

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenresGenreId",
                table: "BookGenre",
                column: "GenresGenreId");
        }
    }
}
