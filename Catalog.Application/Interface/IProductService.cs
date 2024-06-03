using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Application.DTOs;

namespace Catalog.Application.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(int? id);
        Task Add(ProductDTO ProductDTO);
        Task Update(ProductDTO ProductDTO);
        Task Remove(int? id);
    }
}