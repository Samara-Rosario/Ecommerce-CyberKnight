using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;

        private ApplicationDbContext _contextDb;

        public IList<Produto> Produtos;
        
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context) {
            _logger = logger;
            _contextDb = context;
        }

        public async Task OnGet() {
            Produtos = await _contextDb.Produtos.ToListAsync<Produto>();

            ViewData["nome"] = HttpContext.Request.Query["nome"];
        }
    }
}