using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedSetsRepsNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Sets",
                table: "Exercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Reps",
                table: "Exercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Sets",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Reps",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 8, 4 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 10, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 12, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 20, 4 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 8, 4 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 8, 4 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 12, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 12, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 6, 4 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 10, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 12, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 16, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 10, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 15, 4 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 15, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 10, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 12, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 12, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 10, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 60, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 15, 3 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Reps", "Sets" },
                values: new object[] { 12, 3 });
        }
    }
}
