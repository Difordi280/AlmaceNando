using AlmaceNando.Domain.Repositories;
using AlmaceNando.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlmaceNando.Data.Context;

namespace AlmaceNando.Data.Repositories
{
    
    public  class Repositories<T> : IRepository<T> where T :  BaseEntity
    {
        
        private readonly StoreContext _context;

        public Repositories(StoreContext context){ _context = context; }   

        public virtual async Task<IEnumerable<T>> GetAllAny()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public virtual async Task AddAnsy(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAnsy(Guid id)
        {
            await _context.Set<T>().Where(u => u.Id == id ).ExecuteDeleteAsync();
        }
        public async Task UpdateAnsy(Guid id, T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
