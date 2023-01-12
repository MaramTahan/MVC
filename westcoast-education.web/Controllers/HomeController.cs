using Microsoft.AspNetCore.Mvc;


namespace westcoast_education.web.Controllers;

public class HomeController : Controller
{
    
////url: https://localhost:5089/home/index
    public IActionResult Index()
    {
        ViewBag.welcome = "Welcome to WestCoast Education";
        ViewBag.message = "Dear student, with us you can prepare yourself before admission to the university, take a look at the list of courses currently available, and if you have any questions, you can contact us.";
        return View("Index");
    }

    
}
