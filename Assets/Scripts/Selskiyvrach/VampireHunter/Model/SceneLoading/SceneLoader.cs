using System.Threading.Tasks;
    
namespace Selskiyvrach.VampireHunter.Model.SceneLoading
{
    public interface ISceneLoader
    {
        Task LoadScene(SceneID sceneID);
        Task UnloadScene(SceneID sceneID);
    }
}