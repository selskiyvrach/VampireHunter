using System.Threading.Tasks;
using Selskiyvrach.Core.Unity.SceneLoading;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Games
{
    public class GameplayState
    {
        private const string GAMEPLAY_SCENE_NAME = "gameplay";
        private readonly ISceneLoader _sceneLoader;

        public GameplayState(ISceneLoader sceneLoader) => 
            _sceneLoader = sceneLoader;

        public async Task Enter() => 
            await _sceneLoader.LoadSceneAsync(GAMEPLAY_SCENE_NAME);

        public async Task Exit() =>
            await _sceneLoader.UnloadSceneAsync(GAMEPLAY_SCENE_NAME);
    }
}