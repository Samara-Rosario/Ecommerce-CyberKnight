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
            var cliente = new Clientes();

            bool validado = await TryUpdateModelAsync<Clientes>(
                cliente, "cliente", c => c.Nome, c => c.Cpf, c => c.Email, c => c.Telefone,
                c => c.Cep, c => c.Login, c => c.Senha

                );

            if (validado) {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Listar");
            } else {
                return Page();
            }


            try {
                _context.Clientes.Add(cliente);

                await _context.SaveChangesAsync();
            }catch (Exception ex) {
                Debug.WriteLine("=====================");
                Debug.WriteLine(ex);
                Debug.WriteLine("=====================");
            }

            return RedirectToPage("./Listar");

        }
    }
}
