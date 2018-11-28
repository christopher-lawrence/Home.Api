using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Home.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    HomeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colors_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LightBulbs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    RoomId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightBulbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LightBulbs_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: false),
                    ColorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doors_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: false),
                    ColorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Floors_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Windows",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: false),
                    ColorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Windows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Windows_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Windows_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colors_RoomId",
                table: "Colors",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_ColorId",
                table: "Doors",
                column: "ColorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doors_RoomId",
                table: "Doors",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_ColorId",
                table: "Floors",
                column: "ColorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Floors_RoomId",
                table: "Floors",
                column: "RoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LightBulbs_RoomId",
                table: "LightBulbs",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HomeId",
                table: "Rooms",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Windows_ColorId",
                table: "Windows",
                column: "ColorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Windows_RoomId",
                table: "Windows",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doors");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "LightBulbs");

            migrationBuilder.DropTable(
                name: "Windows");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Homes");
        }
    }
}
