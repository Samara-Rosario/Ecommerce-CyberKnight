using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages.crud
{
    public class ListarModel : PageModel{

       private readonly ApplicationDbContext _context;

		public ListarModel(ApplicationDbContext context)
		{
			_context = context;
		}

		public IList<Clientes> Clientes { get; set; }
          
        public async Task<IActionResult> OnGet()
        {

            Clientes = await _context.Clientes.ToListAsync();

			return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id){
			//Busca no banco de dados o cliente com o mesmo id procurado


			var clienteParaDeletar = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            //Verifica se foi retornado algum do cliente do banco de dados

            if (clienteParaDeletar != null){
                _context.Clientes.Remove(clienteParaDeletar);
                await _context.SaveChangesAsync();
            }

            //Redireciona para a pagina de listagens de cliente
             
            return RedirectToPage("./Listar");
        }
    }
}
