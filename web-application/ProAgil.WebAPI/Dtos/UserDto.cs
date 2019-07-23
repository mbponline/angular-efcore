using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.Dtos
{
    public class UserDto
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ser entre 3 e 100 caracteres.")]
        public string UserName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ser entre 3 e 100 caracteres.")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ser entre 3 e 100 caracteres.")]
        public string FullName { get; set; }
    }
}
