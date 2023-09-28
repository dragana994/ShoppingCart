using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCart.SharedKernel.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ManufacturerName",
                table: "Part",
                newName: "Manufacturer_Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manufacturer_Name",
                table: "Part",
                newName: "ManufacturerName");
        }
    }
}
