using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Ecommerce_CyberKnight.Pages.CategoriaCRUD
{
    public class ListarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ListarModel(ApplicationDbContext context) {
            _context = context;
        }

        public IList<Categoria> Categorias { get; set; }
        public async Task<IActionResult> OnGet() {
            Categorias = await _context.Categorias.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            //Busca no banco de dados o Produto com o mesmo id procurado
            var CategoriaParaDeletar = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);

            //Verifica se foi retornado algum Produto do banco de dados
            if (CategoriaParaDeletar != null) {
                _context.Categorias.Remove(CategoriaParaDeletar);
                await _context.SaveChangesAsync();
            }

            //Redireciona para a página de listagem de Produto
            return RedirectToPage("./Listar");
        }
    }
}
