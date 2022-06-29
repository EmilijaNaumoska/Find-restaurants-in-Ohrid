using Microsoft.EntityFrameworkCore.Migrations;

namespace WDaPAssignment.Migrations
{
    public partial class removeDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgreeDisagree");

            migrationBuilder.AddColumn<int>(
                name: "Agree",
                table: "CustomerReview",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disagree",
                table: "CustomerReview",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agree",
                table: "CustomerReview");

            migrationBuilder.DropColumn(
                name: "Disagree",
                table: "CustomerReview");

            migrationBuilder.CreateTable(
                name: "AgreeDisagree",
                columns: table => new
                {
                    AgreeDisagreeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agree = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Disagree = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgreeDisagree", x => x.AgreeDisagreeId);
                });
        }
    }
}
