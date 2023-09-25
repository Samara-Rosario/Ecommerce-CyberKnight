using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ecommerce_CyberKnight.Models {
    [Owned]    
    public class Endereco {
        public int? Id { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set;}
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
    }
}
