using System.Threading.Tasks;
using Selskiyvrach.Core.Unity;
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