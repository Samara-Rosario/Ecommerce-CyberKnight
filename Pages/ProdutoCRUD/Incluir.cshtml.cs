using CodigoApoio;
using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_CyberKnight.Pages.ProdutoCRUD
{
    public class IncluirModel : PageModel
    {
        [BindProperty]
        public Produto produto { get; set; }

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _whe;
        public string CaminhoImagem { get; set; }

        [BindProperty]
        [Display(Name = "Imagem do produto")]
        [Required(ErrorMessage = "0 Campo \"{0}\"� de preenchimento obrigat�rio,")]
        public IFormFile ImagemProduto { get; set; }

        public List<UnidadeMedida> listaUnidadeMedidas { get; set; }
        public List<Categoria> listaCategoria { get; set; }
        
        [BindProperty]
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "0 Campo \"{0}\"� de preenchimento obrigat�rio,")]
        public int IdCategoria { get; set; }

        [BindProperty]
        [Display(Name = "Unidade de Medida")]
        [Required(ErrorMessage = "0 Campo \"{0}\"� de preenchimento obrigat�rio,")]
        public int IdUnidadeMedida { get; set; }



        public IncluirModel(ApplicationDbContext context, IWebHostEnvironment whe) {

            _context = context;
            _whe = whe;
            CaminhoImagem = "~/img/produto/sem_imagem.jpg";
            listaUnidadeMedidas = context.unidadeMedidas.ToList();
            listaCategoria = context.Categorias.ToList();
        }

        public void OnGet() {

        }

        public async Task<IActionResult> OnPostAsync() {
            if (ImagemProduto == null) {
                return Page();
            }

            var produto = new Produto();

            bool validado = await TryUpdateModelAsync<Produto>(produto, "produto", p => p.Nome, p => p.preco, p => p.estoque, p => p.descricao);

            if (validado) {
                produto.categoria = _context.Categorias.FirstOrDefault(c => c.Id == IdCategoria);
                produto.unidadeMedida = _context.unidadeMedidas.FirstOrDefault(u => u.Id == IdUnidadeMedida);

                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
                await AppUtils.ProcessarArquivoDeImagem(produto.Id, ImagemProduto, _whe);

                return RedirectToPage("./Listar");
            } else {
                return Page();
            }



        }
    }
}
