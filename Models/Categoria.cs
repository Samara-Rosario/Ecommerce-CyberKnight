using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_CyberKnight.Models {
    public class Categoria {
        [Key]
        public int? Id { get; set; }

        [MaxLength(100, ErrorMessage = "O campo \"{0}\" deve ter tamanho igual a {1}")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public string Nome { get; set; }

        [MaxLength(200, ErrorMessage = "O campo \"{0}\" deve ter tamanho igual a {1}")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public string? Descricao { get; set; }
    }
}