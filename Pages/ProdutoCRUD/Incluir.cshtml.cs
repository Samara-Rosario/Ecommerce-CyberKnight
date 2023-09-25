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

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                _context.Produtos.Add(produto);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("=====================");
                Debug.WriteLine(ex);
                Debug.WriteLine("=====================");
            }

            return Page();

        }
    }
}
