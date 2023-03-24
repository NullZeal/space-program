using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceProgramApi.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpaceStation",
                columns: table => new
                {
                    SpaceStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceStation", x => x.SpaceStationId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Officer",
                columns: table => new
                {
                    OfficerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpaceStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officer", x => x.OfficerId);
                    table.ForeignKey(
                        name: "FK_Officer_SpaceStation_SpaceStationId",
                        column: x => x.SpaceStationId,
                        principalTable: "SpaceStation",
                        principalColumn: "SpaceStationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Officer_Name",
                table: "Officer",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Officer_SpaceStationId",
                table: "Officer",
                column: "SpaceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceStation_Name",
                table: "SpaceStation",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Officer");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "SpaceStation");
        }
    }
}
