using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_WebApp.Models;
using QL_Vat_Lieu_Xay_Dung_WebApp.Services;
using System;
using System.Threading.Tasks;

namespace QL_Vat_Lieu_Xay_Dung_WebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        private readonly IFeedbackService _feedbackService;

        private readonly IEmailSender _emailSender;

        private readonly IConfiguration _configuration;

        private readonly IViewRenderService _viewRenderService;

        public ContactController(IContactService contactSerivce,
            IViewRenderService viewRenderService,
            IConfiguration configuration,
            IEmailSender emailSender, IFeedbackService feedbackService)
        {
            _contactService = contactSerivce;
            _feedbackService = feedbackService;
            _emailSender = emailSender;
            _configuration = configuration;
            _viewRenderService = viewRenderService;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("contact.html")]
        [HttpGet]
        public IActionResult Index()
        {
            var contact = _contactService.GetById("Default");
            var model = new PageContactViewModel() { Contact = contact };
            return View(model);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("contact.html")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Index(PageContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Feedback.DateCreated = DateTime.Now;
                _feedbackService.Add(model.Feedback);
                _feedbackService.SaveChanges();
                var content = await _viewRenderService.RenderToStringAsync("Contact/ContactMail", model.Feedback);
                await _emailSender.SendEmailAsync(_configuration["MailSettings:AdminMail"], "Bạn Có 1 Phản Hồi Mới", content);
                ViewData["Success"] = true;
            }

            model.Contact = _contactService.GetById("default");

            return View("Index", model);
        }
    }
}