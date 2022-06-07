using System.Collections.Generic;
using System.Linq;
using Selskiyvrach.Core.Tickers;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Model.Spreads
{
    public class SpreadCalculator: ITickable
    {
        private readonly ITicker _ticker;
        private readonly SpreadKickerFactory _spreadKickerFactory;
        private readonly AimSpreadFactory _aimSpreadFactory;
        private readonly GunBaseSpread _gunSpread;
        private readonly AimSpread _aimSpread;
        private readonly List<SpreadKicker> _spreadKickers = new List<SpreadKicker>();
        
        public Spread Spread { get; private set; }
        public bool FullyAimed => _aimSpread.FullyAimed;
        public bool ZeroAimed => _aimSpread.ZeroAimed;
        
        public SpreadCalculator(ITicker ticker, SpreadKickerFactory spreadKickerFactory, AimSpreadFactory aimSpreadFactory)
        {
            _ticker = ticker;
            _ticker.AddTickable(this);
            _spreadKickerFactory = spreadKickerFactory;
            _aimSpreadFactory = aimSpreadFactory;
            _gunSpread = new GunBaseSpread(5);
            _aimSpread = _aimSpreadFactory.Create(_gunSpread);
        }

        public void Tick(float deltaTime) =>
            Spread = new Spread(_aimSpread.Value + _spreadKickers.Sum(n => n.Value));

        public void StartAiming() => 
            _aimSpread.Aiming = true;

        public void StopAiming() => 
            _aimSpread.Aiming = false;

        public void Kick(float value)
        {
            var spreadKicker = GetKicker();
            spreadKicker.Start(value);
        }

        private SpreadKicker GetKicker()
        {
            SpreadKicker spreadKicker = null;
            for (var i = 0; i < _spreadKickers.Count; i++)
                if (_spreadKickers[i].Finished)
                    spreadKicker = _spreadKickers[i];
            if (spreadKicker == null)
            {
                spreadKicker = _spreadKickerFactory.Create();
                _spreadKickers.Add(spreadKicker);
            }
            return spreadKicker;
        }
    }

    public struct Spread
    {
        public float AngleDegrees { get; }

        public Spread(float angleDegrees) => 
            AngleDegrees = angleDegrees;
    }
}