using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace westcoast_education.web.ViewModels;

    public class CoursePostViewModel
    {



[Required(ErrorMessage = "courseNumber is mandatory")]
[DisplayName("courseNumber")]
public string courseNumber { get; set; } = "";


[Required(ErrorMessage = "name is mandatory")]
[DisplayName("name")]
public string name { get; set; } = "";


[Required(ErrorMessage = "startDate is mandatory")]
[DisplayName("startDate")]
public string startDate { get; set; } = "";


[Required(ErrorMessage = "endDate is mandatory")]
[DisplayName("endDate")]
public string endDate { get; set; } = "";


[Required(ErrorMessage = "teatcher is mandatory")]
[DisplayName("teacher")]
public string teacher { get; set; } = "";


[Required(ErrorMessage = "placeStudy is mandatory")]
[DisplayName("placeStudy")]
public string placeStudy { get; set; } = "";
    }
