using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoOcean.Migrations
{
    /// <inheritdoc />
    public partial class relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventoVoluntario");

            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "Voluntario",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParticipacaoId",
                table: "Coleta",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartipiacaoId",
                table: "Coleta",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Participacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    VoluntarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Pontuacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participacao_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participacao_Voluntario_VoluntarioId",
                        column: x => x.VoluntarioId,
                        principalTable: "Voluntario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voluntario_EventoId",
                table: "Voluntario",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Coleta_ParticipacaoId",
                table: "Coleta",
                column: "ParticipacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participacao_EventoId",
                table: "Participacao",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participacao_VoluntarioId",
                table: "Participacao",
                column: "VoluntarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coleta_Participacao_ParticipacaoId",
                table: "Coleta",
                column: "ParticipacaoId",
                principalTable: "Participacao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voluntario_Evento_EventoId",
                table: "Voluntario",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coleta_Participacao_ParticipacaoId",
                table: "Coleta");

            migrationBuilder.DropForeignKey(
                name: "FK_Voluntario_Evento_EventoId",
                table: "Voluntario");

            migrationBuilder.DropTable(
                name: "Participacao");

            migrationBuilder.DropIndex(
                name: "IX_Voluntario_EventoId",
                table: "Voluntario");

            migrationBuilder.DropIndex(
                name: "IX_Coleta_ParticipacaoId",
                table: "Coleta");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Voluntario");

            migrationBuilder.DropColumn(
                name: "ParticipacaoId",
                table: "Coleta");

            migrationBuilder.DropColumn(
                name: "PartipiacaoId",
                table: "Coleta");

            migrationBuilder.CreateTable(
                name: "EventoVoluntario",
                columns: table => new
                {
                    EventosId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VoluntariosId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoVoluntario", x => new { x.EventosId, x.VoluntariosId });
                    table.ForeignKey(
                        name: "FK_EventoVoluntario_Evento_EventosId",
                        column: x => x.EventosId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoVoluntario_Voluntario_VoluntariosId",
                        column: x => x.VoluntariosId,
                        principalTable: "Voluntario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventoVoluntario_VoluntariosId",
                table: "EventoVoluntario",
                column: "VoluntariosId");
        }
    }
}
