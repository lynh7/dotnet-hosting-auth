using Microsoft.AspNetCore.Mvc;
using SceneManagement.IServices;
using SceneManagement.Model;

namespace SceneManagement.Controllers
{
    [ApiController]
    [Route("~/api/[controller]")]
    public class SceneController : ControllerBase
    {
        private readonly ISceneService _sceneService;

        public SceneController(ISceneService sceneService)
        {
            _sceneService = sceneService;
        }
        [HttpGet]
        public async Task<IEnumerable<Scene>> Get() =>
           await _sceneService.GetAll();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Scene>> Get(string id)
        {
            var Scene = await _sceneService.GetByIdAsync(id);

            if (Scene is null)
            {
                return NotFound();
            }

            return Scene;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Scene newScene)
        {
            await _sceneService.AddSceneAsync(newScene);

            return CreatedAtAction(nameof(Get), new { id = newScene.Id }, newScene);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Scene updatedScene)
        {
            var Scene = await _sceneService.GetByIdAsync(id);

            if (Scene is null)
            {
                return NotFound();
            }

            updatedScene.Id = Scene.Id;

            await _sceneService.UpdateSceneAsync(id, updatedScene);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Scene = await _sceneService.GetByIdAsync(id);

            if (Scene is null)
            {
                return NotFound();
            }

            await _sceneService.RemoveSceneAsync(id);

            return NoContent();
        }
    }
}
