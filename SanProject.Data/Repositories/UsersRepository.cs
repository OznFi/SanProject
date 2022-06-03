using SanProject.Data.Repositories.Interfaces;
using SanProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanProject.Data.Repositories
{
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        public UsersRepository(SanProjectDBContext context) : base(context)
        {

        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }


    }
}
