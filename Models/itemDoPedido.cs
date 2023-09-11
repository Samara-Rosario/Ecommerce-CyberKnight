namespace Ecommerce_CyberKnight.Models
{
    public class itemDoPedido
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public string endereco { get; set; }
        public string cliente { get; set; }
        public int quantidade { get; set;}
    }
}
