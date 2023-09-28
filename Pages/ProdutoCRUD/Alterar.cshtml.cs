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

        // o "[BindProperty]" configura a aplicação para relacionar o atributo 'cliente' aos dados que estão vindo do front-end*/
        [BindProperty]
        public Produto produtos { get; set; }

        public async Task<IActionResult> OnGet(int id){
            if(id == null) {
                return NotFound();
            }
            produtos = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            if(produtos == null) {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }
            _context.Attach(produtos).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException error) {
                if (!ProdutoAindaExiste(produtos.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            } catch {
                return Page();
            }

            return RedirectToPage("./Listar");
        }

        private bool ProdutoAindaExiste(int? id) {
            return _context.Produtos.Any(p => p.Id == id);
        }
    }
}
