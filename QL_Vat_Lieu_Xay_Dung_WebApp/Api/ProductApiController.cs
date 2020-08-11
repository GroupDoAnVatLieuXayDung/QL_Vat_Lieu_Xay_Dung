using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Api
{
    public class ProductApiController : ApiController
    {
        private readonly IProductService _productService;

        public ProductApiController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Lấy Danh Sách Product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_productService.GetAll());
        }

        /// <summary>
        /// Lấy Chi Tiết Product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return new OkObjectResult(_productService.GetById(id));
        }

        /// <summary>
        /// Gets the search.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="keyword">The keyword.</param>
        /// <returns></returns>
        [HttpGet("search-{keyword}")]
        public IActionResult GetSearch(string keyword)
        {
            var model = _productService.GetAllSearch(keyword);
            return new OkObjectResult(model);
        }

        /// <summary>
        /// Gets the product images.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        [HttpGet("images-{productId}")]
        public IActionResult GetProductImages(int productId)
        {
            return new OkObjectResult(_productService.GetImages(productId));
        }

        //[HttpGet("so-luong-san-pham-{id}")]
        //[Route("ProductQuantities")]
        //public IActionResult GetQuantities(int productId)
        //{
        //    return new OkObjectResult(_productService.GetQuantities(productId));
        //}
    }
}