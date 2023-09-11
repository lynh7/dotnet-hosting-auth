using SceneManagement.Model;

namespace SceneManagement.IServices
{
    public interface ISceneService
    {
        Task<Scene> AddSceneAsync(Scene obj);
        Task<Scene> UpdateSceneAsync(string id, Scene obj);
        Task<bool> RemoveSceneAsync(string id);
        Task<Scene> GetByIdAsync(string id);
        Task<IEnumerable<Scene>> GetAll();
    }
}
