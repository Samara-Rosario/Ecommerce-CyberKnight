using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages.UnidadeMedidaCRUD {
            public class ListarModel : PageModel {
            private readonly ApplicationDbContext _context;

            public ListarModel(ApplicationDbContext context) {
                _context = context;
            }

            public IList<UnidadeDeMedida> unidadeMedidas { get; set; }
            public async Task<IActionResult> OnGet() {
                unidadeMedidas = await _context.unidadeMedidas.ToListAsync();

                return Page();
            }

            public async Task<IActionResult> OnPostDeleteAsync(int? id) {
                if (id == null) {
                    return NotFound();
                }

                //Busca no banco de dados o Produto com o mesmo id procurado
                var UnidadeMedidaParaDeletar = await _context.unidadeMedidas.FirstOrDefaultAsync(u => u.Id == id);

                //Verifica se foi retornado algum Produto do banco de dados
                if (UnidadeMedidaParaDeletar != null) {
                    _context.unidadeMedidas.Remove(UnidadeMedidaParaDeletar);
                    await _context.SaveChangesAsync();
                }

                //Redireciona para a página de listagem de Produto
                return RedirectToPage("./Listar");
            }
        }
    }