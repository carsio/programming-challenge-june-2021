using Domain.Data;
using Domain.Entity;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Impl
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}