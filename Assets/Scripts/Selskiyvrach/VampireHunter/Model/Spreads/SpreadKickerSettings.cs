using UnityEngine;

namespace Selskiyvrach.VampireHunter.Model.Spreads
{
    [CreateAssetMenu(menuName = "Configs/Recoil/SpreadKickerSettings", fileName = "SpreadKickerSettings", order = 0)]
    public class SpreadKickerSettings : ScriptableObject
    {
        [SerializeField] private AnimationCurve _animationCurve;
        [SerializeField] private float _recoilUnitsProcessedPerSecond;

        public AnimationCurve AnimationCurve => _animationCurve;
        public float RecoilUnitsProcessedPerSecond => _recoilUnitsProcessedPerSecond;
    }
}