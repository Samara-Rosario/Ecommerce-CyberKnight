using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Ecommerce_CyberKnight.Utils {
    public class AuthVerify {
        public static string LoginUrl = "/Logar";

        private readonly UserManager<AppUser> _userManager;

        public AuthVerify(UserManager<AppUser> userManager) {
            _userManager = userManager;
        }

        public async Task<bool> Test(ClaimsPrincipal? currentUser, string Role) {
            //Verificação de autenticação
            if(!currentUser.Identity.IsAuthenticated)return false;

            //Verirficação de autorização
            return await _userManager.IsInRoleAsync(
                            await _userManager.GetUserAsync(currentUser),
                            Role
                    );
        }
    }
}
