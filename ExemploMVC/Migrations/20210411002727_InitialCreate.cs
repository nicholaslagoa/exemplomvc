using Microsoft.EntityFrameworkCore.Migrations;

namespace ExemploMVC.Migrations//primeira migration criada pelo ferramentas>console do gerenciador de pacotes
{//foi utilizado o código Add-Migration InitialCreate, que só foi possível depois de instalar o entityframeworkcore.Tools
    //ao criar, foi tirado um snapshot do context, e esse arquivo possui o dia de criação dele no nome, podendo ter assim todo o histórico das migrations criadas
    //depois da criação, utiliza-se o comando Update-Database para de fato criar e atualizar o banco de dados
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(//cria a tabela
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(//se quiser desfazer o que foi feito
                name: "Categorias");
        }
    }
}
