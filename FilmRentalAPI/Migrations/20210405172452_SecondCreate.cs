using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmRentalAPI.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Customers_CustomerID",
                table: "Rents");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Films_FilmID",
                table: "Rents");

            migrationBuilder.AlterColumn<int>(
                name: "FilmID",
                table: "Rents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Rents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Customers_CustomerID",
                table: "Rents",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Films_FilmID",
                table: "Rents",
                column: "FilmID",
                principalTable: "Films",
                principalColumn: "FilmID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Customers_CustomerID",
                table: "Rents");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Films_FilmID",
                table: "Rents");

            migrationBuilder.AlterColumn<int>(
                name: "FilmID",
                table: "Rents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Rents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Customers_CustomerID",
                table: "Rents",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Films_FilmID",
                table: "Rents",
                column: "FilmID",
                principalTable: "Films",
                principalColumn: "FilmID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
