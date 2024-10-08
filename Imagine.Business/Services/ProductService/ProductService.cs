﻿using AutoMapper;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Entities.Dtos;
using Imagine.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.Business.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productrepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productrepository, IMapper mapper)
        {
            _productrepository = productrepository;
            _mapper = mapper;
        }

        public void AddProduct(Product product)
        {
            _productrepository.Add(product);
        }

        public IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> filter) => _productrepository.GetMany(filter);
        public Product GetProductWithCategory(int id)
        {
            return _productrepository.GetProductWithCategory(p => p.Id == id);
        }

        public IEnumerable<Product> GetProductsWithCategory(Expression<Func<Product, bool>> filter)
        {
            return _productrepository.GetProductsWithCategory(filter);
        }

        public IEnumerable<Product> GetAllProducts() => _productrepository.GetAll();
        public IEnumerable<Product> GetAllProductsWithCategory() => _productrepository.GetAllProductsWithCategory();
        public Product GetProduct(Expression<Func<Product, bool>> filter) => _productrepository.Get(filter);

        public void RemoveProduct(Product product)
        {
            _productrepository.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            _productrepository.Update(product);
        }

        public void RemoveProductById(int id)
        {
            _productrepository.RemoveById(id);
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id)
        {
            var product = _productrepository.Get(p => p.Id == id);
            return _mapper.Map<ProductDtoForUpdate>(product);
        }
    }
}
