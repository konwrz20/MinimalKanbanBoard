using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MinimalKanbanBoard.Infrastructure {
    public static class MongoDatabaseExtensions {
        public static async Task<IEnumerable<TDocument>> GetAll<TDocument>(
            this IMongoDatabase database, Expression<Func<TDocument, bool>> filter = null,
            CancellationToken   cancellationToken = default
        ) where TDocument : MongoDocument {
            filter??=_ => true;

            var collection = database.GetCollection<TDocument>(CollectionName<TDocument>());
            return await collection.Find(filter).ToListAsync(cancellationToken);
        }

        public static async Task Insert<TDocument>(
            this IMongoDatabase database, TDocument document, CancellationToken cancellationToken = default
        ) where TDocument : MongoDocument {
            var collection = database.GetCollection<TDocument>(CollectionName<TDocument>());
            await collection.InsertOneAsync(document, cancellationToken: cancellationToken);
        }

        public static async Task Update<TDocument>(
            this IMongoDatabase database, Guid id, TDocument document, CancellationToken cancellationToken = default
        ) where TDocument : MongoDocument {
            var collection = database.GetCollection<TDocument>(CollectionName<TDocument>());
            await collection.ReplaceOneAsync(doc => doc.Id == id, document, cancellationToken: cancellationToken);
        }

        public static async Task Delete<TDocument>(
            this IMongoDatabase database, Guid id, CancellationToken cancellationToken = default
        ) where TDocument : MongoDocument {
            var collection = database.GetCollection<TDocument>(CollectionName<TDocument>());
            await collection.DeleteOneAsync(doc => doc.Id == id, cancellationToken);
        }

        private static string CollectionName<TDocument>() => typeof(TDocument).Name.ToLowerInvariant();
    }
}