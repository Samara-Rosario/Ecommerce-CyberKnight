using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Ecommerce_CyberKnight.Pages.crud
{
    public class listarModel : PageModel{
        private readonly ApplicationDbContext _context;

        public listarModel(ApplicationDbContext context){
            _context = context;
        }

        public IList<Clientes> Clientes { get; set; }
        public async Task<IActionResult> OnGet(){
            Clientes = await _context.Clientes.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id){
            //Busca no banco de dados o cliente com o mesmo id procurado
            var Cliente = await _context.Clientes.FirstOrDefaultAsync( c => c. Id == id);

            //Verifica se foi retornado algum cliente do banco de dados
            if (Cliente != null){ 
                _context.Clientes.Remove(Cliente);
                await _context.SaveChangesAsync();
            }
            //Redireciona para a página de listagem de clientes
            return RedirectToPage("./listar");
        }
    }
}
