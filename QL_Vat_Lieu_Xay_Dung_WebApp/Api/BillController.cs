using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Enum;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Utilities.Extensions;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Api
{
    [Authorize]
    public class BillController : ApiController
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        // GET: api/<BillController>
        [HttpGet]
        [Route("hoa-don")]
        public IActionResult Get()
        {
            return new OkObjectResult(_billService.GetAllBill());
        }

        // GET api/<BillController>/5
        [HttpGet]
        [Route("chi-tiet-hoa-don-{billId}")]
        public IActionResult GetBillDetail(int billId)
        {
            return new OkObjectResult(_billService.GetDetail(billId));
        }

        [HttpPut]
        [Route("cap-nhat-hoa-don-{billViewModel}")]
        public IActionResult PutBill(BillViewModel billViewModel)
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
            else
            {
                _billService.Update(billViewModel);
            }
            _billService.Save();
            return new OkObjectResult(billViewModel);
        }

        [HttpGet]
        [Route("phuong-thuc-thanh-toan")]
        public IActionResult GetPaymentMethod()
        {
            var enums = ((PaymentMethod[])Enum.GetValues(typeof(PaymentMethod)))
                .Select(p => new EnumModel()
                {
                    Value = (int)p,
                    Name = p.GetDescription()
                }).ToList();
            return new OkObjectResult(enums);
        }

        [HttpGet]
        [Route("trang-thai-hoa-don")]
        public IActionResult GetBillStatus()
        {
            var enums = ((BillStatus[])Enum.GetValues(typeof(BillStatus)))
                .Select(b => new EnumModel()
                {
                    Value = (int)b,
                    Name = b.GetDescription()
                }).ToList();
            return new OkObjectResult(enums);
        }

        [HttpGet]
        [Route("kich-thuoc")]
        public IActionResult GetSizes()
        {
            return new OkObjectResult(_billService.GetSizes());
        }
    }
}