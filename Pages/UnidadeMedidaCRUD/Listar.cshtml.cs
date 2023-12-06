using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages.UnidadeMedidaCRUD {
            public class ListarModel : PageModel {
            private readonly ApplicationDbContext _context;

            public string MsgError { get; set; }

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
                try {
                    if (UnidadeMedidaParaDeletar != null) {
                        _context.unidadeMedidas.Remove(UnidadeMedidaParaDeletar);
                        await _context.SaveChangesAsync();
                    }
                }catch (DbUpdateException ex) {
                    this.MsgError = "A unidade n�o pode ser excluida pois possui produto utilizando-a";
                    unidadeMedidas = await _context.unidadeMedidas.ToListAsync();
			        
                    return Page();
                }
                return RedirectToPage("./Listar");

                //Redireciona para a p�gina de listagem de Produto
            }
        }
    }