using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProAgil.Domain.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }

        public List<UserRole> UserRoles { get; set; }

    }
}