using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;
using westcoast_education.web.Models;

namespace westcoast_education.web.Repositary;

public class UserRepository : IUserRepository
{
  private readonly westcoasteducationContext _context;
 public UserRepository(westcoasteducationContext context)
 {
   _context = context;
 }

 public async Task<bool> AddAsync(UserModel user)
 {
  try
  {
    await _context.users.AddAsync(user);
    return true;
  }
  catch
  {
    
   return false;
  }
 }

 public Task<bool> DeleteAsync(UserModel user)
 {
  try
  {
    _context.users.Remove(user);
    return Task.FromResult(true);
    
  }
  catch
  {
    return Task.FromResult(false);
  }
 }

 public async Task<UserModel?> FindByEmailAsync(string email)
 {
    //c => c.email.Trim().ToLower() = email.Trim().ToLower()
  return await _context.users.SingleOrDefaultAsync();
 }

 public async Task<UserModel?> FindByIdAsync(int id)
 {
  return await _context.users.FindAsync(id);
 }

 public async Task<IList<UserModel>> ListAllAsync()
 {
 return await _context.users.ToListAsync();
 }

 public async Task<bool> SaveAsync()
 {
  try
  {
    if(await _context.SaveChangesAsync() > 0) return true;
    return false;
  }
  catch
  {
    
    return false;
  }
 }

 public Task<bool> UpdateAsync(UserModel user)
 {
  try
  {
    _context.users.Update(user);
    return Task.FromResult(true);
  }
  catch
  {
    return Task.FromResult(false);
  }
 }
}
