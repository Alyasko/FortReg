using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace FortuneRegistry.Persistence
{
    public abstract class BaseRepository<T>
    {
        protected MongoClient DbClient { get; private set; }
        protected IMongoDatabase Database { get; private set; }

        protected BaseRepository()
        {
            DbClient = new MongoClient("mongodb://localhost:27117");
            Database = DbClient.GetDatabase("fortreg");
        }

        protected abstract string CollectionName { get; set; }

        public IMongoCollection<T> Collection => Database.GetCollection<T>(CollectionName);

        public async Task SaveAsync(T item, CancellationToken cancellationToken = default)
        {
            await Collection.InsertOneAsync(item, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task SaveAsync(IEnumerable<T> items, CancellationToken cancellationToken = default)
        {
            await Collection.InsertManyAsync(items, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await Collection.Find(expression).ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> QueryAllAsync(CancellationToken cancellationToken = default)
        {
            return await Collection.Find(FilterDefinition<T>.Empty).ToListAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
