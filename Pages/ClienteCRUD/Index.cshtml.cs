using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce_CyberKnight.Pages.ClienteCRUD {
    public class IndexModel : PageModel {

        public string Nome { get; set; }
        public  int? Num { get; set; }
        public IActionResult OnGet(string nome, int? num) {
            return RedirectToPage("/ClienteCRUD/Listar");
        }
    }
}
