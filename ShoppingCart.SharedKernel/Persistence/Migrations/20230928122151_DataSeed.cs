using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingCart.SharedKernel.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sum",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "PriceCurrency",
                table: "Part",
                newName: "Price_Currency");

            migrationBuilder.RenameColumn(
                name: "PriceCost",
                table: "Part",
                newName: "Price_Cost");

            migrationBuilder.AlterColumn<int>(
                name: "Price_Cost",
                table: "Part",
                type: "integer",
                precision: 10,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Employee",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PriceCost",
                table: "CartItem",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Customer_1" },
                    { 2, "Customer_2" },
                    { 3, "Customer_3" },
                    { 4, "Customer_4" }
                });

            migrationBuilder.InsertData(
                table: "Part",
                columns: new[] { "Id", "Name", "Price_Cost", "Price_Currency", "ManufacturerName" },
                values: new object[,]
                {
                    { 1, "Part_1", 10, "BAM", "Manufacturer_1" },
                    { 2, "Part_2", 20, "BAM", "Manufacturer_2" },
                    { 3, "Part_3", 30, "BAM", "Manufacturer_3" }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "Name", "Address_City", "Address_Country", "Address_Number", "Address_Street" },
                values: new object[,]
                {
                    { 1, "Store_1", "City_1", "Country_1", "1", "Street_1" },
                    { 2, "Store_2", "City_2", "Country_2", "2", "Street_2" },
                    { 3, "Store_3", "City_3", "Country_3", "3", "Street_3" }
                });

            migrationBuilder.InsertData(
                table: "Customer_Addresses",
                columns: new[] { "Id", "City", "Country", "CustomerId", "Number", "Street" },
                values: new object[,]
                {
                    { 1, "City_1", "Country_1", 1, "1", "Street_1" },
                    { 2, "City_2", "Country_2", 2, "2", "Street_2" },
                    { 3, "City_3", "Country_3", 3, "3", "Street_3" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Name", "Status", "StoreId" },
                values: new object[,]
                {
                    { 1, "Employee_1", 0, 1 },
                    { 2, "Employee_2", 0, 1 },
                    { 3, "Employee_3", 0, 2 },
                    { 4, "Employee_4", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "StoreState",
                columns: new[] { "Id", "PartId", "Quantity", "StoreId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 2, 1 },
                    { 3, 3, 3, 1 },
                    { 4, 1, 1, 2 },
                    { 5, 3, 6, 2 },
                    { 6, 1, 1, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customer_Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer_Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer_Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StoreState",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StoreState",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StoreState",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StoreState",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StoreState",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StoreState",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Part",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Part",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Part",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Price_Currency",
                table: "Part",
                newName: "PriceCurrency");

            migrationBuilder.RenameColumn(
                name: "Price_Cost",
                table: "Part",
                newName: "PriceCost");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceCost",
                table: "Part",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldPrecision: 10,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceCost",
                table: "CartItem",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<decimal>(
                name: "Sum",
                table: "Cart",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
