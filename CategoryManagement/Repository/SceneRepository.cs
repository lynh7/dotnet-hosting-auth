using SceneManagement.IRepository;
using SceneManagement.Model;
using SceneManagement.MongoDB;
using SceneManagement.Repository.Base;

namespace SceneManagement.Repository
{
    public class SceneRepository : MongoRepository<Scene>, ISceneRepository
    {
        public SceneRepository(IMongoService context) : base(context)
        {
        }
    }
}
