using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class subservicesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HelperCategories_Name",
                table: "HelperCategories");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "5c645e36-135a-49f6-81d2-2a87569afb59", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c645e36-135a-49f6-81d2-2a87569afb59");

            migrationBuilder.DropColumn(
                name: "ServicesProvided",
                table: "HelperCategories");

            migrationBuilder.AlterColumn<string>(
                name: "SkillName",
                table: "Skills",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "HelperCategories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "HelperCategories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HelperCategories",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LongDescription",
                table: "HelperCategories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "HelpCentres",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "SubServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    HelperCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubServices_HelperCategories_HelperCategoryId",
                        column: x => x.HelperCategoryId,
                        principalTable: "HelperCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c9dc94a3-5255-4191-a184-dacf0db774d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "15352437-81e1-4063-8201-190cfb9c1230");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "67b077db-a82d-429a-bc1f-c165e7ad2770");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "9015fd4e-d46c-4ac2-8adc-c008819936f3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "19b013a3-4da9-4401-a218-522eca281b37", 0, "b76357dd-8638-4759-9a02-a6d49115b002", null, new DateTime(2020, 6, 19, 1, 24, 25, 194, DateTimeKind.Utc).AddTicks(8164), null, new DateTime(2020, 6, 19, 1, 24, 25, 194, DateTimeKind.Utc).AddTicks(8596), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEDw+H4YayX88xgRNyVa134Wt3YFHmlQ7oTC9eTiqdVuWyuvbqHQAAKN0cFnoxD/VwQ==", "123456789", false, (byte)1, "70979487-26d8-4ab2-8545-a843dcde25aa", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 19, 1, 24, 25, 215, DateTimeKind.Utc).AddTicks(90), new DateTime(2020, 6, 19, 1, 24, 25, 215, DateTimeKind.Utc).AddTicks(597) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 19, 1, 24, 25, 215, DateTimeKind.Utc).AddTicks(2099), new DateTime(2020, 6, 19, 1, 24, 25, 215, DateTimeKind.Utc).AddTicks(2105) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 19, 1, 24, 25, 215, DateTimeKind.Utc).AddTicks(2152), new DateTime(2020, 6, 19, 1, 24, 25, 215, DateTimeKind.Utc).AddTicks(2153) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "19b013a3-4da9-4401-a218-522eca281b37", "4" });

            migrationBuilder.CreateIndex(
                name: "IX_HelperCategories_Name",
                table: "HelperCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubServices_HelperCategoryId",
                table: "SubServices",
                column: "HelperCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubServices");

            migrationBuilder.DropIndex(
                name: "IX_HelperCategories_Name",
                table: "HelperCategories");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "19b013a3-4da9-4401-a218-522eca281b37", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19b013a3-4da9-4401-a218-522eca281b37");

            migrationBuilder.AlterColumn<string>(
                name: "SkillName",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "HelperCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "HelperCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HelperCategories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "LongDescription",
                table: "HelperCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ServicesProvided",
                table: "HelperCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "HelpCentres",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

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
                name: "IX_HelperCategories_Name",
                table: "HelperCategories",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }
    }
}
