using Ecommerce_CyberKnight.Data;
using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Ecommerce_CyberKnight.Pages
{

    public class DadosLogin {
        [Required(ErrorMessage = "O campo \"{0}\" deve ser preenchido.")]
        [EmailAddress(ErrorMessage = "Você deve digitar no formato de um email.")]
        [Display(Name = "E-mails")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo \"{0}\" deve ser preenchido.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }


        [Display(Name = "Lembrar de mim")]
        public bool Lembrar { get; set; }

    }

    public class LogarModel : PageModel
    {
        [BindProperty]

        public DadosLogin Dados { get; set; }

        public string ReturnURL { get; set; }

        [TempData]

        public string MensagemError { get; set; }

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;
        private RoleManager<IdentityRole> _roleManager;

        public LogarModel(
                SignInManager<AppUser> singInManager,
                UserManager<AppUser> userManager,
                RoleManager<IdentityRole> roleManager,
                ApplicationDbContext context) {
            _signInManager = singInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }



        public async Task OnGetAsync(string returnURL = null) {

            string emailDefault = "root@senac.br";
            //verifica se já existe um usuário com o e-mail informado
            var usuarioExistente = await _userManager.FindByEmailAsync(emailDefault);

            if (usuarioExistente == null) {

                //cria um novo objeto Cliente
                var cliente = new Clientes();
                cliente.Telefone = "99999999999";
                cliente.Cep = "00000000";
                cliente.Cpf = "00000000000";
                cliente.Email = emailDefault;
                //cliente.Situacao = Clientes.SituacaoCliente.Aprovado;
                cliente.Nome = "Root";

                cliente.Endereco = null;

                var senhaDefault = "qwe123";

                Debug.WriteLine(ModelState.IsValid);

                //verifica se o perfil de usuário "cliente" existe
                if (!await _roleManager.RoleExistsAsync("cliente")) {
                    await _roleManager.CreateAsync(new IdentityRole("cliente"));
                }

                //verifica se o perfil de usuário "admin" existe
                if (!await _roleManager.RoleExistsAsync("admin")) {
                    await _roleManager.CreateAsync(new IdentityRole("admin"));
                }

                //cria o objeto usuário Identity e adiciona ao perfil "cliente"
                var usuario = new AppUser() {
                    UserName = cliente.Email,
                    Email = cliente.Email,
                    PhoneNumber = cliente.Telefone,
                    Nome = cliente.Nome
                };

                //cria usuário no banco de dados
                var result = await _userManager.CreateAsync(usuario, senhaDefault);

                //se a criação do usuário Identity foi bem sucedida
                if (result.Succeeded) {

                    //associa o usuário ao perfil "cliente"
                    await _userManager.AddToRoleAsync(usuario, "cliente");
                    await _userManager.AddToRoleAsync(usuario, "admin");

                    var reult = await TryUpdateModelAsync(cliente, cliente.GetType(), nameof(cliente));

                    //adiciona o novo objeto cliente ao contexto de banco de dados atual e salva no banco de dados
                    _context.Clientes.Add(cliente);
                    int afetados = await _context.SaveChangesAsync();
                }

            }

            returnURL = ReturnURL ?? Url.Content("~/");

            await HttpContext.SignOutAsync(
                IdentityConstants.ExternalScheme
                );

            ReturnURL = returnURL;
        }

        public async Task<IActionResult> OnPostAsync(string returnURL = null) {
            returnURL = returnURL ?? Url.Content("~/");

            if (ModelState.IsValid) {
                var result = await _signInManager.PasswordSignInAsync(Dados.Email, Dados.Senha, Dados.Lembrar, lockoutOnFailure: false);
                if (result.Succeeded) {
                    return LocalRedirect(returnURL);
                } else {
                    ModelState.AddModelError(string.Empty, "Tentativa de login inválida.");
                    return Page();
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostLogoutAsync(string returnURL = null) {
            await _signInManager.SignOutAsync();

            if (returnURL != null) {
                return LocalRedirect(returnURL);
            } else {
                return RedirectToPage();
            }

        }

    }
}

