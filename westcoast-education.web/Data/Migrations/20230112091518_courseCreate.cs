using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace westcoasteducation.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class courseCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coursesData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    courseNumber = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    startDate = table.Column<string>(type: "TEXT", nullable: false),
                    endDate = table.Column<string>(type: "TEXT", nullable: false),
                    teacher = table.Column<string>(type: "TEXT", nullable: false),
                    placeStudy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coursesData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coursesData");
        }
    }
}
