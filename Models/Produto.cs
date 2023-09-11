namespace Ecommerce_CyberKnight.Models
{
    public class Produto{
        public int Id { get; set; }
        public string Nome { get; set; }
        public string descricao { get; set; }
        public string categoria { get; set; }
        public double preco {  get; set; }
        public int unidadeMedida { get; set; }
        public float estoque { get; set; }

        public ICollection<itemDoPedido> ItensDoPedido { get; set; }
    }
}
