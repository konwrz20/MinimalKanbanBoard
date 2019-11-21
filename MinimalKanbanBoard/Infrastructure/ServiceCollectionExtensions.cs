using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace MinimalKanbanBoard.Infrastructure {
    public static class ServiceCollectionExtensions {
        public static void AddMongo(this IServiceCollection services, string connectionString) {
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;
            var mongoClient  = new MongoClient(connectionString);

            services.AddSingleton(mongoClient.GetDatabase(databaseName));
        }
    }
}