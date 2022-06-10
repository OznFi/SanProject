using Microsoft.AspNetCore.Mvc;
using SanProject.Application.Services.Interfaces;
using SanProject.Data;
using SanProject.Domain;
using SanProject.Shared.HotelModels;
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
        public IHotelService _hotelservice;

        public HotelController(IUnitOfWork unitofwork, SanProjectDBContext context,
            IUsersService userservice, IAuthenticationService authenticationservice,
            ICitySearchService citysearchservice, IHotelService hotelservice)
        {
            _unitofwork = unitofwork;
            _context = context;
            _userservice = userservice;
            _authenticationservice = authenticationservice;
            _citysearchservice = citysearchservice;
            _hotelservice = hotelservice;
        }
        public async Task<IActionResult> Index(string id)
        {
            List<HotelObject> t = await _citysearchservice.CityHotelSearch(id);
            return View(t);
        }

        public async Task<IActionResult> NumberofTravelers(string id)
        {
            HotelQueryDTO a=new HotelQueryDTO();
            a.HotelId = id;
            a.NumberOfTravellers = 1;
            return View(a);
        }
        public async Task<IActionResult> HotelDetail(HotelQueryDTO dto)
        {
            HotelDetailDTO dt = await _hotelservice.GetDetails(dto.HotelId, dto.NumberOfTravellers);
            if (dt == null)
            {
                //return View("~/Views/SpecificView.cshtml");
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return View(dt);
        }


    }
}
