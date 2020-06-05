using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class dbcontextmodification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Images",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "84d3d487-197f-4c67-9626-cc755a569662");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "c4085b30-4b33-413f-9e28-40dd570e62cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "858892bb-d04c-4982-9fc3-39db3d88aa1f");

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 4, 6, 57, 6, 785, DateTimeKind.Utc).AddTicks(5072), new DateTime(2020, 6, 4, 6, 57, 6, 785, DateTimeKind.Utc).AddTicks(5841) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 4, 6, 57, 6, 785, DateTimeKind.Utc).AddTicks(8399), new DateTime(2020, 6, 4, 6, 57, 6, 785, DateTimeKind.Utc).AddTicks(8404) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 4, 6, 57, 6, 785, DateTimeKind.Utc).AddTicks(8409), new DateTime(2020, 6, 4, 6, 57, 6, 785, DateTimeKind.Utc).AddTicks(8410) });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageUrl",
                table: "Images",
                column: "ImageUrl",
                unique: true,
                filter: "[ImageUrl] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_ImageUrl",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "75c5d7e7-e7f3-4743-aae1-80f7f0eeedb5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "713b379e-70c7-4429-99df-0f32ba542690");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "8b05e150-841a-439a-ad0a-86b4c74ead48");

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 4, 5, 47, 34, 247, DateTimeKind.Utc).AddTicks(5599), new DateTime(2020, 6, 4, 5, 47, 34, 247, DateTimeKind.Utc).AddTicks(6448) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 4, 5, 47, 34, 247, DateTimeKind.Utc).AddTicks(9684), new DateTime(2020, 6, 4, 5, 47, 34, 247, DateTimeKind.Utc).AddTicks(9691) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 4, 5, 47, 34, 247, DateTimeKind.Utc).AddTicks(9697), new DateTime(2020, 6, 4, 5, 47, 34, 247, DateTimeKind.Utc).AddTicks(9699) });
        }
    }
}
