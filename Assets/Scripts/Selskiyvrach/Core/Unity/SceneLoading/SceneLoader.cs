using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Selskiyvrach.Core.Unity.SceneLoading
{
    public class SceneLoader : ISceneLoader
    {
        public async Task LoadSceneAsync(string sceneName) => 
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        public async Task UnloadSceneAsync(string sceneName) => 
            await SceneManager.UnloadSceneAsync(sceneName);
    }
}