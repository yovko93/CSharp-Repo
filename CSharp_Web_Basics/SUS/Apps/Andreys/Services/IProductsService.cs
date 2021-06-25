using Andreys.Data.Models;
using Andreys.ViewModels.Products;
using System.Collections.Generic;

namespace Andreys.Services
{
    public interface IProductsService
    {
        IEnumerable<ProductViewModel> GetAll();

        int Add(AddProductFormModel model);

        ProductViewModel GetById(int id);

        void Delete(int productId);
    }
}
