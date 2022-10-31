using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermliAPI.Interfaces
{
    public interface IFermliDbSettings
    {
        string ConnectionString { get; set; }
        string DbName { get; set; }
    }
}
