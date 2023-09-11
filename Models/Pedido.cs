namespace Ecommerce_CyberKnight.Models
{
    public class Pedido
    {
        public int Id {  get; set; }
        public string cliente { get; set; }
        public string endereco { get; set; }
        public string itensDoPedido { get; set; }
        public double formaPagamento { get; set; }
        public DateTime DataeHora { get; set; }

    }
}
