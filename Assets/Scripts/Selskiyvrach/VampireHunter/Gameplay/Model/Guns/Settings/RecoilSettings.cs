using UnityEngine;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Guns.Settings
{
    [CreateAssetMenu(menuName = "Configs/Guns/Settings/RecoilSettings", fileName = "recoil_settings", order = 0)]
    public class RecoilSettings : ScriptableObject, IRecoilSettings
    {
        [SerializeField] private AnimationCurve _animationCurve;
        [SerializeField] private float _recoilUnitsProcessedPerSecond;
        [SerializeField] private int _recoil;

        public AnimationCurve AnimationCurve => _animationCurve;
        public float RecoilUnitsProcessedPerSecond => _recoilUnitsProcessedPerSecond;
        public int Recoil => _recoil;
    }
}