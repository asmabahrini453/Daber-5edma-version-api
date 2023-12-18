using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daber_5edma_api.Migrations
{
    /// <inheritdoc />
    public partial class AddData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Candidats_CandidatId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_JobOffers_JobOfferId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Companies_CompanyId",
                table: "JobOffers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobOffers",
                table: "JobOffers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidats",
                table: "Candidats");

            migrationBuilder.RenameTable(
                name: "JobOffers",
                newName: "TJobOffer");

            migrationBuilder.RenameTable(
                name: "JobApplications",
                newName: "JobApplication");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "TCompany");

            migrationBuilder.RenameTable(
                name: "Candidats",
                newName: "TCandidat");

            migrationBuilder.RenameIndex(
                name: "IX_JobOffers_CompanyId",
                table: "TJobOffer",
                newName: "IX_TJobOffer_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_JobOfferId",
                table: "JobApplication",
                newName: "IX_JobApplication_JobOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_CandidatId",
                table: "JobApplication",
                newName: "IX_JobApplication_CandidatId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TJobOffer",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Speciality",
                table: "TJobOffer",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "TJobOffer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Tel",
                table: "TCompany",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "TCompany",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TCompany",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Tel",
                table: "TCandidat",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "TCandidat",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TCandidat",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TJobOffer",
                table: "TJobOffer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplication",
                table: "JobApplication",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TCompany",
                table: "TCompany",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TCandidat",
                table: "TCandidat",
                column: "Id");

            migrationBuilder.InsertData(
                table: "TCandidat",
                columns: new[] { "Id", "DateNaiss", "Education", "Email", "Experience", "Name", "Password", "Speciality", "Tel" },
                values: new object[] { 1, new DateTime(2001, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "EPI", "asma@gmail.com", "1 ans", "asma", "asma", "GL", "25096055" });

            migrationBuilder.InsertData(
                table: "TCompany",
                columns: new[] { "Id", "Description", "Email", "Location", "Name", "Password", "Tel" },
                values: new object[] { 1, "startup", "proxym@gmail.com", "sousse", "proxym", "proxym", "1234567" });

            migrationBuilder.InsertData(
                table: "TJobOffer",
                columns: new[] { "Id", "CompanyId", "Description", "Location", "PostedDate", "Speciality", "Title" },
                values: new object[] { 1, 1, "looking for a software engineer", "sousse", new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "development", "software engineer" });

            migrationBuilder.InsertData(
                table: "JobApplication",
                columns: new[] { "Id", "CandidatId", "JobOfferId", "Status" },
                values: new object[] { 1, 1, 1, "pending" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_TCandidat_CandidatId",
                table: "JobApplication",
                column: "CandidatId",
                principalTable: "TCandidat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_TJobOffer_JobOfferId",
                table: "JobApplication",
                column: "JobOfferId",
                principalTable: "TJobOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TJobOffer_TCompany_CompanyId",
                table: "TJobOffer",
                column: "CompanyId",
                principalTable: "TCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_TCandidat_CandidatId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_TJobOffer_JobOfferId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_TJobOffer_TCompany_CompanyId",
                table: "TJobOffer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TJobOffer",
                table: "TJobOffer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TCompany",
                table: "TCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TCandidat",
                table: "TCandidat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplication",
                table: "JobApplication");

            migrationBuilder.DeleteData(
                table: "JobApplication",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TCandidat",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TJobOffer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TCompany",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "TJobOffer",
                newName: "JobOffers");

            migrationBuilder.RenameTable(
                name: "TCompany",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "TCandidat",
                newName: "Candidats");

            migrationBuilder.RenameTable(
                name: "JobApplication",
                newName: "JobApplications");

            migrationBuilder.RenameIndex(
                name: "IX_TJobOffer_CompanyId",
                table: "JobOffers",
                newName: "IX_JobOffers_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplication_JobOfferId",
                table: "JobApplications",
                newName: "IX_JobApplications_JobOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplication_CandidatId",
                table: "JobApplications",
                newName: "IX_JobApplications_CandidatId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "JobOffers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Speciality",
                table: "JobOffers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "JobOffers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Tel",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Tel",
                table: "Candidats",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Candidats",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Candidats",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobOffers",
                table: "JobOffers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidats",
                table: "Candidats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Candidats_CandidatId",
                table: "JobApplications",
                column: "CandidatId",
                principalTable: "Candidats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_JobOffers_JobOfferId",
                table: "JobApplications",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Companies_CompanyId",
                table: "JobOffers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
