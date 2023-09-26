using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_CyberKnight.Models
{
    public class itemDoPedido{

        [Key]
        public int? IdPedido { get; set; }
        public int? IdProduto { get; set; }

        public double ValorItem {  get; set; }

        [RegularExpression(@"[0-9]{1}", ErrorMessage = "O campo {0} deve ser preenchido com no mínimo 1 digito numérico")]
        public int Quantidade { get; set;}

        [ForeignKey("IdPedido")]
        public Pedido? Pedido { get; set;}

        [ForeignKey("IdProduto")]
        public Produto? Produto { get; set; }
    }
}
