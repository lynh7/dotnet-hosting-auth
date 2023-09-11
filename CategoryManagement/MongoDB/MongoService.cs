using MongoDB.Driver;

namespace SceneManagement.MongoDB
{
    public class MongoService : IMongoService
    {
        public MongoService(IMongoDbSettings mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.ConnectionString);
            Database = client.GetDatabase(mongoDBSettings.DatabaseName);
        }
        public IMongoDatabase Database { get; }
    }

    public interface IMongoService
    {
        IMongoDatabase Database { get; }
    }

}
