using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Classificados.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Descricao { get; set; }

        public List<Classificado> Classificados { get; set; }
    }
}
