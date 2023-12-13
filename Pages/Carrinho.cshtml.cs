using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;

namespace Ecommerce_CyberKnight.Pages{
    public class CarrinhoModel : PageModel
    {
        private ApplicationDbContext _context;
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        
        public string COOKIE_NAME{
            get { return ".AspNetCore.CartId"; }
        }

        public Pedido Pedido { get; set; }
        public double TotalPedido { get; set; }

        public CarrinhoModel(
            ApplicationDbContext context,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(){

            if (Request.Cookies.ContainsKey(COOKIE_NAME)){
            
                var cartId = Request.Cookies[COOKIE_NAME];
                Pedido = await _context.Pedidos
                                            .Include("ItensPedido")
                                            .Include("ItensPedido.Produto").
                                            FirstOrDefaultAsync(p => p.IdCarrinho == cartId);

                if (Pedido != null)
                {
                    if (Pedido.Situacao != Pedido.SituacaoPedido.Carrinho)
                    {
                        Response.Cookies.Delete(COOKIE_NAME);
                        return RedirectToPage("/Index");
                    }
                    TotalPedido = Pedido.ItensDoPedido.Sum(x => x.Quantidade * x.ValorItem);
                }
                else
                {
                    TotalPedido = 0;
                }
            }
            else
            {
                TotalPedido = 0;
                SetCartCookie();
            }

            return Page();
        }

        public string SetCartCookie()
        {
            var cartId = Guid.NewGuid().ToString();

            var options = new Microsoft.AspNetCore.Http.CookieOptions()
            {
                Path = "/",
                Expires = DateTime.UtcNow.AddDays(90),
                IsEssential = true,
                Secure = false,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                HttpOnly = false //necessário para acessar vai ajax
            };

            Response.Cookies.Append(COOKIE_NAME, cartId, options);

            return cartId;
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int? id, int qtde = 1)
        {
            if (id == null) return NotFound();

            var produto = await _context.Produtos.FindAsync(id);

            if (produto != null)
            {
                string cartId = null;

                if (Request.Cookies.ContainsKey(COOKIE_NAME))
                {
                    cartId = Request.Cookies[COOKIE_NAME];
                    Pedido = await _context.Pedidos.Include("ItensPedido").Include("ItensPedido.Produto").FirstOrDefaultAsync(p => p.IdCarrinho == cartId);
                }
                else
                {
                    cartId = SetCartCookie();
                }

                if (Pedido == null)
                {
                    Pedido = new Pedido
                    {
                        IdCarrinho = cartId,
                        DataeHora = DateTime.UtcNow,
                        Situacao = Pedido.SituacaoPedido.Carrinho,
                        ItensDoPedido = new List<itemDoPedido>()
                    };

                    AppUser appUser = _signInManager.IsSignedIn(User) ?
                        await _userManager.GetUserAsync(User) : null;

                    if (appUser != null)
                    {
                        Clientes cliente = await _context.Clientes.FirstOrDefaultAsync<Clientes>(
                            c => c.Email.ToLower().Equals(appUser.Email.ToLower()));

                        if (cliente != null) Pedido.IdCliente = cliente.Id;
                    }

                    _context.Pedidos.Add(Pedido);
                }

                var itemPedido = Pedido.ItensDoPedido.FirstOrDefault(ip => ip.IdProduto == id);
                
                if (itemPedido == null){
                    Pedido.ItensDoPedido.Add(new itemDoPedido{
                            IdProduto = id.Value,
                            Quantidade = qtde,
                            ValorItem = produto.preco
                        }
                    );
                }else{
                    itemPedido.Quantidade += qtde;
                }

                if (_context.SaveChanges() <= 0){
                    ModelState.AddModelError("", "Ocorreu um erro ao adicionar o item ao carrinho.");
                }
            }

            TotalPedido = Pedido.ItensDoPedido.Sum(x => x.Quantidade * x.ValorItem);

            return Page();
        }
    }
}