using FermliAPI.Interfaces;
using FermliAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
namespace FermliAPI.Services
{
    public class AppointmentService
    {
        private readonly IMongoCollection<Appointment> _appointment;
        public AppointmentService(IFermliDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DbName);

            _appointment = db.GetCollection<Appointment>("Appointment");
        }
        public List<Appointment> GetAll(string patientId) => _appointment.Find(app => app.patientId == patientId ).ToList();
        public Appointment Get(string id) => _appointment.Find<Appointment>(app => app.id == id ).FirstOrDefault();
        public Appointment Create(Appointment app)
        {
            _appointment.InsertOne(app);
            return app;
        }
        public void Update(string id, Appointment docIn) => _appointment.ReplaceOne(doc => doc.id == id, docIn);
        public void Remove(string id) => _appointment.DeleteOne(doc => doc.id == id);
    }
}
