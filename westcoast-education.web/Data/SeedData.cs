using System.Text.Json;
using westcoast_education.web.Models;

namespace westcoast_education.web.Data;

    public static class SeedData
    {
        public static async Task LoadCoursesData(westcoasteducationContext context){
            var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        // Only want to load data if the database table is empty...
        if (context.coursesData.Any()) return;

        // Loading the json data...
        var json = System.IO.File.ReadAllText("/Data/json/courses.json");

        // Convert the json objects to a list of Vehicle objects...
        var coursesList = JsonSerializer.Deserialize<List<Courses>> 
            (json, options);

        if (coursesList is not null && coursesList.Count > 0)
        {
            await context.coursesData.AddRangeAsync(coursesList);
            await context.SaveChangesAsync();
        }
        }
//------------------------------------------------------
    //     public static async Task LoadStudentData(westcoasteducationContext context)
    // {
    //     var options = new JsonSerializerOptions
    //     {
    //         PropertyNameCaseInsensitive = true
    //     };
        
    //     if (context.GetstudentData().Any()) return;

    //     var json = System.IO.File.ReadAllText("Data/json/Student.json");
        
    //     var studentList = JsonSerializer.Deserialize<List<Student>> 
    //         (json, options);

    //     if (studentList is not null && studentList.Count > 0)
    //     {
    //         await context.GetstudentData().AddRangeAsync(studentList);
    //         await context.SaveChangesAsync();
    //     }
    // }
    // //------------------------------------------------------

    // public static async Task LoadTeacherData(westcoasteducationContext context)
    // {
    //     var options = new JsonSerializerOptions
    //     {
    //         PropertyNameCaseInsensitive = true
    //     };

    //     if (context.GetteacherData().Any()) return;

    //     var json = System.IO.File.ReadAllText("Data/json/Teacher.json");
        
    //     var TeacherList = JsonSerializer.Deserialize<List<Teacher>> 
    //         (json, options);

    //     if (TeacherList is not null && TeacherList.Count > 0)
    //     {
    //         await context.GetteacherData().AddRangeAsync(TeacherList);
    //         await context.SaveChangesAsync();
    //     }
    // }
    }
