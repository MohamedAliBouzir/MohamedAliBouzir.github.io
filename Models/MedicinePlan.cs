using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FermliAPI.Models
{
    public class MedicinePlan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("packs")]
        [JsonProperty("packs")]
        public int packs { get; set; }
        [BsonElement("dosesPerDay")]
        [JsonProperty("dosesPerDay")]
        public int dosesPerDay { get; set; }
        [BsonElement("DosesTime")]
        [JsonProperty("DosesTime")]
        public List<DateTime> dosesTime { get; set; }
        [BsonElement("monthPlan")]
        [JsonProperty("monthPlan")]
        public List<DateTime> monthPlan { get; set; }
        [BsonElement("patientId")]
        [JsonProperty("patientId")]
        public string patientId { get; set; }
        [BsonElement("medicineId")]
        [JsonProperty("medicineId")]
        public string medicineId { get; set; }
    }
}
