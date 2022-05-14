using System.Threading.Tasks;

namespace Selskiyvrach.VampireHunter.Model.SceneLoading
{
    public interface ISceneLoader
    {
        Task LoadScene(SceneID sceneID);
    }

    public struct SceneID
    {
        public string Name { get; set; }
    }
}