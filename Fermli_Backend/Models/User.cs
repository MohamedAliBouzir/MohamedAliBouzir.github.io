//using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fermli_Backend.Models
{
    public class User 
    {

        public string FullName { get; set; }

        //[Required]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }

        //[Required]
        //[DataType(DataType.PhoneNumber)]
        //public string PhoneNumber { get; set; }

        //[Required]
        
        //public string Password { get; set; }
    }
}
