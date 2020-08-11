using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Api
{
    public class BrandApiController : ApiController
    {
        private readonly IBrandService _brandService;

        public BrandApiController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_brandService.GetAll());
        }
    }
}