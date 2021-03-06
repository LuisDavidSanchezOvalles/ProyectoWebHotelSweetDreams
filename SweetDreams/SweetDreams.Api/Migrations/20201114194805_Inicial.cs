﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetDreams.Api.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    ActividadId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreActividad = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Lugar = table.Column<string>(nullable: true),
                    Encargado = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    HoraInicio = table.Column<DateTime>(nullable: false),
                    HoraFinal = table.Column<DateTime>(nullable: false),
                    Accesibilidad = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.ActividadId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(nullable: false),
                    NombreUsuario = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    Clave = table.Column<string>(nullable: false),
                    Accesibilidad = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    HabitacionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroHabitacion = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    CaracteristicasSelecciones = table.Column<string>(nullable: true),
                    Caracteriscas = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    Foto = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Accesibilidad = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.HabitacionId);
                });

            migrationBuilder.CreateTable(
                name: "Reservaciones",
                columns: table => new
                {
                    ReservacionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaSalida = table.Column<DateTime>(nullable: false),
                    FechaExpiracion = table.Column<DateTime>(nullable: false),
                    Tarjeta = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false),
                    Accesibilidad = table.Column<bool>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    NombreCliente = table.Column<string>(nullable: true),
                    ClienteUsuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaciones", x => x.ReservacionId);
                });

            migrationBuilder.CreateTable(
                name: "ReservacionesDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReservacionId = table.Column<int>(nullable: false),
                    NumeroHabitacion = table.Column<string>(nullable: true),
                    CantidadAdultos = table.Column<int>(nullable: false),
                    CantidadNinos = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    HabitacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservacionesDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_ReservacionesDetalle_Reservaciones_ReservacionId",
                        column: x => x.ReservacionId,
                        principalTable: "Reservaciones",
                        principalColumn: "ReservacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservacionesDetalle_ReservacionId",
                table: "ReservacionesDetalle",
                column: "ReservacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "ReservacionesDetalle");

            migrationBuilder.DropTable(
                name: "Reservaciones");
        }
    }
}
