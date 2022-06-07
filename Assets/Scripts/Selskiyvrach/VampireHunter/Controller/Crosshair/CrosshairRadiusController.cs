using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Model.Players;
using Selskiyvrach.VampireHunter.View.Crosshair;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Controller.Crosshair
{
    public class CrosshairRadiusController : ITickable
    {
        private readonly ISpreadConeProvider _spreadConeProvider;
        private readonly ICrosshair _crosshair;
        private readonly Camera _camera;
        private readonly ITicker _ticker;

        public CrosshairRadiusController(
            ISpreadConeProvider spreadConeProvider,
            ICrosshair crosshair,
            Camera camera,
            ITicker ticker)
        {
            _spreadConeProvider = spreadConeProvider;
            _crosshair = crosshair;
            _camera = camera;
            _ticker = ticker;
            _ticker.AddTickable(this);
        }

        public void Tick(float deltaTime)
        {
            var ratio = _spreadConeProvider.SpreadCone.Angle / _camera.fieldOfView;
            _crosshair.SetRadius(_camera.pixelHeight * ratio);
        }
    }
}