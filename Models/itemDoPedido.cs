using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_CyberKnight.Models
{
    public class itemDoPedido{

        [Key]
        public int? IdPedido { get; set; }
        public int? IdProduto { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é obrigatório")]
        [Display(Name = "Valor do item")]
        public double ValorItem {  get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é obrigatório")]
        public int Quantidade { get; set;}

        [ForeignKey("IdPedido")]
        public Pedido? Pedido { get; set;}

        [ForeignKey("IdProduto")]
        public Produto? Produto { get; set; }
    }
}
