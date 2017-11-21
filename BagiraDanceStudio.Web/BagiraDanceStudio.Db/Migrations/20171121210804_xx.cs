using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BagiraDanceStudio.Db.Migrations
{
    public partial class xx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_PersonsData_PersonDataId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_PersonDataId",
                table: "Managers");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonDataId",
                table: "Managers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Managers_PersonDataId",
                table: "Managers",
                column: "PersonDataId",
                unique: true,
                filter: "[PersonDataId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_PersonsData_PersonDataId",
                table: "Managers",
                column: "PersonDataId",
                principalTable: "PersonsData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_PersonsData_PersonDataId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_PersonDataId",
                table: "Managers");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonDataId",
                table: "Managers",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_PersonDataId",
                table: "Managers",
                column: "PersonDataId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_PersonsData_PersonDataId",
                table: "Managers",
                column: "PersonDataId",
                principalTable: "PersonsData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
