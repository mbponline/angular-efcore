using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProAgil.Domain.Entities.Identity
{
    // IdentityRole<int> determina que a chave autoincrementada seja um inteiro
    // o padrão é um hash gigante
    public class Role : IdentityRole<int>

    {

        public List<UserRole> UserRoles { get; set; }

    }
}