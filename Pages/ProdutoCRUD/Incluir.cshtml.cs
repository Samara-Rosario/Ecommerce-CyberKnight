using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Ecommerce_CyberKnight.Pages.ProdutoCRUD
{
    public class IncluirModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private reandoly IWebHostEnvironment _ whe;
        public string CaminhoImagem { get; set; }

        [BindProperty]
        [Display(Name = "Iamagem do produto")]
        [Required(ErrorMessage = "0 Campo \ "{0}\" é de preenchimento obrigatório,")]
        
        public IFormFile ImagemProduto {  get; set; }
        

        public IncluirModel(ApplicationDbContext context, IWebHostEnvironment whe){
            _context = context;
            _webHostEnviroment = whe;
            CaminhoImagem = "~/img/produto/sem_imagem.jpg";
            
        }

        [BindProperty]
        public Produto produto { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync() {
            var produto = new Produto();

            bool validado = await TryUpdateModelAsync<Produto>(produto, "produto", p => p.Nome, p => p.preco, p => p.estoque, p => p.descricao);

            if (validado)
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Listar");
            }
            else { 
                return Page();
            
            }
                
            

        }
    }
}
