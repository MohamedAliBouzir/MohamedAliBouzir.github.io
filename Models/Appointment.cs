using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FermliAPI.Models
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("title")]
        [JsonProperty("title")]
        public string title { get; set; }
        [BsonElement("type")]
        [JsonProperty("type")]
        public string type { get; set; }
        [BsonElement("location")]
        [JsonProperty("location")]
        public string location { get; set; }
        [BsonElement("date")]
        [JsonProperty("date")]
        [DataType(DataType.Date)]
        public string date { get; set; }
        [BsonElement("notes")]
        [JsonProperty("notes")]
        public string notes { get; set; }
        [BsonElement("docId")]
        [JsonProperty("docId")]
        public string docId { get; set; }
        [BsonElement("patientId")]
        [JsonProperty("patientId")]
        public string patientId { get; set; }
    }
}
