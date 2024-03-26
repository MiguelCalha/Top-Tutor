using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TopTutor.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class addProductsToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TutorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ListPrice", "Title", "TutorName" },
                values: new object[,]
                {
                    { 1, "Explicações de programação", 10.0, "Programming Tutoring", "Miguel Calha" },
                    { 2, "Explicações de matemática", 10.0, "Math Tutoring", "Miguel Calha" },
                    { 3, "Explicações de inglês", 10.0, "English Tutoring", "Miguel Calha" },
                    { 4, "Explicações de francês", 10.0, "French Tutoring", "Miguel Calha" },
                    { 5, "Explicações de espanhol", 10.0, "Spanish Tutoring", "Miguel Calha" },
                    { 6, "Explicações de alemão", 10.0, "German Tutoring", "Miguel Calha" },
                    { 7, "Explicações de italiano", 10.0, "Italian Tutoring", "Miguel Calha" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
