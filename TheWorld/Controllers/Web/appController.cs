﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private IWorldRepository _repository;
        private ILogger<AppController> _logger;

        //private WorldContext _context;

        public AppController(IMailService mailService, IConfigurationRoot  config, IWorldRepository repository, ILogger<AppController> logger) {
            _mailService = mailService;
            _config = config;
            _repository = repository;
            _logger = logger;
        }

        public IActionResult Index() {

            //try
            //{
            //    var data = _repository.GetAllTrips(); //_context.Trips.ToList();

            //    return View(data);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"Error al obtener viajes en la página de Inicio: {ex.Message}");
            //    return Redirect("/error");
            //}

            return View();
        }

        [Authorize]
        public IActionResult Trips()
        {
            try
            {
                var data = _repository.GetAllTrips();

                return View(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener viajes en la página de Inicio: {ex.Message}");
                return Redirect("/error");
            }
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
