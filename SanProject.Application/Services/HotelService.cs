using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SanProject.Application.Models;
using SanProject.Application.Services.Interfaces;
using SanProject.Data;
using SanProject.Domain;
using SanProject.Domain.Hotel;
using SanProject.Shared.HotelModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SanProject.Application.Services
{
    public class HotelService : IHotelService
    {

        public readonly IUnitOfWork _unitofwork;
        public readonly IEmailService _emailService;
        public string tokne { get; set; }
        private readonly ILogger<UsersService> _logger;
        public readonly IAuthenticationService _authenticationService;
        public HotelService(IUnitOfWork unitofwork, IEmailService emailservice,
            ILogger<UsersService> logger, IAuthenticationService authenticationService)
        {
            _unitofwork = unitofwork;
            _emailService = emailservice; ;
            _logger = logger;
            _authenticationService = authenticationService;

        }
        //for get /pricesearch
        public async Task<HotelDetailDTO> GetDetails(string querys, int adultnum)
        {
            if (tokne == null)
            {
                tokne = await _authenticationService.Login();
            }
            /*var searchobj = new
            {
                checkAllotment= true,
                checkStopSale= true,
                getOnlyDiscountedPrice= false,
                getOnlyBestOffers= true,
                productType= 2,
                Products=[
                    querys
                ],
                roomCriteria=[
                new{
                    adult = 2
                }
                ],
                nationality= "DE",
                checkIn= "2022-10-17",
                night= 7,
                currency= "EUR",
                culture= "en-US"
            };*/
            RootQ searchobj = new RootQ();
            searchobj.Products.Add(querys); searchobj.roomCriteria[0].adult = adultnum;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/pricesearch", byteContent);
            var contents = await req.Content.ReadAsStringAsync();
            Root obj = JsonConvert.DeserializeObject<Root>(contents);
            HotelDetailDTO t = new HotelDetailDTO();
            Hotel hotelobj=new Hotel();
            //try
            if (obj.body == null)
            {
                return null;
            }
            //{
            hotelobj = obj.body.hotels[0];
            //}
            //why list?
            t.name = hotelobj.name; t.description = hotelobj.description; t.price = hotelobj.offers[0].price;
            t.rating = Math.Round(hotelobj.rating,1); t.rooms = hotelobj.offers[0].rooms; t.locationName = hotelobj.location.name;
            t.cancellationDueDate = hotelobj.offers[0].cancellationPolicies[0].dueDate;
            t.cancellationPrice = hotelobj.offers[0].cancellationPolicies[0].price.amount;
            t.cancellationCurrency = hotelobj.offers[0].cancellationPolicies[0].price.currency;
            t.offerId = hotelobj.offers[0].offerId; t.offerCheckIn = hotelobj.offers[0].checkIn;
            t.address = hotelobj.address; t.hotelCategory = hotelobj.hotelCategory; t.thumbnail = hotelobj.thumbnailFull;
            t.travellernum = hotelobj.offers[0].rooms[0].travellers.Count;
            return t;

            //List<Item> t = obj.body.items;
            //List<FullCity.Item>conten=new List<FullCity.Item>();
            /*List<CityObject> conten = new List<CityObject>();
            if (t.Count != 0)
            {
                for (int i = 0; i < t.Count; i++)
                {
                    if (t[i].country.name == "Turkey" && !(t[i].hotelCount == 0 || t[i].hotelCount == null))
                    {
                        CityObject c = new CityObject(); c.Name = t[i].city.name; c.HotelCount = t[i].hotelCount;
                        if (!conten.Contains(c))
                        {
                            conten.Add(c);
                        }

                    }
                }
            }*/
            
        }

        /*public async Task<List<CityObject>> Search(string querys)
        {
            if (tokne == null)
            {
                tokne = await _authenticationService.Login();
            }
            var searchobj = new
            {
                ProductType = "2",

                Product = querys,
                Culture = "en-US"
            };
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/productservice/getproductInfo", byteContent);
            var contents = await req.Content.ReadAsStringAsync();
            Root obj = JsonConvert.DeserializeObject<Root>(contents);
            List<Item> t = obj.body.items;
            //List<FullCity.Item>conten=new List<FullCity.Item>();
            List<CityObject> conten = new List<CityObject>();
            if (t.Count != 0)
            {
                for (int i = 0; i < t.Count; i++)
                {
                    if (t[i].country.name == "Turkey" && !(t[i].hotelCount == 0 || t[i].hotelCount == null))
                    {
                        CityObject c = new CityObject(); c.Name = t[i].city.name; c.HotelCount = t[i].hotelCount;
                        if (!conten.Contains(c))
                        {
                            conten.Add(c);
                        }

                    }
                }
            }
            return conten;
        }*/
    }
}
