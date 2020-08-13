using Microsoft.AspNetCore.Mvc;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using System;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Api
{
    public class AnnouncementApiController : ApiController
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementApiController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpGet("{userId}")]
        public IActionResult Get(Guid userId)
        {
            var model = _announcementService.GetAllUnRead(userId);
            return new OkObjectResult(model);
        }

        [HttpPost("checkRead-{userId}-{id}")]
        public IActionResult CheckMarkAsRead(Guid userId, string id)
        {
            var result = _announcementService.MarkAsRead(userId, id);
            _announcementService.Save();
            return new OkObjectResult(result);
        }
    }
}