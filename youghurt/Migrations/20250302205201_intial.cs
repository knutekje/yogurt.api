using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace youghurt.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    registration_number = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    car_make = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    car_model = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    model_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastMaintenanceAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Longitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    Latitude = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicles");
        }
    }
}
