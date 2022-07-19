using System.Threading.Tasks;
using Selskiyvrach.Core.Lifecycle;
using Selskiyvrach.Core.Tickers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Selskiyvrach.Core.Unity.SceneLoading
{
    public class SceneLoader : ISceneLoader
    {
        public async Task<SceneEntryPoint> LoadSceneAsync(string sceneName)
        {
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            return GetEntryPoint(sceneName);
        }

        public async Task UnloadSceneAsync(string sceneName) =>
            await SceneManager.UnloadSceneAsync(sceneName);

        private static SceneEntryPoint GetEntryPoint(string sceneName)
        {
            var scene = SceneManager.GetSceneByName(sceneName);
            var rootObjects = scene.GetRootGameObjects();
            var entryPoint = rootObjects[0].GetComponent<SceneEntryPoint>();
            return entryPoint;
        }
    }

    public class SceneEntryPoint : MonoBehaviour, IInitializable, IResourceReleaser
    {
        public Task Initialize()
        {
            throw new System.NotImplementedException();
        }

        public Task ReleaseResources()
        {
            throw new System.NotImplementedException();
        }
    }
}