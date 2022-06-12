using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SanProject.Application.Services.Interfaces;
using SanProject.Data;
using SanProject.Domain;
using SanProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SanProject.Web.Controllers
{
    public class HomeController : Controller
    {
        public SanProjectDBContext _context;
        public readonly IUnitOfWork _unitofwork;
        public readonly IUsersService _userservice;
        public readonly IAuthenticationService _authenticationservice;
        public readonly ICitySearchService _citysearchservice;

        public HomeController(IUnitOfWork unitofwork, SanProjectDBContext context, 
            IUsersService userservice, IAuthenticationService authenticationservice,
            ICitySearchService citysearchservice)
        {
            _unitofwork = unitofwork;
            _context = context;
            _userservice = userservice;
            _authenticationservice = authenticationservice;
            _citysearchservice = citysearchservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(string citytext)
        {

            //var client = new HttpClient();
            //var req = client.PostAsync("http://service.stage.paximum.com/v2",);
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CityQuery(string quer)
        {
            /*
            string t = _authenticationservice.Login().Result;
            Token to=new Token();
            to.token=t;*/
            //var t=await _authenticationservice.Login();
            //string quer = HttpContext.Request.Form["citysearch"];
            List<CityObject> t = await _citysearchservice.Search(quer);

            //return RedirectToAction("Cities", t);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Cities(string quer)
        {
            if((quer==null || quer=="") || quer.Length < 3)
            {
                return BadRequest("The City field requires at least 3 characters");
            }
            List<CityObject> t = await _citysearchservice.Search(quer);

            
            return View(t);
        }
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
