using Selskiyvrach.Core.StateMachines;
using Selskiyvrach.VampireHunter.Model.SceneLoading;

namespace Selskiyvrach.Core.Unity.Scenes
{
    public class UnloadSceneState : SceneOperationState
    {
        public UnloadSceneState(ISceneLoader sceneLoader, SceneID sceneID, IState decorated = null) : base(sceneLoader, sceneID, decorated) => 
            Decorated = new TaskState(() => sceneLoader.UnloadScene(sceneID));
        
        public override void OnComplete(IState state) => 
            ((TaskState) Decorated).OnComplete(state);
    }
}