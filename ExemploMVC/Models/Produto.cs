using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]//DataAnnotation pra mostrar Descrição com a formatação correta
        [Required(ErrorMessage = "O campo Descrição é obrigatório")]//DataAnnotations para requerir uma informação
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é obrigatório")]
        [Range(1, 10, ErrorMessage = "Valor fora da faixa")]//DataAnnotations para definir uma faixa de valores de 1 a 10 do campo Quantidade
        //Range pede o início, fim da faixa. se quiser uma mensagem, só botar depois da vírgula, ambos os números devem ser DOUBLE
        public int Quantidade { get; set; }

        public int CategoriaId { get; set; }//id da categoria(FK?)
        public Categoria Categoria { get; set; }//relação com a table Produto
    }
}
