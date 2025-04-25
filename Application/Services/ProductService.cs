using Application.Repository;
using Application.ViewModels;
using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;


        public ProductService(AplicationContext dbContext)
        {
            _productRepository = new (dbContext);
        }
        public async Task Add(SaveProductViewModel  vm)
        {
            Product product = new();
            product.Name = vm.Name;
            product.Price = vm.Price;
            product.Descripcion = vm.Descripcion;
            product.ImagePath = vm.ImagePath;
            product.CategoryId = vm.CategoryId;

            await _productRepository.AddAsync(product);
        }

      
      

        public async Task Update(SaveProductViewModel vm)
        {
            Product product = new();
            product.Id = vm.Id;
            product.Name = vm.Name;
            product.Price = vm.Price;
            product.Descripcion = vm.Descripcion;
            product.ImagePath = vm.ImagePath;
            product.CategoryId = vm.CategoryId;




            await _productRepository.UpdateAsync(product);
        }

        public async Task Delete(int Id)
        {
            var product = await _productRepository.GetByIdAsync(Id);
            await _productRepository.DeleteAsync(product);
        }

        public async Task<SaveProductViewModel> GetByIdSaveViewModel(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            SaveProductViewModel vm = new();
            vm.Id = product.Id;
            vm.Name = product.Name;
            vm.Descripcion = product.Descripcion;
            vm.Category = product.Category;
            vm.Price = product.Price;
            vm.ImagePath = product.ImagePath;


            return vm;
            
        }


        public async Task<List<ProductViewModel>> GetAllViewModel(int? categoryId = null)

        {
            var productList = await _productRepository.GetAllAsync();
            return productList.Select(product => new ProductViewModel
            {
                Name = product.Name,
                Descripcion = product.Descripcion,
                Id = product.Id,
                Price = product.Price,
                ImagePath = product.ImagePath,
                  CategoryId = product.CategoryId

            }

            ).ToList();
        }

    }
}
