using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class ticketentitychanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Tickets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Tickets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactNo1",
                table: "Tickets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactNo2",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HelpDateFrom",
                table: "Tickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HelpDateTo",
                table: "Tickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OtherRequirements",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Tickets",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "TicketStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Help has been requested");

            migrationBuilder.InsertData(
                table: "TicketStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[] { 4, "Help has been cancelled" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TicketStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ContactNo1",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ContactNo2",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "HelpDateFrom",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "HelpDateTo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "OtherRequirements",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Tickets");

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

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 5, 8, 5, 34, 37, 616, DateTimeKind.Utc).AddTicks(4766), new DateTime(2020, 5, 8, 5, 34, 37, 616, DateTimeKind.Utc).AddTicks(5600) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 5, 8, 5, 34, 37, 616, DateTimeKind.Utc).AddTicks(8502), new DateTime(2020, 5, 8, 5, 34, 37, 616, DateTimeKind.Utc).AddTicks(8509) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 5, 8, 5, 34, 37, 616, DateTimeKind.Utc).AddTicks(8517), new DateTime(2020, 5, 8, 5, 34, 37, 616, DateTimeKind.Utc).AddTicks(8518) });

            migrationBuilder.UpdateData(
                table: "TicketStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Help has been equested");
        }
    }
}
