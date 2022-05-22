using Selskiyvrach.Core.StateMachines;
using Selskiyvrach.VampireHunter.Model.SceneLoading;

namespace Selskiyvrach.Core.Unity.Scenes
{
    public class LoadSceneState : SceneOperationState
    {
        public LoadSceneState(ISceneLoader sceneLoader, SceneID sceneID, IState decorated = null) : base(sceneLoader, sceneID, decorated) => 
            Decorated = new TaskState(() => sceneLoader.LoadScene(sceneID));

        public override void OnComplete(IState state) => 
            ((TaskState) Decorated).OnComplete(state);
    }
}