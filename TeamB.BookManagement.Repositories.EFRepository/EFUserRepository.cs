using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamB.Utils;

namespace TeamB.BookManagement.Repositories.EFRepository
{
    public class EFUserRepository : IRepository<User, string>
    {
        BMSContext context;
        public EFUserRepository(BMSContext context)
        {
            this.context = context;
        }
        public async Task<User> Add(User entity)
        {
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(string id)
        {
            await Task.CompletedTask;

            return context.Users.FirstOrDefault(a => a.Email == id);
        }

        public Task<User> Update(User entity, Action<User, User> mergeOldNew)
        {
            throw new NotImplementedException();
        }
    }
}
