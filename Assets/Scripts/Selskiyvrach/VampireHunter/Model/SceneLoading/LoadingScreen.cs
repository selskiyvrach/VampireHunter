using System.Threading.Tasks;

namespace Selskiyvrach.VampireHunter.Model.SceneLoading
{
    public class LoadingScreen
    {
        private readonly ISceneLoader _sceneLoader;

        public LoadingScreen(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async Task Activate()
        {
            await _sceneLoader.LoadScene(new SceneID("loading_screen"));
                        
        }
    }
}