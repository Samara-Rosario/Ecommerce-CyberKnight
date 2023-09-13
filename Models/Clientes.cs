using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_CyberKnight.Models {
    public class Clientes {

        [Key]
        public int Id { get; set; }
        public string Cpf {  get; set; }
        public int IdEndereco { get; set; }
        public string Nome {  get; set; }
        public string Email {  get; set; }
        public string Telefone {  get; set; }
        public string Cep {  get; set; }
        public string Login {  get; set; }
        public string Senha {  get; set; }

   
        [ForeignKey("IdEndereco")]
        public Endereco Endereco {  get; set; }
    
    }

}
