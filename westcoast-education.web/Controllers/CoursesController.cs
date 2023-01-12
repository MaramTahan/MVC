using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Models;

namespace westcoast_education.web.Controllers
{
    [Route("Courses")]
    public class CoursesController : Controller
    {
////url: https://localhost:5089/Courses/index
        private readonly westcoasteducationContext _context;
  public CoursesController(westcoasteducationContext context)
  {
   this._context = context;
  }
  public async Task<IActionResult> Index()
        {
            var courses = await _context.coursesData.ToListAsync();
            return View("Index", courses);
        }

    }
}