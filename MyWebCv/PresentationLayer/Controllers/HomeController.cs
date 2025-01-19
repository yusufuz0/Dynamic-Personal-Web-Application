using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Diagnostics;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            var data = BusinessLayer.Home.Datas();

            return View("/views/Home/About.cshtml",data);
        }

        public IActionResult Projects()
        {


            return View("/views/Home/Projects.cshtml", BusinessLayer.Home.projects());
        }

        public IActionResult Skills()
        {


            return View("/views/Home/Skills.cshtml", BusinessLayer.Home.skills());
        }


        public IActionResult Contact()
        {


            return View("/views/Home/Contact.cshtml", BusinessLayer.Home.Datas());
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}