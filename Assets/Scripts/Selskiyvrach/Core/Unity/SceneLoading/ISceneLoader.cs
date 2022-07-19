using System.Threading.Tasks;

namespace Selskiyvrach.Core.Unity.SceneLoading
{
    public interface ISceneLoader
    {
        Task<SceneEntryPoint> LoadSceneAsync(string sceneName);
        Task UnloadSceneAsync(string sceneName);
    }
}