using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto360.Repositorio.Migrations
{
    public partial class Iniciall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoDeUsuario",
                table: "Usuarios",
                newName: "Tipo");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Usuarios",
                newName: "TipoDeUsuario");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDeUsuario",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
