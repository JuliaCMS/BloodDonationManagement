using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddedBloodTypeTableAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "BloodInventories");

            migrationBuilder.DropColumn(
                name: "ComponentType",
                table: "BloodInventories");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BloodInventories");

            migrationBuilder.AddColumn<int>(
                name: "BloodTypeId",
                table: "Donors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BloodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboRhType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodComponentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BloodInventoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodTypes_BloodInventories_BloodInventoryId",
                        column: x => x.BloodInventoryId,
                        principalTable: "BloodInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donors_BloodTypeId",
                table: "Donors",
                column: "BloodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTypes_BloodInventoryId",
                table: "BloodTypes",
                column: "BloodInventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_BloodTypes_BloodTypeId",
                table: "Donors",
                column: "BloodTypeId",
                principalTable: "BloodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_BloodTypes_BloodTypeId",
                table: "Donors");

            migrationBuilder.DropTable(
                name: "BloodTypes");

            migrationBuilder.DropIndex(
                name: "IX_Donors_BloodTypeId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "BloodTypeId",
                table: "Donors");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "BloodInventories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ComponentType",
                table: "BloodInventories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BloodInventories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
