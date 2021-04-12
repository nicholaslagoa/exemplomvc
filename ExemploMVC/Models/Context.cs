using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploMVC.Models//para trabalhar com entity, cria-se um context
{//lembrar sempre de instalar o nuget do microsoft.entityframeworkcore.sqlserver e o tools
    public class Context : DbContext//classe que herdará da interface do entityframework DbContext
    {//como criei a classe Categoria, o entity precisa saber que vai ter uma table categoria
        public DbSet<Categoria> Categorias { get; set; }//DbSet<> pede o tipo da classe dentro do <>, um nome pra tabela no caso Categorias e cria get;set;
        //assim, toda vez que for mexer com a table categorias, só mexer com o context
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//como herda da interface, ela tem um método que deve ser sobrescrito(overrided)
        {//método responsável por configurar o entityframework, dentro dele será dito qual db será utilizado, ele pede uma optionsBuilder do context a ser criado
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Exemplomvc;Integrated Security=True");//essa linha o .Use pode ser de outro tipo de db
        }//dentro do usesqlserver, ele pede uma string de conexão que é nesse formato acima
    }
}
