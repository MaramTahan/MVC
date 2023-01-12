
using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;

namespace westcoast_education.web.Repositary;

public class CourseRepository : ICourseRepository
{
  private readonly westcoasteducationContext _context;
 public CourseRepository(westcoasteducationContext context)
 {
   _context = context;
 }

 public async Task<bool> AddAsync(Courses courses)
 {
  try
  {
    await _context.coursesData.AddAsync(courses);
    return true;
  }
  catch
  {
    
   return false;
  }
 }

 public Task<bool> DeleteAsync(Courses courses)
 {
  try
  {
    _context.coursesData.Remove(courses);
    return Task.FromResult(true);
    
  }
  catch
  {
    return Task.FromResult(false);
  }
  
 }

 public async Task<Courses?> FindBycourseNumberAsync(string courseNo)
 {
  return await _context.coursesData.SingleOrDefaultAsync();
 }

 public async Task<Courses?> FindByIdAsync(int id)
 {
  return await _context.coursesData.FindAsync(id);
 }

 public async Task<IList<Courses>> ListAllAsync()
 {
  return await _context.coursesData.ToListAsync();
 }

 public async Task<bool> SaveAsync()
 {
  try
  {
    if(await _context.SaveChangesAsync() > 0)return true;
    return false;
  }
  catch
  {
    
    return false;
  }
 }

 public Task<bool> UpdateAsync(Courses courses)
 {
  try
  {
    _context.coursesData.Update(courses);
    return Task.FromResult(true);
  }
  catch
  {
    return Task.FromResult(false);
  }
 }
}
