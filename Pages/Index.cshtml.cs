using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Diagnostics;

namespace Ecommerce_CyberKnight.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private ApplicationDbContext _contextDb;

        public IList<Produto> Produtos;
        public IList<Categoria> categorias;


        private int paginaAtual = 1;
        public int? _valorMinimo = 0;
        public int? _valorMaximo = 30;
        public string termoBusca = "";

        public int QuantidadePagina { get; private set; }
        private int qtdProdPorPagina = 12;
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _contextDb = context;

        }

        public async Task<IActionResult> OnGetAsync(
            [FromQuery(Name = "q")] string TermoBusca,
            [FromQuery(Name = "p")] int? pagina,
            [FromQuery(Name = "o")] int? ordem,
            [FromQuery(Name = "cats")] string? listaCategorias,
            [FromQuery(Name = "valMin")] int? valorMinimo,
            [FromQuery(Name = "valMax")] int? valorMaximo
        )
        {

            this.termoBusca = TermoBusca;

            paginaAtual = pagina ?? 1;

            var query = _contextDb.Produtos.AsQueryable();
            categorias = await _contextDb.Categorias.ToListAsync();

            if (!string.IsNullOrEmpty(TermoBusca)){
                query = query.Where(
                        p => p.Nome.ToLower().Contains(TermoBusca.ToLower())
                );
            }

            List<string> catsFront = new List<string>();


            //filtro categoria
            if (!string.IsNullOrEmpty(listaCategorias)){
                //Debug.WriteLine(listaCategorias);

                foreach(var item in listaCategorias.Split('|')){
                    Debug.WriteLine(item);

                    if (!string.IsNullOrEmpty(item)){
                        catsFront.Add(item);
                    }
                }

                /*
                query = query.Where(
                      
                );
                */
            }


            // Filtro pre�o
            try
            {
                //Filtro Rager de Valores
                if (valorMinimo != null && valorMaximo != null)
                {
                    query = query.Where(
                        p => p.preco >= valorMinimo && p.preco <= valorMaximo
                    );
                }
            }
            catch (Exception erro)
            {
                Debug.WriteLine(erro);
            }


            //fiiltro de ordena��o
            if (ordem.HasValue)
            {
                switch (ordem.Value)
                {
                    case 1:
                        query = query.OrderBy(p => p.Nome.ToLower());
                        break;
                    case 2:
                        query = query.OrderByDescending(p => p.Nome.ToLower());
                        break;
                    case 3:
                        query = query.OrderBy(p => p.preco);
                        break;
                    case 4:
                        query = query.OrderByDescending(p => p.preco);
                        break;
                }
            
            }

            var stage = query;
            var qtdProdutos = stage.Count();


            double result = qtdProdutos * 1.0 / qtdProdPorPagina;
            result = Math.Ceiling(result);



            QuantidadePagina = Convert.ToInt32(result);
            //Aqui voc� deve escrever o calculo para obter a quantidade de p�ginas, voc� j� ter definido quantos produtos deve ter em cada p�gina,



            //e tamb�m possui la quantidade de produto em toda o sistema. O n�mero a obter deve ser no tipo inteiro

            query = query.Skip(qtdProdPorPagina * (this.paginaAtual - 1)).Take(qtdProdPorPagina);

            Produtos = await query.ToListAsync();


            return Page();
        }
    }
}
