using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedinitialvalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mobile_number",
                table: "people",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mobile",
                columns: table => new
                {
                    mobile_number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    provider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personcustom_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobile", x => x.mobile_number);
                    table.ForeignKey(
                        name: "FK_Mobile_people_Personcustom_id",
                        column: x => x.Personcustom_id,
                        principalTable: "people",
                        principalColumn: "custom_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_people_mobile_number",
                table: "people",
                column: "mobile_number");

            migrationBuilder.CreateIndex(
                name: "IX_Mobile_Personcustom_id",
                table: "Mobile",
                column: "Personcustom_id");

            migrationBuilder.AddForeignKey(
                name: "FK_people_Mobile_mobile_number",
                table: "people",
                column: "mobile_number",
                principalTable: "Mobile",
                principalColumn: "mobile_number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_people_Mobile_mobile_number",
                table: "people");

            migrationBuilder.DropTable(
                name: "Mobile");

            migrationBuilder.DropIndex(
                name: "IX_people_mobile_number",
                table: "people");

            migrationBuilder.DropColumn(
                name: "mobile_number",
                table: "people");
        }
    }
}
