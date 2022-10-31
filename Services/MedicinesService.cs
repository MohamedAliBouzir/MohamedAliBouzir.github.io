using FermliAPI.Interfaces;
using FermliAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace FermliAPI.Services
{
    public class MedicinesService
    {
        private readonly IMongoCollection<Medicine> _Medicine;
        public MedicinesService(IFermliDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DbName);

            _Medicine = db.GetCollection<Medicine>("Medicines");
        }
        public List<Medicine> Get() => _Medicine.Find(med => true).ToList();
        public Medicine Get(string id) => _Medicine.Find<Medicine>(med => med.id == id).FirstOrDefault();
        public Medicine Create(Medicine med)
        {
            _Medicine.InsertOne(med);
            return med;
        }
        public void Update(string id, Medicine medIn) => _Medicine.ReplaceOne(med => med.id == id, medIn);
        public void Remove(string id) => _Medicine.DeleteOne(med => med.id == id);
    }
}
