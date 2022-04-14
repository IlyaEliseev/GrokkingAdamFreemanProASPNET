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
       
        public ViewResult List(string category, int productPage = 1) => View(new ProductsListViewModel 
        {
            Products = _productRepository.Products
            .Where(x => category == null || x.Category == category)
            .OrderBy(x => x.ProductId)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = (category == null) ? 
                _productRepository.Products.Count() :
                _productRepository.Products.Where(x => x.Category == category).Count()
            },
            CurrentCategory = category
        });
    }
}
