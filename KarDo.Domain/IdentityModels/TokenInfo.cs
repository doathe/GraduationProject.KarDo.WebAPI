using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Domain.IdentityModels
{
    public class TokenInfo
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
