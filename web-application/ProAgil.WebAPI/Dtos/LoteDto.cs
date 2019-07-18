using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.Dtos
{
    public class LoteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ser entre 3 e 100 caracteres.")]
        public string Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }
          [Required(ErrorMessage = "O campo {0} é obrigatório.")]
         [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string DataInicio { get; set; }
         [Required(ErrorMessage = "O campo {0} é obrigatório.")]
         [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string DataFim { get; set; }

        [Range(2, 120000)]
        public int Quantidade { get; set; }
    }
}