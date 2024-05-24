using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppStore.Migrations
{
    public partial class Seeding_Roles_And_Admin_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d717dff-ea8e-4824-8477-a87d63d259b7", "0d717dff-ea8e-4824-8477-a87d63d259b7", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a8b5e27-7197-4b22-a111-6d7f5c27ac25", "5a8b5e27-7197-4b22-a111-6d7f5c27ac25", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a610a115-9e98-4a4c-a005-082cd2661ddc", 0, "d5996322-bb5d-481c-a282-f887eae1926e", "admin1@webappstore.com", false, false, null, "ADMIN1@WEBAPPSTORE.COM", "ADMIN1", "AQAAAAEAACcQAAAAECLWALW0YN+154FhefWqlw7Oq8OK5N4IwbgrK00GnxUKiZa3fCmxPZyQmV+9dzGCMA==", null, false, "32f9eda1-5a6a-4b42-a647-330aad1c06f9", false, "Admin1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0d717dff-ea8e-4824-8477-a87d63d259b7", "a610a115-9e98-4a4c-a005-082cd2661ddc" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5a8b5e27-7197-4b22-a111-6d7f5c27ac25", "a610a115-9e98-4a4c-a005-082cd2661ddc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0d717dff-ea8e-4824-8477-a87d63d259b7", "a610a115-9e98-4a4c-a005-082cd2661ddc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5a8b5e27-7197-4b22-a111-6d7f5c27ac25", "a610a115-9e98-4a4c-a005-082cd2661ddc" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d717dff-ea8e-4824-8477-a87d63d259b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a8b5e27-7197-4b22-a111-6d7f5c27ac25");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a610a115-9e98-4a4c-a005-082cd2661ddc");
        }
    }
}
