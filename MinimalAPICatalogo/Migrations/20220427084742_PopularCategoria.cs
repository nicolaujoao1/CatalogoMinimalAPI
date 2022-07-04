using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPICatalogo.Migrations
{
    public partial class PopularCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao)VALUES('Teçido','Teçido leve para costura')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao)VALUES('Mascaras','Teçido leve para costura')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao)VALUES('Remedios','Teçido leve para costura')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao)VALUES('Modelagens','Teçido leve para costura')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
