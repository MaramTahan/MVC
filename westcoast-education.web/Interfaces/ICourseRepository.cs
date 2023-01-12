using westcoast_education.web.Models;

namespace westcoast_education.web.Interfaces;

    public interface ICourseRepository
    {
        Task<IList<Courses>> ListAllAsync();
        Task<Courses?> FindByIdAsync(int id);
        Task<Courses?> FindBycourseNumberAsync(string courseNo);
        Task<bool> AddAsync(Courses courses);
        Task<bool> UpdateAsync(Courses courses);
        Task<bool> DeleteAsync(Courses courses);
        Task<bool> SaveAsync();
    }
