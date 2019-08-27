using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompassTask.Models;
using Microsoft.EntityFrameworkCore;

namespace CompassTask.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext )
        {
            this._dataContext = dataContext;
        }
        public async Task<User> AddUser(User user)
        {
           await _dataContext.Users.AddAsync(user);
           await _dataContext.SaveChangesAsync();
            return user;
        }

        public async  Task<User> EditUser(User user)
        {
             _dataContext.Users.Update(user);
            await  _dataContext.SaveChangesAsync();
            return user;

        }

        public async Task<bool> EmailExist(string Email)
        {
            if (await _dataContext.Users.AnyAsync(x => x.Email == Email))
                return true;

            return false;
          }

        public async Task<User> GetUser(int Id)
        {
          return  await _dataContext.Users.FindAsync(Id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dataContext.Users.ToListAsync();
        }
    }
}
