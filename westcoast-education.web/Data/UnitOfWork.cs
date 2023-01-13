using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Repositary;

namespace westcoast_education.web.Data;

public class UnitOfWork : IUnitOfWork
{
  private readonly westcoasteducationContext _context;
 public UnitOfWork(westcoasteducationContext context)
 {
   _context = context;
 }

 public ICourseRepository CourseRepository => new CourseRepository(_context);

 public ITeacherUserRepository TeacherUserRepository => new TeacherUserRepository(_context);
 
 public IStudentUserRepository StudentUserRepository => new StudentUserRepository(_context);

 public async Task<bool> Complete()
 {
  return await _context.SaveChangesAsync() > 0;
 }
}
