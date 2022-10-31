using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCart.Models;

namespace MyCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DeliveryManagementSystemContext db;

        public CustomerController(DeliveryManagementSystemContext _db)
        {
            db=_db;
        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetRegistration()
        {
            return Ok(db.CustomerRegistrations.ToList());
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult AddRegistration(CustomerRegistration a)

        {
            db.CustomerRegistrations.Add(a);
            db.SaveChanges();
            return Ok(a);

        }
        [Route("[action]")]
        [HttpGet]

        public IActionResult GetLogin()
        {
            return Ok(db.CustomerRegistrations.ToList());
        }
        [Route("[action]")]
        [HttpGet]
        
        public IActionResult AddLogin(string username,string password)

        {
         var result=   db.CustomerRegistrations.Where(row => row.CustomerName==username && row.Password==password).FirstOrDefault();
            return Ok (result);
        }
    }

}