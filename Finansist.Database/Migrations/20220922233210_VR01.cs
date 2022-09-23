using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finansist.Database.Migrations
{
    public partial class VR01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ControleSequencia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Identificador do registro.", collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false, comment: "Nome das tabelas.")
                        .Annotation("MySql:CharSet", "utf8"),
                    Numero = table.Column<int>(type: "int", nullable: false, comment: "Número sequencial."),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "Data e hora de criação do registro."),
                    AlteradoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "Data e hora da última alteração do registro.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleSequencia", x => x.Id);
                },
                comment: "Tabela responsável pelo controle de sequencia.")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "Entidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Identificador do registro.", collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(120)", nullable: false, comment: "Nome.")
                        .Annotation("MySql:CharSet", "utf8"),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: false, comment: "Descrição.")
                        .Annotation("MySql:CharSet", "utf8"),
                    CodigoInterno = table.Column<int>(type: "int", nullable: false, comment: "Código interno (sequencial)."),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Define de o registro está ativo."),
                    CEP = table.Column<string>(type: "varchar(8)", nullable: true, comment: "CEP.")
                        .Annotation("MySql:CharSet", "utf8"),
                    Logradouro = table.Column<string>(type: "varchar(120)", nullable: true, comment: "Logradouro.")
                        .Annotation("MySql:CharSet", "utf8"),
                    Bairro = table.Column<string>(type: "varchar(120)", nullable: true, comment: "Bairro.")
                        .Annotation("MySql:CharSet", "utf8"),
                    Complemento = table.Column<string>(type: "varchar(120)", nullable: true, comment: "Complemento.")
                        .Annotation("MySql:CharSet", "utf8"),
                    Localidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    UF = table.Column<string>(type: "varchar(2)", nullable: true, comment: "UF.")
                        .Annotation("MySql:CharSet", "utf8"),
                    Numero = table.Column<int>(type: "int", nullable: true, comment: "Número do endereço."),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "Data e hora de criação do registro."),
                    AlteradoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "Data e hora da última alteração do registro.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidade", x => x.Id);
                },
                comment: "Tabela responsável pelos registros de entidade.")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateIndex(
                name: "unq1_Entidade",
                table: "ControleSequencia",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unq1_Entidade",
                table: "Entidade",
                column: "CodigoInterno",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControleSequencia");

            migrationBuilder.DropTable(
                name: "Entidade");
        }
    }
}
