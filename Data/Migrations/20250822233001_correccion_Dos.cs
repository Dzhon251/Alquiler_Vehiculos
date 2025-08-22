using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alquiler_Vehiculos.Data.Migrations
{
    /// <inheritdoc />
    public partial class correccion_Dos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vehiculo_Id",
                table: "Vehiculos",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "Create_At",
                table: "Vehiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Update_At",
                table: "Vehiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "Vehiculos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Create_At",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Update_At",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Alquilados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAlquiler = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Codigo_Alquiler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total_Alquiler = table.Column<double>(type: "float", nullable: false),
                    ClienteModelId = table.Column<int>(type: "int", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquilados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alquilados_Clientes_ClienteModelId",
                        column: x => x.ClienteModelId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiculosAlquilados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculosModelId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    AlquilerModelId = table.Column<int>(type: "int", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculosAlquilados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiculosAlquilados_Alquilados_AlquilerModelId",
                        column: x => x.AlquilerModelId,
                        principalTable: "Alquilados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiculosAlquilados_Vehiculos_VehiculosModelId",
                        column: x => x.VehiculosModelId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquilados_ClienteModelId",
                table: "Alquilados",
                column: "ClienteModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculosAlquilados_AlquilerModelId",
                table: "VehiculosAlquilados",
                column: "AlquilerModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculosAlquilados_VehiculosModelId",
                table: "VehiculosAlquilados",
                column: "VehiculosModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiculosAlquilados");

            migrationBuilder.DropTable(
                name: "Alquilados");

            migrationBuilder.DropColumn(
                name: "Create_At",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "Update_At",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "Create_At",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Update_At",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vehiculos",
                newName: "Vehiculo_Id");
        }
    }
}
