using Microsoft.EntityFrameworkCore.Migrations;

namespace Prototipos_Huertos_Autosustentables.Data.Migrations
{
    public partial class Huertos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Climas",
                columns: table => new
                {
                    IdClima = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreClima = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Climas", x => x.IdClima);
                });

            migrationBuilder.CreateTable(
                name: "TipoCultivos",
                columns: table => new
                {
                    IdTipoCultivos = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoCultivos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCultivos", x => x.IdTipoCultivos);
                });

            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    IdRegiones = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClima = table.Column<int>(nullable: true),
                    NombreRegiones = table.Column<string>(nullable: true),
                    IdClimaNavigationIdClima = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.IdRegiones);
                    table.ForeignKey(
                        name: "FK_Regiones_Climas_IdClimaNavigationIdClima",
                        column: x => x.IdClimaNavigationIdClima,
                        principalTable: "Climas",
                        principalColumn: "IdClima",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cultivos",
                columns: table => new
                {
                    IdCultivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoCultivos = table.Column<int>(nullable: true),
                    IdRegiones = table.Column<int>(nullable: true),
                    NombreCultivos = table.Column<string>(nullable: true),
                    IntroduccionCultivos = table.Column<string>(nullable: true),
                    CuerpoCultivos = table.Column<string>(nullable: true),
                    Recomendaciones = table.Column<string>(nullable: true),
                    IdRegionesNavigationIdRegiones = table.Column<int>(nullable: true),
                    IdTipoCultivosNavigationIdTipoCultivos = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivos", x => x.IdCultivo);
                    table.ForeignKey(
                        name: "FK_Cultivos_Regiones_IdRegionesNavigationIdRegiones",
                        column: x => x.IdRegionesNavigationIdRegiones,
                        principalTable: "Regiones",
                        principalColumn: "IdRegiones",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cultivos_TipoCultivos_IdTipoCultivosNavigationIdTipoCultivos",
                        column: x => x.IdTipoCultivosNavigationIdTipoCultivos,
                        principalTable: "TipoCultivos",
                        principalColumn: "IdTipoCultivos",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCultivosUsuarios",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCultivo = table.Column<int>(nullable: true),
                    IdUsers = table.Column<string>(nullable: true),
                    MetrosCuadrasDetalle = table.Column<double>(nullable: true),
                    PrecioSemillasDetalle = table.Column<double>(nullable: true),
                    LugarCultivoDetalle = table.Column<string>(nullable: true),
                    IdCultivoNavigationIdCultivo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCultivosUsuarios", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_DetalleCultivosUsuarios_Cultivos_IdCultivoNavigationIdCultivo",
                        column: x => x.IdCultivoNavigationIdCultivo,
                        principalTable: "Cultivos",
                        principalColumn: "IdCultivo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cultivos_IdRegionesNavigationIdRegiones",
                table: "Cultivos",
                column: "IdRegionesNavigationIdRegiones");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivos_IdTipoCultivosNavigationIdTipoCultivos",
                table: "Cultivos",
                column: "IdTipoCultivosNavigationIdTipoCultivos");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCultivosUsuarios_IdCultivoNavigationIdCultivo",
                table: "DetalleCultivosUsuarios",
                column: "IdCultivoNavigationIdCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_Regiones_IdClimaNavigationIdClima",
                table: "Regiones",
                column: "IdClimaNavigationIdClima");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleCultivosUsuarios");

            migrationBuilder.DropTable(
                name: "Cultivos");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropTable(
                name: "TipoCultivos");

            migrationBuilder.DropTable(
                name: "Climas");
        }
    }
}
