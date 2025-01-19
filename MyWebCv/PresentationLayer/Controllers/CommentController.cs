using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CommentWall()
        {
            var data = BusinessLayer.Comment.FetchComments();
            return View("/views/Comment/CommentWall.cshtml",data); 
        }


        [HttpGet]
        public IActionResult NewComment()
        {
            return View("/views/Comment/CommentForm.cshtml");
        }


        [HttpPost]
        public IActionResult NewComment(DataTransferObject.Request.Comments data)
        {
            BusinessLayer.Comment.AddComments(data);  
            return RedirectToAction("Index", "Home");
        }


    }
}
