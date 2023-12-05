using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Ecommerce_CyberKnight.Pages.ClienteCRUD
{
    public class IncluirModelNovo : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IncluirModelNovo(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clientes cliente { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var cliente = new Clientes();

            bool validado = await TryUpdateModelAsync<Clientes>(
                cliente, "cliente", c => c.Nome, c => c.Cpf, c => c.Email, c => c.Cep, c => c.Telefone,
                c => c.DataDeNascimento, c => c.Login, c => c.Senha, c => c.ConfirmarSenha

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