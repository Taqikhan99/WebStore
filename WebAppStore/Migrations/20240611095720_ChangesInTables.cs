using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppStore.Migrations
{
    public partial class ChangesInTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Generation",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessorId",
                table: "Laptops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a610a115-9e98-4a4c-a005-082cd2661ddc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ec5d20b-cb79-4ed5-a944-ee1917c9146d", "AQAAAAEAACcQAAAAEIxv5IO2rK+06sXi7+emYsrudGvvxD+iJjq7h/nHiPvmfhnzh/Y2ieO69yUMoJn0tw==", "60765a4b-eebf-424a-82be-3427607d832f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Generation",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "ProcessorId",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Brands");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a610a115-9e98-4a4c-a005-082cd2661ddc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adfba1a4-6d6f-4da0-bf05-a1543375aa3e", "AQAAAAEAACcQAAAAELMIMrJyG/xRaIhV9bsAIELDFwJ2qnfQI0i8CblRfW86k2LtF1+ap8cpXg4ULT4X3Q==", "4afb464e-b435-4119-a7a5-5a60b20d4b58" });
        }
    }
}
