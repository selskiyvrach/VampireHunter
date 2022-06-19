using Selskiyvrach.Core.Tickers;
using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.UI.Gameplay.GunSpreadIndicator
{
    public class GunSpreadIndicator : IGunSpreadIndicatorValueGetter, IGunSpreadIndicatorValueSetter, IChangeable
    {
        private float _angleDegrees;
        private bool _changedThisTick;

        public float AngleDegrees => _angleDegrees;
        public bool ChangedLastTick => _changedThisTick;

        public void OnAfterTick() => 
            _changedThisTick = false;

        public void SetSpread(float angleDegrees)
        {
            if (Mathf.Approximately(_angleDegrees, angleDegrees))
                return;
            
            _angleDegrees = angleDegrees;
            _changedThisTick = true;
        }
    }
}