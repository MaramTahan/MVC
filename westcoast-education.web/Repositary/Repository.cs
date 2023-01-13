using Microsoft.EntityFrameworkCore;
using westcoast_education.web.Data;
using westcoast_education.web.Interfaces;

namespace westcoast_education.web.Repositary;

public class Repository<T> : IRepository<T> where T : class
{
  protected readonly westcoasteducationContext _context;
  protected readonly DbSet<T> _entity;
 public Repository(westcoasteducationContext context)
 {
   _context = context;
   _entity = _context.Set<T>();
 }

 public async Task<bool> AddAsync(T entity)
 {
  try
        {
           await _entity.AddAsync(entity);
           return true;
        }
        catch
        {
            return false;
        }
 }

 public Task<bool> DeleteAsync(T entity)
 {
  try
        {
            _entity.Remove(entity);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
 }

 public async Task<T?> FindByIdAsync(int id)
 {
   return await _entity.FindAsync(id);
 }

 public async Task<IList<T>> ListAllAsync()
 {
  return await _entity.ToListAsync();
 }

 public Task<bool> UpdateAsync(T entity)
 {
  try
        {
            _entity.Update(entity);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
 }
}
