﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalAPI.Migrations
{
    /// <inheritdoc />
    public partial class FinalAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Carrera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<double>(type: "float", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estrato = table.Column<int>(type: "int", nullable: false),
                    ContactoEmergencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Name",
                table: "Students",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
