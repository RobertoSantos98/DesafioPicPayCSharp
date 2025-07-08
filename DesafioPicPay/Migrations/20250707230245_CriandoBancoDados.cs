using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesafioPicPay.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBancoDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carteira",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Sobrenome = table.Column<string>(type: "text", nullable: false),
                    CpfCnpj = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Saldo = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteira", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transferencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPagador = table.Column<int>(type: "integer", nullable: false),
                    IdRecebedor = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DataTransferencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Aprovada = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tranferencia_Pagador",
                        column: x => x.IdPagador,
                        principalTable: "Carteira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tranferencia_Recebedor",
                        column: x => x.IdRecebedor,
                        principalTable: "Carteira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carteira_CpfCnpj",
                table: "Carteira",
                column: "CpfCnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_IdPagador",
                table: "Transferencia",
                column: "IdPagador");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_IdRecebedor",
                table: "Transferencia",
                column: "IdRecebedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transferencia");

            migrationBuilder.DropTable(
                name: "Carteira");
        }
    }
}
