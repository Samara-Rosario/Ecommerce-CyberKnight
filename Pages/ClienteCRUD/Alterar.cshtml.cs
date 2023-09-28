using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Ecommerce_CyberKnight.Pages.crud
{
	public class AlterarModel : PageModel
	{

		private readonly ApplicationDbContext _context;

		public AlterarModel(ApplicationDbContext context)
		{
			_context = context;

		}
		[BindProperty]

		public Clientes clientes { get; set; }
		public async Task<IActionResult> OnGetAsync(int? Id) {
			if (Id == null) { 
			return NotFound();
		}
			clientes = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == Id);

			if(clientes == null){
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			_context.Attach(clientes).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException error)
			{
				if (!ClienteAindaExiste(clientes.Id)){
					return NotFound();

				}
				else
				{
					throw;
				}
			} catch {
				return Page();
			}

				return RedirectToPage("./Listar");

			}

		private bool ClienteAindaExiste(int? id){
			return _context.Clientes.Any(c => c.Id == id);
		}
	}
}