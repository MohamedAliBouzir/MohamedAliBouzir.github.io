using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace FermliAPI.Models
{
    public class Medicine
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }
        [BsonElement("Kind")]
        [JsonProperty("Kind")]
        public string kind { get; set; }
        [BsonElement("Doses")]
        [JsonProperty("Doses")]
        public int doses { get; set; }
    }
}
