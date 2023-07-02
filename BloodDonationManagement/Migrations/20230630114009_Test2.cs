using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationManagement.Migrations
{
    /// <inheritdoc />
    public partial class Test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodBanks_Addresses_AddressId",
                table: "BloodBanks");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodBanks_BloodInventories_BloodInventoryId",
                table: "BloodBanks");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodTypes_BloodInventories_BloodInventoryId",
                table: "BloodTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Addresses_AddressId",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Donors_BloodTypes_BloodTypeId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_BloodBanks_BloodInventoryId",
                table: "BloodBanks");

            migrationBuilder.AlterColumn<string>(
                name: "RequisitionDate",
                table: "Requisitions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "BloodTypeId",
                table: "Donors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Donors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "BloodTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BloodInventoryId",
                table: "BloodTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BloodComponentType",
                table: "BloodTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AboRhType",
                table: "BloodTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BloodInventoryId",
                table: "BloodBanks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "BloodBanks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_BloodBanks_BloodInventoryId",
                table: "BloodBanks",
                column: "BloodInventoryId",
                unique: true,
                filter: "[BloodInventoryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodBanks_Addresses_AddressId",
                table: "BloodBanks",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

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
                name: "FK_Donors_Addresses_AddressId",
                table: "Donors",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_BloodTypes_BloodTypeId",
                table: "Donors",
                column: "BloodTypeId",
                principalTable: "BloodTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodBanks_Addresses_AddressId",
                table: "BloodBanks");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodBanks_BloodInventories_BloodInventoryId",
                table: "BloodBanks");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodTypes_BloodInventories_BloodInventoryId",
                table: "BloodTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Addresses_AddressId",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Donors_BloodTypes_BloodTypeId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_BloodBanks_BloodInventoryId",
                table: "BloodBanks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequisitionDate",
                table: "Requisitions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BloodTypeId",
                table: "Donors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Donors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "BloodTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BloodInventoryId",
                table: "BloodTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BloodComponentType",
                table: "BloodTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboRhType",
                table: "BloodTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BloodInventoryId",
                table: "BloodBanks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "BloodBanks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BloodBanks_BloodInventoryId",
                table: "BloodBanks",
                column: "BloodInventoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodBanks_Addresses_AddressId",
                table: "BloodBanks",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodBanks_BloodInventories_BloodInventoryId",
                table: "BloodBanks",
                column: "BloodInventoryId",
                principalTable: "BloodInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodTypes_BloodInventories_BloodInventoryId",
                table: "BloodTypes",
                column: "BloodInventoryId",
                principalTable: "BloodInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Addresses_AddressId",
                table: "Donors",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_BloodTypes_BloodTypeId",
                table: "Donors",
                column: "BloodTypeId",
                principalTable: "BloodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
