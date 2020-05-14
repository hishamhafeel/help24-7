using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class Helpcentremadeauditable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "HelpCentres",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HelpCentres",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "HelpCentres",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedOn",
                table: "HelpCentres",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "RecordState",
                table: "HelpCentres",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "201f5c9a-8594-4ed4-a52c-865dd338319f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8ddf26f7-05d3-4e25-a1e8-5d32836d3030");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "eb59e0c5-2100-4b2d-ad1c-f0ea35bc356e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "HelpCentres");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HelpCentres");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "HelpCentres");

            migrationBuilder.DropColumn(
                name: "EditedOn",
                table: "HelpCentres");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "HelpCentres");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c721502f-0a94-44d3-bf9c-bae0a4cba53f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "96781c85-a0ef-4b0d-b4c1-b3de6ab9cae3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "cb28fa2a-cf82-4680-ae63-e92b04895f4a");
        }
    }
}
