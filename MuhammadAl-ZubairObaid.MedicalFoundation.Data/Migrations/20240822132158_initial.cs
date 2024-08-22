using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Billing",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billing", x => x.ID);
                });

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
                name: "ClinicAppointments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicAppointments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Identifier = table.Column<string>(type: "TEXT", nullable: false),
                    Domain = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonName",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonName", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    RegionalCode = table.Column<string>(type: "TEXT", nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WorkingShifts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    StartDay = table.Column<int>(type: "INTEGER", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    EndDay = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingShifts", x => x.ID);
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
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    NameID = table.Column<Guid>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Rank = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_PersonName_NameID",
                        column: x => x.NameID,
                        principalTable: "PersonName",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    NameID = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmailID = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneNumberID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patients_EmailAddress_EmailID",
                        column: x => x.EmailID,
                        principalTable: "EmailAddress",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_PersonName_NameID",
                        column: x => x.NameID,
                        principalTable: "PersonName",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_PhoneNumber_PhoneNumberID",
                        column: x => x.PhoneNumberID,
                        principalTable: "PhoneNumber",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clinicians",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    FullNameID = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmailID = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Specialization = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkingShiftID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicians", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clinicians_EmailAddress_EmailID",
                        column: x => x.EmailID,
                        principalTable: "EmailAddress",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clinicians_PersonName_FullNameID",
                        column: x => x.FullNameID,
                        principalTable: "PersonName",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clinicians_PhoneNumber_NumberID",
                        column: x => x.NumberID,
                        principalTable: "PhoneNumber",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clinicians_WorkingShifts_WorkingShiftID",
                        column: x => x.WorkingShiftID,
                        principalTable: "WorkingShifts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ParentStreetID = table.Column<Guid>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "PatientVisits",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClinicianID = table.Column<Guid>(type: "TEXT", nullable: false),
                    AppointmentID = table.Column<Guid>(type: "TEXT", nullable: false),
                    BillingID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PatientID = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVisits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientVisits_Billing_BillingID",
                        column: x => x.BillingID,
                        principalTable: "Billing",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientVisits_ClinicAppointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "ClinicAppointments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientVisits_Clinicians_ClinicianID",
                        column: x => x.ClinicianID,
                        principalTable: "Clinicians",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientVisits_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_ParentStreetID",
                table: "Buildings",
                column: "ParentStreetID");

            migrationBuilder.CreateIndex(
                name: "IX_Clinicians_EmailID",
                table: "Clinicians",
                column: "EmailID");

            migrationBuilder.CreateIndex(
                name: "IX_Clinicians_FullNameID",
                table: "Clinicians",
                column: "FullNameID");

            migrationBuilder.CreateIndex(
                name: "IX_Clinicians_NumberID",
                table: "Clinicians",
                column: "NumberID");

            migrationBuilder.CreateIndex(
                name: "IX_Clinicians_WorkingShiftID",
                table: "Clinicians",
                column: "WorkingShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_EmailID",
                table: "Patients",
                column: "EmailID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_NameID",
                table: "Patients",
                column: "NameID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PhoneNumberID",
                table: "Patients",
                column: "PhoneNumberID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVisits_AppointmentID",
                table: "PatientVisits",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVisits_BillingID",
                table: "PatientVisits",
                column: "BillingID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVisits_ClinicianID",
                table: "PatientVisits",
                column: "ClinicianID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVisits_PatientID",
                table: "PatientVisits",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_ParentCityID",
                table: "Streets",
                column: "ParentCityID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NameID",
                table: "Users",
                column: "NameID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "PatientVisits");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Billing");

            migrationBuilder.DropTable(
                name: "ClinicAppointments");

            migrationBuilder.DropTable(
                name: "Clinicians");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "WorkingShifts");

            migrationBuilder.DropTable(
                name: "EmailAddress");

            migrationBuilder.DropTable(
                name: "PersonName");

            migrationBuilder.DropTable(
                name: "PhoneNumber");
        }
    }
}
