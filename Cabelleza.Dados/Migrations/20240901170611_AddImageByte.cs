using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cabelleza.Dados.Migrations
{
    /// <inheritdoc />
    public partial class AddImageByte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "Salao",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Salao");
        }
    }
}
