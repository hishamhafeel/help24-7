using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class Majorchangestoentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Helpers_PhoneNo",
                table: "Helpers");

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "District",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "CategoryDescription",
                table: "HelperCategories");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "HelperCategories");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Helpers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Helpers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Helpers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "Helpers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine",
                table: "Helpers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Helpers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Helpers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Helpers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                table: "Helpers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MyService",
                table: "Helpers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Helpers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Helpers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "HelperCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "HelperCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "HelperCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "HelperCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "HelperCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "HelperCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicesProvided",
                table: "HelperCategories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    ImageType = table.Column<string>(nullable: true),
                    SubServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(nullable: true),
                    HelperId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Helpers_HelperId",
                        column: x => x.HelperId,
                        principalTable: "Helpers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Helpers_MobileNo",
                table: "Helpers",
                column: "MobileNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Helpers_PhoneNo",
                table: "Helpers",
                column: "PhoneNo",
                unique: true,
                filter: "[PhoneNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_HelperId",
                table: "Skills",
                column: "HelperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Helpers_MobileNo",
                table: "Helpers");

            migrationBuilder.DropIndex(
                name: "IX_Helpers_PhoneNo",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "AddressLine",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "MobileNo",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "MyService",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "HelperCategories");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "HelperCategories");

            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "HelperCategories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "HelperCategories");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "HelperCategories");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "HelperCategories");

            migrationBuilder.DropColumn(
                name: "ServicesProvided",
                table: "HelperCategories");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Helpers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Helpers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Helpers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Helpers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Helpers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Helpers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryDescription",
                table: "HelperCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "HelperCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "5d1a1b1c-f25a-451e-b92f-26f864255a24");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "abda33f0-1db1-4b45-8c7b-10f9fda8a6a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "96596d89-1427-4e16-94a2-5b87421d8bb7");

            migrationBuilder.InsertData(
                table: "HelperCategories",
                columns: new[] { "Id", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, "CCTV Installation and Fixing", "Cctv" },
                    { 2, "Network Planning and Troubleshooting", "NetworkPlanning" },
                    { 3, "PABX - Private Automatic Issues", "Pabx" },
                    { 4, "Cisco Routing - Service Maintenance", "Cisco" },
                    { 5, "IT and other projects", "IT" },
                    { 6, "Office Relocation IT Setup", "OfficeRelocation" },
                    { 7, "Office New IT Setup", "OfficeNewSetup" },
                    { 8, "Basic Hardware Repairing", "HardwareRepair" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Helpers_PhoneNo",
                table: "Helpers",
                column: "PhoneNo",
                unique: true);
        }
    }
}
