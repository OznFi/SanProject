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
using SanProject.Domain.ReservationDetails;
using SanProject.Domain;

namespace SanProject.Application.Services
{
    public class BookingService : IBookingService
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

        public async Task<Root> BeginTransaction(string offerid, string currency, string culture)
        {

            /* if (tokne == null)
             {
                 tokne = await _authenticationService.Login();
             }*/
            List<string> Query = new List<string>() { offerid };
            var searchobj = new
            {
                currency = currency,
                offerIds=Query,
                culture = culture
            };
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/bookingservice/begintransaction", byteContent);
            var contents = await req.Content.ReadAsStringAsync();
            Root obj = JsonConvert.DeserializeObject<Root>(contents);

            return obj;
        }

        public async Task<string> SetReservation(Root ob, List<Domain.SetReservation.Traveller> manyt)
        {

            RootReservation searchobj = new RootReservation();
            Domain.SetReservation.Traveller traveller1 = new Domain.SetReservation.Traveller();
            /* traveller1.travellerId = "1";traveller1.type = 1;traveller1.title = 1; traveller1.passengerType = 1;
             traveller1.name = "Name";traveller1.surname = "Surname";traveller1.isLeader = true;traveller1.birthDate = DateTime.Parse("1990 - 10 - 10");
             traveller1.nationality.twoLetterCode = "DE"; traveller1.identityNumber = "";
             traveller1.passportInfo.serial = "a";traveller1.passportInfo.number = "13";traveller1.passportInfo.expireDate = DateTime.Parse("2030-01-01");
             traveller1.passportInfo.issueDate = DateTime.Parse("2020-01-01");traveller1.passportInfo.citizenshipCountryCode = "";
             traveller1.address.contactPhone.countryCode = "90"; traveller1.address.contactPhone.areaCode = "555";traveller1.address.contactPhone.phoneNumber = "5555555";
             traveller1.address.email = "email@test.com"; traveller1.address.address = ""; traveller1.address.zipCode = "";
             traveller1.address.city.id = ""; traveller1.address.city.name = ""; traveller1.address.country.id = ""; traveller1.address.country.name = "";
             traveller1.destinationAddress =new Domain.SetReservation.DestinationAddress();
             traveller1.orderNumber = 1; traveller1.documents = new List<object> { }; traveller1.insertFields= new List<object> { };
             traveller1.status = 0;*/

            Domain.SetReservation.Traveller traveller2 = new Domain.SetReservation.Traveller();
            List<Domain.SetReservation.Traveller> tlist = new List<Domain.SetReservation.Traveller>();

            /*traveller2.travellerId = "2"; traveller2.type = 1; traveller2.title = 3; traveller2.passengerType = 1;
            traveller2.name = "SecondName"; traveller2.surname = "Surname"; traveller2.isLeader = false; traveller2.birthDate = DateTime.Parse("1990-01-01");
            traveller2.nationality.twoLetterCode = "DE"; traveller2.identityNumber = "";
            traveller2.passportInfo.serial = "a"; traveller2.passportInfo.number = "19"; traveller2.passportInfo.expireDate = DateTime.Parse("2030-01-01");
            traveller2.passportInfo.issueDate = DateTime.Parse("2020-01-01"); traveller2.passportInfo.citizenshipCountryCode = "";
            traveller2.address.contactPhone.countryCode = ""; traveller2.address.contactPhone.areaCode = ""; traveller2.address.contactPhone.phoneNumber = "";
            traveller2.address.email = ""; traveller2.address.address = ""; traveller2.address.zipCode = "";
            traveller2.address.city.id = ""; traveller2.address.city.name = ""; traveller2.address.country.id = ""; traveller2.address.country.name = "";
            traveller2.destinationAddress = new Domain.SetReservation.DestinationAddress();
            traveller2.orderNumber = 1; traveller2.documents = new List<object> { }; traveller2.insertFields = new List<object> { };
            traveller2.status = 0;*/
            List<Domain.Booking.Traveller> ta = ob.body.reservationData.travellers;
            List<Domain.SetReservation.Traveller>ts=new List<Domain.SetReservation.Traveller>();
            for (int i = 0; i < ta.Count; i++)
            {
                Domain.SetReservation.Traveller traveller = new Domain.SetReservation.Traveller();
                traveller.address = new Domain.SetReservation.Address();
                if (manyt[i].address.email=="" || manyt[i].address.email==null)
                {
                    traveller.address.email = "";
                }
                else
                {
                    traveller.address.email = manyt[i].address.email;
                }
                traveller.travellerId = ta[i].travellerId; traveller.type = ta[i].type; traveller.title = ta[i].title;
                traveller.passengerType = ta[i].passengerType; traveller.name = manyt[i].name; traveller.surname = manyt[i].surname;
                traveller.isLeader = ta[i].isLeader; traveller.birthDate = ta[i].birthDate; 
                traveller.nationality=new Domain.SetReservation.Nationality();
                traveller.nationality.twoLetterCode = ta[i].nationality.twoLetterCode; traveller.identityNumber = ta[i].identityNumber;
                traveller.passportInfo = new Domain.SetReservation.PassportInfo();
                traveller.passportInfo.serial = "a"; traveller.passportInfo.number = "13"; traveller.passportInfo.issueDate = DateTime.Parse("2020-01-01");
                traveller.passportInfo.expireDate = DateTime.Parse("2030-01-01"); traveller.passportInfo.citizenshipCountryCode = "";
                traveller.address.contactPhone=new Domain.SetReservation.ContactPhone();
                traveller.address.contactPhone.countryCode = ""; traveller.address.contactPhone.areaCode = ""; traveller.address.contactPhone.phoneNumber = "";
                traveller.address.email = ""; traveller.address.address = ""; traveller.address.zipCode = "";
                traveller.address.city = new Domain.SetReservation.City(); traveller.address.country= new Domain.SetReservation.Country();
                traveller.address.city.id = ""; traveller.address.city.name = ""; traveller.address.country.id = ""; traveller.address.country.name = "";
                ts.Add(traveller);
            }
            searchobj.travellers = ts;
            searchobj.transactionId = ob.body.transactionId;
            searchobj.reservationNote = "Reservation note"; searchobj.agencyReservationNumber = "Agency reservation number text";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/bookingservice/setreservationinfo", byteContent);
            var contents = await req.Content.ReadAsStringAsync();

            ReservationReponseRoot obj = JsonConvert.DeserializeObject<ReservationReponseRoot>(contents);
            if (obj.body == null)
            {
                return null;
            }
            return obj.body.transactionId;
        }

