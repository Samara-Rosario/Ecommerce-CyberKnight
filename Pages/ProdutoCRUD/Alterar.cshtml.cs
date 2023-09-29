using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_CyberKnight.Pages.ProdutoCRUD
{
    public class AlterarModel : PageModel{
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        // o "[BindProperty]" configura a aplicação para relacionar o atributo 'produto' aos dados que estão vindo do front-end*/
        [BindProperty]
        public Produto produtos { get; set; }
        public string CaminhoImagem { get; set; }

        [BindProperty]
        [Display(Name = "Imagem do Produto")]
        public IFormFile ImagemProduto { get; set; }
        public AlterarModel(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> OnGetAsync(int? id){
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
