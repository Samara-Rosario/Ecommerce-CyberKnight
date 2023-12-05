using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages.UnidadeMedidaCRUD
{
    public class AlterarVelhoModel : PageModel
    {
		private readonly ApplicationDbContext _context;

		public AlterarVelhoModel(ApplicationDbContext context) {
			_context = context;
		}

		// o "[BindProperty]" configura a aplicação para relacionar o atributo 'unidadeMedida' aos dados que estão vindo do front-end*/
		[BindProperty]
		public UnidadeDeMedida unidadeMedida { get; set; }

		public async Task<IActionResult> OnGet(int id) {
			if (id == null) {
				return NotFound();
			}
			unidadeMedida = await _context.unidadeMedidas.FirstOrDefaultAsync(u => u.Id == id);

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
				if (!unidadeMedidaAindaExiste(unidadeMedida.Id)) {
					return NotFound();
				} else {
					throw;
				}
			} catch {
				return Page();
			}

			return RedirectToPage("./Listar");
		}

		private bool unidadeMedidaAindaExiste(int? id) {
			return _context.unidadeMedidas.Any(c => c.Id == id);
		}
	}
}
