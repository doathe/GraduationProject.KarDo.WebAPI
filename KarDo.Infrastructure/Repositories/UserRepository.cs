using KarDo.Domain.AggregateModels.EventAggregate;
using KarDo.Domain.AggregateModels.UserAggregate;
using KarDo.Domain.IdentityModels;
using KarDo.Domain.Interfaces;
using KarDo.Infrastructure.EFCore.Common;
using KarDo.Infrastructure.EFCore.Context;
using KarDo.Infrastructure.EFCore.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Infrastructure.EFCore.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public IConfiguration _config { get; set; }
        public UserRepository(ApplicationDbContext dbContext, IConfiguration config) : base(dbContext)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public async Task<ApplicationUser?> GetByUsernameAsync(string username)
        {
            return await _dbContext.Set<ApplicationUser>().FirstOrDefaultAsync(x => x.UserName == username);
        }
        public async Task<bool> EmailExistCheckAsync(string email)
        {
            return _dbContext.Set<ApplicationUser>().Any(x => x.Email == email);
        }
        public async Task<bool> UsernameExistCheckAsync(string username)
        {
            return _dbContext.Set<ApplicationUser>().Any(x => x.UserName == username);
        }
        public TokenInfo Authorization(ApplicationUser userModel)
        {
            AccessTokenGenerator _tokengenerator = new AccessTokenGenerator(_dbContext, _config, userModel);

            var token = _tokengenerator.GetToken();

            return token;
        }

        public async Task UpdateUserAsync(ApplicationUser entity, string id)
        {
            //Guid.TryParse(id, out Guid idGuid);
            var existingEntity = await _dbContext.Set<ApplicationUser>().FindAsync(id);

            if (existingEntity != null)
            {
                existingEntity.FirstName = entity.FirstName;
                existingEntity.LastName = entity.LastName;
                existingEntity.UserName = entity.UserName;
                existingEntity.Email = entity.Email;
                existingEntity.PasswordHash = entity.PasswordHash;
                _dbContext.Update(existingEntity);
                //_dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
