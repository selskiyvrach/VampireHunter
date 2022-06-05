using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Model.Gunslingers;
using UnityEngine;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Model.Player
{
    public class Player : ITickable
    {
        private readonly Gunslinger _gunslinger;
        private readonly Camera _camera;
        private readonly ITicker _ticker;

        public Player(Gunslinger gunslinger, Camera camera, ITicker ticker)
        {
            _gunslinger = gunslinger;
            _camera = camera;
            _ticker = ticker;
            _ticker.AddTickable(this);
        }

        public void Tick(float deltaTime)
        {
        }
    }
}