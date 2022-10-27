using Fermli_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class AccountController : ControllerBase
    {
    //    private readonly UserManager<User> _userManager;
    //    private readonly SignInManager<User> _signInManager;
    //    private readonly IConfiguration _configuration;
    //    private readonly ILogger<AccountController> _logger;

    //    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, ILogger<AccountController> logger)
    //    {
    //        _userManager = userManager;
    //        _signInManager = signInManager;
    //        _configuration = configuration;
    //        _logger = logger;
    //    }

    //    //[HttpPost]
    //    //public JsonResult Register(User user)
    //    //{
    //    //    try
    //    //    {
    //    //        MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("FermliAppCon"));

    //    //        int LastMedicineId = dbClient.GetDatabase("fermlidb").GetCollection<Medicine>("Medicine").AsQueryable().Count();
    //    //        //med.MedicineId = LastMedicineId + 1;

    //    //       // dbClient.GetDatabase("fermlidb").GetCollection<Medicine>("Medicine").InsertOne(user);

    //    //        return new JsonResult("Added Successfully!");
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        _logger.LogError(ex, "Something went wrong !");
    //    //        return new JsonResult(StatusCode(500, "Internal Server Error. Please Try Again Later."));
    //    //    }

    //    //}
    }
}
