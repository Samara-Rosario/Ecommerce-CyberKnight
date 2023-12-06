using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages
{
    public class AdmPedidosModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdmPedidosModel(ApplicationDbContext context) {
            _context = context;
        }

        public IList<Pedido> pedidos { get; set; }
        public async Task<IActionResult> OnGet() {
            pedidos = await _context.Pedidos
                                        .Include(p => p.Endereco)
                                        .Include(p => p.Clientes)
                                        .Include(p => p.ItensDoPedido)
                                        .ThenInclude(p => p.Produto)
                                        .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            //Busca no banco de dados o Produto com o mesmo id procurado
            var PedidoParaDeletar = await _context.Pedidos.FirstOrDefaultAsync(pe => pe.Id == id);

            //Verifica se foi retornado algum Pedido do banco de dados
            if (PedidoParaDeletar != null) {
                _context.Pedidos.Remove(PedidoParaDeletar);
                await _context.SaveChangesAsync();
            }

            //Redireciona para a página de listagem do pedido
            return RedirectToPage("./Listar");
        }
    }
}
