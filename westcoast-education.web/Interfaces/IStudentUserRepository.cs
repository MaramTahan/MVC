
using westcoast_education.web.Models;

namespace westcoast_education.web.Interfaces;

    public interface IStudentUserRepository : IRepository<StudentUserModel>
    {
         Task<StudentUserModel?> FindByEmailAsync(string email);
    }
