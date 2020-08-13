using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Enum;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Utilities.Extensions;
using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Api
{
    [Authorize]
    public class BillApiController : ApiController
    {
        private readonly IBillService _billService;
        private readonly IWebHostEnvironment _webHostingEnvironment;

        public BillApiController(IBillService billService, IWebHostEnvironment webHostingEnvironment)
        {
            _billService = billService;
            _webHostingEnvironment = webHostingEnvironment;
        }

        // GET: api/<BillController>
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_billService.GetAllBill());
        }

        // GET api/<BillController>/5
        [HttpGet("{billId}")]
        public IActionResult GetBillDetail(int billId)
        {
            return new OkObjectResult(_billService.GetDetail(billId));
        }

        [HttpPost("create-{billViewModel}")]
        public IActionResult PostBill(BillViewModel billViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }

            if (billViewModel.Id == 0)
            {
                _billService.Create(billViewModel);
            }

            _billService.Save();
            return new OkObjectResult(billViewModel);
        }

        [HttpGet]
        [Route("PaymentMethod")]
        public IActionResult GetPaymentMethod()
        {
            var enums = ((PaymentMethod[]) Enum.GetValues(typeof(PaymentMethod)))
                .Select(p => new EnumModel()
                {
                    Value = (int) p,
                    Name = p.GetDescription()
                }).ToList();
            return new OkObjectResult(enums);
        }

        [HttpGet]
        [Route("BillStatus")]
        public IActionResult GetBillStatus()
        {
            var enums = ((BillStatus[]) Enum.GetValues(typeof(BillStatus)))
                .Select(b => new EnumModel()
                {
                    Value = (int) b,
                    Name = b.GetDescription()
                }).ToList();
            return new OkObjectResult(enums);
        }

        [HttpGet]
        [Route("Sizes")]
        public IActionResult GetSizes()
        {
            return new OkObjectResult(_billService.GetSizes());
        }
    }
}