using System.Threading.Tasks;
using Selskiyvrach.VampireHunter.Controller.SceneLoading;
using UnityEngine.SceneManagement;

namespace Selskiyvrach.VampireHunter.Unity.SceneLoading
{
    public class SceneLoader
    {
        public async Task LoadScene(string sceneName)
        {
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
    }
}