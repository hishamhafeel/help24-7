using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class helpercategorychanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "HelperCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HelperCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "HelperCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedOn",
                table: "HelperCategories",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "RecordState",
                table: "HelperCategories",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "385bc488-9bab-4d7e-bd3c-d532a3a5021f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "c5154787-5ff6-4072-bea0-bed11d0d8707");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "e3aa6962-b79c-4821-89b8-6b2f67c06809");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "HelperCategories");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HelperCategories");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "HelperCategories");

            migrationBuilder.DropColumn(
                name: "EditedOn",
                table: "HelperCategories");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "HelperCategories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "3e37609f-b224-4202-9f00-03a606e1a427");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ad298df9-78fb-411b-8a8f-ae641ff1089f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "dbe39279-bacc-4c19-bc85-503d545bb5b9");
        }
    }
}
