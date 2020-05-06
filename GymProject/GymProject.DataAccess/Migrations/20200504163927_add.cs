using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymProject.DataAccess.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassName = table.Column<string>(nullable: true),
                    HourClass = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Corporates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNr = table.Column<string>(nullable: true),
                    CompanysName = table.Column<string>(nullable: true),
                    NrEmployees = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceAbonament",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MonthDuration = table.Column<int>(nullable: false),
                    TypeAbonament = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceAbonament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Progress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Kg = table.Column<float>(nullable: false),
                    Height = table.Column<float>(nullable: false),
                    ArmLeft = table.Column<float>(nullable: false),
                    ArmRight = table.Column<float>(nullable: false),
                    Shoulders = table.Column<float>(nullable: false),
                    Chest = table.Column<float>(nullable: false),
                    Belly = table.Column<float>(nullable: false),
                    Fesier = table.Column<float>(nullable: false),
                    Legs = table.Column<float>(nullable: false),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    PhoneNr = table.Column<string>(nullable: true),
                    ClassIdId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Classes_ClassIdId",
                        column: x => x.ClassIdId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    ClassIdId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_Classes_ClassIdId",
                        column: x => x.ClassIdId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    priceAbonamentIdId = table.Column<Guid>(nullable: true),
                    AbonamentFacilities = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facilities_PriceAbonament_priceAbonamentIdId",
                        column: x => x.priceAbonamentIdId,
                        principalTable: "PriceAbonament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ClassIdId",
                table: "Booking",
                column: "ClassIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_priceAbonamentIdId",
                table: "Facilities",
                column: "priceAbonamentIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_ClassIdId",
                table: "Trainers",
                column: "ClassIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Corporates");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Progress");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "PriceAbonament");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
