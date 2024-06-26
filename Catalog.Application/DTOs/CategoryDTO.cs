using System.ComponentModel.DataAnnotations;


namespace Catalog.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe o nome da imagem")]
        [MinLength(5)]
        [MaxLength(250)]
        public string ImageUrl { get; set; }
    }
}