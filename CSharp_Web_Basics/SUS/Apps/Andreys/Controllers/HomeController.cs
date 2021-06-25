namespace Andreys.App.Controllers
{
    using Andreys.Services;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }

        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                var products = productsService.GetAll();

                return this.View(products, "Home");
            }

            return this.View();
        }

    }
}
