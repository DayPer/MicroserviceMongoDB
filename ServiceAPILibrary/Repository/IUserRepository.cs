using APIServiceTest.Core.Entities;
using APIServiceTest.Core.Entities;
using ServiceAPILibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServiceTest.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
    }
}
