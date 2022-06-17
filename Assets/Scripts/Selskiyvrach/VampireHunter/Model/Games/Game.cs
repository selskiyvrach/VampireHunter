using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Model.Gunslingers.Installers;
using Selskiyvrach.VampireHunter.Model.Players;

namespace Selskiyvrach.VampireHunter.Model.Games
{
    public class Game 
    {
        public Game(ITicker ticker, PlayerFactory playerFactory, GunslingerFactory gunslingerFactory)
        {
            ticker.AddTickable(playerFactory.Create(gunslingerFactory.Create()));
        }
    }
}