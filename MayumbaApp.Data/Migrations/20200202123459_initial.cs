using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MayumbaApp.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Bill_Id = table.Column<string>(nullable: false),
                    FullAmountToPay = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Payment_Method = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Bill_Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Manager_NIN = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Manager_FName = table.Column<string>(nullable: true),
                    Manager_LNane = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false),
                    MaritualStatus = table.Column<string>(nullable: true),
                    DateHired = table.Column<DateTime>(nullable: false),
                    DateRetired = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Manager_NIN);
                });

            migrationBuilder.CreateTable(
                name: "Occupants",
                columns: table => new
                {
                    Occupant_NIN = table.Column<string>(nullable: false),
                    Occupant_FName = table.Column<string>(nullable: true),
                    Occupant_LName = table.Column<string>(nullable: true),
                    OccupantType = table.Column<string>(nullable: true),
                    PhoneNumber1 = table.Column<string>(nullable: true),
                    PhoneNumber2 = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupants", x => x.Occupant_NIN);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Owner_NIN = table.Column<string>(nullable: false),
                    Owner_FName = table.Column<string>(nullable: true),
                    Owner_LName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Owner_NIN);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    PropertyType_Id = table.Column<string>(nullable: false),
                    PropertyType_Name = table.Column<string>(nullable: true),
                    PropertyType_Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.PropertyType_Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Bill_Id = table.Column<string>(nullable: false),
                    Occupant_NIN = table.Column<string>(nullable: false),
                    Bill_Id1 = table.Column<string>(nullable: true),
                    Occupant_NIN1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => new { x.Bill_Id, x.Occupant_NIN });
                    table.ForeignKey(
                        name: "FK_Payments_Bills_Bill_Id1",
                        column: x => x.Bill_Id1,
                        principalTable: "Bills",
                        principalColumn: "Bill_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Occupants_Occupant_NIN1",
                        column: x => x.Occupant_NIN1,
                        principalTable: "Occupants",
                        principalColumn: "Occupant_NIN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Property_Id = table.Column<string>(nullable: false),
                    PropertyType_Id = table.Column<string>(nullable: true),
                    Property_Address = table.Column<string>(nullable: true),
                    No_Of_bedrooms = table.Column<int>(nullable: false),
                    No_Of_bathrooms = table.Column<int>(nullable: false),
                    inside_area_size = table.Column<int>(nullable: false),
                    No_Of_small_car_parking_area = table.Column<int>(nullable: false),
                    Availability_Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Property_Id);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyTypes_PropertyType_Id",
                        column: x => x.PropertyType_Id,
                        principalTable: "PropertyTypes",
                        principalColumn: "PropertyType_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Managements",
                columns: table => new
                {
                    PropertyId = table.Column<string>(nullable: false),
                    Manager_NIN = table.Column<string>(nullable: false),
                    Manager_NIN1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managements", x => new { x.PropertyId, x.Manager_NIN });
                    table.ForeignKey(
                        name: "FK_Managements_Managers_Manager_NIN1",
                        column: x => x.Manager_NIN1,
                        principalTable: "Managers",
                        principalColumn: "Manager_NIN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Managements_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Property_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ownerships",
                columns: table => new
                {
                    Property_Id = table.Column<string>(nullable: false),
                    Owner_NIN = table.Column<string>(nullable: false),
                    Percent_Owned = table.Column<int>(nullable: false),
                    Owner_NIN1 = table.Column<string>(nullable: true),
                    Property_Id1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ownerships", x => new { x.Owner_NIN, x.Property_Id });
                    table.ForeignKey(
                        name: "FK_Ownerships_Owners_Owner_NIN1",
                        column: x => x.Owner_NIN1,
                        principalTable: "Owners",
                        principalColumn: "Owner_NIN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ownerships_Properties_Property_Id1",
                        column: x => x.Property_Id1,
                        principalTable: "Properties",
                        principalColumn: "Property_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentAgreements",
                columns: table => new
                {
                    Occupant_NIN = table.Column<string>(nullable: false),
                    Property_Id = table.Column<string>(nullable: false),
                    Agreement_Id = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Amount_Of_Initial_Deposite = table.Column<int>(nullable: false),
                    Per_Period_Charged = table.Column<string>(nullable: true),
                    Cost_Per_Period = table.Column<int>(nullable: false),
                    Property_Id1 = table.Column<string>(nullable: true),
                    Occupant_NIN1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentAgreements", x => new { x.Occupant_NIN, x.Property_Id });
                    table.ForeignKey(
                        name: "FK_RentAgreements_Occupants_Occupant_NIN1",
                        column: x => x.Occupant_NIN1,
                        principalTable: "Occupants",
                        principalColumn: "Occupant_NIN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentAgreements_Properties_Property_Id1",
                        column: x => x.Property_Id1,
                        principalTable: "Properties",
                        principalColumn: "Property_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Managements_Manager_NIN1",
                table: "Managements",
                column: "Manager_NIN1");

            migrationBuilder.CreateIndex(
                name: "IX_Ownerships_Owner_NIN1",
                table: "Ownerships",
                column: "Owner_NIN1");

            migrationBuilder.CreateIndex(
                name: "IX_Ownerships_Property_Id1",
                table: "Ownerships",
                column: "Property_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Bill_Id1",
                table: "Payments",
                column: "Bill_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Occupant_NIN1",
                table: "Payments",
                column: "Occupant_NIN1");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyType_Id",
                table: "Properties",
                column: "PropertyType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RentAgreements_Occupant_NIN1",
                table: "RentAgreements",
                column: "Occupant_NIN1");

            migrationBuilder.CreateIndex(
                name: "IX_RentAgreements_Property_Id1",
                table: "RentAgreements",
                column: "Property_Id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managements");

            migrationBuilder.DropTable(
                name: "Ownerships");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RentAgreements");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Occupants");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "PropertyTypes");
        }
    }
}
