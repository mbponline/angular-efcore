using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ser entre 3 e 100 caracteres.")]
        public string Local { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string DataEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Tema { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(2, 120000, ErrorMessage = "O campo {0} é entre 2 e 120000")]
        public int QtdPessoas { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string ImagemURL { get; set; }

        [Phone]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Telefone { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Email { get; set; }
        public List<LoteDto> Lotes { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Palestrantes { get; set; }
    }
}