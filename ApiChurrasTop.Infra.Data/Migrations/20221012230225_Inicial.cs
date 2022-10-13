using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiChurrasTop.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    data = table.Column<DateTime>(type: "date", nullable: false),
                    descricao = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    observacao = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cpf = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: true),
                    nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    telefone = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    senha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AgendaPessoa",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    pessoa_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    agenda_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComBebida = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaPessoa", x => x.id);
                    table.ForeignKey(
                        name: "FK_AgendaPessoa_Agenda",
                        column: x => x.agenda_id,
                        principalTable: "Agenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgendaPessoa_Pessoa",
                        column: x => x.pessoa_id,
                        principalTable: "Pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendaPessoa_agenda_id",
                table: "AgendaPessoa",
                column: "agenda_id");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaPessoa_pessoa_id",
                table: "AgendaPessoa",
                column: "pessoa_id");

            migrationBuilder.CreateIndex(
                name: "UN_Pessoa_CPF",
                table: "Pessoa",
                column: "cpf",
                unique: true,
                filter: "[cpf] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UN_Pessoa_EMAIL",
                table: "Pessoa",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaPessoa");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
