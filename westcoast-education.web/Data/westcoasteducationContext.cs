
using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Models;

namespace westcoast_education.web.Data;

public class westcoasteducationContext: DbContext
{
   public DbSet<Courses> coursesData => Set<Courses>();
   public DbSet<TeacherUserModel> teacherData => Set<TeacherUserModel>();
   public DbSet<StudentUserModel> studentData => Set<StudentUserModel>();
   public westcoasteducationContext(DbContextOptions options) : base(options)
   {
   }
}
