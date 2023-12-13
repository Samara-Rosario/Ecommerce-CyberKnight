using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Ecommerce_CyberKnight.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages.ClienteCRUD
{
    public class AlterarModelNovo : PageModel{
        private readonly ApplicationDbContext _context;
        private AuthVerify authVerify;

        public AlterarModelNovo(ApplicationDbContext context, UserManager<AppUser> userManager){
            _context = context;
            authVerify = new AuthVerify(userManager);
        }
        [BindProperty]

        public Clientes clientes { get; set; }
        public async Task<IActionResult> OnGetAsync(int? Id){
            if (!await authVerify.Test(User, "admin")) {
                return Redirect(AuthVerify.LoginUrl);
            }


            if (Id == null)
            {
                return NotFound();
            }
            clientes = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == Id);

            if (clientes == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(){
            if (!await authVerify.Test(User, "admin")) {
                return Redirect(AuthVerify.LoginUrl);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(clientes).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException error)
            {
                if (!ClienteAindaExiste(clientes.Id))
                {
                    return NotFound();

                }
                else
                {
                    throw;
                }
            }
            catch
            {
                return Page();
            }

            return RedirectToPage("/ClienteCRUD/Listar");

        }

        private bool ClienteAindaExiste(int? id)
        {
            return _context.Clientes.Any(c => c.Id == id);
            }
        }
    }