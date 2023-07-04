using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationManagement.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodBanks_BloodInventories_BloodInventoryId",
                table: "BloodBanks");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodTypes_BloodInventories_BloodInventoryId",
                table: "BloodTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Donors_AspNetUsers_BloodBankAppUserId",
                table: "Donors");

            migrationBuilder.DropTable(
                name: "BloodInventories");

            migrationBuilder.DropTable(
                name: "Requisitions");

            migrationBuilder.DropIndex(
                name: "IX_Donors_BloodBankAppUserId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_BloodTypes_BloodInventoryId",
                table: "BloodTypes");

            migrationBuilder.DropIndex(
                name: "IX_BloodBanks_BloodInventoryId",
                table: "BloodBanks");

            migrationBuilder.DropColumn(
                name: "BloodBankAppUserId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "BloodComponentType",
                table: "BloodTypes");

            migrationBuilder.DropColumn(
                name: "BloodInventoryId",
                table: "BloodTypes");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BloodTypes");

            migrationBuilder.DropColumn(
                name: "BloodInventoryId",
                table: "BloodBanks");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "BloodBanks");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "BloodBanks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BloodBankAppUserId",
                table: "Donors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodComponentType",
                table: "BloodTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BloodInventoryId",
                table: "BloodTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BloodTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BloodInventoryId",
                table: "BloodBanks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "BloodBanks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "BloodBanks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BloodInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodInventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requisitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodBankId = table.Column<int>(type: "int", nullable: true),
                    DonorId = table.Column<int>(type: "int", nullable: true),
                    RequisitionDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisitions_BloodBanks_BloodBankId",
                        column: x => x.BloodBankId,
                        principalTable: "BloodBanks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requisitions_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donors_BloodBankAppUserId",
                table: "Donors",
                column: "BloodBankAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTypes_BloodInventoryId",
                table: "BloodTypes",
                column: "BloodInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodBanks_BloodInventoryId",
                table: "BloodBanks",
                column: "BloodInventoryId",
                unique: true,
                filter: "[BloodInventoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_BloodBankId",
                table: "Requisitions",
                column: "BloodBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_DonorId",
                table: "Requisitions",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodBanks_BloodInventories_BloodInventoryId",
                table: "BloodBanks",
                column: "BloodInventoryId",
                principalTable: "BloodInventories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodTypes_BloodInventories_BloodInventoryId",
                table: "BloodTypes",
                column: "BloodInventoryId",
                principalTable: "BloodInventories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_AspNetUsers_BloodBankAppUserId",
                table: "Donors",
                column: "BloodBankAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
