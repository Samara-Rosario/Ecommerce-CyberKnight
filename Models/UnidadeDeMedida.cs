using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_CyberKnight.Models {
	public class UnidadeMedida {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }


		[Required(ErrorMessage = "O campo \"{0}\" é obrigatório")]
		public string Sigla { get; set; }


		[Required(ErrorMessage = "O campo \"{0}\" é obrigatório")]
		public string NomeExtenso { get; set; }
	}
}