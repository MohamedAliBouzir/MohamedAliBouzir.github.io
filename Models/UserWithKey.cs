using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermliAPI.Models
{
    public class UserWithKey
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Roles { get; set; }
    }
}
