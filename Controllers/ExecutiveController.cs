using Microsoft.AspNetCore.Mvc;
using MyCartMVC.Models;
using Newtonsoft.Json;
using System.Text;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace MyCartMVC.Controllers
{
    public class ExecutiveController : Controller
    {
        private readonly DeliveryManagementSystemContext dd;
        private readonly ISession session;
        public ExecutiveController(DeliveryManagementSystemContext _dd, IHttpContextAccessor httpContextAccessor)
        {
            dd= _dd;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(ExecutiveRegistration e)
        {
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:44374/api/Executive/AddRegistration", content))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    var empobj = JsonConvert.DeserializeObject<ExecutiveRegistration>(apiresponse);
                }
            }
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ExecutiveRegistration e)
        {
            using (var client = new HttpClient())
            {
               // StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");
                using (var response =  client.GetAsync("https://localhost:44374/api/Executive/AddLogin?username="+e.ExecutiveName+"&password="+e.Password).Result)
                {
                    string apiresponse =  response.Content.ReadAsStringAsync().Result;
                    var empobj = JsonConvert.DeserializeObject<ExecutiveRegistration>(apiresponse);
                    if (empobj!=null)
                    {
                        HttpContext.Session.SetInt32("Empid", empobj.ExecutiveId);
                        HttpContext.Session.SetString("Ename", empobj.ExecutiveName);
                        return RedirectToAction("Home");
                    }
                    else
                    {
                        ViewBag.FailureMessage="Invalid UserName or Password";
                        return View();
                    }
                }
                
            }
         }
        public IActionResult Reglogpage()
        {
            return View();
        }
        public IActionResult Home()
        {
            if (HttpContext.Session.GetString("Ename")!=null) {
                return RedirectToAction("Home");

            }
            else
            {
                return View("Login");
            }
           
        }
       
        //public IActionResult Home()
        //{
        //    var emp = HttpContext.Session.GetInt32("Empid");
        //    var result = dd.AddBookings.Where(val => val.ExecutiveId==emp).ToList();
        //    if (result!=null) {
        //        return RedirectToAction("ViewRequest",result);
        //    }
        //    else
        //    {
        //        ViewBag.mess="no data";
        //        return View();
        //    }
        //}
        public IActionResult ViewRequest()
        {
           

           // var result = dd.AddBookings.ToList();

            var final = dd.AddBookings.Where(var => var.ExecutiveId==null).ToList();          
            return View("ViewRequest", final);



        }
        public IActionResult UpdateExecutive(int id)
        {
            var emp = HttpContext.Session.GetInt32("Empid");
            var fil = dd.AddBookings.Where(var => var.OrderId==id).FirstOrDefault();
            fil.ExecutiveId=emp;
            dd.AddBookings.Update(fil);
            dd.SaveChanges();
            return View("UpdateExecutive",new List<AddBooking> { fil});
        }
        public IActionResult BookDetails()
        {
            var empt = HttpContext.Session.GetInt32("Empid");
            var answer = dd.AddBookings.Where(var => var.ExecutiveId==empt).ToList();
                return View("UpdateExecutive",answer);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
    }




 