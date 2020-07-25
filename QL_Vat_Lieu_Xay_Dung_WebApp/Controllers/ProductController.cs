﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_WebApp.Models;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IBillService _billService;
        public ProductController(IProductService productService,
            IProductCategoryService productCategoryService, IBillService billService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _billService = billService;
        }
        [Route("products.html")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("search.html")]
        public IActionResult Search(int? categoryId, string keyword, int? pageSize, string sortBy, int page = 1)
        {
            var productCatalog = new SearchViewModel();
            ViewData["BodyClass"] = "shop_grid_page";
            pageSize ??= 3;
            productCatalog.PageSize = pageSize;
            productCatalog.Sizes = _billService.GetSizes();
            productCatalog.SortType = sortBy;
            productCatalog.Data = _productService.GetAllPaging(categoryId, keyword, page, pageSize.Value, sortBy);
            if (categoryId.HasValue)
            {
                if (!string.IsNullOrEmpty(keyword))
                {
                    productCatalog.Keyword = "DM_" + _productCategoryService.GetById(categoryId.Value).Name + " - " + keyword;
                }
                else
                {
                    productCatalog.Keyword = "DM_" + _productCategoryService.GetById(categoryId.Value).Name;
                }
            }
            else
            {
                productCatalog.Keyword = keyword;
            }
            return View(productCatalog);
        }
        [Route("{alias}-c.{id}.html")]
        public IActionResult ProductCatalog(int id, int? pageSize, int? first_value, int? end_value, int? sizeid, string sortBy, int page = 1)
        {
            var productCatalog = new ProductCatalogViewModel();
            ViewData["BodyClass"] = "shop_grid_page";
            pageSize ??= 3;
            productCatalog.PageSize = pageSize;
            productCatalog.SortType = sortBy;
            productCatalog.Sizes = _billService.GetSizes();
            productCatalog.Data = _productService.GetAllPaging(id, string.Empty, page, pageSize.Value, sortBy);
            productCatalog.ProductCategory = _productCategoryService.GetById(id);
           // productCatalog
            return View(productCatalog);
        }

        [Route("{alias}-p.{id}.html")]
        public IActionResult ProductDetail(int id)
        {
            ViewData["BodyClass"] = "product-page";
            var model = new ProductDetailViewModel
            {
                Product = _productService.GetById(id),
                RelatedProducts = _productService.GetRelatedProducts(id, 9),
                UpsellProducts = _productService.GetUpsellProducts(6),
                ProductImages = _productService.GetImages(id),
                Tags = _productService.GetProductTags(id),
                Sizes = _productService.GetQuantities(id).Select(x => new SelectListItem()
                {
                    Text = x.Size.Name,
                    Value = x.SizeId.ToString()
                }).ToList()
            };
                model.ProductCategory = _productCategoryService.GetById(model.Product.CategoryId);
            return View(model);
        }
    }
}
