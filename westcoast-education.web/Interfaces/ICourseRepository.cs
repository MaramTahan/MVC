using westcoast_education.web.Models;

namespace westcoast_education.web.Interfaces;

    public interface ICourseRepository : IRepository<Courses>
    {
       
        Task<Courses?> FindBycourseNumberAsync(string courseNo);
    }
