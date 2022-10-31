using FermliAPI.Interfaces;
using FermliAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
namespace FermliAPI.Services
{
    public class DoctorsService
    {
        private readonly IMongoCollection<Doctors> _Doctor;
        public DoctorsService(IFermliDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DbName);

            _Doctor = db.GetCollection<Doctors>("Doctors");
        }
        public List<Doctors> Get() => _Doctor.Find(doc => true).ToList();
        public Doctors Get(string id) => _Doctor.Find<Doctors>(doc => doc.id == id).FirstOrDefault();
        public  Doctors Create(Doctors doc)
        {
            _Doctor.InsertOne(doc);
            return doc;
        }
        public void Update(string id, Doctors docIn) => _Doctor.ReplaceOne(doc => doc.id == id, docIn);
        public void Remove(string id) => _Doctor.DeleteOne(doc => doc.id == id);
    }
}
