using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Ecommerce_CyberKnight.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages.ClienteCRUD
{
    public class ListarModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        public readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        AuthVerify authVerify;

        public List<string> EmailsAdmins { get; private set; }


        public ListarModel(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            authVerify = new AuthVerify(userManager);
        }

        public IList<Clientes> Clientes { get; set; } = new List<Clientes>();

        public async Task<IActionResult> OnGet(){
            if (!await authVerify.Test(User, "admin")) {
                return Redirect(AuthVerify.LoginUrl);
            }

            EmailsAdmins = (await _userManager.GetUsersInRoleAsync("admin"))
                                  .Select(x => x.Email).ToList();

            Clientes = await _context.Clientes.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id){
            if (!await authVerify.Test(User, "admin")) {
                return Redirect(AuthVerify.LoginUrl);
            }

            if (id == null)
            {
                return NotFound();
            }

            //Busca no banco de dados o cliente com o mesmo id procurado
            var clienteParaDeletar = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            //Verifica se foi retornado algum cliente do banco de dados
            if (clienteParaDeletar != null)
            {
                _context.Clientes.Remove(clienteParaDeletar);
                await _context.SaveChangesAsync();
            }

            //Redireciona para a página de listagem de Cliente
            return RedirectToPage("/ClienteCRUD/Listar");
        }

        public async Task<IActionResult> OnPostDelAdminAsync(int? id){
            if (!await authVerify.Test(User, "admin")) {
                return Redirect(AuthVerify.LoginUrl);
            }

            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente != null)
            {
                AppUser usuario = await _userManager.FindByNameAsync(cliente.Email);
                if (usuario != null)
                {
                    await _userManager.RemoveFromRoleAsync(usuario, "admin");
                }
            }

            return RedirectToPage("/ClienteCRUD/Listar");
        }

        public async Task<IActionResult> OnPostSetAdminAsync(int? id){
            if (!await authVerify.Test(User, "admin")) {
                return Redirect(AuthVerify.LoginUrl);
            }

            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente != null)
            {
                AppUser usuario = await _userManager.FindByNameAsync(cliente.Email);
                if (usuario != null)
                {
                    if (!await _roleManager.RoleExistsAsync("admin"))
                        await _roleManager.CreateAsync(new IdentityRole("admin"));

                    await _userManager.AddToRoleAsync(usuario, "admin");
                }
            }

            return RedirectToPage("/ClienteCRUD/Listar");
        }
    }
}
