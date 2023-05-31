﻿using KarDo.Domain.AggregateModels.EventAggregate;
using KarDo.Domain.AggregateModels.UserEventJoinAggregate;
using KarDo.Domain.Interfaces;
using KarDo.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Infrastructure.EFCore.Repositories
{
    public class UserEventJoinRepository : IUserEventJoinRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserEventJoinRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UserEventJoinAddAsync(UserEventJoin entity)
        {
            await _dbContext.UserEventJoins.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UserEventJoinCheckAsync(UserEventJoin entity)
        {
            var existingEntity = await _dbContext.UserEventJoins.FirstOrDefaultAsync(x => x.UserId == entity.UserId && x.EventId == entity.EventId);
            if(existingEntity != null)
            {
                if (existingEntity.IsJoined != entity.IsJoined)
                {
                    await UserEventJoinUpdateAsync(entity);
                }
            }
            else
            {
                await UserEventJoinAddAsync(entity);
            }
        }

        public async Task UserEventJoinUpdateAsync(UserEventJoin entity)
        {
            var existingEntity = await _dbContext.UserEventJoins.FirstOrDefaultAsync(x => x.UserId == entity.UserId && x.EventId == entity.EventId);

            if (existingEntity != null)
            {
                existingEntity.IsJoined = entity.IsJoined;
                _dbContext.Update(existingEntity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}