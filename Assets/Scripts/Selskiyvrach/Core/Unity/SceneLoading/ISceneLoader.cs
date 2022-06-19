using System.Threading.Tasks;

namespace Selskiyvrach.Core.Unity.SceneLoading
{
    public interface ISceneLoader
    {
        Task LoadSceneAsync(string sceneName);
        Task UnloadSceneAsync(string sceneName);
    }
}