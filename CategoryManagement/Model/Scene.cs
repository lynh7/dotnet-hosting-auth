using CategoryManagement.Model.Base;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace SceneManagement.Model
{
    public class Scene : BaseEntity
    {
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string SceneName { get; set; } = null!;

    }
}
