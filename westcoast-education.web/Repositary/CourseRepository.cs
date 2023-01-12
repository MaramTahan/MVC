using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;

namespace westcoast_education.web.Repositary;

public class CourseRepository : Repository<Courses>, ICourseRepository
{
 public CourseRepository(westcoasteducationContext context) : base(context){}

 public async Task<Courses?> FindBycourseNumberAsync(string courseNo)
 {
  return await _context.coursesData.SingleOrDefaultAsync(c => c.courseNumber.Trim().ToLower() == courseNo.Trim().ToLower());
 }
 }
