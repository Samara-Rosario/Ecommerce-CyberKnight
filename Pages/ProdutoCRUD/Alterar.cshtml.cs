using CodigoApoio;
using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Ecommerce_CyberKnight.Pages.ProdutoCRUD
{
    public class AlterarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        // o "[BindProperty]" configura a aplicação para relacionar o atributo 'produto' aos dados que estão vindo do front-end*/
        [BindProperty]
        public Produto produtos { get; set; }
        public string CaminhoImagem { get; set; }

        [BindProperty]
        [Display(Name = "Imagem do Produto")]
        public IFormFile ImagemProduto { get; set; }

        public List<UnidadeMedida> listaUnidadeMedidas { get; set; }
        public List<Categoria> listaCategoria { get; set; }

        [BindProperty]
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "0 Campo \"{0}\"é de preenchimento obrigatório,")]
        public int IdCategoria { get; set; }

        [BindProperty]
        [Display(Name = "Unidade de Medida")]
        [Required(ErrorMessage = "0 Campo \"{0}\"é de preenchimento obrigatório,")]
        public int IdUnidadeMedida { get; set; }


        public AlterarModel(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            listaUnidadeMedidas = context.unidadeMedidas.ToList();
            listaCategoria = context.Categorias.ToList();
        }
        
        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }
            produtos = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            if (produtos == null) {
                return NotFound();
            }

            CaminhoImagem = $"~/img/produto/{produtos.Id:D6}.jpg";

            return Page();
        }






        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }
            _context.Attach(produtos).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
                //Se há uma imagem de produto submetia
                if (ImagemProduto != null) {
                    await AppUtils.ProcessarArquivoDeImagem(produtos.Id, ImagemProduto, _webHostEnvironment);

                }
            } catch (DbUpdateConcurrencyException error) {
                if (!ProdutoAindaExiste(produtos.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            } catch (Exception err) {
                Debug.WriteLine(err);
                return Page();
            }

            return RedirectToPage("./Listar");
        }

        private bool ProdutoAindaExiste(int? id) {
            return _context.Produtos.Any(p => p.Id == id);
        }
    }
}
