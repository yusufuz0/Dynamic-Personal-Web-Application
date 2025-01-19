using DataTransferObject.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ManagementPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult DatasForm()
        {
            var data = BusinessLayer.ManagementPanel.DatasReturn();

            return View("/views/ManagementPanel.cshtml", data);
        }


        public IActionResult DatasUpdate(Datas data)
        {
            BusinessLayer.ManagementPanel.DatasUpdate(data);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult AddProject()
        {


            return View("/views/ManagementPanel/AddProject.cshtml");
        }


        [HttpPost]
        public IActionResult AddProject(DataTransferObject.Request.Projects data)
        {
            BusinessLayer.ManagementPanel.AddProject(data);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult AddSkill()
        {


            return View("/views/ManagementPanel/AddSkill.cshtml");
        }


        [HttpPost]
        public IActionResult AddSkill(DataTransferObject.Request.Skills data)
        {
            BusinessLayer.ManagementPanel.AddSkill(data);

            return RedirectToAction("Index", "Home");
        }




    }
}
