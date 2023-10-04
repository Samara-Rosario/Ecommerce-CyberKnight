using Microsoft.AspNetCore.Identity;

namespace Ecommerce_CyberKnight.Models {
	public class AppUser : IdentityUser{
		public string Nome { get; set; }
	}
}
