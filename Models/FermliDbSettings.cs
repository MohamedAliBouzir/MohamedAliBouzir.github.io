using FermliAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermliAPI.Models
{
    public class FermliDbSettings:IFermliDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DbName { get; set; } = null!;

    }
}
