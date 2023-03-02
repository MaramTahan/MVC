

using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;

namespace westcoast_education.web.Repositary;

    public class StudentUserRepository : Repository<StudentUserModel>, IStudentUserRepository
    {
        

 public StudentUserRepository(westcoasteducationContext context) : base(context)
 {
 }
 public async Task<StudentUserModel?> FindByEmailAsync(string Email)
 {
  return await _context.studentData.SingleOrDefaultAsync(c => c.email.Trim().ToLower() == Email.Trim().ToLower());
 }

    }
