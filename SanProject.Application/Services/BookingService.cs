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
using SanProject.Domain.SetReservation.Reponse;
using SanProject.Domain.CommitReservation;

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
            traveller1.address.email = "email@test.com"; traveller1.address.address = ""; traveller1.address.zipCode = "";
            traveller1.address.city.id = ""; traveller1.address.city.name = ""; traveller1.address.country.id = ""; traveller1.address.country.name = "";
            traveller1.destinationAddress =new Domain.SetReservation.DestinationAddress();
            traveller1.orderNumber = 1; traveller1.documents = new List<object> { }; traveller1.insertFields= new List<object> { };
            traveller1.status = 0;

            Domain.SetReservation.Traveller traveller2 = new Domain.SetReservation.Traveller();
            traveller2.travellerId = "2"; traveller2.type = 1; traveller2.title = 3; traveller2.passengerType = 1;
            traveller2.name = "SecondName"; traveller2.surname = "Surname"; traveller2.isLeader = false; traveller2.birthDate = DateTime.Parse("1990-01-01");
            traveller2.nationality.twoLetterCode = "DE"; traveller2.identityNumber = "";
            traveller2.passportInfo.serial = "a"; traveller2.passportInfo.number = "19"; traveller2.passportInfo.expireDate = DateTime.Parse("2030-01-01");
            traveller2.passportInfo.issueDate = DateTime.Parse("2020-01-01"); traveller2.passportInfo.citizenshipCountryCode = "";
            traveller2.address.contactPhone.countryCode = ""; traveller2.address.contactPhone.areaCode = ""; traveller2.address.contactPhone.phoneNumber = "";
            traveller2.address.email = ""; traveller2.address.address = ""; traveller2.address.zipCode = "";
            traveller2.address.city.id = ""; traveller2.address.city.name = ""; traveller2.address.country.id = ""; traveller2.address.country.name = "";
            traveller2.destinationAddress = new Domain.SetReservation.DestinationAddress();
            traveller2.orderNumber = 1; traveller2.documents = new List<object> { }; traveller2.insertFields = new List<object> { };
            traveller2.status = 0;

            searchobj.transactionId = transactid; searchobj.travellers.Add(traveller1); searchobj.travellers.Add(traveller2);
            searchobj.reservationNote = "Reservation note"; searchobj.agencyReservationNumber = "Agency reservation number text";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/bookingservice/setreservationinfo", byteContent);
            var contents = await req.Content.ReadAsStringAsync();

            ReservationReponseRoot obj = JsonConvert.DeserializeObject<ReservationReponseRoot>(contents);
            return obj.body.transactionId;
        }

        public async Task<string> CommitReservation(string transactid)
        {
            var searchobj = new
            {
                TransactionId=transactid
            };
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/bookingservice/setreservationinfo", byteContent);
            var contents = await req.Content.ReadAsStringAsync();
            ReservationCommitRoot obj= JsonConvert.DeserializeObject<ReservationCommitRoot>(contents);
            return obj.body.reservationNumber;
        }


    }
}
