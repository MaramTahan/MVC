using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;

namespace westcoast_education.web.Repositary;

public class TeacherUserRepository : Repository<TeacherUserModel>, ITeacherUserRepository
{
 public TeacherUserRepository(westcoasteducationContext context) : base(context)
 {
 }
 public async Task<TeacherUserModel?> FindByEmailAsync(string Email)
 {
  return await _context.teacherData.SingleOrDefaultAsync((c => c.email.Trim().ToLower() == Email.Trim().ToLower()));
 }
}
