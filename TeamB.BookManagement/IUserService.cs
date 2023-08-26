using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamB.BookManagement
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(string id);
        Task<List<User>> SearchUsers(string term);
    }
}
