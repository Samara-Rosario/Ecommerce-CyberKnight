using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages.ProdutoCRUD
{
    public class AlterarModel : PageModel{
        private readonly ApplicationDbContext _context;

        public AlterarModel(ApplicationDbContext context) {
            _context = context;
        }

        // o [BindProperty] configura a aplicação para relacionar o atributo 'cliente' aos dados que estão vindo do front-end*/
        [BindProperty]
        public Produto produtos { get; set; }

        public async Task<IActionResult> OnGet(int id){
            produtos = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {


            _context.Attach(produtos).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Listar");
        }
    }
}
