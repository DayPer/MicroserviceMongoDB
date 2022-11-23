using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ServiceAPILibrary.Core;
using ServiceAPILibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APIServiceCard.Repository
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IOptions<MongoSetting> options)
        {
            var client = new MongoClient(options.Value.ConnecionString);
            var database = client.GetDatabase(options.Value.DataBase);
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()).CollectionName;
        }
        public async Task<IEnumerable<TDocument>> GetAll()
        {
            return await _collection.Find(p => true).ToListAsync();
        }

        public async Task<TDocument> GetById(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.id, id);
           return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task InsertDocument(TDocument document)
        {
            await _collection.InsertOneAsync(document);

        }

        public async Task UpdatetDocument(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.id, document.id);
           await _collection.FindOneAndReplaceAsync(filter, document);
        }

        public async Task DeleteById(string Id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.id, Id);
            await _collection.FindOneAndDeleteAsync(filter);
        }

        public async Task<PaginationEntity<TDocument>> PaginationBy(Expression<Func<TDocument, bool>> filterExpresion, PaginationEntity<TDocument> _pagination)
        {
            var _sort = Builders<TDocument>.Sort.Ascending(_pagination.Sort);
            if (_pagination.SottiDirecction == "desc")
            {
                _sort = Builders<TDocument>.Sort.Descending(_pagination.Sort);
            }

            if (string.IsNullOrEmpty(_pagination.Filter))
            {
                _pagination.Data = await _collection.Find(p => true).Sort(_sort).
                    Skip((_pagination.Pege - 1) * _pagination.PegesSize).
                    Limit(_pagination.PegesSize).ToListAsync();
            }
            else {

                _pagination.Data = await _collection.Find(filterExpresion).Sort(_sort).
                    Skip((_pagination.Pege - 1) * _pagination.PegesSize).
                    Limit(_pagination.PegesSize).ToListAsync();
            }

            long _tatalDocuments = await _collection.CountDocumentsAsync(FilterDefinition<TDocument>.Empty);
            var _totalpage = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(_tatalDocuments / _pagination.PegesSize)));
            _pagination.PegesQuantity = _totalpage;

            return _pagination;
        }

        public async Task<PaginationEntity<TDocument>> PaginationByFilter(PaginationEntity<TDocument> _pagination)
        {
            var _sort = Builders<TDocument>.Sort.Ascending(_pagination.Sort);
            if (_pagination.SottiDirecction == "desc")
            {
                _sort = Builders<TDocument>.Sort.Descending(_pagination.Sort);
            }

            var _totalDocument = 0;

            if (_pagination.Filtervalue == null)
            {
                _pagination.Data = await _collection.Find(p => true).Sort(_sort).
                    Skip((_pagination.Pege - 1) * _pagination.PegesSize).
                    Limit(_pagination.PegesSize).ToListAsync();

                _totalDocument = (await _collection.Find(p => true).ToListAsync()).Count();
            }
            else
            {
                var _valueFilter = ".*" + _pagination.Filtervalue.Value + ".*";
                var _filter = Builders<TDocument>.Filter.Regex(_pagination.Filtervalue.Property, new MongoDB.Bson.BsonRegularExpression(_valueFilter, "i"));

                _pagination.Data = await _collection.Find(_filter).Sort(_sort).
                    Skip((_pagination.Pege - 1) * _pagination.PegesSize).
                    Limit(_pagination.PegesSize).ToListAsync();

                _totalDocument = (await _collection.Find(_filter).ToListAsync()).Count();

            }

            //long _tatalDocuments = await _collection.CountDocumentsAsync(FilterDefinition<TDocument>.Empty);
            var _rounded = Math.Ceiling(_totalDocument / Convert.ToDecimal(_pagination.PegesSize));

            var _totalpage = Convert.ToInt32(_rounded);

            _pagination.PegesQuantity = _totalpage;

            _pagination.totalRow = Convert.ToInt32(_totalDocument);

            return _pagination;
        }
    }
}
