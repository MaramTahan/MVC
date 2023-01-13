
using Microsoft.AspNetCore.Mvc;

using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;
using westcoast_education.web.ViewModels;

namespace westcoast_education.web.Controllers;

[Route("courses/admin")]

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
        public async Task<IActionResult> Create(CoursePostViewModel addCourse)
        {
            try
            {
                  if (!ModelState.IsValid) return View("Create", addCourse);
                var exists = await _unitOfWork.CourseRepository.FindBycourseNumberAsync(addCourse.courseNumber);
                if (exists is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "An error has occurred when saving the course!"
                };

                return View("_Error", error);
            }
            var courseToAdd = new Courses{
                courseNumber = addCourse.courseNumber,
                name = addCourse.name,
                startDate = addCourse.startDate,
                endDate = addCourse.endDate,
                teacher = addCourse.teacher,
                placeStudy = addCourse.placeStudy
            };
            if(await _unitOfWork.CourseRepository.AddAsync(courseToAdd)){
                if (await _unitOfWork.Complete())
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            var saveError = new ErrorModel
                {
                    ErrorTitle = "An error has occurred when saving the course!"
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
                var result = await _unitOfWork.CourseRepository.FindByIdAsync(Id);
                if (result is null){
                    var error = new ErrorModel
            {
                ErrorTitle = "An error occurred when we were about to pick up a course for editing",
                ErrorMessage = $"We can't find a course with this ID"
            };
             return View("_Error", error);
                }
                var model = new CourseUpdateViewModel{
                Id = result.Id,
                courseNumber = result.courseNumber,
                name = result.name,
                startDate = result.startDate,
                endDate = result.endDate,
                teacher = result.teacher,
                placeStudy = result.placeStudy
                };
                return View("Edit", model);
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
            public async Task<IActionResult> Edit(int Id, CourseUpdateViewModel addCourse){
                try
                {
                    if (!ModelState.IsValid) return View("Edit", addCourse);

                    var courseToUpdate = await _unitOfWork.CourseRepository.FindByIdAsync(Id);

                    if (courseToUpdate is null) return RedirectToAction(nameof(Index));
                    courseToUpdate.courseNumber = 
                    addCourse.courseNumber;
                    courseToUpdate.name = addCourse.name;
                    courseToUpdate.startDate = addCourse.startDate;
                    courseToUpdate.endDate = addCourse.endDate;
                    courseToUpdate.teacher = addCourse.teacher;
                    courseToUpdate.placeStudy = addCourse.placeStudy;

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
    
