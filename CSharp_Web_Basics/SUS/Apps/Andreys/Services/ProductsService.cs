using Andreys.Data;
using Andreys.Data.Models;
using Andreys.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public int Add(AddProductFormModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Category = Enum.Parse<Category>(model.Category),
                Gender = Enum.Parse<Gender>(model.Gender),
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();

            return product.Id;
        }

        public void Delete(int productId)
        {
            var product = this.db.Products.Find(productId);

            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }

        public ProductViewModel GetById(int id)
        {
            var product = db.Products
              .Select(x => new ProductViewModel
              {
                  Category = x.Category.ToString(),
                  Description = x.Description,
                  Gender = x.Gender.ToString(),
                  Id = x.Id,
                  ImageUrl = x.ImageUrl,
                  Name = x.Name,
                  Price = x.Price
              })
              .FirstOrDefault(x => x.Id == id);

            return product;
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var products = this.db.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Category = p.Category.ToString(),
                    Gender = p.Gender.ToString(),
                    Description = p.Description,
                    Price = p.Price,
                })
                .ToList();

            return products;
        }
    }
}
