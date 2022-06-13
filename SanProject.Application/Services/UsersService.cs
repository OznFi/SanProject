using Microsoft.Extensions.Logging;
using SanProject.Application.Models;
using SanProject.Application.Services.Interfaces;
using SanProject.Data;
using SanProject.Domain;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanProject.Application.Services
{
    public class UsersService : IUsersService
    {
        public readonly IUnitOfWork _unitofwork;
        public readonly IEmailService _emailService;
        private readonly ILogger<UsersService> _logger;
        public UsersService(IUnitOfWork unitofwork, IEmailService emailservice, ILogger<UsersService> logger)
        {
            _unitofwork = unitofwork;
            _emailService = emailservice; ;
            _logger = logger;
        }
        
        public async Task AddUser(User user)
        {
            //Log.Logger = new LoggerConfiguration()
            //.WriteTo.RollingFile(new JsonFormatter(), Path.Combine(@"c:\log", "[filename]-{Date}.txt"))
            //.CreateLogger();
          // var log = new LoggerConfiguration()
            //.MinimumLevel.Debug()
            //.WriteTo.File(@"SanProject\SanProject.Web\Serilogs\Applogs.log")
            //.CreateLogger();
            user.RegistryDate = DateTime.Now;
            user.IsActive = true;
            _unitofwork.UsersRepository.Add(user);
            MailRequest mail = new MailRequest()
            {
                Body = "Kaydiniz yapildi",
                Subject = "Otel user kayit",
                ToEmail = user.Email
            };
            await _emailService.SendEmailAsync(mail);

            _unitofwork.Complete();
            _logger.LogInformation("{@user} kaydedildi", user);
        }
        
        public async Task EditUser(User us)
        {
            
            _unitofwork.UsersRepository.EditUser(us);
            _unitofwork.Complete();
            _logger.LogInformation("{@us} updated", us);
            //add editing
        }


        public async Task DeleteUser(int id)
        {
            User us = _unitofwork.UsersRepository.FindUser(id);
            _unitofwork.UsersRepository.Remove(us);
            _unitofwork.Complete();
            _logger.LogInformation("{@us} silindi", us);
            await Task.CompletedTask;
        }
        public async Task SoftDelete(User us)
        {
            //User us = _unitofwork.UsersRepository.FindUser(id);
            us.IsDeleted = !us.IsDeleted;
            _unitofwork.UsersRepository.SoftDeleteUser(us);
            _unitofwork.Complete();
            _logger.LogInformation("{@us} soft silindi", us);
        }
        public async Task ActivateUser(int id)
        {
            User us = _unitofwork.UsersRepository.FindUser(id);
            bool act = us.IsActive;
            us.IsActive = !act;
            _unitofwork.UsersRepository.ActivateUser(us);
            _unitofwork.Complete();
            _logger.LogInformation("{@id} numarali user aktifligi degistirildi", id);
            await Task.CompletedTask;

        }
    }
}
