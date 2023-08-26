using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamB.Utils;

namespace TeamB.BookManagement
{
    public class PersistentUserService : IUserService
    {
        IRepository<User, string> repository;

        //constructor based DI
        public PersistentUserService(IRepository<User, string> repository)
        {
            this.repository = repository;
        }
        public async Task<User> AddUser(User user)
        {
            if (user == null)
                throw new InvalidDataException("User can't be null");

            return await repository.Add(user);
        }

        public Task DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(string id)
        {
            return await repository.GetById(id);
        }

        public Task<List<User>> SearchUsers(string term)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
