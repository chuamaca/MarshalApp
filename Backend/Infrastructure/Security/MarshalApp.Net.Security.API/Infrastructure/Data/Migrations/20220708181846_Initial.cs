using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarshalApp.Net.Security.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CanAccessAuthors = table.Column<bool>(type: "bit", nullable: false),
                    CanAddAuthor = table.Column<bool>(type: "bit", nullable: false),
                    CanSaveAuthor = table.Column<bool>(type: "bit", nullable: false),
                    CanAccessBooks = table.Column<bool>(type: "bit", nullable: false),
                    CanAccessStudent = table.Column<bool>(type: "bit", nullable: false),
                    CanAddStudent = table.Column<bool>(type: "bit", nullable: false),
                    CanSaveStudent = table.Column<bool>(type: "bit", nullable: false),
                    CanAccessGrades = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
