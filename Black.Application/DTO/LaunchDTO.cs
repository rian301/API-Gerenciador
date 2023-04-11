using System;
using System.ComponentModel.DataAnnotations;

namespace Black.Application.DTO
{
    public class LaunchDTO
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Description { get; set; }
        [Display(Name = "Data")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Date { get; set; }
        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QuantityStudents { get; set; }
        [Display(Name = "Faturamento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Invoice { get; set; }
        [Display(Name = "Investimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Investment { get; set; }
        public string TopCriative { get; set; }
        public string Note { get; set; }
    }
}
