using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finansist.Database.Migrations
{
    public partial class VR02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Identificador do registro.", collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(120)", nullable: false, comment: "Nome.")
                        .Annotation("MySql:CharSet", "utf8"),
                    Email = table.Column<string>(type: "varchar(120)", nullable: false, comment: "E-mail.")
                        .Annotation("MySql:CharSet", "utf8"),
                    Senha = table.Column<string>(type: "varchar(30)", nullable: false, comment: "Senha.")
                        .Annotation("MySql:CharSet", "utf8"),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    Perfil = table.Column<int>(type: "int", nullable: false, comment: "Perfil do Usuário. { 1 -> Administrador, 2 -> Cliente }."),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Define de o registro está ativo."),
                    ExigirNovaSenha = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "Data e hora de criação do registro."),
                    AlteradoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "Data e hora da última alteração do registro.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                },
                comment: "Tabela responsável pelos registros de entidade.")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateIndex(
                name: "unq1_Usuario",
                table: "Usuario",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
