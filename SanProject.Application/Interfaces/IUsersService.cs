using SanProject.Domain;
using System.Threading.Tasks;

namespace SanProject.Application.Services.Interfaces
{
    public interface IUsersService
    {
        Task AddUser(User user);
        Task DeleteUser(int id);
        Task EditUser();
        Task ActivateUser(int id);
        Task SoftDelete(User us);
    }
}