using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Api
{
    public class SlideController : ApiController
    {
        private readonly ISlideService _slideService;
        public SlideController(ISlideService slideService)
        {
            _slideService = slideService;
        }
        [HttpGet("slides-{groupAlias}")]
        public IActionResult GetSlides(string groupAlias)
        {
            return new OkObjectResult(_slideService.GetSlides(groupAlias));
        }
    }
}
