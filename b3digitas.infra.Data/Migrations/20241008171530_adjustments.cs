﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace b3digitas.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adjustments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuantityAvailable",
                table: "Quote",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityAvailable",
                table: "Quote");
        }
    }
}
