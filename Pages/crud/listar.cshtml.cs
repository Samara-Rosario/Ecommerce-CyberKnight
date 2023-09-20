using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace Ecommerce_CyberKnight.Pages.crud
{
    public class listarModel : PageModel{
        private readonly ApplicationDbContext _context;

        public listarModel(ApplicationDbContext context){
            _context = context;
        }

        public IList<Clientes> Clientes { get; set; }
        public void OnGet(){

        }
    }
}
