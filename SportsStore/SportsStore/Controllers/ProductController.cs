using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public int PageSize = 4;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
       
        public ViewResult List(int productPage = 1) => View(_productRepository.Products
            .OrderBy(x => x.ProductId)
            .Skip((productPage - 1)*PageSize)
            .Take(PageSize));
    }
}
