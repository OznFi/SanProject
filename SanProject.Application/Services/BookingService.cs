using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SanProject.Application.Models;
using SanProject.Application.Services.Interfaces;
using SanProject.Data;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using SanProject.Domain.Booking;
using SanProject.Domain.SetReservation;
using SanProject.Shared.BookingModels;

namespace SanProject.Application.Services
{
    public class BookingService
    {
        public readonly IUnitOfWork _unitofwork;
        public readonly IEmailService _emailService;
        public string tokne { get; set; }
        private readonly ILogger<UsersService> _logger;
        public readonly IAuthenticationService _authenticationService;
        public BookingService(IUnitOfWork unitofwork, IEmailService emailservice,
            ILogger<UsersService> logger, IAuthenticationService authenticationService)
        {
            _unitofwork = unitofwork;
            _emailService = emailservice; ;
            _logger = logger;
            _authenticationService = authenticationService;

        }

        public async Task<string> BeginTransaction(string offerid, string currency, string culture)
        {

           /* if (tokne == null)
            {
                tokne = await _authenticationService.Login();
            }*/
            List<string> Query = new List<string>() { offerid };
            var searchobj = new
            {
                Currency = currency,
                Query,
                Culture = culture
            };
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/bookingservice/begintransaction", byteContent);
            var contents = await req.Content.ReadAsStringAsync();
            Root obj = JsonConvert.DeserializeObject<Root>(contents);
            
            return obj.body.transactionId;
        }

        public async Task<string> SetReservation(string transactid){

            RootReservation searchobj=new RootReservation();
            Domain.SetReservation.Traveller traveller1 =new Domain.SetReservation.Traveller();
            traveller1.travellerId = "1";traveller1.type = 1;traveller1.title = 1; traveller1.passengerType = 1;
            traveller1.name = "Name";traveller1.surname = "Surname";traveller1.isLeader = true;traveller1.birthDate = DateTime.Parse("1990 - 10 - 10");
            traveller1.nationality.twoLetterCode = "DE"; traveller1.identityNumber = "";
            traveller1.passportInfo.serial = "a";traveller1.passportInfo.number = "13";traveller1.passportInfo.expireDate = DateTime.Parse("2030-01-01");
            traveller1.passportInfo.issueDate = DateTime.Parse("2020-01-01");traveller1.passportInfo.citizenshipCountryCode = "";
            traveller1.address.contactPhone.countryCode = "90"; traveller1.address.contactPhone.areaCode = "555";traveller1.address.contactPhone.phoneNumber = "5555555";

            Domain.SetReservation.Traveller traveller2 = new Domain.SetReservation.Traveller();

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            return null;
        }
    }
}
