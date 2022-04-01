using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

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
       
        public ViewResult List(int productPage = 1) => View(new ProductsListViewModel 
        {
            Products = _productRepository.Products
            .OrderBy(x => x.ProductId)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = _productRepository.Products.Count()
            }
        });
    }
}
