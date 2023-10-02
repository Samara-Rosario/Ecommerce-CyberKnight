using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_CyberKnight.Models
{
    public class Produto{
        [Key]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "O campo \"{0}\" deve ter tamanho igual a {1}")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public string Nome { get; set; }

        [MaxLength(200, ErrorMessage = "O campo \"{0}\" deve ter tamanho igual a {1}")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public string descricao { get; set; }
        public int? IdCategoria { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public double preco {  get; set; }
        public int? IdUnidadeMedida { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public float estoque { get; set; }

        public ICollection<itemDoPedido>? ItensDoPedido { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria? categoria { get; set; }

        [ForeignKey("IdUnidadeMedida")]
        public UnidadeMedida? unidadeMedida { get; set; }
    }
}
