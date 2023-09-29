using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages.CategoriaCRUD
{
    public class AlterarModel : PageModel{
        private readonly ApplicationDbContext _context;

        public AlterarModel(ApplicationDbContext context) {
            _context = context;
        }

        // o "[BindProperty]" configura a aplicação para relacionar o atributo 'cliente' aos dados que estão vindo do front-end*/
        [BindProperty]
        public Categoria categorias { get; set; }

        public async Task<IActionResult> OnGet(int id) {
            if (id == null) {
                return NotFound();
            }
            categorias = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);

            if (categorias == null) {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }
            _context.Attach(categorias).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException error) {
                if (!CategoriaAindaExiste(categorias.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            } catch {
                return Page();
            }

            return RedirectToPage("./Listar");
        }

        private bool CategoriaAindaExiste(int? id) {
            return _context.Categorias.Any(c => c.Id == id);
        }
    }
}
