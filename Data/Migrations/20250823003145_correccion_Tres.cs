using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alquiler_Vehiculos.Data.Migrations
{
    /// <inheritdoc />
    public partial class correccion_Tres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehiculoModelId",
                table: "Alquilados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alquilados_VehiculoModelId",
                table: "Alquilados",
                column: "VehiculoModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alquilados_Vehiculos_VehiculoModelId",
                table: "Alquilados",
                column: "VehiculoModelId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alquilados_Vehiculos_VehiculoModelId",
                table: "Alquilados");

            migrationBuilder.DropIndex(
                name: "IX_Alquilados_VehiculoModelId",
                table: "Alquilados");

            migrationBuilder.DropColumn(
                name: "VehiculoModelId",
                table: "Alquilados");
        }
    }
}
