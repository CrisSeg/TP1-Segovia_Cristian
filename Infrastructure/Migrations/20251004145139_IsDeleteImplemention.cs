using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsDeleteImplemention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCategory = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deliverytypes",
                columns: table => new
                {
                    IdD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDeliveryT = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverytypes", x => x.IdD);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameStatus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    DishId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameDish = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Avialable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.DishId);
                    table.ForeignKey(
                        name: "FK_Dishes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryTo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OStatusId = table.Column<int>(type: "int", nullable: false),
                    DeliveryTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Deliverytypes_DeliveryTypeId",
                        column: x => x.DeliveryTypeId,
                        principalTable: "Deliverytypes",
                        principalColumn: "IdD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Statuses_OStatusId",
                        column: x => x.OStatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DishId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_orderItems_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderItems_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_DishId",
                table: "orderItems",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_OrderId",
                table: "orderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_StatusId",
                table: "orderItems",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryTypeId",
                table: "Orders",
                column: "DeliveryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OStatusId",
                table: "Orders",
                column: "OStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderItems");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Deliverytypes");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
