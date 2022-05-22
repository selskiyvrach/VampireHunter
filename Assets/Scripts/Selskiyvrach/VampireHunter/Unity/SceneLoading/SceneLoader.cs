using System.Threading.Tasks;
using Selskiyvrach.VampireHunter.Controller.SceneLoading;
using UnityEngine.SceneManagement;

namespace Selskiyvrach.VampireHunter.Unity.SceneLoading
{
    public class SceneLoader
    {
        public async Task<Scene> LoadScene(string sceneName)
        {
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            await asyncOperation;
            return SceneManager.GetSceneByName(sceneName);
        }

        public async Task UnloadScene(string sceneName)
        {
            await SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}