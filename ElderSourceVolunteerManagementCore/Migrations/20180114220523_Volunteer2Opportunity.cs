using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElderSourceVolunteerManagementCore.Migrations
{
    public partial class Volunteer2Opportunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Volunteer2Opportunities_OPPORTUNITYID",
                table: "Volunteer2Opportunities",
                column: "OPPORTUNITYID");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer2Opportunities_VOLUNTEERID",
                table: "Volunteer2Opportunities",
                column: "VOLUNTEERID");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteer2Opportunities_Opportunities_OPPORTUNITYID",
                table: "Volunteer2Opportunities",
                column: "OPPORTUNITYID",
                principalTable: "Opportunities",
                principalColumn: "OPPORTUNITYID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteer2Opportunities_Volunteers_VOLUNTEERID",
                table: "Volunteer2Opportunities",
                column: "VOLUNTEERID",
                principalTable: "Volunteers",
                principalColumn: "VOLUNTEERID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volunteer2Opportunities_Opportunities_OPPORTUNITYID",
                table: "Volunteer2Opportunities");

            migrationBuilder.DropForeignKey(
                name: "FK_Volunteer2Opportunities_Volunteers_VOLUNTEERID",
                table: "Volunteer2Opportunities");

            migrationBuilder.DropIndex(
                name: "IX_Volunteer2Opportunities_OPPORTUNITYID",
                table: "Volunteer2Opportunities");

            migrationBuilder.DropIndex(
                name: "IX_Volunteer2Opportunities_VOLUNTEERID",
                table: "Volunteer2Opportunities");
        }
    }
}
