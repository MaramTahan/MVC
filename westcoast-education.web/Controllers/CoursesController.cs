using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;

namespace westcoast_education.web.Controllers
{
    
    public class CoursesController : Controller
    {
////url: https://localhost:5089/Courses/index
  private readonly IUnitOfWork _unitOfWork;
  public CoursesController(IUnitOfWork unitOfWork)
  {
   _unitOfWork = unitOfWork;
  }
  public async Task<IActionResult> Index()
        {
            var courses = await _unitOfWork.CourseRepository.ListAllAsync();
            return View("Index", courses);
        }

    }
}