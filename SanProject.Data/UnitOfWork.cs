using Microsoft.Extensions.Logging;
using SanProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanProject.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public UsersRepository _userrepository { get; }
        void Complete();
    }
    public  class UnitOfWork : IUnitOfWork
    {
        public readonly SanProjectDBContext _context;
        public UsersRepository _userrepository { get; private set; }
        public UnitOfWork(SanProjectDBContext context, UsersRepository userrepository)
        {
            _context=context;
            _userrepository=userrepository;
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
