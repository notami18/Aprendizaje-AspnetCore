using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class appController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;

        public appController(IMailService mailService, IConfigurationRoot  config) {
            _mailService = mailService;
            _config = config;
        }

        public IActionResult Index() {  
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("aol.com"))
                ModelState.AddModelError("Email", "No apoyamos la dirección de AOL");

            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From: Hola TheWorld", model.Message);

                ModelState.Clear();
                ViewBag.UserMessage = "Mensaje enviado corectamente";
            }
            
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
