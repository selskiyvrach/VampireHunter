namespace Selskiyvrach.VampireHunter.Games
{
    public class Game 
    {
        public Game(GameplayState gameplayState) => 
            gameplayState.Enter();
    }
}