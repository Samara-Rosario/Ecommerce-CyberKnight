using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Ecommerce_CyberKnight.Pages.ProdutoCRUD
{
    public class IncluirModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IncluirModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produto produto { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync() {
            var produto = new Produto();

            bool validado = await TryUpdateModelAsync<Produto>(produto, "produto", p => p.Nome, p => p.preco, p => p.estoque, p => p.descricao);

            if (validado)
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Listar");
            }
            else { 
                return Page();
            
            }
                
            

        }
    }
}
