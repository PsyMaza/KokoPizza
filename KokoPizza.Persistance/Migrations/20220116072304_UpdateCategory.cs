using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KokoPizza.Persistance.Migrations
{
    public partial class UpdateCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "categories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "weather_forecasts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_by", "created_date", "date", "summary", "temperature_c" },
                values: new object[] { 1L, new DateTime(2022, 1, 16, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2230), new DateTime(2022, 1, 17, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2215), "Chilly", 15 });

            migrationBuilder.UpdateData(
                table: "weather_forecasts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_by", "created_date", "date", "summary", "temperature_c" },
                values: new object[] { 1L, new DateTime(2022, 1, 16, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2232), new DateTime(2022, 1, 18, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2231), "Cool", 4 });

            migrationBuilder.UpdateData(
                table: "weather_forecasts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_by", "created_date", "date", "summary", "temperature_c" },
                values: new object[] { 1L, new DateTime(2022, 1, 16, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2233), new DateTime(2022, 1, 19, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2232), "Chilly", -19 });

            migrationBuilder.UpdateData(
                table: "weather_forecasts",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_by", "created_date", "date", "summary", "temperature_c" },
                values: new object[] { 1L, new DateTime(2022, 1, 16, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2235), new DateTime(2022, 1, 20, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2234), "Chilly", 51 });

            migrationBuilder.UpdateData(
                table: "weather_forecasts",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "created_by", "created_date", "date", "summary", "temperature_c" },
                values: new object[] { 1L, new DateTime(2022, 1, 16, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2237), new DateTime(2022, 1, 21, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2235), "Hot", -1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "categories");

            migrationBuilder.UpdateData(
                table: "weather_forecasts",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_by", "created_date", "date", "summary", "temperature_c" },
                values: new object[] { -1L, new DateTime(2022, 1, 8, 12, 17, 1, 993, DateTimeKind.Utc).AddTicks(1595), new DateTime(2022, 1, 9, 12, 17, 1, 993, DateTimeKind.Utc).AddTicks(1579), "Warm", 35 });

            migrationBuilder.UpdateData(
                table: "weather_forecasts",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_by", "created_date", "date", "summary", "temperature_c" },
                values: new object[] { -1L, new DateTime(2022, 1, 8, 12, 17, 1, 993, DateTimeKind.Utc).AddTicks(1598), new DateTime(2022, 1, 10, 12, 17, 1, 993, DateTimeKind.Utc).AddTicks(1596), "Chilly", 0 });

            migrationBuilder.UpdateData(
                table: "weather_forecasts",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_by", "created_date", "date", "summary", "temperature_c" },
                values: new object[] { -1L, new DateTime(2022, 1, 8, 12, 17, 1, 993, DateTimeKind.Utc).AddTicks(1599), new DateTime(2022, 1, 11, 12, 17, 1, 993, DateTimeKind.Utc).AddTicks(1598), "Freezing", 12 });

            migrationBuilder.UpdateData(
                table: "weather_forecasts",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_by", "created_date", "date", "summary", "temperature_c" },
                values: new object[] { -1L, new DateTime(2022, 1, 8, 12, 17, 1, 993, DateTimeKind.Utc).AddTicks(1601), new DateTime(2022, 1, 12, 12, 17, 1, 993, DateTimeKind.Utc).AddTicks(1600), "Cool", 17 });

            migrationBuilder.UpdateData(
                table: "weather_forecasts",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "created_by", "created_date", "date", "summary", "temperature_c" },
                values: new object[] { -1L, new DateTime(2022, 1, 8, 12, 17, 1, 993, DateTimeKind.Utc).AddTicks(1602), new DateTime(2022, 1, 13, 12, 17, 1, 993, DateTimeKind.Utc).AddTicks(1601), "Cool", 28 });
        }
    }
}
