using Selskiyvrach.VampireHunter.Model.Gunslingers;
using Selskiyvrach.VampireHunter.Model.Gunslingers.Installers;
using Selskiyvrach.VampireHunter.Model.Players;

namespace Selskiyvrach.VampireHunter.Model.Games
{
    public class Game 
    {
        private readonly Player _player;
        private readonly Gunslinger _gunslinger;

        public Game(PlayerFactory playerFactory, GunslingerFactory gunslingerFactory)
        {
            _gunslinger = gunslingerFactory.Create();
            _player = playerFactory.Create(_gunslinger);
        }
    }
}