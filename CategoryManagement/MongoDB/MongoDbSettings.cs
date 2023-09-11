namespace SceneManagement.MongoDB
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string SceneCollectionName { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }

    public interface IMongoDbSettings
    {
        string SceneCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
