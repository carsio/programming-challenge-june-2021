using Domain.Data;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Impl
{
    public class BaseRepository<T>: IBaseRepository<T> where T : class, new()
    {
        protected readonly ApplicationDbContext Context;

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}