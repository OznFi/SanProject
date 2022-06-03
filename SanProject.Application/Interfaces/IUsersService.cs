using SanProject.Domain;
using System.Threading.Tasks;

namespace SanProject.Application.Services.Interfaces
{
    public interface IUsersService
    {
        Task AddUser(User user);
        Task DeleteUser(User user);
        Task EditUser();
    }
}