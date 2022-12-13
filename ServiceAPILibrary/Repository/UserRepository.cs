using MongoDB.Driver;
using APIServiceTest.Core.ContextMongoDB;
using ServiceAPILibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIServiceTest.Core.Entities;
using APIServiceTest.Core.Entities;
using APIServiceTest.Core.ContextMongoDB;

namespace APIServiceTest.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _userContext;
        public UserRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public  async Task<IEnumerable<User>> GetUsers()
        {
                        return await _userContext.Users.Find(p => true).ToListAsync();
        }
    }
}
