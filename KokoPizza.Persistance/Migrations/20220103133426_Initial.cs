using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KokoPizza.Persistance.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "weather_forecasts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    temperature_c = table.Column<int>(type: "integer", nullable: false),
                    summary = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_by = table.Column<long?>(type: "bigint", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_weather_forecasts", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "weather_forecasts",
                columns: new[] { "id", "created_by", "created_date", "date", "last_modified_by", "last_modified_date", "summary", "temperature_c" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2022, 1, 3, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8720), new DateTime(2022, 1, 4, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8703), 1L, new DateTime(2022, 1, 3, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8720), "Warm", 29 },
                    { 2L, 1L, new DateTime(2022, 1, 3, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8722), new DateTime(2022, 1, 5, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8721), 1L, new DateTime(2022, 1, 3, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8722), "Freezing", -5 },
                    { 3L, 1L, new DateTime(2022, 1, 3, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8724), new DateTime(2022, 1, 6, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8723), 1L, new DateTime(2022, 1, 3, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8724), "Chilly", 52 },
                    { 4L, 1L, new DateTime(2022, 1, 3, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8725), new DateTime(2022, 1, 7, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8725), 1L, new DateTime(2022, 1, 3, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8725), "Balmy", 42 },
                    { 5L, 1L, new DateTime(2022, 1, 3, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8727), new DateTime(2022, 1, 8, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8726), 1L, new DateTime(2022, 1, 3, 13, 34, 26, 708, DateTimeKind.Utc).AddTicks(8727), "Chilly", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "weather_forecasts");
        }
    }
}
