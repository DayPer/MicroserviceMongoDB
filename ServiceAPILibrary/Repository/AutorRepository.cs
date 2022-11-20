using MongoDB.Driver;
using ServiceAPILibrary.Core.ContextMongoDB;
using ServiceAPILibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPILibrary.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly IAutorContext _autorContext;
        public AutorRepository(IAutorContext autorContext)
        {
            _autorContext = autorContext;
        }
        public async Task<IEnumerable<Autor>> GetAutors()
        {
            return await _autorContext.Autores.Find(p => true).ToListAsync();
        }


    }
}
