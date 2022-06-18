using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Model.Players;

namespace Selskiyvrach.VampireHunter.Model.Games
{
    public class GameplayState
    {
        private readonly ITicker _ticker;
        private readonly Player _player;

        public GameplayState(ITicker ticker, Player player)
        {
            _ticker = ticker;
            _player = player;
        }

        public void Enter() => 
            _ticker.AddTickable(_player);
    }
}