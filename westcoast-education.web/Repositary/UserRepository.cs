using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;

namespace westcoast_education.web.Repositary;

public class UserRepository : Repository<UserModel>, IUserRepository
{
 public UserRepository(westcoasteducationContext context) : base(context)
 {
 }
 public async Task<UserModel?> FindByEmailAsync(string email)
 {
    //c => c.email.Trim().ToLower() = email.Trim().ToLower()
  return await _context.users.SingleOrDefaultAsync();
 }
}
