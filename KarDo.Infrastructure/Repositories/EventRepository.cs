using KarDo.Domain.AggregateModels.EventAggregate;
using KarDo.Domain.Interfaces;
using KarDo.Infrastructure.EFCore.Common;
using KarDo.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Infrastructure.EFCore.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task UpdateEventAsync(Event entity, string id)
        {
            Guid.TryParse(id, out Guid idGuid);
            var existingEntity = await _dbContext.Set<Event>().FindAsync(idGuid);

            if (existingEntity != null)
            {
                existingEntity.EventDate = entity.EventDate;
                existingEntity.Name = entity.Name;
                existingEntity.ShowType = entity.ShowType;
                _dbContext.Update(existingEntity);
                //_dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Event>> GetEventAllAsync()
        {
            return await _dbContext.Set<Event>().Where(x => x.ShowType == 1).Include(i => i.User).Include(i => i.EventUserJoins).OrderByDescending(i => i.CreatedOn).ToListAsync();
        }
        public async Task<IEnumerable<Event>> GetEventByUserIdAsync(string id)
        {
            //Guid.TryParse(id, out Guid idGuid);
            return await _dbContext.Set<Event>().Where(x => x.UserId == id).Include(i => i.User).OrderByDescending(i => i.CreatedOn).ToListAsync();
        }
    }
}
