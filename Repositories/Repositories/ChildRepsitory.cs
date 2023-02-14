using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Repositories.Repositories
{
    public class ChildRepsitory : IDataRepository<Child>
    {
        private readonly IContext _context;
        public ChildRepsitory(IContext context)
        {
            _context = context;
        }
        public async Task<Child> AddAsync(Child entity)
        {
            EntityEntry<Child> newOne = _context.Children.Add(entity);
            await _context.SaveChangesAsync();
            return newOne.Entity;

        }

        public async Task DeleteAsync(string id)
        {
            _context.Children.Remove(_context.Children.FirstOrDefault(p => p.Identity == id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Child>> GetAllAsync()
        {
           return await _context.Children.Include(p => p.Parent).ToListAsync();

            //return await _context.Children.ToListAsync();
        }

        public async Task<Child> GetByIdAsync(string id)
        {
            return await _context.Children.FindAsync(id);
        }

        public async Task<Child> UpdateAsync(Child entity)
        {
            var upd = await GetByIdAsync(entity.Identity);
            upd.DateOfBirdth = entity.DateOfBirdth;
            upd.Name = entity.Name;
            upd.ParentId = entity.ParentId;
            var newEntity = _context.Children.Update(upd);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
           
        }
    }
}
