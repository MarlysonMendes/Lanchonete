using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lanchonete.Models
{

    public class Lunch
    {
        [Key]
        public int LouchId { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no minimo {1} e tamanho máximo é {2}")]
        public string LouchName { get; set; }
        [Display(Name = "Descrição curta do lanch")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [StringLength(200, MinimumLength = 30, ErrorMessage = "O {0} deve ter no minimo {1} e tamanho máximo é {2}")]
        public string ShortDescription { get; set; }
        [Display(Name = "Descrição longa do lanche")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "O {0} deve ter no minimo {1} e tamanho máximo é {2}")]
        public string DetailedDescription { get; set; }
        [Display(Name ="Preço")]
        [Required(ErrorMessage ="Informe o preço do lanche")]
        [Column(TypeName ="decimal(10,2)")]
        public decimal Price { get; set; }
        [Display(Name = "Caminho da Imagem")]
        public string ImageUrl { get; set; }
        [Display(Name = "Caminho da Imagem em miniatura")]
        public string ImageThumbnailUrl { get; set; }
        [Display(Name = "Preferido?")]
        public bool IsFavoriteLouch { get; set; }
        [Display(Name = "Em estoque?")]
        public bool inStock { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
