﻿// <auto-generated />
using System;
using Finansist.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Finansist.Database.Migrations
{
    [DbContext(typeof(FinansistContext))]
    [Migration("20221026020305_VR01")]
    partial class VR01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Finansist.Domain.Entities.ControleSequencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("Identificador do registro.");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime(6)")
                        .HasComment("Data e hora da última alteração do registro.");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime(6)")
                        .HasComment("Data e hora de criação do registro.");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasComment("Nome das tabelas.");

                    b.Property<int>("Numero")
                        .HasColumnType("int")
                        .HasComment("Número sequencial.");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasDatabaseName("unq1_Entidade");

                    b.ToTable("ControleSequencia", (string)null);

                    b.HasComment("Tabela responsável pelo controle de sequencia.");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                });

            modelBuilder.Entity("Finansist.Domain.Entities.Entidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("Identificador do registro.");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime(6)")
                        .HasComment("Data e hora da última alteração do registro.");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasComment("Define de o registro está ativo.");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(120)")
                        .HasComment("Bairro.");

                    b.Property<string>("CEP")
                        .HasColumnType("varchar(8)")
                        .HasComment("CEP.");

                    b.Property<int>("CodigoInterno")
                        .HasColumnType("int")
                        .HasComment("Código interno (sequencial).");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(120)")
                        .HasComment("Complemento.");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime(6)")
                        .HasComment("Data e hora de criação do registro.");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasComment("Descrição.");

                    b.Property<string>("Localidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Logradouro")
                        .HasColumnType("varchar(120)")
                        .HasComment("Logradouro.");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasComment("Nome.");

                    b.Property<int?>("Numero")
                        .HasColumnType("int")
                        .HasComment("Número do endereço.");

                    b.Property<string>("UF")
                        .HasColumnType("varchar(2)")
                        .HasComment("UF.");

                    b.HasKey("Id");

                    b.HasIndex("CodigoInterno")
                        .IsUnique()
                        .HasDatabaseName("unq1_Entidade");

                    b.ToTable("Entidade", (string)null);

                    b.HasComment("Tabela responsável pelos registros de entidade.");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                });

            modelBuilder.Entity("Finansist.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("Identificador do registro.");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime(6)")
                        .HasComment("Data e hora da última alteração do registro.");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)")
                        .HasComment("Define de o registro está ativo.");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime(6)")
                        .HasComment("Data e hora de criação do registro.");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasComment("E-mail.");

                    b.Property<bool>("ExigirNovaSenha")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasComment("Nome.");

                    b.Property<int>("Perfil")
                        .HasColumnType("int")
                        .HasComment("Perfil do Usuário. { 1 -> Administrador, 2 -> Cliente }.");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasComment("Senha.");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("unq1_Usuario");

                    b.ToTable("Usuario", (string)null);

                    b.HasComment("Tabela responsável pelos registros de entidade.");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                });
#pragma warning restore 612, 618
        }
    }
}
