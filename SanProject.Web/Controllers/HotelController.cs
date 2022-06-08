using Microsoft.AspNetCore.Mvc;
using SanProject.Application.Services.Interfaces;
using SanProject.Data;
using SanProject.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SanProject.Web.Controllers
{
    public class HotelController : Controller
    {
        public SanProjectDBContext _context;
        public readonly IUnitOfWork _unitofwork;
        public readonly IUsersService _userservice;
        public readonly IAuthenticationService _authenticationservice;
        public readonly ICitySearchService _citysearchservice;

        public HotelController(IUnitOfWork unitofwork, SanProjectDBContext context,
            IUsersService userservice, IAuthenticationService authenticationservice,
            ICitySearchService citysearchservice)
        {
            _unitofwork = unitofwork;
            _context = context;
            _userservice = userservice;
            _authenticationservice = authenticationservice;
            _citysearchservice = citysearchservice;
        }
        public async Task<IActionResult> Index(string id)
        {
            List<HotelObject> t = await _citysearchservice.CityHotelSearch(id);
            return View(t);
        }



    }
}
