using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HallOfFame.Db.Migrations
{
    public partial class AddCascading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Persons_PersonId",
                table: "Skills");

            migrationBuilder.AlterColumn<byte[]>(
                name: "level",
                table: "Skills",
                type: "binary(2)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "binary(1)");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Persons_PersonId",
                table: "Skills",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "person_id",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Persons_PersonId",
                table: "Skills");

            migrationBuilder.AlterColumn<byte[]>(
                name: "level",
                table: "Skills",
                type: "binary(2)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "binary(1)");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Persons_PersonId",
                table: "Skills",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "person_id");
        }
    }
}
