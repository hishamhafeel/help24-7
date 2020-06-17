using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class imageIdincustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Customers_CustomerId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CustomerId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "dee7c787-b352-44f1-a1f1-8ca311d30ea6", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dee7c787-b352-44f1-a1f1-8ca311d30ea6");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Customers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a7e26ee1-5b7f-41d4-8b31-b3db5ac49a55");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "de87b71f-0f40-473b-a22c-84f4ee649647");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "db3523e7-4ea7-4556-9a66-0b25c7fc446c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "cde75899-12ef-4c29-8011-20d23a478fda");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5c645e36-135a-49f6-81d2-2a87569afb59", 0, "291eb67b-3b8d-4a24-ab2a-bb2b392fbe52", null, new DateTime(2020, 6, 17, 15, 31, 0, 394, DateTimeKind.Utc).AddTicks(3100), null, new DateTime(2020, 6, 17, 15, 31, 0, 394, DateTimeKind.Utc).AddTicks(3945), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEDcnREK4bufEDyDSlUmjMk8k21ispNdRfyHO1hWLWka1MD6f8TcyG5Df3V4Mb31+1Q==", "123456789", false, (byte)1, "31b9c87c-6cd2-43bf-bb89-928da0ed8be6", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 17, 15, 31, 0, 457, DateTimeKind.Utc).AddTicks(6515), new DateTime(2020, 6, 17, 15, 31, 0, 457, DateTimeKind.Utc).AddTicks(7402) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 17, 15, 31, 0, 458, DateTimeKind.Utc).AddTicks(393), new DateTime(2020, 6, 17, 15, 31, 0, 458, DateTimeKind.Utc).AddTicks(403) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 17, 15, 31, 0, 458, DateTimeKind.Utc).AddTicks(480), new DateTime(2020, 6, 17, 15, 31, 0, 458, DateTimeKind.Utc).AddTicks(483) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "5c645e36-135a-49f6-81d2-2a87569afb59", "4" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ImageId",
                table: "Customers",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Images_ImageId",
                table: "Customers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Images_ImageId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ImageId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "5c645e36-135a-49f6-81d2-2a87569afb59", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c645e36-135a-49f6-81d2-2a87569afb59");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "02de289b-d374-474f-a4dc-9f80dec3012b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ac1fe539-d652-49f7-91e8-96d7a5339698");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "dd00065a-f95e-492b-900e-2c2787c9c8d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "e670e87c-7723-44a2-811a-806bcb261c3e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dee7c787-b352-44f1-a1f1-8ca311d30ea6", 0, "fb76f00a-95d5-4c5b-90f3-a66e35eac5c5", null, new DateTime(2020, 6, 17, 15, 28, 32, 726, DateTimeKind.Utc).AddTicks(6781), null, new DateTime(2020, 6, 17, 15, 28, 32, 726, DateTimeKind.Utc).AddTicks(7876), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEMHJksENVlkj8sF/QhW6nbbhj99NXT9R+wjQbDpgByVSAzXirLpXuBRB7RMIx9W74A==", "123456789", false, (byte)1, "5ed0fd62-3b72-4b71-91df-d46633bf4a2a", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 17, 15, 28, 32, 758, DateTimeKind.Utc).AddTicks(8529), new DateTime(2020, 6, 17, 15, 28, 32, 758, DateTimeKind.Utc).AddTicks(9332) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 17, 15, 28, 32, 759, DateTimeKind.Utc).AddTicks(1894), new DateTime(2020, 6, 17, 15, 28, 32, 759, DateTimeKind.Utc).AddTicks(1907) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 17, 15, 28, 32, 759, DateTimeKind.Utc).AddTicks(1984), new DateTime(2020, 6, 17, 15, 28, 32, 759, DateTimeKind.Utc).AddTicks(1986) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "dee7c787-b352-44f1-a1f1-8ca311d30ea6", "4" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_CustomerId",
                table: "Images",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Customers_CustomerId",
                table: "Images",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
