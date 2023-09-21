using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Ecommerce_CyberKnight.Pages.crud{
    public class IncluirModel : PageModel{

        private readonly ApplicationDbContext _context;
        
        public IncluirModel(ApplicationDbContext context) { 
            _context = context;
        }

        [BindProperty]
        public Clientes cliente { get; set; }
        public void OnGet(){

        }

        public async Task<IActionResult> OnPostAsync() {
            try {
                _context.Clientes.Add(cliente);

                await _context.SaveChangesAsync();
            }catch (Exception ex) {
                Debug.WriteLine("=====================");
                Debug.WriteLine(ex);
                Debug.WriteLine("=====================");
            }

            return Page();

        }
    }
}
