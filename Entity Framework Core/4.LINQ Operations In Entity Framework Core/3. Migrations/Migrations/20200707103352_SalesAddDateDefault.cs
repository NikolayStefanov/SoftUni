using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_SalesDatabase.Migrations
{
    public partial class SalesAddDateDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Quantity",
                table: "Products",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Desctiption",
                table: "Products",
                maxLength: 250,
                nullable: true,
                defaultValue: "No description",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "Desctiption",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true,
                oldDefaultValue: "No description");
        }
    }
}
