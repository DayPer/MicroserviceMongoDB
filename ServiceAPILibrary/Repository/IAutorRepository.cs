using ServiceAPILibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServiceCard.Repository
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAutors();
    }
}
