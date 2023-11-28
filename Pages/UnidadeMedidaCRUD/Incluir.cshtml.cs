using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ecommerce_CyberKnight.Data;

namespace Ecommerce_CyberKnight.Pages
{
    public class IncluirModel : PageModel{
        private readonly ApplicationDbContext _context;

        public IncluirModel(ApplicationDbContext context) {
            _context = context;
        }

        [BindProperty]
        public UnidadeDeMedida unidadeMedida { get; set; }
        public void OnGet() {

        }

        public async Task<IActionResult> OnPostAsync() {
            var unidadeMedida = new UnidadeDeMedida();

            bool validado = await TryUpdateModelAsync<UnidadeDeMedida>(unidadeMedida, "unidadeMedida", u => u.NomeExtenso, u => u.Sigla);

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
