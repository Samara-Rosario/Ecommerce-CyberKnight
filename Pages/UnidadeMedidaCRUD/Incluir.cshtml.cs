using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce_CyberKnight.Pages.UnidadeMedidaCRUD
{
    public class IncluirModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IncluirModel(ApplicationDbContext context) {
            _context = context;
        }

        [BindProperty]
        public UnidadeMedida unidadeMedida { get; set; }
        public void OnGet() {

        }

        public async Task<IActionResult> OnPostAsync() {
            var unidadeMedida = new UnidadeMedida();

            bool validado = await TryUpdateModelAsync<UnidadeMedida>(unidadeMedida, "unidadeMedida", u => u.NomeExtenso, u => u.Sigla);

            if (validado) {
                _context.unidadeMedidas.Add(unidadeMedida);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Listar");
            } else {
                return Page();

            }



        }
    }
}
