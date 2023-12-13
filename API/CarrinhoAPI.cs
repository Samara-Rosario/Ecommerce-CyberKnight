using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;

namespace Ecommerce_CyberKnight.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarrinhoAPIController : ControllerBase{
        private ApplicationDbContext _context;

        public CarrinhoAPIController(ApplicationDbContext context){
            _context = context;
        }

        [HttpPost]
        public async Task<JsonResult> AtualizarItemCarrinho(
            [FromForm] string idCarrinho, 
            [FromForm] int? idProduto = 0,
            [FromForm] int? quantidade = 0)
        {
            if (string.IsNullOrEmpty(
                idCarrinho) ||
                (idProduto <= 0) || 
                (quantidade <= 0)
            ) return new JsonResult(false);

            var pedido = await _context.Pedidos
                                            .Include("ItensPedido")
                                            .FirstOrDefaultAsync(p => p.IdCarrinho == idCarrinho);

            if (pedido != null){
                if (pedido.Situacao == Models.Pedido.SituacaoPedido.Carrinho){
                    var itemPedido = pedido.ItensDoPedido.FirstOrDefault<itemDoPedido>(ip => ip.IdProduto == idProduto);

                    if (itemPedido != null){

                        itemPedido.Quantidade = quantidade.Value;

                        if (_context.SaveChanges() > 0){
                            double valorPedido = pedido.ItensDoPedido.Sum(ip => ip.ValorItem);
                            var item = pedido.ItensDoPedido.Select(
                                x => new { id = x.IdProduto, q = x.Quantidade, v = x.ValorItem }).
                                FirstOrDefault(ip => ip.id == idProduto);
                            var jsonRes = new JsonResult(new { v = valorPedido, item });
                            return jsonRes;
                        }

                    }
                }
            }
            return new JsonResult(false);
        }

        [HttpPost]
        public async Task<JsonResult> ExcluirItemCarrinho([FromForm] string idCarrinho, 
            [FromForm] int? idProduto = 0)
        {
            if (string.IsNullOrEmpty(idCarrinho) || (idProduto <= 0)) return new JsonResult(false);

            var pedido = await _context.Pedidos.Include("ItensPedido").
                FirstOrDefaultAsync(p => p.IdCarrinho == idCarrinho);

            if (pedido != null)
            {
                if (pedido.Situacao == Models.Pedido.SituacaoPedido.Carrinho)
                {
                    var itemPedido = pedido.ItensDoPedido.FirstOrDefault(ip => ip.IdProduto == idProduto);
                    if (itemPedido != null)
                    {
                        pedido.ItensDoPedido.Remove(itemPedido);

                        if (_context.SaveChanges() > 0)
                        {
                            double valorPedido = pedido.ItensDoPedido.Sum(ip => ip.ValorItem);
                            var jsonRes = new JsonResult(new { v = valorPedido, id = idProduto });
                            return jsonRes;
                        }
                    }
                }
            }
            return new JsonResult(false);
        }
    }
}