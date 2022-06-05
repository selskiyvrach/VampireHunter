using System.Collections.Generic;
using System.Linq;
using Selskiyvrach.Core.Tickers;
using Selskiyvrach.VampireHunter.Model.Guns;
using UnityEngine;
using ITickable = Selskiyvrach.Core.Tickers.ITickable;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public abstract class SpreadTerm
    {
        public float Value { get; protected set; }
    }

    public class StaticSpread : SpreadTerm
    {
        public StaticSpread(float value) => 
            Value = value;

        public StaticSpread SetValue(float value)
        {
            Value = value;
            return this;
        }
    }

    public class AimSpread : SpreadTerm, ITickable
    {
        private readonly StaticSpread _baseSpread;
        private readonly float _aimedCoefficient;
        private readonly ITicker _ticker;

        private readonly float _toAimDuration;
        private readonly float _fromAimDuration;
        private float _normalizedPos;
        
        public bool Aiming { get; set; }
        public bool FullyAimed => _normalizedPos >= 1;
        public bool ZeroAimed => _normalizedPos <= 0;

        public AimSpread(StaticSpread baseSpread, float aimedCoefficient, float toAimDuration, float fromAimDuration, ITicker ticker)
        {
            _baseSpread = baseSpread;
            _aimedCoefficient = aimedCoefficient;
            _ticker = ticker;
            _ticker.AddTickable(this);
            _toAimDuration = toAimDuration;
            _fromAimDuration = fromAimDuration;
        }

        public void Tick(float deltaTime)
        {
            if (Aiming && !FullyAimed) 
                _normalizedPos += deltaTime / _toAimDuration;

            if (!Aiming && !ZeroAimed) 
                _normalizedPos -= deltaTime / _fromAimDuration;

            Value = Mathf.Lerp(_baseSpread.Value, _baseSpread.Value * _aimedCoefficient, _normalizedPos);
        }
    }
    
    public class SpreadKicker : SpreadTerm, ITickable
    {
        private readonly float _duration;
        private readonly float _targetValue;
        private readonly AnimationCurve _curve;
        private readonly ITicker _ticker;

        private float _timePassedNormalized;
        public bool Finished => _timePassedNormalized >= 1;

        public SpreadKicker(float duration, float targetValue, AnimationCurve curve, ITicker ticker)
        {
            _duration = duration;
            _targetValue = targetValue;
            _curve = curve;
            _ticker = ticker;
            _ticker.AddTickable(this);
        }

        public void Start() => 
            _timePassedNormalized = 0;

        public void Tick(float deltaTime)
        {
            if(Finished)
                return;
            
            _timePassedNormalized += deltaTime / _duration;
            Value = _targetValue * _curve.Evaluate(_timePassedNormalized);
        }
    }
    
    public class Aimer
    {
        public Vector3 AimDirection { get; private set; }
        
        public void AdjustAimDirection(Vector2 delta) => 
            AimDirection += (Vector3)delta;
    }
    
    public class SpreadController: ITickable
    {
        private readonly ITicker _ticker;
        private readonly AnimationCurve _kickCurve;
        private readonly StaticSpread _gunSpread;
        private readonly AimSpread _aimSpread;
        private readonly List<SpreadKicker> _spreadKickers = new List<SpreadKicker>();
        
        public float Spread { get; private set; }
        
        public SpreadController(ITicker ticker, AnimationCurve kickCurve)
        {
            _ticker = ticker;
            _ticker.AddTickable(this);
            _kickCurve = kickCurve;
            _gunSpread = new StaticSpread(10);
            _aimSpread = new AimSpread(_gunSpread, 0.75f, 1, 1, _ticker);
        }

        public void Tick(float deltaTime) => 
            Spread = _aimSpread.Value + _spreadKickers.Sum(n => n.Value);

        public void StartAiming() => 
            _aimSpread.Aiming = true;

        public void StopAiming() => 
            _aimSpread.Aiming = false;

        public void Kick(float value)
        {
            var spreadKicker = GetKicker();
            spreadKicker.Start();
        }

        private SpreadKicker GetKicker()
        {
            SpreadKicker spreadKicker = null;
            for (var i = 0; i < _spreadKickers.Count; i++)
                if (_spreadKickers[i].Finished)
                    spreadKicker = _spreadKickers[i];
            if (spreadKicker == null)
            {
                spreadKicker = new SpreadKicker(1, 100, _kickCurve, _ticker);
                _spreadKickers.Add(spreadKicker);
            }
            return spreadKicker;
        }
    }
}