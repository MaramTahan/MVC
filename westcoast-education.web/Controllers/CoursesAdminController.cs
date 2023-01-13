using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;
using westcoast_education.web.ViewModels;

namespace westcoast_education.web.Controllers;

[Route("courses/admin")]
[Authorize]
    public class CoursesAdminController : Controller
    {
  private readonly IUnitOfWork _unitOfWork;
  public CoursesAdminController(IUnitOfWork unitOfWork)
  {
   _unitOfWork = unitOfWork;
   
  }

  public async Task<IActionResult> Index()
        {
            try{
                var courses = await _unitOfWork.CourseRepository.ListAllAsync();
            
            var model = courses.Select(v => new CourseListViewModel{
                Id = v.Id,
                courseNumber = v.courseNumber,
                name = v.name,
                startDate = v.startDate,
                endDate = v.endDate,
                teacher = v.teacher,
                placeStudy = v.placeStudy
            }).ToList();
            return View("Index", model);

            }
            catch (Exception ex){
                var error = new ErrorModel
            {
                ErrorTitle = "An error has occurred when we were to pick up all the courses",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
            };
        }
//--------------------------start create course----------------------
        [HttpGet("create")]
        public IActionResult Create(){
            var addCourse = new CoursePostViewModel();
            return View("Create", addCourse);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CoursePostViewModel addcourse)
        {
            try
            {
                  if (!ModelState.IsValid) return View("create", addcourse);
                var exists = await _unitOfWork.CourseRepository.FindBycourseNumberAsync(addcourse.courseNumber);
                if (exists is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "An error has occurred when saving the course!",
                    ErrorMessage = $"A course with a CourseId {addcourse.Id} already exists in the system"
                };

                return View("_Error", error);
            }
            var courseToAdd = new Courses{
                courseNumber = addcourse.courseNumber,
                name = addcourse.name,
                startDate = addcourse.startDate,
                endDate = addcourse.endDate,
                teacher = addcourse.teacher,
                placeStudy = addcourse.placeStudy
            };
            if(await _unitOfWork.CourseRepository.AddAsync(courseToAdd)){
                if (await _unitOfWork.Complete())
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            var saveError = new ErrorModel
                {
                    ErrorTitle = "An error has occurred when saving the course!",
                    ErrorMessage = $"A course with a CourseId {addcourse.Id} already exists in the system"
                };

                return View("_Error", saveError);
            
            }
            catch (Exception ex)
            {
                var error = new ErrorModel
            {
                ErrorTitle = "An error has occurred when we were trying to save the course",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
            }
            }
            //-------------------end create course------------------
            //------------------------------------------------------
            //-------------------start edit course------------------
            [HttpGet("edit/{Id}")]

            public async Task<IActionResult> Edit(int Id){
               try
               {
                var courseEdit = await _unitOfWork.CourseRepository.FindByIdAsync(Id);
                if (courseEdit is null){
                    var error = new ErrorModel
            {
                ErrorTitle = "An error occurred when we were about to pick up a course for editing",
                ErrorMessage = $"We can't find a course with this ID"
            };
             return View("_Error", error);
                }
                var model = new CourseUpdateViewModel{
                Id = courseEdit.Id,
                courseNumber = courseEdit.courseNumber,
                name = courseEdit.name,
                startDate = courseEdit.startDate,
                endDate = courseEdit.endDate,
                teacher = courseEdit.teacher,
                placeStudy = courseEdit.placeStudy
                };
                return View("edit", model);
               }
               catch (Exception ex)
               {
                var error = new ErrorModel
            {
                ErrorTitle = "An error occurred when we were about to pick up a course for editing",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
                
               }
            }

            [HttpPost("edit/{Id}")]
            public async Task<IActionResult> Edit(int Id, CourseUpdateViewModel courseEdit){
                try
                {
                    if (!ModelState.IsValid) return View("edit", courseEdit);

                    var courseToUpdate = await _unitOfWork.CourseRepository.FindByIdAsync(Id);

                    if (courseToUpdate is null) return RedirectToAction(nameof(Index));
                    courseToUpdate.courseNumber = courseEdit.courseNumber;
                    courseToUpdate.name = courseEdit.name;
                    courseToUpdate.startDate = courseEdit.startDate;
                    courseToUpdate.endDate = courseEdit.endDate;
                    courseToUpdate.teacher = courseEdit.teacher;
                    courseToUpdate.placeStudy = courseEdit.placeStudy;

                    if(await _unitOfWork.CourseRepository.UpdateAsync(courseToUpdate)){
                        if (await _unitOfWork.Complete())
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    var error = new ErrorModel
            {
                ErrorTitle = "An error has occurred when we were trying to save the course",
                ErrorMessage = $"An error occurred when we were to update the course with coursenumber{courseToUpdate.courseNumber}"
            };

            return View("_Error", error);
                    
                }
                catch (Exception ex)
                {
                    var error = new ErrorModel
                {
                    ErrorTitle = "An error has occurred when saving the course!",
                    ErrorMessage = ex.Message
                };

                return View("_Error", error);
                }
            }
            //-----------------------end edit course--------------
            //--------------------------------------------------------
            //-----------------------start delete course-----------
            [Route("delete/{Id}")]
            public async Task<IActionResult> Delete(int Id){
                try
                {
                    var courseToDelete = await _unitOfWork.CourseRepository.FindByIdAsync(Id);

                    if (courseToDelete is null) return RedirectToAction(nameof(Index));

                    if(await _unitOfWork.CourseRepository.DeleteAsync(courseToDelete)){
                        if (await _unitOfWork.Complete())
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                     var error = new ErrorModel
            {
                ErrorTitle = "An error has occurred when the course was to be deleted",
                ErrorMessage = $"An error occurred when the car with coursenumber {courseToDelete.courseNumber} would be removed"
            };

            return View("_Error", error);
                    
                }
                catch (Exception ex)
                {
                    var error = new ErrorModel
            {
                ErrorTitle = "An error has occurred when the course was to be deleted",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
                    
                }
            }
            //-------------------------end delete course----------
        }
    
