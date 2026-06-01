using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddExerciseAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Muscle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Bg", "Color", "Icon", "Muscle", "Name", "Reps", "Sets" },
                values: new object[,]
                {
                    { 1, "bg-orange-500/15", "text-orange-400", "fa-arrow-up", "chest", "Bench Press", 8, 4 },
                    { 2, "bg-orange-400/15", "text-orange-300", "fa-angle-double-up", "chest", "Incline DB Press", 10, 3 },
                    { 3, "bg-orange-500/15", "text-orange-400", "fa-expand-alt", "chest", "Cable Fly", 12, 3 },
                    { 4, "bg-orange-400/15", "text-orange-300", "fa-arrow-up", "chest", "Push-Ups", 20, 4 },
                    { 5, "bg-blue-500/15", "text-blue-400", "fa-arrow-down", "back", "Pull-Ups", 8, 4 },
                    { 6, "bg-blue-500/15", "text-blue-400", "fa-minus", "back", "Barbell Row", 8, 4 },
                    { 7, "bg-blue-400/15", "text-blue-300", "fa-arrow-down", "back", "Lat Pulldown", 12, 3 },
                    { 8, "bg-blue-500/15", "text-blue-400", "fa-compress-alt", "back", "Seated Cable Row", 12, 3 },
                    { 9, "bg-green-500/15", "text-green-400", "fa-sort-amount-down", "legs", "Squat", 6, 4 },
                    { 10, "bg-green-500/15", "text-green-400", "fa-long-arrow-alt-down", "legs", "Romanian DL", 10, 3 },
                    { 11, "bg-green-400/15", "text-green-300", "fa-chevron-down", "legs", "Leg Press", 12, 3 },
                    { 12, "bg-green-500/15", "text-green-400", "fa-shoe-prints", "legs", "Walking Lunges", 16, 3 },
                    { 13, "bg-purple-500/15", "text-purple-400", "fa-angle-double-up", "shoulders", "Shoulder Press", 10, 3 },
                    { 14, "bg-purple-500/15", "text-purple-400", "fa-arrows-alt-h", "shoulders", "Lateral Raises", 15, 4 },
                    { 15, "bg-purple-400/15", "text-purple-300", "fa-compress-alt", "shoulders", "Face Pulls", 15, 3 },
                    { 16, "bg-pink-500/15", "text-pink-400", "fa-dumbbell", "arms", "Barbell Curl", 10, 3 },
                    { 17, "bg-pink-500/15", "text-pink-400", "fa-arrow-down", "arms", "Tricep Pushdown", 12, 3 },
                    { 18, "bg-pink-400/15", "text-pink-300", "fa-dumbbell", "arms", "Hammer Curl", 12, 3 },
                    { 19, "bg-pink-500/15", "text-pink-400", "fa-minus", "arms", "Skull Crushers", 10, 3 },
                    { 20, "bg-yellow-500/15", "text-yellow-400", "fa-minus", "core", "Plank", 60, 3 },
                    { 21, "bg-yellow-500/15", "text-yellow-400", "fa-angle-down", "core", "Cable Crunch", 15, 3 },
                    { 22, "bg-yellow-400/15", "text-yellow-300", "fa-sort-amount-up", "core", "Hanging Leg Raise", 12, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Admin User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Admin");
        }
    }
}
