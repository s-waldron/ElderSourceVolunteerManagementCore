using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElderSourceVolunteerManagementCore.Migrations
{
    public partial class Opportunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OpportunityCity",
                table: "Opportunities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpportunityCounty",
                table: "Opportunities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpportunityState",
                table: "Opportunities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpportunityStreet",
                table: "Opportunities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OpportunityZipCode",
                table: "Opportunities",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.DropColumn(
                name: "OpportunityCity",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "OpportunityCounty",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "OpportunityState",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "OpportunityStreet",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "OpportunityZipCode",
                table: "Opportunities");
        }
    }
}
