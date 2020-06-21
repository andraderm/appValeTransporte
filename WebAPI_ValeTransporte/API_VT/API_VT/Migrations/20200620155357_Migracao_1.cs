using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_VT.Migrations
{
    public partial class Migracao_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicial = table.Column<DateTime>(nullable: false),
                    DataFinal = table.Column<DateTime>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escalas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EscalaTrabalho = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escalas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 30, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 30, nullable: false),
                    DataAdmissao = table.Column<DateTime>(nullable: false),
                    CustoDiarioVT = table.Column<double>(nullable: false),
                    EscalaId = table.Column<int>(nullable: false),
                    SetorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Escalas_EscalaId",
                        column: x => x.EscalaId,
                        principalTable: "Escalas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Setores_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DespesasFuncionarios",
                columns: table => new
                {
                    DespesaId = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false),
                    DiasTrabalhados = table.Column<int>(nullable: false),
                    CustoIndividual = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesasFuncionarios", x => new { x.DespesaId, x.FuncionarioId });
                    table.ForeignKey(
                        name: "FK_DespesasFuncionarios_Despesas_DespesaId",
                        column: x => x.DespesaId,
                        principalTable: "Despesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DespesasFuncionarios_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Escalas",
                columns: new[] { "Id", "EscalaTrabalho" },
                values: new object[,]
                {
                    { 1, "5x2" },
                    { 2, "6x1" },
                    { 3, "6x2" },
                    { 4, "12x36" }
                });

            migrationBuilder.InsertData(
                table: "Setores",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Vendas" },
                    { 2, "Manutenção" },
                    { 3, "Limpeza" },
                    { 4, "Segurança" },
                    { 5, "Recursos Humanos" },
                    { 6, "Administração" },
                    { 7, "Brigada de Incêndio" },
                    { 8, "Recepção" }
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "CustoDiarioVT", "DataAdmissao", "EscalaId", "Nome", "SetorId", "Sobrenome" },
                values: new object[,]
                {
                    { 5, 12.1, new DateTime(2018, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Fábio", 1, "Torres" },
                    { 8, 7.5999999999999996, new DateTime(2018, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Fabiana", 1, "Alves" },
                    { 1, 15.6, new DateTime(2017, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "João", 2, "Paulo" },
                    { 9, 14.5, new DateTime(2017, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "José", 2, "Augusto" },
                    { 12, 11.6, new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Vinícius", 2, "André" },
                    { 7, 12.9, new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ana", 3, "Paula" },
                    { 6, 16.0, new DateTime(2017, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Marcos", 4, "Oliveira" },
                    { 13, 10.1, new DateTime(2018, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Guilherme", 4, "Barros" },
                    { 3, 11.199999999999999, new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Mariana", 5, "Silva" },
                    { 14, 9.5999999999999996, new DateTime(2017, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Regina", 5, "Pires" },
                    { 2, 9.4000000000000004, new DateTime(2017, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Antônio", 6, "Figueiredo" },
                    { 10, 13.300000000000001, new DateTime(2018, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Bruna", 7, "Ferraz" },
                    { 4, 10.4, new DateTime(2016, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Maria", 8, "José" },
                    { 11, 7.9000000000000004, new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", 8, "Viana" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DespesasFuncionarios_FuncionarioId",
                table: "DespesasFuncionarios",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EscalaId",
                table: "Funcionarios",
                column: "EscalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_SetorId",
                table: "Funcionarios",
                column: "SetorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DespesasFuncionarios");

            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Escalas");

            migrationBuilder.DropTable(
                name: "Setores");
        }
    }
}
