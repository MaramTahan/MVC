namespace westcoast_education.web.Models
{
    public class Courses
    {
public int Id { get; set; }
public string courseNumber { get; set; } = "";
public string name { get; set; } = "";
public string startDate { get; set; } = "";
public string endDate { get; set; } = "";
public string teacher { get; set; } = "";
public string placeStudy { get; set; } = "";
    }
}