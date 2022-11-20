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
    public class ServicesLibraryController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;

        private readonly IMongoRepository<AutorEntity> _autoGenericoRepository;

        private readonly IMongoRepository<EmployeeEntity> _employeeGenericRepository;

        public ServicesLibraryController(IAutorRepository autorRepository, IMongoRepository<AutorEntity> autoGenericoRepository, IMongoRepository<EmployeeEntity> employeeGenericRepository)
        {
            _autorRepository = autorRepository;
            _autoGenericoRepository = autoGenericoRepository;
            _employeeGenericRepository = employeeGenericRepository;

        }

        [HttpGet("GenericEmployee")]  
        public async Task<ActionResult<IEnumerable<EmployeeEntity>>> GetGenericEmployee()
        {
            var GenericaEmployee = await _employeeGenericRepository.GetAll();
            return Ok(GenericaEmployee);
        }


        [HttpGet("Genericautors")]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> GetGenericAutors()
        {
            var Genericautors = await _autoGenericoRepository.GetAll();
            return Ok(Genericautors);
        }

        [HttpGet("autors")]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutors()
        {
            var autors = await _autorRepository.GetAutors();
            return Ok(autors);
        }

    }
}
