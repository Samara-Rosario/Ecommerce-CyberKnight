using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_CyberKnight.Models
{
    public class Pedido{

        [Key]
        public int? Id {  get; set; }
        public int? IdCliente { get; set; }
        public int? IdEndereco { get; set; }
        public string itensDoPedido { get; set; }
        public double FormaPagamento { get; set; }
        public DateTime DataeHora { get; set; }

        public ICollection<itemDoPedido> ItensDoPedido { get; set; }
        [ForeignKey("IdEndereco")]
        public Endereco? Endereco { get; set; }

        [ForeignKey("IdClientes")]
        public Clientes? Clientes { get; set; }
    }
}
