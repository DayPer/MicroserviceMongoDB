
using ServiceAPILibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServiceAPILibrary.Repository
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {

        //CRUD
        Task<IEnumerable<TDocument>> GetAll();
        Task<TDocument> GetById(string id);
        Task InsertDocument(TDocument document);
        Task UpdatetDocument(TDocument document);
        Task DeleteById(string Id);

        Task<PaginationEntity<TDocument>> PaginationBy(
            Expression<Func<TDocument, bool>> filterExpresion, 
            PaginationEntity<TDocument> pagination
        );

        Task<PaginationEntity<TDocument>> PaginationByFilter(
            PaginationEntity<TDocument> pagination
);
    }
}
