using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserFullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PersonName_NameID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_NameID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "NameID",
                table: "Users",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "FullNameID",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FullNameID",
                table: "Users",
                column: "FullNameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PersonName_FullNameID",
                table: "Users",
                column: "FullNameID",
                principalTable: "PersonName",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PersonName_FullNameID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FullNameID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullNameID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "NameID");

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_NameID",
                table: "Users",
                column: "NameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PersonName_NameID",
                table: "Users",
                column: "NameID",
                principalTable: "PersonName",
                principalColumn: "ID");
        }
    }
}
