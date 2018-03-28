using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ElderSourceVolunteerManagementCore.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursWorked",
                table: "Volunteer2Opportunities");

            migrationBuilder.CreateTable(
                name: "Volunteer2OpprotunityHoursWorked",
                columns: table => new
                {
                    VOLUNTEER2OPPORTUNITYHOURSWORKEDID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateWorked = table.Column<DateTime>(nullable: false),
                    HoursWorked = table.Column<int>(nullable: false),
                    VOLUNTEER2OPPORTUNITYID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer2OpprotunityHoursWorked", x => x.VOLUNTEER2OPPORTUNITYHOURSWORKEDID);
                    table.ForeignKey(
                        name: "FK_Volunteer2OpprotunityHoursWorked_Volunteer2Opportunities_VOLUNTEER2OPPORTUNITYID",
                        column: x => x.VOLUNTEER2OPPORTUNITYID,
                        principalTable: "Volunteer2Opportunities",
                        principalColumn: "VOLUNTEER2OPPORTUNITYID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerUpdateUser",
                columns: table => new
                {
                    VOLUNTEERUPDATEUSERID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    VOLUNTEERID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerUpdateUser", x => x.VOLUNTEERUPDATEUSERID);
                    table.ForeignKey(
                        name: "FK_VolunteerUpdateUser_Volunteers_VOLUNTEERID",
                        column: x => x.VOLUNTEERID,
                        principalTable: "Volunteers",
                        principalColumn: "VOLUNTEERID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer2OpprotunityHoursWorked_VOLUNTEER2OPPORTUNITYID",
                table: "Volunteer2OpprotunityHoursWorked",
                column: "VOLUNTEER2OPPORTUNITYID");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerUpdateUser_VOLUNTEERID",
                table: "VolunteerUpdateUser",
                column: "VOLUNTEERID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Volunteer2OpprotunityHoursWorked");

            migrationBuilder.DropTable(
                name: "VolunteerUpdateUser");

            migrationBuilder.AddColumn<int>(
                name: "HoursWorked",
                table: "Volunteer2Opportunities",
                nullable: false,
                defaultValue: 0);
        }
    }
}
