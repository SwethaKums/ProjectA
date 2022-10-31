using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCart.Models;
using System;

namespace MyCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutiveController : ControllerBase
    {
        private readonly DeliveryManagementSystemContext db;

        public ExecutiveController(DeliveryManagementSystemContext _db)
        {
            db=_db;
        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetRegistration()
        {
            return Ok(db.ExecutiveRegistrations.ToList());
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult AddRegistration(ExecutiveRegistration a)

        {
            db.ExecutiveRegistrations.Add(a);
            db.SaveChanges();
            return Ok(a);

        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetLogin()
        {
            return Ok(db.ExecutiveRegistrations.ToList());
        }
        [Route("[action]")]
        [HttpGet]

        public IActionResult AddLogin(string username, string password)

        {
            var result = db.ExecutiveRegistrations.Where(row => row.ExecutiveName==username && row.Password==password).FirstOrDefault();
            return Ok(result);
        }
    }


}

