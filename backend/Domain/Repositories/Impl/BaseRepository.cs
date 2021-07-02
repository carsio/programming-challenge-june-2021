using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Impl
{
    public class BaseRepository<T>: IBaseRepository<T> where T : class, new()
    {
        protected readonly ApplicationDbContext Context;

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<T>> GetAll() => await Context.Set<T>().ToListAsync();

        public async Task<T> Create(T obj)
        {
            var saved = await Context.Set<T>().AddAsync(obj);
            await Context.SaveChangesAsync();
            return saved.Entity;
        }

        public async Task<int> CreateRange(IEnumerable<T> objList)
        {
            await Context.Set<T>().AddRangeAsync(objList);
            return await Context.SaveChangesAsync();
        }
    }
}