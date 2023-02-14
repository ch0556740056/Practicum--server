using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repositories
{
    public class PersonalDetailsRepository : IDataRepository<PersonalDetail>
    {
        private readonly IContext _context;
        public PersonalDetailsRepository(IContext context)
        {
            _context = context;
        }
        public async Task<PersonalDetail> AddAsync(PersonalDetail entity)
        {
            EntityEntry<PersonalDetail> newOne = _context.PersonalDetails.Add(entity);
            await _context.SaveChangesAsync();
            return newOne.Entity;
        }

        public async Task DeleteAsync(string id)
        {
            _context.PersonalDetails.Remove(_context.PersonalDetails.FirstOrDefault(p => p.Identity == id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<PersonalDetail>> GetAllAsync()
        {
            return await _context.PersonalDetails.ToListAsync();
        }

        public async Task<PersonalDetail> GetByIdAsync(string id)
        {
            return await _context.PersonalDetails.FindAsync(id);
        }

        public async Task<PersonalDetail> UpdateAsync(PersonalDetail entity)
        {
            var upd = await GetByIdAsync(entity.Identity);
            upd.Identity = entity.Identity;
            upd.Gender = entity.Gender;
            upd.DateOfBirdth = entity.DateOfBirdth;
            upd.FirstName = entity.FirstName;
            upd.LastName = entity.LastName;
            upd.Hmo = entity.Hmo;
            var newEntity = _context.PersonalDetails.Update(upd);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }
    }
}
