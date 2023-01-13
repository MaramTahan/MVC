using westcoast_education.web.Models;

namespace westcoast_education.web.Interfaces;

    public interface IUserRepository : IRepository<UserModel>
    {
        Task<UserModel?> FindByEmailAsync(string email);
    }
