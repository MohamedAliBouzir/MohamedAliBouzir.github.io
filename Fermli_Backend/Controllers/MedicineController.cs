using Fermli_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fermli_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MedicineController> _logger;

        public MedicineController(IConfiguration configuration, ILogger<MedicineController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("FermliAppCon"));

                var dbList = dbClient.GetDatabase("fermlidb").GetCollection<Medicine>("Medicine").AsQueryable();

                return new JsonResult(dbList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong !");
                return new JsonResult (StatusCode(500, "Internal Server Error. Please Try Again Later."));
            }
        }

        [HttpGet("{id}")]
        public JsonResult GetOne(int id)
        {
            try
            {
                MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("FermliAppCon"));

                var filter = Builders<Medicine>.Filter.Eq("MedicineId", id);

                var dbList = dbClient.GetDatabase("fermlidb").GetCollection<Medicine>("Medicine").Find(filter).FirstOrDefault();

                return new JsonResult(dbList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong !");
                return new JsonResult(StatusCode(500, "Internal Server Error. Please Try Again Later."));
            }
        }

        [HttpPost]
        public  JsonResult Post(Medicine med)
        {
            try
            {
                MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("FermliAppCon"));

                int LastMedicineId = dbClient.GetDatabase("fermlidb").GetCollection<Medicine>("Medicine").AsQueryable().Count();
                med.MedicineId = LastMedicineId + 1;

                dbClient.GetDatabase("fermlidb").GetCollection<Medicine>("Medicine").InsertOne(med);

                return new JsonResult("Added Successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong !");
                return new JsonResult(StatusCode(500, "Internal Server Error. Please Try Again Later."));
            }

        }

        [HttpPut]
        public JsonResult Put(Medicine med)
        {
            try
            {
                MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("FermliAppCon"));

                var filter = Builders<Medicine>.Filter.Eq("MedicineId", med.MedicineId);

                var update = Builders<Medicine>.Update.Set("MedicineName", med.MedicineTitle)
                                                        .Set("MedicineType", med.MedicineType)
                                                        .Set("MedicineDoses", med.MedicineDoses);



                dbClient.GetDatabase("fermlidb").GetCollection<Medicine>("Medicine").UpdateOne(filter, update);

                return new JsonResult("Updated Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong !");
                return new JsonResult(StatusCode(500, "Internal Server Error. Please Try Again Later."));
            }
           
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("FermliAppCon"));

            var filter = Builders<Medicine>.Filter.Eq("MedicineId", id);

            dbClient.GetDatabase("fermlidb").GetCollection<Medicine>("Medicine").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong !");
                return new JsonResult(StatusCode(500, "Internal Server Error. Please Try Again Later."));
            }
}


    }
}
