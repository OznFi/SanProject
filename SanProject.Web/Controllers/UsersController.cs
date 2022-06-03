using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SanProject.Data;
using SanProject.Domain;
using SanProject.Web.Models;
using System;
using System.Linq;
using System.Net.Http;

namespace SanProject.Web.Controllers
{
    public class UsersController : Controller
    {

        public SanProjectDBContext _context;
        public UsersController(SanProjectDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewUsers()
        {
            var users= _context.Users.ToList();
            return View(users);
        }
        [HttpPut]
        public IActionResult ActivateUser(User user)
        {
            if (ModelState.IsValid)
            {
                bool stat = user.IsActive;
                user.IsActive = !stat;
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
            
        }
        [HttpDelete]
        public IActionResult SoftDelete(User user)
        {
            if (ModelState.IsValid)
            {
                user.IsDeleted = true;
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                user.RegistryDate = DateTime.Now;
                user.IsActive = true;
                /*do unit of work here
                 
                 */
                /*send email to user*/

                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }

        //might be placed onto some other Page
        [HttpPost]
        public IActionResult Login(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                //string jsonuser = JsonConvert.SerializeObject(myReturnData);
                var client = new HttpClient();
                //var req = client.PostAsync("http://service.stage.paximum.com/v2", user);

            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
