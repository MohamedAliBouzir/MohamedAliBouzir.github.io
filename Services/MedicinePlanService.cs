using FermliAPI.Interfaces;
using FermliAPI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermliAPI.Services
{
    public class MedicinePlanService
    {
        private readonly IMongoCollection<MedicinePlan> _medPlan;
        public MedicinePlanService(IFermliDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DbName);
            _medPlan = db.GetCollection<MedicinePlan>("MedicinePlan");
        }
        public List<MedicinePlan> GetAll(string patientId) => _medPlan.Find(med => med.patientId == patientId).ToList();
        public MedicinePlan Get(string id) => _medPlan.Find<MedicinePlan>(med => med.id == id).FirstOrDefault();
        public MedicinePlan Create(MedicinePlan med)
        {
            _medPlan.InsertOne(med);
            return med;
        }
        public void Update(string id, MedicinePlan medPlanIn) => _medPlan.ReplaceOne(medPlan => medPlan.id == id, medPlanIn);
        public void Remove(string id) => _medPlan.DeleteOne(medPlan => medPlan.id == id);
    }
}
