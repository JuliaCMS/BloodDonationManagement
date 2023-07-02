using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationManagement.Migrations
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisitions_Donors_DonorId",
                table: "Requisitions");

            migrationBuilder.DropIndex(
                name: "IX_Donors_AddressId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_Donors_BloodTypeId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_BloodBanks_AddressId",
                table: "BloodBanks");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_AddressId",
                table: "Donors",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_BloodTypeId",
                table: "Donors",
                column: "BloodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodBanks_AddressId",
                table: "BloodBanks",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisitions_Donors_DonorId",
                table: "Requisitions",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisitions_Donors_DonorId",
                table: "Requisitions");

            migrationBuilder.DropIndex(
                name: "IX_Donors_AddressId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_Donors_BloodTypeId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_BloodBanks_AddressId",
                table: "BloodBanks");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_AddressId",
                table: "Donors",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donors_BloodTypeId",
                table: "Donors",
                column: "BloodTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BloodBanks_AddressId",
                table: "BloodBanks",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisitions_Donors_DonorId",
                table: "Requisitions",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
