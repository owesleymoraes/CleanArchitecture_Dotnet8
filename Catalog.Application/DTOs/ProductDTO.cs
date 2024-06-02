using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Application.DTOs
{
    public class ProductDTO
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Informe o preço")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [MaxLength(250)]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "O estoque é obrigatório")]
        [Range(1, 9999)]
        public int Stoke { get; set; }

        [Required(ErrorMessage = "Informe a data do cadastro")]
        public DateTime DateRegister { get; set; }
        public int CategoryId { get; set; }

    }
}