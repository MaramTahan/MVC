using Microsoft.AspNetCore.Mvc;

namespace westcoast_education.web.Controllers
{
    public class AdminController : Controller
    {


        public IActionResult Index()
        {
            return View("Index");
        }

        
    }
}