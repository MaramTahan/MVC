
using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Models;

namespace westcoast_education.web.Data;

public class westcoasteducationContext: DbContext
{
   public DbSet<Courses> coursesData => Set<Courses>();
   public DbSet<UserModel> users => Set<UserModel>();
   public westcoasteducationContext(DbContextOptions options) : base(options)
   {
   }
}
