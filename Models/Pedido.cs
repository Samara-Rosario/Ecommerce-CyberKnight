using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_CyberKnight.Models
{
    public class Pedido{

        [Key]
        public int? Id {  get; set; }
        public int? IdCliente { get; set; }
        public int? IdEndereco { get; set; }
        public double FormaPagamento { get; set; }
        public DateTime DataeHora { get; set; }

        public ICollection<itemDoPedido> ItensDoPedido { get; set; }

        public double Preco {
            get {
                double valor = 0;

                foreach (var pedido in ItensDoPedido) {
                    valor += pedido.ValorItem * pedido.Quantidade;
                }
                return valor;
            }
        }

        public double ValorPedido() {
            double valor = 0;

            foreach(var pedido in ItensDoPedido) {
                valor += pedido.ValorItem * pedido.Quantidade;
            }

            return valor;
        }


        [ForeignKey("IdEndereco")]
        public Endereco? Endereco { get; set; }

        [ForeignKey("IdCliente")]
        public Clientes? Clientes { get; set; }
    }
}
