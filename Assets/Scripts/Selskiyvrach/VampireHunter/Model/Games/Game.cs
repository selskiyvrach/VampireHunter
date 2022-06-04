using Selskiyvrach.VampireHunter.Model.Games.Installers;
using Selskiyvrach.VampireHunter.Model.Gunslingers.Installers;

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
        public GameplayState(GunslingerFactory gunslingerFactory)
        {
            var gunslinger = gunslingerFactory.Create();
        }
    }
}