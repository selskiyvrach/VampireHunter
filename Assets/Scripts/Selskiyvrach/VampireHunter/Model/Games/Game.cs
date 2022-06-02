using Selskiyvrach.VampireHunter.Model.Games.Installers;

namespace Selskiyvrach.VampireHunter.Model.Games
{
    public class Game
    {
        private GameplayState _gameplayState;
        
        public Game(GameplayFactory gameplayFactory) => 
            _gameplayState = gameplayFactory.Create();
    }
    
    public class GameplayState
    {
    }
}