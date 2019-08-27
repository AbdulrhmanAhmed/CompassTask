using CompassTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompassTask.Data
{
    public interface IUserRepository
    {
        Task <User> AddUser(User user);
        Task <User> EditUser(User user);
        Task <bool> EmailExist(string Email);
        Task < List<User>> GetUsers();
       Task <User> GetUser(int Id);
    }
}
