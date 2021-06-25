using Andreys.Services;
using Andreys.ViewModels.Products;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddProductFormModel product)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(product.Name) || product.Name.Length < 4 || product.Name.Length > 20)
            {
                return this.Error("Product name should be between 4 and 20 characters.");
            }

            if (product.Description.Length > 10)
            {
                return this.Error("Description should be less than 11 characters.");
            }

            if (!product.ImageUrl.StartsWith("http"))
            {
                return this.Error("Please enter a valid image URL");
            }

            var productId = this.productsService.Add(product);
            return this.Redirect($"/Products/Details?id={productId}");
        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var product = this.productsService.GetById(id);

            return this.View(product);
        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.productsService.Delete(id);
            return this.Redirect("/");
        }

    }
}
