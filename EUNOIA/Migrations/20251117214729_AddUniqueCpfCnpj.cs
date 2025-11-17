using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EUNOIA.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueCpfCnpj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_CPF",
                table: "Users",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CNPJ",
                table: "Companies",
                column: "CNPJ",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_CPF",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CNPJ",
                table: "Companies");
        }
    }
}
