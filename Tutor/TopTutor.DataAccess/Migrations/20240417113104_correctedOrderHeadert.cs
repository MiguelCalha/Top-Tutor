using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopTutor.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class correctedOrderHeadert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "meetingLink",
                table: "OrderHeaders",
                newName: "SessionId");

            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "OrderHeaders",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "StudentEmail",
                table: "OrderHeaders",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "ShippingDate",
                table: "OrderHeaders",
                newName: "TutoringDay");

            migrationBuilder.RenameColumn(
                name: "Platform",
                table: "OrderHeaders",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "LessonDate",
                table: "OrderHeaders",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeetinLink",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetingPlatform",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDueDate",
                table: "OrderHeaders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "MeetinLink",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "MeetingPlatform",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "PaymentDueDate",
                table: "OrderHeaders");

            migrationBuilder.RenameColumn(
                name: "TutoringDay",
                table: "OrderHeaders",
                newName: "ShippingDate");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "OrderHeaders",
                newName: "StudentName");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "OrderHeaders",
                newName: "StudentEmail");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "OrderHeaders",
                newName: "meetingLink");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "OrderHeaders",
                newName: "Platform");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "OrderHeaders",
                newName: "LessonDate");
        }
    }
}
