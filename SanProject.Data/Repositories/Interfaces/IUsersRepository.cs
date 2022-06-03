using SanProject.Domain;
using System.Collections.Generic;

namespace SanProject.Data.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        List<User> GetUsers();
    }
}