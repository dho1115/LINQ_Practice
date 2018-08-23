using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Linq_Practice.Data.Migrations
{
    public partial class AgentBidII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgentInfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImagePath = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bid",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgentInfoid = table.Column<int>(nullable: true),
                    BidAmount = table.Column<int>(nullable: false),
                    DatePosted = table.Column<DateTime>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bid", x => x.id);
                    table.ForeignKey(
                        name: "FK_bid_AgentInfo_AgentInfoid",
                        column: x => x.AgentInfoid,
                        principalTable: "AgentInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bid_AgentInfoid",
                table: "bid",
                column: "AgentInfoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bid");

            migrationBuilder.DropTable(
                name: "AgentInfo");
        }
    }
}
