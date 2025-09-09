using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedAgregadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "NameCategory", "Order" },
                values: new object[,]
                {
                    { 1, "Pequeñas porcines para abrir el apetito antes del plato principal.", "Entradas", 1 },
                    { 2, "Opciones frescas y livianas, ideales como acompañamiento o plato principal.", "Ensaladas", 2 },
                    { 3, "Platos rápidos y clásicos de bodegón: milanesas, torillas, revueltos.", "Minutas", 3 },
                    { 4, "Vareidad de pastas caseras y salsas tradicinales.", "Pastas", 4 },
                    { 5, "Cortes de carne asados a la parrilla, servidos con guarnicion.", "Parrilla", 5 },
                    { 6, "Pizzas artesanales con masa casera y variedad de ingredientes.", "Pizzas", 6 },
                    { 7, "Sandwiches y lomitos completos preparados al momento.", "Sandwiches", 7 },
                    { 8, "Gaseosas, jugos, aguas  y opciones sin alcohol.", "Bebidas", 8 },
                    { 9, "Cervezas de produccion artesanal, rubias, rojas, negras.", "Cervezas Artesanales", 9 },
                    { 10, "Dulces tentaciones para finalizar la comida con broche de oro.", "Postres", 10 }
                });

            migrationBuilder.InsertData(
                table: "Deliverytypes",
                columns: new[] { "IdD", "NameDeliveryT" },
                values: new object[,]
                {
                    { 1, "Delivery" },
                    { 2, "Take away" },
                    { 3, "Dine in" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "NameStatus" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "In Progress" },
                    { 3, "Ready" },
                    { 4, "Delivery" },
                    { 5, "Delivered" },
                    { 6, "Closed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Deliverytypes",
                keyColumn: "IdD",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deliverytypes",
                keyColumn: "IdD",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Deliverytypes",
                keyColumn: "IdD",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
