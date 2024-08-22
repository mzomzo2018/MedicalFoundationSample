using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Data.Migrations
{
    /// <inheritdoc />
    public partial class PersonAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinicians_WorkingShifts_WorkingShiftID",
                table: "Clinicians");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientVisits_Billing_BillingID",
                table: "PatientVisits");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_PatientVisits_BillingID",
                table: "PatientVisits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkingShifts",
                table: "WorkingShifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Billing",
                table: "Billing");

            migrationBuilder.DropColumn(
                name: "BillingID",
                table: "PatientVisits");

            migrationBuilder.RenameTable(
                name: "WorkingShifts",
                newName: "WorkingShift");

            migrationBuilder.RenameTable(
                name: "Billing",
                newName: "Billings");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressID",
                table: "Patients",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressID",
                table: "Clinicians",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BillingID",
                table: "ClinicAppointments",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkingShift",
                table: "WorkingShift",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Billings",
                table: "Billings",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "PersonAddress",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Country = table.Column<int>(type: "INTEGER", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    StreetNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Building = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAddress", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressID",
                table: "Patients",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Clinicians_AddressID",
                table: "Clinicians",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicAppointments_BillingID",
                table: "ClinicAppointments",
                column: "BillingID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicAppointments_Billings_BillingID",
                table: "ClinicAppointments",
                column: "BillingID",
                principalTable: "Billings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clinicians_PersonAddress_AddressID",
                table: "Clinicians",
                column: "AddressID",
                principalTable: "PersonAddress",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clinicians_WorkingShift_WorkingShiftID",
                table: "Clinicians",
                column: "WorkingShiftID",
                principalTable: "WorkingShift",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_PersonAddress_AddressID",
                table: "Patients",
                column: "AddressID",
                principalTable: "PersonAddress",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicAppointments_Billings_BillingID",
                table: "ClinicAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Clinicians_PersonAddress_AddressID",
                table: "Clinicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Clinicians_WorkingShift_WorkingShiftID",
                table: "Clinicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_PersonAddress_AddressID",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "PersonAddress");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AddressID",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Clinicians_AddressID",
                table: "Clinicians");

            migrationBuilder.DropIndex(
                name: "IX_ClinicAppointments_BillingID",
                table: "ClinicAppointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkingShift",
                table: "WorkingShift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Billings",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Clinicians");

            migrationBuilder.DropColumn(
                name: "BillingID",
                table: "ClinicAppointments");

            migrationBuilder.RenameTable(
                name: "WorkingShift",
                newName: "WorkingShifts");

            migrationBuilder.RenameTable(
                name: "Billings",
                newName: "Billing");

            migrationBuilder.AddColumn<Guid>(
                name: "BillingID",
                table: "PatientVisits",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkingShifts",
                table: "WorkingShifts",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Billing",
                table: "Billing",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Country = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    FullNameID = table.Column<Guid>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_PersonName_FullNameID",
                        column: x => x.FullNameID,
                        principalTable: "PersonName",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParentCityID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Streets_Cities_ParentCityID",
                        column: x => x.ParentCityID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParentStreetID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Buildings_Streets_ParentStreetID",
                        column: x => x.ParentStreetID,
                        principalTable: "Streets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientVisits_BillingID",
                table: "PatientVisits",
                column: "BillingID");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_ParentStreetID",
                table: "Buildings",
                column: "ParentStreetID");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_ParentCityID",
                table: "Streets",
                column: "ParentCityID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FullNameID",
                table: "Users",
                column: "FullNameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinicians_WorkingShifts_WorkingShiftID",
                table: "Clinicians",
                column: "WorkingShiftID",
                principalTable: "WorkingShifts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientVisits_Billing_BillingID",
                table: "PatientVisits",
                column: "BillingID",
                principalTable: "Billing",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
