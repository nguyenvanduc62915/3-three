using WebServicesAPI.DAL.Models;
using WebServicesAPI.DTO;

namespace WebServicesAPI.Services
{
    public interface IUserServices
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(AddUserRequest userRequest);
        void UpdateUser(UpdateUserRequest userRequest);
        void DeleteUser(int id);
    }
}
