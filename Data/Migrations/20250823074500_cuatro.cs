using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alquiler_Vehiculos.Data.Migrations
{
    /// <inheritdoc />
    public partial class cuatro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiculosAlquilados_Vehiculos_VehiculosModelId",
                table: "VehiculosAlquilados");

            migrationBuilder.RenameColumn(
                name: "VehiculosModelId",
                table: "VehiculosAlquilados",
                newName: "VehiculoModelId");

            migrationBuilder.RenameIndex(
                name: "IX_VehiculosAlquilados_VehiculosModelId",
                table: "VehiculosAlquilados",
                newName: "IX_VehiculosAlquilados_VehiculoModelId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_At",
                table: "VehiculosAlquilados",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "VehiculosAlquilados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dias",
                table: "VehiculosAlquilados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Subtotal",
                table: "VehiculosAlquilados",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Precio_Diario",
                table: "Vehiculos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiculosAlquilados_Vehiculos_VehiculoModelId",
                table: "VehiculosAlquilados",
                column: "VehiculoModelId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiculosAlquilados_Vehiculos_VehiculoModelId",
                table: "VehiculosAlquilados");

            migrationBuilder.DropColumn(
                name: "Dias",
                table: "VehiculosAlquilados");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "VehiculosAlquilados");

            migrationBuilder.DropColumn(
                name: "Precio_Diario",
                table: "Vehiculos");

            migrationBuilder.RenameColumn(
                name: "VehiculoModelId",
                table: "VehiculosAlquilados",
                newName: "VehiculosModelId");

            migrationBuilder.RenameIndex(
                name: "IX_VehiculosAlquilados_VehiculoModelId",
                table: "VehiculosAlquilados",
                newName: "IX_VehiculosAlquilados_VehiculosModelId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_At",
                table: "VehiculosAlquilados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "VehiculosAlquilados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiculosAlquilados_Vehiculos_VehiculosModelId",
                table: "VehiculosAlquilados",
                column: "VehiculosModelId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
