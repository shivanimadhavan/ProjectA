using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicManagementSystem.Migrations
{
    public partial class ClinicalManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "DocTable",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specializationrequired = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocTable", x => x.DoctorID);
                });

            migrationBuilder.CreateTable(
                name: "FrontStaffTable",
                columns: table => new
                {
                    StaffUsername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontStaffTable", x => x.StaffUsername);
                });

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
                    PFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Specializationrequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visitdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppoinmentTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTable", x => x.AppointmentId);
                    table.ForeignKey(
                             name: "FK_AppointmentTable_PatientTable_PatientID",
                             column: x => x.PatientID,
                             principalTable: "PatientTable",
                             principalColumn: "PatientId",
                             onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentTable");

            migrationBuilder.DropTable(
                name: "DocTable");

            migrationBuilder.DropTable(
                name: "FrontStaffTable");

            migrationBuilder.DropTable(
                name: "LoginTable");

            migrationBuilder.DropTable(
                name: "PatientTable");
        }
    }
}
