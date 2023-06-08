using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionRH.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conge_Users_EmployeId",
                table: "Conge");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeId",
                table: "Conge",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Conge_Users_EmployeId",
                table: "Conge",
                column: "EmployeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conge_Users_EmployeId",
                table: "Conge");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeId",
                table: "Conge",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Conge_Users_EmployeId",
                table: "Conge",
                column: "EmployeId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
