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
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("fullname")]
        [JsonProperty("fullname")]
        public string fullname { get; set; }
        [BsonElement("email")]
        [JsonProperty("email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [BsonElement("phonenumber")]
        [JsonProperty("phonenumber")]
        [DataType(DataType.PhoneNumber)]
        public int phonenumber { get; set; }
        [BsonElement("role")]
        [JsonProperty("role")]
        public string role { get; set; }
        [BsonElement("password")]
        [JsonProperty("password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
