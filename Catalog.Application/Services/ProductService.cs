using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Application.Interface;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;

namespace Catalog.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        private readonly IMapper _mapper;
        
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task Add(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.CreateAsync(productEntity);
        }

        public async Task Update(ProductDTO productDto)
        {

            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(productEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = _productRepository.GetByIdAsync(id).Result;
            await _productRepository.RemoveAsync(productEntity);
        }
    }


}