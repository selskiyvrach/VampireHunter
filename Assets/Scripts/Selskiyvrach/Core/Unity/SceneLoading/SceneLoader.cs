using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Selskiyvrach.Core.Unity.SceneLoading
{
    public class SceneLoader
    {
        public async Task LoadScene(string sceneName)
        {                                    
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
    }
}