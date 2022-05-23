using Selskiyvrach.Core;
using Selskiyvrach.Core.StateMachines;
using Selskiyvrach.VampireHunter.Model.SceneLoading;

namespace Selskiyvrach.VampireHunter.Model
{
    public class Game : ITickable
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly StateMachine _stateMachine;
        
        public Game(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = new StateMachine();
            var loadGameplaySceneState = CreateLoadGameplaySceneState();
            _stateMachine.StartState(loadGameplaySceneState);
        }

        private IState CreateLoadGameplaySceneState() =>
            new StateBuilder()
                .OnEnter(new ActionAction(() => _sceneLoader.LoadScene(new SceneID("Gameplay"))))
                .Build();

        public void Tick(float deltaTime) => 
            _stateMachine.Tick(deltaTime);
    }
}