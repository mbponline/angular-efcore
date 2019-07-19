using Microsoft.AspNetCore.Identity;

namespace ProAgil.Domain.identity
{
    
    // IdentityUserRole<int> determina que a chave autoincrementada seja um inteiro
    // o padrão é um hash gigante
    public class UserRole : IdentityUserRole<int>
    {

        public User User { get; set; }

        public Role Role { get; set; }
    }
}