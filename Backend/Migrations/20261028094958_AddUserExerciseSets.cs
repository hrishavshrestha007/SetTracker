using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUserExerciseSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reps",
                table: "UserExercises");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "UserExercises");

            migrationBuilder.CreateTable(
                name: "UserExerciseSets",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    SetNumber = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExerciseSets", x => new { x.UserId, x.ExerciseId, x.SetNumber });
                    table.ForeignKey(
                        name: "FK_UserExerciseSets_UserExercises_UserId_ExerciseId",
                        columns: x => new { x.UserId, x.ExerciseId },
                        principalTable: "UserExercises",
                        principalColumns: new[] { "UserId", "ExerciseId" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExerciseSets");

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "UserExercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "UserExercises",
                type: "int",
                nullable: true);
        }
    }
}
