using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages.crud{
    public class alterarModel : PageModel{

        private readonly ApplicationDbContext _context;

        public alterarModel(ApplicationDbContext context){
            _context = context;
        }
        //O '[BindProperty]' configura a aplicação para relacionar o atributo
        //'cliente' aos dados que estão vindo do front-end

        [BindProperty]
        public Clientes cliente { get; set; }

        public async Task <IActionResult> OnGet(int id){
            cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(){ 
            _context.Attach(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./listar");
        }
    }
}
