using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages.ProdutoCRUD {
    public class ListarModel : PageModel {

        private readonly ApplicationDbContext _context;

        public ListarModel(ApplicationDbContext context) {
            _context = context;
        }

        public IList<Produto> Produto { get; set; }
        public async Task<IActionResult> OnGet() {
           Produto  = await _context.Produtos.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id) {
			//Busca no banco de dados o Produto com o mesmo id procurado
			var ProdutoParaDeletar = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

			//Verifica se foi retornado algum Produto do banco de dados
			if (ProdutoParaDeletar != null) {
                _context.Produtos.Remove(ProdutoParaDeletar);
                await _context.SaveChangesAsync();
            }

            Produto = await _context.Produtos.ToListAsync();

            //Redireciona para a página de listagem de Produto
            return Page();
        }
    }
}