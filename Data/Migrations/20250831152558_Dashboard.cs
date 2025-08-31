using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alquiler_Vehiculos.Data.Migrations
{
    /// <inheritdoc />
    public partial class Dashboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DashboardViewModelId",
                table: "Alquilados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dashboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clientes = table.Column<int>(type: "int", nullable: false),
                    Vehiculos = table.Column<int>(type: "int", nullable: false),
                    Numero_Alquiler = table.Column<int>(type: "int", nullable: false),
                    Total_Alquilados = table.Column<double>(type: "float", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboards", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquilados_DashboardViewModelId",
                table: "Alquilados",
                column: "DashboardViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alquilados_Dashboards_DashboardViewModelId",
                table: "Alquilados",
                column: "DashboardViewModelId",
                principalTable: "Dashboards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alquilados_Dashboards_DashboardViewModelId",
                table: "Alquilados");

            migrationBuilder.DropTable(
                name: "Dashboards");

            migrationBuilder.DropIndex(
                name: "IX_Alquilados_DashboardViewModelId",
                table: "Alquilados");

            migrationBuilder.DropColumn(
                name: "DashboardViewModelId",
                table: "Alquilados");
        }
    }
}
