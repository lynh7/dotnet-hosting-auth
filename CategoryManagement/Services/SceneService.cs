using SceneManagement.IRepository;
using SceneManagement.IServices;
using SceneManagement.Model;

namespace SceneManagement.Services
{
    public class SceneService : ISceneService
    {
        private readonly ISceneRepository _sceneRepository;
        public SceneService(ISceneRepository sceneRepository)
        {
            _sceneRepository = sceneRepository;
        }
        public async Task<Scene> AddSceneAsync(Scene obj)
        {
            return await _sceneRepository.Add(obj);
        }

        public async Task<IEnumerable<Scene>> GetAll()
        {
            return await _sceneRepository.GetAll();
        }

        public async Task<Scene> GetByIdAsync(string id)
        {
            return await _sceneRepository.GetById(id);
        }

        public async Task<bool> RemoveSceneAsync(string id)
        {
            return await _sceneRepository.Remove(id);
        }

        public async Task<Scene> UpdateSceneAsync(string id, Scene obj)
        {
            return await _sceneRepository.Update(id, obj);
        }
    }
}
