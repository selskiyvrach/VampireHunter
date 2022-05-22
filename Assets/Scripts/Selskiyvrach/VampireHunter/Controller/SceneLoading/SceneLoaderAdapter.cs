using System.Threading.Tasks;
using Selskiyvrach.VampireHunter.Model.SceneLoading;
using Selskiyvrach.VampireHunter.Unity.SceneLoading;

namespace Selskiyvrach.VampireHunter.Controller.SceneLoading
{
    public class SceneLoaderAdapter : ISceneLoader
    {
        private readonly SceneLoader _sceneLoader;

        public SceneLoaderAdapter(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async Task LoadScene(SceneID sceneID)
        {
            await _sceneLoader.LoadScene(sceneID.Name);
        }

        public async Task UnloadScene(SceneID sceneID)
        {
            await _sceneLoader.UnloadScene(sceneID.Name);
        }
    }
}
