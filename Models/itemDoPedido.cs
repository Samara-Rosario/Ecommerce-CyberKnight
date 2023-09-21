using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_CyberKnight.Models
{
    public class itemDoPedido{

        [Key]
        public int? IdPedido { get; set; }
        public int? IdProduto { get; set; }

        public double ValorItem {  get; set; }
        public int Quantidade { get; set;}

        [ForeignKey("IdPedido")]
        public Pedido? Pedido { get; set;}

        [ForeignKey("IdProduto")]
        public Produto? Produto { get; set; }
    }
}
