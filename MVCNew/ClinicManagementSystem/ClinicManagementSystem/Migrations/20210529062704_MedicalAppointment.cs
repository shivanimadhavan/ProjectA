using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicManagementSystem.Migrations
{
    public partial class MedicalAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.CreateTable(
                name: "LoginTable",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginTable", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "PatientTable",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Date_of_Birth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTable", x => x.PatientID);
                });
            migrationBuilder.CreateTable(
              name: "AppointmentTable",
              columns: table => new
              {
                  AppointmentId = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  PatientID = table.Column<int>(type: "int", nullable: false),
                  SpecializationRequired = table.Column<int>(type: "int", nullable: false),
                  VisitDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  VisitTime = table.Column<DateTime>(type: "datetime2", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_AppointmentTable", x => x.AppointmentId);
                  table.ForeignKey(
                     name: "FK_AppointmentTable_PatientTable_PatientID",
                     column: x => x.PatientID,
                     principalTable: "PatientTable",
                     principalColumn: "PatientID",
                     onDelete: ReferentialAction.Restrict);
              });

            migrationBuilder.CreateTable(
                name: "RegisterTable",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterTable", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "DocTable",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Date_of_Birth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Specialization = table.Column<int>(type: "int", nullable: false),
                    FromTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocTable", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_DocTable_AppointmentTable_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "AppointmentTable",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocTable_AppointmentId",
                table: "DocTable",
                column: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocTable");

            migrationBuilder.DropTable(
                name: "LoginTable");

            migrationBuilder.DropTable(
                name: "PatientTable");

            migrationBuilder.DropTable(
                name: "RegisterTable");

            migrationBuilder.DropTable(
                name: "AppointmentTable");
        }
    }
}
