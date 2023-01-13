using Microsoft.AspNetCore.Mvc;
using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;
using westcoast_education.web.ViewModels.Users;

namespace westcoast_education.web.Controllers;

    public class TeacherAdminController : Controller
    {
  private readonly IUnitOfWork _unitOfWork;
  public TeacherAdminController(IUnitOfWork unitOfWork)
  {
   _unitOfWork = unitOfWork;
   
  }

  [Route("teacher/admin")]
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.TeacherUserRepository.ListAllAsync();
            var users = result.Select(u => new UsersListViewModel
            {
                userId = u.userId,
                userName = u.userName,
                firstName = u.firstName,
                lastName = u.lastName,
                email = u.email,
                coursesTaught = u.coursesTaught,
                phoneNumber = u.phoneNumber,
                address = u.address
                
            }).ToList();

            return View("Index", users);
        }
        [HttpGet("create")]
        public IActionResult Create(){
            var addUser = new UserPostViewModel();
            return View("Create", addUser);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(UserPostViewModel addUser)
        {
            try
            {
                  if (!ModelState.IsValid) return View("create", addUser);
                var exists = await _unitOfWork.TeacherUserRepository.FindByEmailAsync(addUser.email);
                if (exists is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "An error has occurred when saving the user!",
                };

                return View("_Error", error);
            }
            var userToAdd = new TeacherUserModel{
                userName = addUser.userName,
                firstName = addUser.firstName,
                lastName = addUser.lastName,
                email = addUser.email,
                password= addUser.password,
                coursesTaught = addUser.coursesTaught,
                phoneNumber = addUser.phoneNumber,
                address = addUser.address
            };
            if(await _unitOfWork.TeacherUserRepository.AddAsync(userToAdd)){
                if (await _unitOfWork.Complete())
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            var saveError = new ErrorModel
                {
                    ErrorTitle = "An error has occurred when saving the user!"
                };

                return View("_Error", saveError);
            
            }
            catch (Exception ex)
            {
                var error = new ErrorModel
            {
                ErrorTitle = "An error has occurred when we were trying to save the user",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
            }
            }
            //-------------------end create course------------------
            //------------------------------------------------------
            //-------------------start edit course------------------
            [HttpGet("edit/{userId}")]

            public async Task<IActionResult> Edit(int userId){
               try
               {
                var userEdit = await _unitOfWork.TeacherUserRepository.FindByIdAsync(userId);
                if (userEdit is null){
                    var error = new ErrorModel
            {
                ErrorTitle = "An error occurred when we were about to pick up a user for editing"
            };
             return View("_Error", error);
                }
                var userToUpdate = new UserUpdateViewModel{
                userId = userEdit.userId,
                userName = userEdit.userName,
                firstName = userEdit.firstName,
                lastName = userEdit.lastName,
                email = userEdit.email,
                password= userEdit.password,
                coursesTaught = userEdit.coursesTaught,
                phoneNumber = userEdit.phoneNumber,
                address = userEdit.address
                };
                return View("edit", userToUpdate);
               }
               catch (Exception ex)
               {
                var error = new ErrorModel
            {
                ErrorTitle = "An error occurred when we were about to pick up a user for editing",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
                
               }
            }

            [HttpPost("edit/{userId}")]
            public async Task<IActionResult> Edit(int userId, UserUpdateViewModel userEdit){
                try
                {
                    if (!ModelState.IsValid) return View("edit", userEdit);

                    var userToUpdate = await _unitOfWork.TeacherUserRepository.FindByIdAsync(userId);

                    if (userToUpdate is null){
                        var notFoundError = new ErrorModel{
                            ErrorTitle ="user missing!"
                        };
                        return View("_Error", notFoundError);
                    }
                    userToUpdate.userName = userEdit.userName;
                    userToUpdate.firstName = userEdit.firstName;
                    userToUpdate.lastName = userEdit.lastName;
                    userToUpdate.email = userEdit.email;
                    userToUpdate.coursesTaught = userEdit.coursesTaught;
                    userToUpdate.phoneNumber = userEdit.phoneNumber;
                    userToUpdate.address = userEdit.address;

                    if(await _unitOfWork.TeacherUserRepository.UpdateAsync(userToUpdate)){
                        if (await _unitOfWork.Complete())
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    var error = new ErrorModel
            {
                ErrorTitle = "An error has occurred when we were trying to save the user"
            };

            return View("_Error", error);
                    
                }
                catch (Exception ex)
                {
                    var error = new ErrorModel
                {
                    ErrorTitle = "An error has occurred when saving the user!",
                    ErrorMessage = ex.Message
                };

                return View("_Error", error);
                }
            }
            //-----------------------end edit course--------------
            //--------------------------------------------------------
            //-----------------------start delete course-----------
            [Route("delete/{userId}")]
            public async Task<IActionResult> Delete(int userId){
                try
                {
                    var userToDelete = await _unitOfWork.TeacherUserRepository.FindByIdAsync(userId);

                    if (userToDelete is null) return RedirectToAction(nameof(Index));

                    if(await _unitOfWork.TeacherUserRepository.DeleteAsync(userToDelete)){
                        if (await _unitOfWork.Complete())
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                     var error = new ErrorModel
            {
                ErrorTitle = "An error has occurred when the user was to be deleted"
            };

            return View("_Error", error);
                    
                }
                catch (Exception ex)
                {
                    var error = new ErrorModel
            {
                ErrorTitle = "An error has occurred when the user was to be deleted",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
                    
                }
            }
            //-------------------------end delete course----------
    }
