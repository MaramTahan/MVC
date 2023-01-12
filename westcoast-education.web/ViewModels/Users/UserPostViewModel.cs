using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace westcoast_education.web.ViewModels.Users;

    public class UserPostViewModel
    {
    [Required(ErrorMessage = "userId is mandatory")]
    public int userId { get; set; }


    [Required(ErrorMessage = "Username is mandatory")]
    [DisplayName("username")]
    public string userName { get; set; } = "";

    [Required(ErrorMessage = "FirstName is mandatory")]
    [DisplayName("firstname")]
    public string firstName { get; set; } = "";

    [Required(ErrorMessage = "LastName is mandatory")]
    [DisplayName("lastname")]
    public string lastName { get; set; } = "";

    [Required(ErrorMessage = "E-post is mandatory")]
    [DisplayName("E-Post")]
    public string email { get; set; } = "";

    [Required(ErrorMessage = "A default password is required")]
    [DisplayName("Temporary password")]
    public string password { get; set; } = "";
    }
