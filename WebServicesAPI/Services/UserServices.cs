using Azure.Core;
using Microsoft.EntityFrameworkCore;
using WebServicesAPI.DAL.Data;
using WebServicesAPI.DAL.Models;
using WebServicesAPI.DAL.Repository;
using WebServicesAPI.DTO;

namespace WebServicesAPI.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _appDbContext;
        public UserServices(IUserRepository userRepository, AppDbContext appDbContext)
        {
            _userRepository = userRepository;
            _appDbContext = appDbContext;
        }
        public void AddUser(AddUserRequest userRequest)
        {
            using var transaction = _appDbContext.Database.BeginTransaction();
            try
            {
                var user = new User
                {
                    FullName = userRequest.FullName,
                    PhoneNumbers = userRequest.PhoneNumberDTO.Select(p => new PhoneNumber { Number = p.Number }).ToList(),
                    Addresses = userRequest.AddressDTO.Select(a => new Address { Location = a.Location }).ToList(),
                };
                _userRepository.AddUser(user);
                transaction.Commit();
            } catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public void UpdateUser(UpdateUserRequest userRequest)
        {
            using var transaction = _appDbContext.Database.BeginTransaction();
            try
            {
                var user = _userRepository.GetUserById(userRequest.Id);
                if (user != null)
                {
                    user.FullName = userRequest.FullName;

                    user.PhoneNumbers.Clear();
                    user.Addresses.Clear();

                    user.PhoneNumbers = userRequest.PhoneNumberDTO.Select(p => new PhoneNumber { Number = p.Number, UserId = userRequest.Id }).ToList();

                    user.Addresses = userRequest.AddressDTO.Select(a => new Address { Location = a.Location, UserId = userRequest.Id }).ToList();

                    _userRepository.UpdateUser(user);
                    transaction.Commit();
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
