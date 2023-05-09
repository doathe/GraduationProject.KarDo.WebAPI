using KarDo.Domain.AggregateModels.UserAggregate;
using KarDo.Domain.IdentityModels;
using KarDo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<ApplicationUser?> GetByUsernameAsync(string username);
        Task<bool> EmailExistCheckAsync(string email);
        Task<bool> UsernameExistCheckAsync(string username);
        public TokenInfo Authorization(ApplicationUser userModel);
    }
}
