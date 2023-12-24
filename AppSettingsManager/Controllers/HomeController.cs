using AppSettingsManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppSettingsManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;
        private readonly AuthSettings _authSettings;

        public HomeController(IConfiguration configuration,
                              ILogger<HomeController> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _authSettings = new AuthSettings();
            _configuration.GetSection("Auth").Bind(_authSettings);

        }

        public IActionResult Index()
        {
            ViewBag.SendGridKey = _configuration.GetValue<string>("SendGridKey");
            ViewBag.SectretKey = _configuration.GetValue<string>("Auth:SectretKey");
            //ViewBag.PublicKey = _configuration.GetValue<string>("Auth:PublicKey");

            ViewBag.PublicKey = _configuration.GetSection("Auth").GetValue<string>("PublicKey");
            ViewBag.PhoneNumber = _authSettings.PhoneNumber;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
