using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Linq_Practice.Data.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hotel_location_Locationid",
                table: "hotel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_location",
                table: "location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hotel",
                table: "hotel");

            migrationBuilder.RenameTable(
                name: "location",
                newName: "locations");

            migrationBuilder.RenameTable(
                name: "hotel",
                newName: "hotels");

            migrationBuilder.RenameIndex(
                name: "IX_hotel_Locationid",
                table: "hotels",
                newName: "IX_hotels_Locationid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_locations",
                table: "locations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hotels",
                table: "hotels",
                column: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_hotels_locations_Locationid",
                table: "hotels",
                column: "Locationid",
                principalTable: "locations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hotels_locations_Locationid",
                table: "hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_locations",
                table: "locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hotels",
                table: "hotels");

            migrationBuilder.RenameTable(
                name: "locations",
                newName: "location");

            migrationBuilder.RenameTable(
                name: "hotels",
                newName: "hotel");

            migrationBuilder.RenameIndex(
                name: "IX_hotels_Locationid",
                table: "hotel",
                newName: "IX_hotel_Locationid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_location",
                table: "location",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hotel",
                table: "hotel",
                column: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_hotel_location_Locationid",
                table: "hotel",
                column: "Locationid",
                principalTable: "location",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
