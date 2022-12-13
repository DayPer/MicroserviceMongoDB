using MongoDB.Driver;
using APIServiceTest.Core.ContextMongoDB;
using ServiceAPILibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIServiceTest.Core.Entities;

namespace APIServiceTest.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly ICardContext _cardContext;
        public CardRepository(ICardContext cardContext)
        {
            _cardContext = cardContext;
        }

        public  async Task<IEnumerable<Card>> GetCards()
        {
                        return await _cardContext.Cards.Find(p => true).ToListAsync();
        }
    }
}
