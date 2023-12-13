using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce_CyberKnight.Pages.CategoriaCRUD
{
    public class Incluir2Model : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Incluir2Model(ApplicationDbContext context) {
            _context = context;
        }

        [BindProperty]
        public Categoria categoria { get; set; }
        public void OnGet() {

        }

        public async Task<IActionResult> OnPostAsync() {
            var categoria = new Categoria();

            bool validado = await TryUpdateModelAsync<Categoria>(categoria, "categoria", c => c.Nome, c => c.Descricao);

            if (validado) {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Listar");
            } else {
                return Page();

            }



        }
    }
}
