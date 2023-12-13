using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Ecommerce_CyberKnight.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Ecommerce_CyberKnight.Pages.ClienteCRUD {
    public class IncluirModelNovo : PageModel {
        private readonly ApplicationDbContext _context;
        private AuthVerify authVerify;

        public IncluirModelNovo(ApplicationDbContext context, UserManager<AppUser> userManager) {
            _context = context;
            authVerify = new AuthVerify(userManager);
        }

        [BindProperty]
        public Clientes cliente { get; set; }
        public async Task<IActionResult> OnGetAsync(){
            if (!await authVerify.Test(User, "admin")) {
                return Redirect(AuthVerify.LoginUrl);
            }else{
                return Page();
           }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!await authVerify.Test(User, "admin")) {
                return Redirect(AuthVerify.LoginUrl);
            }

            var cliente = new Clientes();

            bool validado = await TryUpdateModelAsync<Clientes>(
                cliente, "cliente", c => c.Nome, c => c.Cpf, c => c.Email, c => c.Cep, c => c.Telefone,
                c => c.DataDeNascimento

                );

            if (validado)
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                return RedirectToPage("/ClienteCRUD/Listar");
            }
            else
            {
                return Page();
            }

        }
    }
}