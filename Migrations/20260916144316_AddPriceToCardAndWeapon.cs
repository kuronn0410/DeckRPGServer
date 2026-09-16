using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeckRPGServer.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToCardAndWeapon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Money",
                table: "Weapons",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Money",
                table: "Cards",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Weapons",
                newName: "Money");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Cards",
                newName: "Money");
        }
    }
}
