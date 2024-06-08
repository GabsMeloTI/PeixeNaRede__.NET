using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeixeNaRede.Migrations
{
    /// <inheritdoc />
    public partial class Global : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.CreateTable(
                name: "Encontro",
                columns: table => new
                {
                    CdEncontro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DtEncontro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DsLocal = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DsStatus = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encontro", x => x.CdEncontro);
                });

            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    CdEspecie = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmCientifico = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NmPopular = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DsFoto = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    DsDescricao = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.CdEspecie);
                });

            migrationBuilder.CreateTable(
                name: "Pescaria",
                columns: table => new
                {
                    CdPescaria = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DtPescaria = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DsLocalizacao = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: false),
                    DsCondicoesClimaticas = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TpPesca = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    DsMetodoPesca = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DsDetalhes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pescaria", x => x.CdPescaria);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    CdOferta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DsEspecie = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DsQuantidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VlPreco = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    DsStatus = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CdEncontro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.CdOferta);
                    table.ForeignKey(
                        name: "FK_Oferta_Encontro_CdEncontro",
                        column: x => x.CdEncontro,
                        principalTable: "Encontro",
                        principalColumn: "CdEncontro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Captura",
                columns: table => new
                {
                    CdCaptura = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DsQuantidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DsPeso = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    DsFoto = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    CdEspecie = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CdPescaria = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Captura", x => x.CdCaptura);
                    table.ForeignKey(
                        name: "FK_Captura_Especie_CdEspecie",
                        column: x => x.CdEspecie,
                        principalTable: "Especie",
                        principalColumn: "CdEspecie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Captura_Pescaria_CdPescaria",
                        column: x => x.CdPescaria,
                        principalTable: "Pescaria",
                        principalColumn: "CdPescaria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    CdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmUsuario = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    DsEmail = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    DsSenha = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    DsTipo = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    DsLocalizacao = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    DsFotoPerfil = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    CdPescaria = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.CdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Pescaria_CdPescaria",
                        column: x => x.CdPescaria,
                        principalTable: "Pescaria",
                        principalColumn: "CdPescaria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncontrosUsuarios",
                columns: table => new
                {
                    CdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CdEncontro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncontrosUsuarios", x => new { x.CdUsuario, x.CdEncontro });
                    table.ForeignKey(
                        name: "FK_EncontrosUsuarios_Encontro_CdEncontro",
                        column: x => x.CdEncontro,
                        principalTable: "Encontro",
                        principalColumn: "CdEncontro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncontrosUsuarios_Usuario_CdUsuario",
                        column: x => x.CdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Captura_CdEspecie",
                table: "Captura",
                column: "CdEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_Captura_CdPescaria",
                table: "Captura",
                column: "CdPescaria");

            migrationBuilder.CreateIndex(
                name: "IX_EncontrosUsuarios_CdEncontro",
                table: "EncontrosUsuarios",
                column: "CdEncontro");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_CdEncontro",
                table: "Oferta",
                column: "CdEncontro");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CdPescaria",
                table: "Usuario",
                column: "CdPescaria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Captura");

            migrationBuilder.DropTable(
                name: "EncontrosUsuarios");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Especie");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Encontro");

            migrationBuilder.DropTable(
                name: "Pescaria");

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataFim = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                });
        }
    }
}
