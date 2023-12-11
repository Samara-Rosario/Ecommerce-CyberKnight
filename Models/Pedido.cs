using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_CyberKnight.Models
{
    public class Pedido{
        public enum SituacaoPedido {
            Carrinho,
            Realizado,
            Verificado,
            Atendido,
            Entregue,
            Cancelado
        }

        public enum TipoFormaPagamento {
            PIX,
            C_CREDITO,
            C_DEBITO,
            BOLETO,
            A_VISTA
        }


        [Key]
        public int? Id {  get; set; }
        public int? IdCliente { get; set; }
        public int? IdEndereco { get; set; }
        public string IdCarrinho { get; set; }
        public TipoFormaPagamento FormaPagamento { get; set; }
        public DateTime DataeHora { get; set; }


        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        [DisplayName("Situação")]
        public SituacaoPedido Situacao { get; set; }

        public double ValorPedido()
        {
            double valor = 0;

            foreach (var pedido in ItensDoPedido)
            {
                valor += pedido.ValorItem * pedido.Quantidade;
            }

            return valor;
        }
        
        public ICollection<itemDoPedido> ItensDoPedido { get; set; }
        [ForeignKey("IdEndereco")]
        public Endereco? Endereco { get; set; }

        [ForeignKey("IdClientes")]
        public Clientes? Clientes { get; set; }
    }
}
