using APIServiceTest.Repository;
using APIServiceTest.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServiceTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMongoRepository<UserEntity> _userGenericRepository;

        public UserController(IMongoRepository<UserEntity> userGenericRepository)
        {
            _userGenericRepository = userGenericRepository;
        }

        [HttpGet]
        //GetAll information Entity Card
        public async Task<ActionResult<IEnumerable<UserEntity>>> Get()
        {
            return Ok(await _userGenericRepository.GetAll());
        }

        [HttpGet("{Id}")]
        //Get by Id information Entity Card
        public async Task<ActionResult<User>> GetById(string Id)
        {
            var autor = await _userGenericRepository.GetById(Id);
            return Ok(autor);
        }

        [HttpPost]
        public async Task Post(UserEntity user)
        {
            await _userGenericRepository.InsertDocument(user);
        }

        [HttpPut("{Id}")]
        public async Task Put(string Id, UserEntity user)
        {
            user.id = Id;
            await _userGenericRepository.UpdatetDocument(user);

        }

        [HttpDelete("{Id}")]
        public async Task Delete(string Id)
        {

            await _userGenericRepository.DeleteById(Id);

        }

    }
}
