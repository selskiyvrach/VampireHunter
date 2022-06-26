using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Gameplay.Model.Players;
using Selskiyvrach.VampireHunter.Gameplay.View.Crosshairs;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Mediator.Crosshairs
{
    public class CrosshairMediator : ITickable
    {
        private readonly ICrosshair _crosshair;
        private readonly Camera _camera;
        private readonly Player _player;
        private readonly ITicker _ticker;

        public CrosshairMediator(ICrosshair crosshair, Camera camera, Player player, ITicker ticker)
        {
            _crosshair = crosshair;
            _camera = camera;
            _player = player;
            _ticker = ticker;
            _ticker.AddTickable(this);
        }

        public void Tick(float deltaTime)
        {
            var spreadToFovRatio = _player.GunSpread.AngleDegrees / _camera.fieldOfView;
            var crosshairHeight = _camera.pixelHeight * spreadToFovRatio; 
            _crosshair.SetRadius(crosshairHeight);
        }
    }
}