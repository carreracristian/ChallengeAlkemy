using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Challenge2Alkemy.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
