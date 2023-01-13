using westcoast_education.web.Models;

namespace westcoast_education.web.Interfaces;

    public interface ITeacherUserRepository : IRepository<TeacherUserModel>
    {
        Task<TeacherUserModel?> FindByEmailAsync(string email);
    }
