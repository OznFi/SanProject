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
            _unitofwork._userrepository.Add(user);
            MailRequest mail = new MailRequest()
            {
                Body = "Kaydiniz yapildi",
                Subject = "Otel user kayit",
                ToEmail = ""
            };
            await _emailService.SendEmailAsync(mail);

            _unitofwork.Complete();
            _logger.LogInformation("{@user} kaydedildi", user);
        }
        public async Task DeleteUser(User user)
        {
            _unitofwork._userrepository.Remove(user);
            _unitofwork.Complete();
            _logger.LogInformation("{@user} silindi", user);
            await Task.CompletedTask;
        }
        public async Task EditUser()
        {
            //add editing
        }
    }
}
