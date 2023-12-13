using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages
{
    public class AdmPedidosModel : PageModel
    {

        private readonly ILogger<AdmPedidosModel> _logger;
        private ApplicationDbContext _contextDb;
        private readonly ApplicationDbContext _context;

        public AdmPedidosModel(ILogger<AdmPedidosModel> logger, ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        private int _ordem = 1;

        public IList<Pedido> Pedidos { get; set; }

        public async Task<IActionResult> OnGetAsync(
            [FromQuery(Name = "o")] int? ordem
        ) {
            this._ordem = ordem ?? 1;

            //var query = _contextDb.Produtos.AsQueryable();
            var query = _context.Pedidos
                                    .Include(p => p.Endereco)
                                    .Include(p => p.Clientes)
                                    .Include(p => p.ItensDoPedido)
                                    .ThenInclude(p => p.Produto)
                                    .AsQueryable();

           //filtro ordenação
           if (ordem.HasValue) {
                switch (ordem.Value) { 
                    case 1: //data e hora do pedido
                        query = query.OrderBy(dh => dh.DataeHora);
                        break;
                    case 2: //data e hora do pedido
                        query = query.OrderByDescending(dh => dh.DataeHora);
                        break;
                }
            }

            Pedidos = await query.ToListAsync();
           
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
