using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QL_Vat_Lieu_Xay_Dung_WebApi.Controllers
{

    public class ProductController : APIController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/values
        [HttpGet]
        [Route("san-pham")]
        public IActionResult GetProduct()
        {
            return new OkObjectResult(_productService.GetAll());
        }
        [HttpGet("san-pham-{productId}")]
        public IActionResult GetById(int productId)
        {
            return new OkObjectResult(_productService.GetById(productId));
        }
        [HttpGet]
        [Route("tim-kiem-san-pham-{keyword}-c.{category}")]
        public IActionResult GetSearch(int? categoryId, string keyword)
        {
            var model = _productService.GetAllSearch(categoryId, keyword);
            return new OkObjectResult(model);
        }

        [HttpGet("anh-san-pham-{productId}")]
        [Route("ProductImages")]
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
