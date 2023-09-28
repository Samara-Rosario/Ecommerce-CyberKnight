using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_CyberKnight.Models {
    public class Clientes {

        [Key]
        public int? Id { get; set; }
        
    [Required(ErrorMessage = "O campo \"{0}\" é de preechimento obrigatório")]
		[RegularExpression(@"[0-9]{11}", ErrorMessage = "O campo {0} deve ser preenchido com 11 digitos numéricos")]
     public string Cpf {  get; set; }

		public int? IdEndereco { get; set; }

    [Required(ErrorMessage = "O campo \"{0}\" é de preechimento obrigatório")]
    public string Nome {  get; set; }

		[Required(ErrorMessage = "O campo \"{0}\" é de preechimento obrigatório")]
		[EmailAddress(ErrorMessage = "O campo {0} deve conter um endereço de e-mail válido")]
		public string Email {  get; set; }


		[Required(ErrorMessage = "O campo \"{0}\" é de preechimento obrigatório")]
		[MinLength(11, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
		public string Telefone {  get; set; }


		[Required(ErrorMessage = "O campo \"{0}\" é de preechimento obrigatório")]
		[MinLength(8, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
		public string Cep {  get; set; }


		[Required(ErrorMessage = "O campo \"{0}\" é de preechimento obrigatório")]
		[MinLength(8, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
		public string Login {  get; set; }

		[Required(ErrorMessage = "O campo \"{0}\" é de preechimento obrigatório")]
		[MinLength(8, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
		public string Senha {  get; set; }

   
        [ForeignKey("IdEndereco")]
        public Endereco? Endereco {  get; set; }
    
    }   

}