        public async Task<string> CommitReservation(string transactid)
        {
            var searchobj = new
            {
                TransactionId = transactid
            };
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/bookingservice/committransaction", byteContent);
            var contents = await req.Content.ReadAsStringAsync();
            ReservationCommitRoot obj = JsonConvert.DeserializeObject<ReservationCommitRoot>(contents);
            //if (obj.body == null)
            //{
              //  return null;
            //}
            return obj.body.reservationNumber;
        }

        public async Task<ReservationDetailDTO> GetReservationDetails(string reservationid)
        {
            var searchobj = new
            {
                reservationNumber = reservationid
            };
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokne);
            var content = JsonConvert.SerializeObject(searchobj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = await client.PostAsync("http://service.stage.paximum.com/v2/api/bookingservice/getreservationdetail", byteContent);
            var contents = await req.Content.ReadAsStringAsync();
            ReservationDetailRoot obj = JsonConvert.DeserializeObject<ReservationDetailRoot>(contents);
            ReservationDBDTO dbobj= new ReservationDBDTO();
            ReservationDetailDTO detaildto = new ReservationDetailDTO();
            
            //fill the view dto
            detaildto.travellers = obj.body.reservationData.travellers; detaildto.expiresOn = obj.body.expiresOn;
            detaildto.bookingNumber = obj.body.reservationData.reservationInfo.bookingNumber;
            detaildto.agency = obj.body.reservationData.reservationInfo.agency;
            detaildto.agencyUser = obj.body.reservationData.reservationInfo.agencyUser;
            detaildto.beginDate = obj.body.reservationData.reservationInfo.beginDate;
            detaildto.endDate = obj.body.reservationData.reservationInfo.endDate;
            detaildto.agencyReservationNumber = obj.body.reservationData.reservationInfo.agencyReservationNumber;
            detaildto.paymentDetail = obj.body.reservationData.paymentDetail;
            detaildto.documenturl = obj.body.reservationData.reservationInfo.documents[0].url;
            detaildto.serviceDetails = obj.body.reservationData.services[0].serviceDetails;

            //fill DB dto
            dbobj.reservationNumber = obj.body.reservationNumber; dbobj.buyerId = detaildto.travellers[0].travellerId;
            dbobj.travellerNumber = detaildto.travellers.Count; dbobj.paymentNo = detaildto.paymentDetail.paymentPlan[0].paymentNo;
            dbobj.paymentAmount = detaildto.paymentDetail.paymentPlan[0].price.amount;
            dbobj.paymetCurrency = detaildto.paymentDetail.paymentPlan[0].price.currency;
            dbobj.bookingNumber = detaildto.bookingNumber; dbobj.beginDate = detaildto.beginDate;
            dbobj.endDate = detaildto.endDate; dbobj.serviceId = detaildto.serviceDetails.serviceId;
            dbobj.hotelName = detaildto.serviceDetails.hotelDetail.name;
            dbobj.hotelPhoneNumber = detaildto.serviceDetails.hotelDetail.phoneNumber;
            dbobj.hotelHomePage= detaildto.serviceDetails.hotelDetail.homePage;
            dbobj.hotelCity = detaildto.serviceDetails.hotelDetail.city.name;
            dbobj.hotelCountry=detaildto.serviceDetails.hotelDetail.country.name;

            _unitofwork.ReservationsRepository.Add(dbobj);
            _unitofwork.Complete();

            return detaildto;
        }

        public async Task<ReservationDetailDTO> FullBooking(string offerId, string currency, string culture, List<Domain.SetReservation.Traveller> manyt)
        {
            if (tokne == null)
            {
                tokne = await _authenticationService.Login();
            }
            Root beginstransact = await BeginTransaction(offerId, currency, culture);
            string transactid = await SetReservation(beginstransact, manyt);
            string reservenumber = await CommitReservation(transactid);
            ReservationDetailDTO detaildot = await GetReservationDetails(reservenumber);
            return detaildot;
        }
    }
}
