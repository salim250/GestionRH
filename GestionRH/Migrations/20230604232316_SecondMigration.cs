using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionRH.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Credit");

            migrationBuilder.DropColumn(
                name: "Statut",
                table: "Credit");

            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Conge");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Conge");

            migrationBuilder.DropColumn(
                name: "Statut",
                table: "Autorisation");

            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "Conge",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cin",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateNaissance",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Poste",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Telephone",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeId",
                table: "Credit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Credit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TypeConge",
                table: "Conge",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EmployeId",
                table: "Conge",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeId",
                table: "Autorisation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Autorisation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Credit_EmployeId",
                table: "Credit",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_Conge_EmployeId",
                table: "Conge",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_Autorisation_EmployeId",
                table: "Autorisation",
                column: "EmployeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autorisation_Users_EmployeId",
                table: "Autorisation",
                column: "EmployeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Conge_Users_EmployeId",
                table: "Conge",
                column: "EmployeId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Credit_Users_EmployeId",
                table: "Credit",
                column: "EmployeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autorisation_Users_EmployeId",
                table: "Autorisation");

            migrationBuilder.DropForeignKey(
                name: "FK_Conge_Users_EmployeId",
                table: "Conge");

            migrationBuilder.DropForeignKey(
                name: "FK_Credit_Users_EmployeId",
                table: "Credit");

            migrationBuilder.DropIndex(
                name: "IX_Credit_EmployeId",
                table: "Credit");

            migrationBuilder.DropIndex(
                name: "IX_Conge_EmployeId",
                table: "Conge");

            migrationBuilder.DropIndex(
                name: "IX_Autorisation_EmployeId",
                table: "Autorisation");

            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Cin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateNaissance",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Poste",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeId",
                table: "Credit");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Credit");

            migrationBuilder.DropColumn(
                name: "EmployeId",
                table: "Conge");

            migrationBuilder.DropColumn(
                name: "EmployeId",
                table: "Autorisation");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Autorisation");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Conge",
                newName: "Telephone");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Credit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Statut",
                table: "Credit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TypeConge",
                table: "Conge",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Conge",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Conge",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Statut",
                table: "Autorisation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
