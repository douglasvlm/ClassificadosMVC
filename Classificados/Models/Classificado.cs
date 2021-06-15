using System.ComponentModel.DataAnnotations;

namespace Classificados.Models
{
    public class Classificado
    {

        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Titulo { get; set; }

        [Display(Name ="Descrição")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Descricao { get; set; }

        [Range(1, 1000000, ErrorMessage = "O valor deve ser de no mínimo 1 real e no máximo 1000000")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public double Valor { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}