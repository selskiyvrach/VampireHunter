using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings
{
    public abstract class RecoilProcessingSettings : ScriptableObject, IRecoilProcessingSettings
    {
        [SerializeField] private AnimationCurve _animationCurve;
        [SerializeField] private float _recoilUnitsProcessedPerSecond;

        public AnimationCurve AnimationCurve => _animationCurve;
        public float RecoilUnitsProcessedPerSecond => _recoilUnitsProcessedPerSecond;
    }
}