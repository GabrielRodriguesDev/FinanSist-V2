using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finansist.Database.Migrations
{
    public partial class VR02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Entidades",
                table: "Entidades");

            migrationBuilder.RenameTable(
                name: "Entidades",
                newName: "Entidade");

            migrationBuilder.AlterTable(
                name: "Entidade",
                comment: "Tabela responsável pelos registros de entidade.")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Entidade",
                type: "varchar(120)",
                nullable: false,
                comment: "Nome.",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExcluidoEm",
                table: "Entidade",
                type: "datetime(6)",
                nullable: true,
                comment: "Data e hora da exclusão lógica do registro.",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Entidade",
                type: "varchar(150)",
                nullable: false,
                comment: "Descrição.",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "Entidade",
                type: "datetime(6)",
                nullable: true,
                comment: "Data e hora de criação do registro.",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Entidade",
                type: "tinyint(1)",
                nullable: false,
                comment: "Define de o registro está ativo.",
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteradoEm",
                table: "Entidade",
                type: "datetime(6)",
                nullable: true,
                comment: "Data e hora da última alteração do registro.",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Entidade",
                type: "char(36)",
                nullable: false,
                comment: "Identificador do registro.",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Entidade",
                type: "varchar(120)",
                nullable: true,
                comment: "Bairro.")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Entidade",
                type: "varchar(8)",
                nullable: true,
                comment: "CEP.")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<int>(
                name: "CodigoInterno",
                table: "Entidade",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Código interno (sequencial).");

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Entidade",
                type: "varchar(120)",
                nullable: true,
                comment: "Complemento.")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Entidade",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Entidade",
                type: "varchar(120)",
                nullable: true,
                comment: "Logradouro.")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Entidade",
                type: "int",
                nullable: true,
                comment: "Número do endereço.");

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Entidade",
                type: "varchar(2)",
                nullable: true,
                comment: "UF.")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entidade",
                table: "Entidade",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ControleSequencia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Identificador do registro.", collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false, comment: "Nome das tabelas.")
                        .Annotation("MySql:CharSet", "utf8"),
                    Numero = table.Column<int>(type: "int", nullable: false, comment: "Número sequencial."),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "Data e hora de criação do registro."),
                    AlteradoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "Data e hora da última alteração do registro."),
                    ExcluidoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "Data e hora da exclusão lógica do registro."),
                    CodigoExclusao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleSequencia", x => x.Id);
                },
                comment: "Tabela responsável pelo controle de sequencia.")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateIndex(
                name: "unq1_Entidade",
                table: "Entidade",
                column: "CodigoInterno",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unq1_Entidade",
                table: "ControleSequencia",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControleSequencia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entidade",
                table: "Entidade");

            migrationBuilder.DropIndex(
                name: "unq1_Entidade",
                table: "Entidade");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Entidade");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Entidade");

            migrationBuilder.DropColumn(
                name: "CodigoInterno",
                table: "Entidade");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Entidade");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Entidade");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Entidade");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Entidade");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Entidade");

            migrationBuilder.RenameTable(
                name: "Entidade",
                newName: "Entidades");

            migrationBuilder.AlterTable(
                name: "Entidades",
                oldComment: "Tabela responsável pelos registros de entidade.")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Entidades",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldComment: "Nome.")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExcluidoEm",
                table: "Entidades",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldComment: "Data e hora da exclusão lógica do registro.");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Entidades",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldComment: "Descrição.")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "Entidades",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldComment: "Data e hora de criação do registro.");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Entidades",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldComment: "Define de o registro está ativo.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlteradoEm",
                table: "Entidades",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldComment: "Data e hora da última alteração do registro.");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Entidades",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldComment: "Identificador do registro.")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entidades",
                table: "Entidades",
                column: "Id");
        }
    }
}
