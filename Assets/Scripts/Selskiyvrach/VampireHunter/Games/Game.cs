namespace Selskiyvrach.VampireHunter.Gameplay.Model.Games
{
    public class Game 
    {
        public Game(GameplayState gameplayState) => 
            gameplayState.Enter();
    }
}