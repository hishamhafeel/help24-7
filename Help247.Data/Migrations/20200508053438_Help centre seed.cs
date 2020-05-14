using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class Helpcentreseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "be4bb90c-719f-4145-b4eb-b7509104d2b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "af024297-5499-4c89-88f4-2889b7770fac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "1c507d21-106e-4a41-b23e-4d9a4c5e1a2a");

            migrationBuilder.InsertData(
                table: "HelpCentres",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Description", "EditedById", "EditedOn", "RecordState", "Title", "Topics" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 5, 8, 5, 34, 37, 616, DateTimeKind.Utc).AddTicks(4766), null, null, new DateTime(2020, 5, 8, 5, 34, 37, 616, DateTimeKind.Utc).AddTicks(5600), (byte)1, "Terms & Conditions", "{}" },
                    { 2, null, new DateTime(2020, 5, 8, 5, 34, 37, 616, DateTimeKind.Utc).AddTicks(8502), null, null, new DateTime(2020, 5, 8, 5, 34, 37, 616, DateTimeKind.Utc).AddTicks(8509), (byte)1, "Privacy Policy", "{}" },
                    { 3, null, new DateTime(2020, 5, 8, 5, 34, 37, 616, DateTimeKind.Utc).AddTicks(8517), null, null, new DateTime(2020, 5, 8, 5, 34, 37, 616, DateTimeKind.Utc).AddTicks(8518), (byte)1, "FAQ", "{}" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3);

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
    }
}
