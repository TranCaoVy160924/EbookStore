using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbookStore.Data.Migrations
{
    public partial class AddBookDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "Description", "ReleaseDate" },
                values: new object[] { "Description 1", new DateTime(2023, 2, 15, 10, 39, 55, 492, DateTimeKind.Local).AddTicks(6452) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                columns: new[] { "Description", "ReleaseDate" },
                values: new object[] { "Description 2", new DateTime(2023, 2, 15, 10, 39, 55, 499, DateTimeKind.Local).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                columns: new[] { "Description", "ReleaseDate" },
                values: new object[] { "Description 3", new DateTime(2023, 2, 15, 10, 39, 55, 507, DateTimeKind.Local).AddTicks(541) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4,
                columns: new[] { "Description", "ReleaseDate" },
                values: new object[] { "Description 4", new DateTime(2023, 2, 15, 10, 39, 55, 518, DateTimeKind.Local).AddTicks(8653) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5,
                columns: new[] { "Description", "ReleaseDate" },
                values: new object[] { "Description 5", new DateTime(2023, 2, 15, 10, 39, 55, 530, DateTimeKind.Local).AddTicks(5071) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6,
                columns: new[] { "Description", "ReleaseDate" },
                values: new object[] { "Description 6", new DateTime(2023, 2, 15, 10, 39, 55, 541, DateTimeKind.Local).AddTicks(8199) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7,
                columns: new[] { "Description", "ReleaseDate" },
                values: new object[] { "Description 7", new DateTime(2023, 2, 15, 10, 39, 55, 552, DateTimeKind.Local).AddTicks(9687) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8,
                columns: new[] { "Description", "ReleaseDate" },
                values: new object[] { "Description 8", new DateTime(2023, 2, 15, 10, 39, 55, 563, DateTimeKind.Local).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 9,
                columns: new[] { "Description", "ReleaseDate" },
                values: new object[] { "Description 9", new DateTime(2023, 2, 15, 10, 39, 55, 572, DateTimeKind.Local).AddTicks(9659) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 10,
                columns: new[] { "Description", "ReleaseDate" },
                values: new object[] { "Description 10", new DateTime(2023, 2, 15, 10, 39, 55, 579, DateTimeKind.Local).AddTicks(8811) });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("423e533c-d43d-4fd9-9676-e31af724522a"),
                column: "ConcurrencyStamp",
                value: "022bbb42-7ced-460f-8011-a4d4a39a6ad9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("da35db1a-5b54-4618-884e-bcd7f7b1dd19"),
                column: "ConcurrencyStamp",
                value: "8203dc71-884d-4d23-af77-36aaa3993184");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef60"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "37485df4-d02e-42dc-aff5-94703b4ed6dc", "AQAAAAEAACcQAAAAEIgrYlppJoCjgogkBMllAXftJeXoY+Cm8kK/uwsmKNuNGna8bCrLRsJlf/qAIocqHQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef61"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "86e11b21-24ed-4573-a98c-6b067f8ca5e6", "AQAAAAEAACcQAAAAEG9pymx9ORu4RyUhi8rhMRWAFhNX+b68j3qA7fg1+dn/8dlTWdMFMZny7vwQzW34yw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef62"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f38fd923-4592-45db-a9df-9905b2d8aac0", "AQAAAAEAACcQAAAAEJXPAi0ZYhS0jP7BBw9LLHB3MSPfj3HIdRUcvFv3Ul8hgi2qJjhBKYN8RwO2DOCMAw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef63"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9ae33cfd-48b5-43c7-979d-93807bd1fa45", "AQAAAAEAACcQAAAAELJeH7I9NOkunhtjk5DKXabxIFItNZP7NBotAlyZTCxf6N4eHOHY8wzP/5gowegt9w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef64"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f8a1628f-b9d8-4346-ba9a-70264ec83b8a", "AQAAAAEAACcQAAAAEHQkdByyTo/f4/qfwfP4MBmcQCpkxB8rS3VuM8S0R6Mc2BxV3LPqdSLEN9PYTg/Pow==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef65"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2731f955-6f6f-40c0-a3a8-774b5ebcce2c", "AQAAAAEAACcQAAAAEDEwOF77HFfI9eEuwiDGYsCh+qnK4JvRzwwCf9VFH9wvFM0g0r67qr0dJRmm8G9I0g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef66"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "89c07e7c-e5a2-46c8-8ae5-80e0ecfdecb6", "AQAAAAEAACcQAAAAEBEPLKIMvrXPC0DBiPfOMgpKEqoh+eosW7u7w3PHUH+6M6i8Lpg7hdRbwmju6zdQRg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef67"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b3acae8b-7f20-491d-a766-a900f10da3ba", "AQAAAAEAACcQAAAAEHw4U0Afyw+FWc9+twPJGrqX3xYvU/hYmhzh5mSauhFCmSGMgkiG+8WIZmGQA2q4BQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef68"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4165f2e9-43ed-4fad-924b-99ce3255c256", "AQAAAAEAACcQAAAAEOdDwfEWbGrCvySyl1nPDQZuCsVtG/XOgOwz8ckMgenXHK4ZNc01eJ8XYccNGfWeGQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6baa519d-aaed-4190-a3c9-3c8f67ecef69"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2df78c5f-6451-4156-a52a-3be8535d73f1", "AQAAAAEAACcQAAAAED8IiPOsiY9iGq0FwCncyJnE9ATFugabZw29ye9FGdUgzT7oFc7xEDOvKUHBHmkCvQ==" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 16, 22, 25, 27, 170, DateTimeKind.Local).AddTicks(3199));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 16, 22, 25, 27, 183, DateTimeKind.Local).AddTicks(3172));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 16, 22, 25, 27, 196, DateTimeKind.Local).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 16, 22, 25, 27, 208, DateTimeKind.Local).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 16, 22, 25, 27, 221, DateTimeKind.Local).AddTicks(5488));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 16, 22, 25, 27, 233, DateTimeKind.Local).AddTicks(8892));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 16, 22, 25, 27, 246, DateTimeKind.Local).AddTicks(3177));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 16, 22, 25, 27, 258, DateTimeKind.Local).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 9,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 16, 22, 25, 27, 270, DateTimeKind.Local).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 10,
                column: "ReleaseDate",
                value: new DateTime(2023, 1, 16, 22, 25, 27, 283, DateTimeKind.Local).AddTicks(1696));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 16, 22, 25, 27, 170, DateTimeKind.Local).AddTicks(3156), new DateTime(2023, 1, 16, 22, 25, 27, 170, DateTimeKind.Local).AddTicks(3145) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 16, 22, 25, 27, 183, DateTimeKind.Local).AddTicks(3124), new DateTime(2023, 1, 16, 22, 25, 27, 183, DateTimeKind.Local).AddTicks(3111) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 16, 22, 25, 27, 196, DateTimeKind.Local).AddTicks(1946), new DateTime(2023, 1, 16, 22, 25, 27, 196, DateTimeKind.Local).AddTicks(1934) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 16, 22, 25, 27, 208, DateTimeKind.Local).AddTicks(9202), new DateTime(2023, 1, 16, 22, 25, 27, 208, DateTimeKind.Local).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 16, 22, 25, 27, 221, DateTimeKind.Local).AddTicks(5443), new DateTime(2023, 1, 16, 22, 25, 27, 221, DateTimeKind.Local).AddTicks(5423) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 16, 22, 25, 27, 233, DateTimeKind.Local).AddTicks(8851), new DateTime(2023, 1, 16, 22, 25, 27, 233, DateTimeKind.Local).AddTicks(8836) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 16, 22, 25, 27, 246, DateTimeKind.Local).AddTicks(3137), new DateTime(2023, 1, 16, 22, 25, 27, 246, DateTimeKind.Local).AddTicks(3125) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 16, 22, 25, 27, 258, DateTimeKind.Local).AddTicks(4676), new DateTime(2023, 1, 16, 22, 25, 27, 258, DateTimeKind.Local).AddTicks(4656) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 16, 22, 25, 27, 270, DateTimeKind.Local).AddTicks(7807), new DateTime(2023, 1, 16, 22, 25, 27, 270, DateTimeKind.Local).AddTicks(7789) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 16, 22, 25, 27, 283, DateTimeKind.Local).AddTicks(1653), new DateTime(2023, 1, 16, 22, 25, 27, 283, DateTimeKind.Local).AddTicks(1636) });
        }
    }
}
