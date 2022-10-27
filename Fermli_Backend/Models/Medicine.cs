using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fermli_Backend.Models
{
    public class Medicine
    {
        public ObjectId Id { get; set; }

        [Required]
        public int MedicineId {get ; set; }

        [Required]
        [DataType(DataType.Text)]
        public string MedicineTitle { get; set; }

        public string MedicineType { get; set; }
        
        public int MedicineDoses { get; set; }

    }
}
