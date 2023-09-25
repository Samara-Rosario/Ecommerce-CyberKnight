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

		public Clientes clientes{ get; set; }
		public async Task<IActionResult> OnGet(int id){
			clientes = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			_context.Attach(clientes).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return RedirectToPage("./Listar");
		}
	}
}