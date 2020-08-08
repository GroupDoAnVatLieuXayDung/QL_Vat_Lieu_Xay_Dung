using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using System.Threading.Tasks;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Controllers.Components
{
    public class BrandViewComponent : ViewComponent
    {
        private readonly IBrandService _brandService;

        public BrandViewComponent(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_brandService.GetAll());
        }
    }
}