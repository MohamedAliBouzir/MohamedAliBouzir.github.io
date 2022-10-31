using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace FermliAPI.Models
{
    public class Doctors
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("fullname")]
        [JsonProperty("fullname")]
        public string fullname { get; set; }
        [BsonElement("phonenumber")]
        [JsonProperty("phonenumber")]
        [DataType(DataType.PhoneNumber)]
        public int phonenumber { get; set; }
        [BsonElement("speciality")]
        [JsonProperty("speciality")]
        public string speciality { get; set; }
    }
}
