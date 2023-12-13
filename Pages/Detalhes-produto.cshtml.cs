using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages
{
    public class Detalhes_produtoModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Detalhes_produtoModel(ApplicationDbContext context) {
            _context = context;
        }

        public Produto produto { get; set; }

        public async Task<IActionResult> OnGet(int id) {
            if (id == null) {
                return NotFound();
            }
            produto = await _context.Produtos.FirstOrDefaultAsync(c => c.Id == id);

            if (produto == null) {
                return NotFound();
            }

            return Page();
        }

    }
}
