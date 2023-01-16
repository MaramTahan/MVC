using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace westcoast_education.web.ViewModels.Users;

    public class UserUpdateViewModel
    {
    [Required(ErrorMessage = "userId is mandatory")]
    public int userId { get; set; }


    [Required(ErrorMessage = "Username is mandatory")]
    [DisplayName("userName")]
    public string userName { get; set; } = "";

    [Required(ErrorMessage = "FirstName is mandatory")]
    [DisplayName("firstName")]
    public string firstName { get; set; } = "";

    [Required(ErrorMessage = "LastName is mandatory")]
    [DisplayName("lastName")]
    public string lastName { get; set; } = "";

    [Required(ErrorMessage = "E-post is mandatory")]
    [DisplayName("E-Post")]
    public string email { get; set; } = "";

    [Required(ErrorMessage = "A default password is required")]
    [DisplayName("Temporary password")]
    public string password { get; set; } = "";
    public string coursesTaught { get; set; } = "";
    public string phoneNumber { get; set; } = "";
    public string address { get; set; } = "";
    }
