using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Model.Players;
using Selskiyvrach.VampireHunter.View.Crosshair;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Controller.Crosshair
{
    public class CrosshairRadiusController : ITickable
    {
        private readonly ICrosshair _crosshair;
        private readonly ITicker _ticker;
        private readonly Camera _camera;
        private readonly IWeaponSpread _weaponSpread;

        public CrosshairRadiusController(
            IWeaponSpread weaponSpread,
            ICrosshair crosshair,
            Camera camera,
            ITicker ticker)
        {
            _weaponSpread = weaponSpread;
            _crosshair = crosshair;
            _camera = camera;
            _ticker = ticker;
            _ticker.AddTickable(this);
        }

        public void Tick(float deltaTime)
        {
            var ratio = _weaponSpread.Spread.AngleDegrees / _camera.fieldOfView;
            _crosshair.SetRadius(_camera.pixelHeight * ratio);
        }
    }
}