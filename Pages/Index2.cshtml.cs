using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages {
    public class Index2Model : PageModel {
        private readonly ILogger<IndexModel> _logger;

        private ApplicationDbContext _contextDb;

        public IList<Produto> Produtos;

        private int paginaAtual = 1;

        public int QuantidadePagina { get; private set; }
        private int qtdProdPorPagina = 12;
        public Index2Model(ILogger<IndexModel> logger, ApplicationDbContext context) {
            _logger = logger;
            _contextDb = context;
        }

        public async Task OnGet(
            [FromQuery(Name = "q")] string  TermoBusca,
            [FromQuery(Name = "p")] int? pagina,
            [FromQuery(Name = "o")] int? ordem
        ) {

            paginaAtual = pagina ?? 1;

            var query = _contextDb.Produtos.AsQueryable();

            if (!string.IsNullOrEmpty(TermoBusca)) {
                query = query.Where(
                        p => p.Nome.ToLower().Contains(TermoBusca.ToLower())
                );
            }

            if (ordem.HasValue) {
                switch (ordem.Value) {
                    case 1:
                        query = query.OrderBy(p => p.Nome.ToLower());
                        break;
                    case 2:
                        query = query.OrderBy(p => p.preco);
                        break;
                    case 3:
                        query = query.OrderByDescending(p => p.preco);
                        break;
                }
            }

            var stage = query;
            var qtdProdutos = stage.Count(); 
            
                    
            double result = qtdProdutos * 1.0 / qtdProdPorPagina;
            result = Math.Ceiling(result);



            QuantidadePagina = Convert.ToInt32(result);
            //Aqui você deve escrever o calculo para obter a quantidade de páginas, você já ter definido quantos produtos deve ter em cada página,



            //e também possui la quantidade de produto em toda o sistema. O número a obter deve ser no tipo inteiro

            query = query.Skip(qtdProdPorPagina * (this.paginaAtual - 1)).Take(qtdProdPorPagina);

            Produtos = await query.ToListAsync();



        }
    }
}
