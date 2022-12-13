using APIServiceTest.Core.Entities;
using APIServiceTest.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceAPILibrary.Core.Entities;
using ServiceAPILibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServiceTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IMongoRepository<CardEntity> _cardGenericRepository;

        public CardController(IMongoRepository<CardEntity> cardGenericRepository)
        {
            _cardGenericRepository = cardGenericRepository;
        }

        [HttpGet]
        //GetAll information Entity Card
        public async Task<ActionResult<IEnumerable<CardEntity>>> Get()
        {
            return Ok(await _cardGenericRepository.GetAll());
        }

        [HttpGet("{Id}")]
        //Get by Id information Entity Card
        public async Task<ActionResult<CardEntity>> GetById(string Id)
        {
            var autor = await _cardGenericRepository.GetById(Id);
            return Ok(autor);
        }

        [HttpPost]
        public async Task Post(CardEntity card)
        {
            await _cardGenericRepository.InsertDocument(card);
        }

        [HttpPut("{Id}")]
        public async Task Put(string Id, CardEntity card)
        {
            card.id = Id;
            await _cardGenericRepository.UpdatetDocument(card);

        }

        [HttpDelete("{Id}")]
        public async Task Delete(string Id)
        {

            await _cardGenericRepository.DeleteById(Id);

        }

        [HttpPost("Pagination")]
        public async Task<ActionResult<PaginationEntity<CardEntity>>> PostPagination(PaginationEntity<CardEntity> _pagination)
        {
            var result = await _cardGenericRepository.PaginationByFilter(_pagination);
            return Ok(result);
        }

    }
}
