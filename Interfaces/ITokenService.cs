using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FermliAPI.Models;

namespace FermliAPI.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(User user);
    }
}
