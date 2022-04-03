using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KokoPizza.Persistance.Migrations
{
    public partial class AddOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "weather_forecasts");

            migrationBuilder.DropTable(
                name: "status_types");

            migrationBuilder.CreateSequence(
                name: "EntityFrameworkHiLoSequence",
                incrementBy: 10);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "categories",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "carts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "cart_items",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    status_id = table.Column<long>(type: "bigint", nullable: false),
                    ship_address = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_by = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    product_price = table.Column<decimal>(type: "numeric", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_by = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_items_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_items_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_items_order_id",
                table: "items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_items_product_id",
                table: "items",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropSequence(
                name: "EntityFrameworkHiLoSequence");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "categories",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "carts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "cart_items",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "status_types",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    last_modified_by = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    type_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_status_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "weather_forecasts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_by = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    summary = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    temperature_c = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_weather_forecasts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_type_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    last_modified_by = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_statuses", x => x.id);
                    table.ForeignKey(
                        name: "fk_statuses_status_types_status_type_id",
                        column: x => x.status_type_id,
                        principalTable: "status_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "weather_forecasts",
                columns: new[] { "id", "created_by", "created_date", "date", "last_modified_by", "last_modified_date", "summary", "temperature_c" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2022, 1, 16, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2230), new DateTime(2022, 1, 17, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2215), 0L, null, "Chilly", 15 },
                    { 2L, 1L, new DateTime(2022, 1, 16, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2232), new DateTime(2022, 1, 18, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2231), 0L, null, "Cool", 4 },
                    { 3L, 1L, new DateTime(2022, 1, 16, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2233), new DateTime(2022, 1, 19, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2232), 0L, null, "Chilly", -19 },
                    { 4L, 1L, new DateTime(2022, 1, 16, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2235), new DateTime(2022, 1, 20, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2234), 0L, null, "Chilly", 51 },
                    { 5L, 1L, new DateTime(2022, 1, 16, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2237), new DateTime(2022, 1, 21, 7, 23, 4, 234, DateTimeKind.Utc).AddTicks(2235), 0L, null, "Hot", -1 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_statuses_status_type_id",
                table: "statuses",
                column: "status_type_id");
        }
    }
}
