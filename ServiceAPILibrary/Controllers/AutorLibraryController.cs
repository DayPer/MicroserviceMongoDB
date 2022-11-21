using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceAPILibrary.Core.Entities;
using ServiceAPILibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPILibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorLibraryController : ControllerBase
    {
        private readonly IMongoRepository<AutorEntity> _autorGenericRepository;

        public AutorLibraryController(IMongoRepository<AutorEntity> autorGenericRepository)
        {
            _autorGenericRepository = autorGenericRepository;
        }

        [HttpGet]
        //GetAll information Entity Autor
        public async Task<ActionResult<IEnumerable<AutorEntity>>> Get() 
        {
            return Ok( await _autorGenericRepository.GetAll());
        }

        [HttpGet("{Id}")]
        //Get by Id information Entity Autor
        public async Task<ActionResult<AutorEntity>> GetById(string Id)
        {
            var autor = await _autorGenericRepository.GetById(Id);
            return Ok(autor);
        }
        
        [HttpPost]
        public async Task Post(AutorEntity autor)
        {
            await _autorGenericRepository.InsertDocument(autor);
        }

        [HttpPut("{Id}")]
        public async Task  Put(string Id, AutorEntity autor)
        {
            autor.id = Id;
            await _autorGenericRepository.UpdatetDocument(autor);
              
        }

        [HttpDelete("{Id}")]
        public async Task Delete(string Id)
        {
        
            await _autorGenericRepository.DeleteById(Id);

        }

        [HttpPost("Pagination")]
        public async Task<ActionResult<PaginationEntity<AutorEntity>>> PostPagination(PaginationEntity<AutorEntity> _pagination)
        {
            var result = await _autorGenericRepository.PaginationByFilter(_pagination);
            return Ok(result);
        }

    }
}
