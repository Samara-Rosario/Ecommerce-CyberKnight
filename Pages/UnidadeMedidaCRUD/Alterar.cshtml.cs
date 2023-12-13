using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages.UnidadeMedidaCRUD
{
    public class AlterarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AlterarModel(ApplicationDbContext context) {
            _context = context;
        }

        [BindProperty]
        public UnidadeDeMedida unidadeMedida { get; set; }
        public async Task<IActionResult> OnGetAsync(int? Id) {
            if (Id == null) {
                return NotFound();
            }
            unidadeMedida = await _context.unidadeMedidas.FirstOrDefaultAsync(c => c.Id == Id);

            if (unidadeMedida == null) {
                return NotFound();
            }

            return Page();

        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }
            _context.Attach(unidadeMedida).State = EntityState.Modified;
            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException error) {
                if (!unidadedeMedidaAindaExiste(unidadeMedida.Id)) {
                    return NotFound();

                } else {
                    throw;
                }
            } catch {
                return Page();
            }

            return RedirectToPage("./Listar");

        }

        private bool unidadedeMedidaAindaExiste(int? id) {
            return _context.unidadeMedidas.Any(c => c.Id == id);
        }

    }
}
