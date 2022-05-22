using Selskiyvrach.Core.StateMachines;
using Selskiyvrach.VampireHunter.Model.SceneLoading;

namespace Selskiyvrach.Core.Unity.Scenes
{
    public abstract class SceneOperationState : DecoratorState, IThroughState
    {
        public SceneOperationState(ISceneLoader sceneLoader, SceneID sceneID, IState decorated = null) : base(decorated)
        {
        }

        public abstract void OnComplete(IState state);
    }
}