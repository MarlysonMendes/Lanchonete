using System.ComponentModel.DataAnnotations;

namespace Lanchonete.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Display(Name ="Nome")]
        [Required(ErrorMessage ="Informe o nome da categoria")]
        [StringLength(100, ErrorMessage ="O tamanho máximo é 100")]
        public string CategoryName { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [StringLength(300, ErrorMessage = "O tamanho máximo é 300")]
        public string Description { get; set; }

        public List<Lunch> Lunches { get; set; }
    }
}
