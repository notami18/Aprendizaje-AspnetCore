using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld.Controllers.Web
{
    public class appController : Controller
    {
        public IActionResult Index() {  
            return View();
        }

        public IActionResult Contact()
        {
            //throw new InvalidOperationException("LAs cosas malas solo le pasan a los desarrolladores buenos");
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
