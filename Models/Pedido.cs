using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_CyberKnight.Models
{
    public class Pedido{

        public enum FormaPagamento{
            Pix,
            Boleto,
            CartaoDeCredito
        }

        [Key]
        public int? Id {  get; set; }
        public int? IdCliente { get; set; }
        public int? IdEndereco { get; set; }

        [MinLength(7, ErrorMessage = "O campo {0} deve ter no mínimo {7} caracteres.")]
        
        public string itensDoPedido { get; set; }
        [Required]
        public FormaPagamento formaPagamento { get; set; }

        [DataType(DataType.Date, ErrorMessage = "O campo {0} deve ter uma data válida")]   
        public DateTime DataeHora { get; set; }

        public ICollection<itemDoPedido> ItensDoPedido { get; set; }
        [ForeignKey("IdEndereco")]
        public Endereco? Endereco { get; set; }

        [ForeignKey("IdClientes")]
        public Clientes? Clientes { get; set; }
    }
}
