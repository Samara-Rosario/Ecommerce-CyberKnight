using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ecommerce_CyberKnight.Models {
    [Owned]    
    public class Endereco {
        [Key]
        public int? Id { get; set; }

        [MaxLength(8, ErrorMessage = "O campo \"{0}\" deve ter tamanho igual a {1}")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public string Cep { get; set; }

        [MaxLength(100, ErrorMessage = "O campo \"{0}\" deve ter tamanho igual a {1}")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public string Cidade { get; set;}

        [MaxLength(100, ErrorMessage = "O campo \"{0}\" deve ter tamanho igual a {1}")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public string Bairro { get; set; }

        [MaxLength(100, ErrorMessage = "O campo \"{0}\" deve ter tamanho igual a {1}")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public string Rua { get; set; }

        [MaxLength(4, ErrorMessage = "O campo \"{0}\" deve ter tamanho igual a {1}")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public int Numero { get; set; }

        [MaxLength(100, ErrorMessage = "O campo \"{0}\" deve ter tamanho igual a {1}")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public string Logradouro { get; set; }

        [MaxLength(150, ErrorMessage = "O campo \"{0}\" deve ter tamanho igual a {1}")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatório.")]
        public string Complemento { get; set; }
    }
}
