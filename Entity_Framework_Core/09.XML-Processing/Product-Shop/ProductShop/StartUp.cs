using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XmlHelper;
using System;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var userXml = File.ReadAllText("./Datasets/users.xml");
            //var productXml = File.ReadAllText("./Datasets/products.xml");
            //var categoryXml = File.ReadAllText("./Datasets/categories.xml");
            //var categoryProductXml = File.ReadAllText("./Datasets/categories-products.xml");

            //ImportUsers(context, userXml);
            //ImportProducts(context, productXml);
            //ImportCategories(context, categoryXml);
            //ImportCategoryProducts(context, categoryProductXml);

            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = new ExportUsersWithCountAndProductsDto
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = context.Users.Where(x => x.ProductsSold.Count() > 0)
                               .Select(u => new ExportUserWithProductsDto
                               {
                                   FirstName = u.FirstName,
                                   LastName = u.LastName,
                                   Age = u.Age,
                                   SoldProducts = new ExportSoldProductDto
                                   {
                                       Count = u.ProductsSold.Count,
                                       SoldProducts = u.ProductsSold.Select(s =>
                                       new ExportProductMiniDto
                                       {
                                           Name = s.Name,
                                           Price = s.Price
                                       })
                                       .OrderByDescending(y => y.Price)
                                       .ToArray()
                                   }
                               })
                               .OrderByDescending(v => v.SoldProducts.Count)
                               .Take(10)
                               .ToList()
            };

            var xml = XmlConverter.Serialize(users, "Users");

            return xml;

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new CategoryOutputModel
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Select(p => p.Product.Price).Average(),
                    TotalRevenue = x.CategoryProducts.Select(r => r.Product.Price).Sum()
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            var xml = XmlConverter.Serialize(categories, "Categories");

            return xml;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any())
                .Select(u => new UserOutputModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new ProductOutputModel
                    {
                        Name = p.Name,
                        Price = p.Price,
                    })
                    .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            var xml = XmlConverter.Serialize(users, "Users");

            return xml;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 & x.Price <= 1000)
                .Select(x => new ProductOutputModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerName = x.Buyer.FirstName + " " + x.Buyer.LastName,
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToList();

            var xml = XmlConverter.Serialize(products, "Products");

            return xml;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string root = "CategoryProducts";

            var categoryProductsDto = XmlConverter.Deserializer<CategoryProductInputModel>(inputXml, root);

            var categoryIds = context.Categories.Select(c => c.Id).ToList();
            var productIds = context.Products.Select(p => p.Id).ToList();

            var categoryProducts = categoryProductsDto
                .Where(x => categoryIds.Contains(x.CategoryId) &&
                    productIds.Contains(x.ProductId))
                .Select(x => new CategoryProduct
                {
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId,
                })
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {context.CategoryProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string root = "Categories";

            var categoriesDto = XmlConverter.Deserializer<CategoryInputModel>(inputXml, root);

            var categories = categoriesDto
                .Where(x => x.Name != null)
                .Select(x => new Category
                {
                    Name = x.Name,
                })
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {context.Categories.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string root = "Products";

            var productsDto = XmlConverter.Deserializer<ProductInputModel>(inputXml, root);

            var products = productsDto
                .Select(x => new Product
                {
                    Name = x.Name,
                    Price = x.Price,
                    SellerId = x.SellerId,
                    BuyerId = x.BuyerId,
                })
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var root = "Users";

            var usersDto = XmlConverter.Deserializer<UserInputModel>(inputXml, root);

            var users = usersDto
                .Select(x => new User
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                })
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}