using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace westcoast_education.web.ViewModels.Users;

    public class TeacherUpdateViewModel
    {
    public int userId { get; set; }

    [Required(ErrorMessage = "FirstName is mandatory")]
    [DisplayName("firstName")]
    public string firstName { get; set; } = "";

    [Required(ErrorMessage = "LastName is mandatory")]
    [DisplayName("lastName")]
    public string lastName { get; set; } = "";

    [Required(ErrorMessage = "E-post is mandatory")]
    [DisplayName("E-Post")]
    public string email { get; set; } = "";
    public string coursesTaught { get; set; } = "";
    public string phoneNumber { get; set; } = "";
    public string address { get; set; } = "";
    }
