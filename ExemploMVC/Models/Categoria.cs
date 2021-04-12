using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploMVC.Models
{
    public class Categoria
    {
        public int Id { get; set; }//como to usando o modelo CodeFirst do Entity, todas as classes terão um Id que será a PK no db
        [Display(Name = "Descrição")]//DataAnnotations pra mostrar da forma correta a formatação
        [Required(ErrorMessage = "O campo Descrição é obrigatório")]//dataAnnotations que bota a seguinte Id como obrigatória
        //dentro do () pode-se colocar outras coisas, mas só quis colocar uma ErrorMessage
        public string Descricao { get; set; }

        //public List<Produto> Produtos { get; set; }//para se conectar com produtos
        //a linha acima foi retirada porque tava saindo no swagger errado(saía produtos: null), fora a referência circular pois
        //o produto pede uma categoria, e uma categoria pede produto
    }
}
