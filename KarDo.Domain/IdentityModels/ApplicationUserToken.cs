using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Domain.IdentityModels
{
    public class ApplicationUserToken : IdentityUserToken<string>
    {
        public DateTime ExpireDate { get; set; }
    }
}
